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
using Syncfusion.Blazor.Lists;

namespace BlazorAptit.Pages.AptitManage
{
    public partial class Home
    {
        
        [Inject]
        public IRepository RepositoryAsync { get; set; }

        [Inject]
        public IAptitRepository AptitRepository { get; set; }


        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        private SfListView<AptitGroup> ListViewObj;

        private SfListView<AptitUser> ListViewObj2;

        
        protected List<AptitGroup> aptitGroups;

        protected List<AptitUser> 오늘검사단체;

        protected AptitGroup aptitGroupsSub = new AptitGroup();

        protected AptitUser aptitUserSub = new AptitUser();

        public DateTime dt = DateTime.Now;

        public ObservableCollection<AptitGroup> ObservableData { get; set; }
        public string groupid = "";
        public string groupname = "";
         protected  override  async Task OnInitializedAsync()
        {
            DateTime now =  DateTime.Now;
            aptitGroups = await AptitRepository.GetAllTodayGroupList(now);

             //if(aptitGroups != null)
             //{
             //     groupid = aptitGroups[aptitGroups.Count - 1 ].Group_ID;
             //    groupname = aptitGroups[aptitGroups.Count - 1 ].Group_Name;

            //}

             오늘검사단체 = await AptitRepository.오늘검사단체(now);
        }

        
    public async Task Complete(Object args)
    {
        // Select the listview items using selectItem method.
         // ListViewObj.SelectItem(new AptitGroup { Group_ID = groupid  });

    }

    private void select(ClickEventArgs<AptitGroup> e)
    {
        var list = e.Index.ToString();
       
        aptitGroupsSub = e.ItemData;
        
    }
         private void select(ClickEventArgs<AptitUser> e)
    {
        var list = e.Index.ToString();

            aptitUserSub = e.ItemData;
        
    }
    }
}
