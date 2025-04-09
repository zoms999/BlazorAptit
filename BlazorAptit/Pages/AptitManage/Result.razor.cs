using BlazorAptit.Models;
using BlazorAptit.Models.Dapper;
using BlazorAptit.Models.EfCore;
using BlazorDemos.Data.FileFormats.PDF;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Pages.AptitManage
{
    public partial class Result
    {

        SfGrid<AptitResultUserView> SubGrid;

        [Inject]
        public IRepository RepositoryAsync { get; set; }

        [Inject]
        public IAptitRepository AptitRepository { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

         [Inject]
        Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment { get; set; }

         [Inject] public IJSRuntime JS { get; set; }

        protected List<AptitGroup> resutl;

        List<AptitResultUserView> Users = new List<AptitResultUserView>();

        List<AptitReply> AptitReplys = new List<AptitReply>();
        List<UserReplyView> userReplyViews = new List<UserReplyView>();


        
        public IEnumerable<AptitResultUserView> GridData { get; set; }



        public ObservableCollection<AptitResultUserView> ObservableData { get; set; }
        
        public string SelectedGroupID { get; set; }
        public int? RowIndex { get; set; } = 1;

        public int AptitAnswerID { get; set; }

        public int AptitUserID { get; set; }

        public void AddRecord()
        {
        }
        public void UpdateRecord()
        {
            if (ObservableData.Count() != 0)
            {
                var name = ObservableData.First();
                name.User_Name = "Record Updated";
            }
        }

        public void DeleteRecord()
        {
            if (ObservableData.Count() != 0)
            {
                ObservableData.Remove(ObservableData.First());
            }
        }

        protected override async Task OnInitializedAsync()
        {
            resutl = await AptitRepository.GetAllAptitUsers();
            //ObservableData = new ObservableCollection<AptitUser>(aptitUsers);

        }
        public async void RowSelecthandler(RowSelectEventArgs<AptitGroup> Args)
        {
            SelectedGroupID = Args.Data.Group_ID;
            
            Users = await AptitRepository.GetGroupByID(SelectedGroupID);
            GridData = this.Users;

            ObservableData = new ObservableCollection<AptitResultUserView>(Users);
            
            //
        }

        private string documentPath;
        private bool isShowPdfViewer;
        private string DocumentPath { get; set; }

        private async Task OnShowWorkOrder()
        {

               
        }


         public async Task CommandClickHandler(CommandClickEventArgs<AptitResultUserView> args)
        {
            //NavigationManager.NavigateTo($"/AptitManage/ResultDetail/{args.RowData.ID}/{args.RowData.AptitAnswerID}");
          
            if(args.CommandColumn.ButtonOption.Content.Equals("결과보기"))
                NavigationManager.NavigateTo($"/AptitManage/ResultScore/{args.RowData.ID}");
            //NavigationManager.NavigateTo($"/AptitManage/ResultDetail4/{args.RowData.ID}/{args.RowData.ID}");

            if (args.CommandColumn.ButtonOption.Content.Equals("PDF_성향결과"))
            {
                AptitUserID = args.RowData.ID;
               

                //isShowPdfViewer = true;
                userReplyViews = await AptitRepository.GetUsersReplyView(AptitUserID);
                 RearrangePagesService service = new RearrangePagesService(hostingEnvironment, userReplyViews);
                MemoryStream documentStream = service.CreatePdfDocument();
                string fileNm = $"(성향){args.RowData.Group_Name}_{args.RowData.User_Name}.pdf";
                await JS.SaveAs(fileNm, documentStream.ToArray());   

                // DocumentPath = $"wwwroot/data/지면검사결과분석지.pdf";
            }

            if (args.CommandColumn.ButtonOption.Content.Equals("PDF_교과목결과"))
            {
                AptitUserID = args.RowData.ID;

                //isShowPdfViewer = true;
                userReplyViews = await AptitRepository.GetUsersReplyView(AptitUserID);
                RearrangePagesService service = new RearrangePagesService(hostingEnvironment, userReplyViews);
                MemoryStream documentStream = service.CreatePdfDocument_Subject();
                string fileNm = $"(교과목){args.RowData.Group_Name}_{args.RowData.User_Name}.pdf";
                await JS.SaveAs(fileNm, documentStream.ToArray());

                // DocumentPath = $"wwwroot/data/지면검사결과분석지.pdf";
            }


        }

        public void SubRowSelecthandler(RowSelectEventArgs<AptitResultUserView> Args)
        {
           //int  SelValue = Args.Data.AptitAnswerID;
        }

       

        public async void GeneratePDF(MouseEventArgs args)
        {	   
            //RearrangePagesService service = new RearrangePagesService(hostingEnvironment, );
            //MemoryStream documentStream = service.CreatePdfDocument();
            //await JS.SaveAs("Helloworld.pdf", documentStream.ToArray());        
        }
            
       
       
    }
         
}
