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


namespace BlazorAptit.Pages.AptitManage
{
   public partial class GroupList
    {
        [Inject]
        public IRepository RepositoryAsync { get; set; }

        [Inject]
        public IAptitRepository AptitRepository { get; set; }


        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected List<AptitGroup> aptitGroups;

        public ObservableCollection<AptitGroup> ObservableData { get; set; }
        

        protected  override  async Task OnInitializedAsync()
        {
            aptitGroups = await AptitRepository.GetAllGroupList();
            ObservableData = new ObservableCollection<AptitGroup>(aptitGroups);

        }

        public void AddRecord()
        {
        }
        public void UpdateRecord()
        {
            if (ObservableData.Count() != 0)
            {
                var name = ObservableData.First();
                //name.User_Name = "Record Updated";
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
