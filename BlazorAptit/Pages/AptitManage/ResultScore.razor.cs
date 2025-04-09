using BlazorAptit.Models.Dapper;
using BlazorAptit.Models.EfCore;
using BlazorAptit.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Syncfusion.Blazor.Grids;

namespace BlazorAptit.Pages.AptitManage
{
    public partial class ResultScore
    {
        [Inject]
        public IRepository RepositoryAsync { get; set; }

        [Inject]
        public IAptitRepository AptitRepository { get; set; }


        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected List<AptitUserQue> aptitUserQue;

        public ObservableCollection<AptitUserQue> ObservableData { get; set; }

        SfGrid<AptitUserQue> GridInstance { get; set; }

        protected override async Task OnInitializedAsync()
        {
            aptitUserQue = await AptitRepository.GetResultScore(AptitUserID);
            ObservableData = new ObservableCollection<AptitUserQue>(aptitUserQue);

        }
        public async Task ActionBeginHandler(ActionEventArgs<AptitUserQue> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Add)
            {
                //args.Cancel = true;
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit)
            {
                //args.Cancel = true;
                
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                await AptitRepository.UpdateResultScoreAsync(args.Data);
            }


        }

        public async Task OnActionComplete(ActionEventArgs<AptitUserQue>
       args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Add)
            {
                //args.Cancel = true;
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit)
            {
                //args.Cancel = true;
                //await GridInstance.EndEdit();
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                await OnInitializedAsync();
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.BatchSave)
            {
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Refresh)
            {
               
                await GridInstance.EndEdit();
            }


           
        }
        public void BatchSaveHandler(BeforeBatchSaveArgs<AptitUserQue>   args)
        {
            // Here you can customize your code
        }
        public async Task CellSaveHandler(CellSaveArgs<AptitUserQue> args)
        {
            // Here you can customize your code
            
            
        }


        public async Task CellSavedHandler(CellSaveArgs<AptitUserQue> args)
        {
            // Here you can customize your code
           

        }

        public async Task LoadHandler(object args)
        {
            // Here you can customize your code
        }

    }
}
