using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorAptit.Models;

namespace BlazorAptit.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<AptitUser> AptitUsers { get; set; }

        public DbSet<AptitAnswer> AptitAnswers { get; set; }

        public DbSet<AptitQuestion> AptitQuestions { get; set; }

         public DbSet<AptitResult> AptitResults { get; set; }

        public DbSet<AptitGroup> AptitGroups { get; set; }

        public DbSet<AptitReply> AptitReplys { get; set; }

        public DbSet<AptitUserQue> AptitUserQue { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<AptitGroup>().ToTable("AptitGroup");
            modelBuilder.Entity<AptitUser>().ToTable("AptitUser");
            modelBuilder.Entity<AptitAnswer>().ToTable("AptitAnswer");
            modelBuilder.Entity<AptitQuestion>().ToTable("AptitQuestion");
            modelBuilder.Entity<AptitResult>().ToTable("AptitResult");
            modelBuilder.Entity<AptitReply>().ToTable("AptitReply");
            modelBuilder.Entity<AptitUserQue>().ToTable("AptitUserQue");

            //modelBuilder.Ignore<AptitAnswer>();

            modelBuilder.Entity<AptitUser>().HasMany(city => city.AptitAnswers)
                            .WithOne(d => d.AptitUsers)
                          .HasForeignKey(con => con.AptitUserID);

            modelBuilder.Entity<AptitGroup>()
              .HasKey(x => new {  x.Group_ID });

            modelBuilder.Entity<AptitAnswer>()
             .Property(x => x.Created ).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AptitAnswer>()
            .Property(x => x.Updated).HasDefaultValueSql("getdate()");


            modelBuilder.Entity<AptitUser>()
            .HasIndex(u => u.User_Email)
            .IsUnique();

             modelBuilder.Entity<AptitReply>()
              .HasNoKey();


            modelBuilder.Entity<AptitUserQue>()
             .HasKey(x => new { x.AptitUserID, x.AptitQuestionID });


            //            modelBuilder.Entity<AptitGroup>()
            //.HasIndex(e => e.Group_Name)
            //.IsUnique()
            //.IsClustered();

            //modelBuilder.Entity<City>().HasMany(city => city.Connections)
            //               .WithRequired().HasForeignKey(con => con.StartCityId);

        }
    }
}
