using BlazorAptit.Areas.Identity;
using BlazorAptit.Data;
using BlazorAptit.Models.Dapper;
using BlazorAptit.Models.EfCore;
using BlazorAptit.Services;
using BlazorAptit.Settings;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Licensing;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MDAxQDMxMzkyZTMxMmUzMEVuTTlYSysrVnNYMWZrM3pkVVE3MHRQblJZR0hSSTJKbElFN3p4TjFkOTA9");
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt"))
            {
                string licenseKey = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt");
                SyncfusionLicenseProvider.RegisterLicense(licenseKey);
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));



            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddEntityFrameworkSqlServer().AddDbContext<SchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(p => p.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }));

            services.AddRazorPages();
            services.AddControllersWithViews();  //MVC
            services.AddServerSideBlazor();

            services
               .AddScoped<IAccountService, AccountService>()
              .AddScoped<IAlertService, AlertService>()
              .AddScoped<ILocalStorageService, LocalStorageService>();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<AptitService>();
            services.AddScoped<IRepository, Repository>();

            services.AddBlazoredSessionStorage();

            services.AddSingleton<IAptitRepository>(
               new AptitRepository(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddSingleton<IJobRepository>(
            //   new JobRepository(Configuration.GetConnectionString("MywayDBConnection")));

            services.AddSingleton<IOctRepository>(
             new OctRepository(Configuration.GetConnectionString("PostGreSqlConnection")));

            services.AddSyncfusionBlazor();
            services.AddSignalR(e => {
                e.MaximumReceiveMessageSize = 102400000; // 더 큰 값으로 늘림 (약 100MB)
                e.ClientTimeoutInterval = TimeSpan.FromSeconds(60); // 클라이언트 타임아웃 60초
                e.KeepAliveInterval = TimeSpan.FromSeconds(15); // 15초마다 연결 유지 신호 전송
                e.HandshakeTimeout = TimeSpan.FromSeconds(30); // 핸드셰이크 타임아웃 30초
            });


            services.AddSession(options => { // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(36000000);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, Services.MailService>();
            services.AddControllers();

            services.AddHttpClient();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    ServeUnknownFileTypes = true,
            //    DefaultContentType = "image/png"
            //});

            app.UseRouting();

            // Apache �Ǵ� IIS ������ ���Ͻ�
            // using Microsoft.AspNetCore.HttpOverrides;�� �ؾ���
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                //MVC
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host"); //Blazor ��Ʈ������

                //MVC �⺻ ��Ʈ������ �ε����ڸ��� Ư�� URL�� �̵��ϰ��� �� ��
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/Aptit/MainLogin");
                    return Task.CompletedTask;
                });


            });
        }
    }
}
