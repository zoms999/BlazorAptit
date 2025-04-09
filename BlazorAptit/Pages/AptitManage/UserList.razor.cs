using BlazorAptit.Models;
using BlazorAptit.Models.EfCore;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Blazor.Data;
using System.Collections.ObjectModel;
using BlazorAptit.Models.Dapper;
using Syncfusion.Blazor.Grids;

namespace BlazorAptit.Pages.AptitManage
{

    public partial class UserList
    {
        [Inject]
        public IRepository RepositoryAsync { get; set; }

        [Inject]
        public IAptitRepository AptitRepository { get; set; }


        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected List<AptitUser> aptitUsers;

        public ObservableCollection<AptitUser> ObservableData { get; set; }
        

        protected  override  async Task OnInitializedAsync()
        {
            aptitUsers = await AptitRepository.GetAllUserList();
            ObservableData = new ObservableCollection<AptitUser>(aptitUsers);

        }


        public void ActionBegin(ActionEventArgs<AptitUser> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit)
            {
                // Triggers before editing operation starts
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Add)
            {
                // Triggers before add operation starts
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Cancel)
            {
                // Triggers before cancel operation starts
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                // Triggers before save operation starts
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
            {
                // Triggers before delete operation starts
            }
        }

        public async Task ActionComplete(ActionEventArgs<AptitUser> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit)
            {
                // Triggers once editing operation completes
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Add)
            {
                // Triggers once add operation completes
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Cancel)
            {
                // Triggers once cancel operation completes
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                // Triggers once save operation completes
                await AptitRepository.UserEdit(args.RowData);
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
            {
                // Triggers once delete operation completes
            }
        }

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
   

      
       
     


    }
}
