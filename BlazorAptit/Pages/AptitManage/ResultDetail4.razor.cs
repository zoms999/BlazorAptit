using BlazorAptit.Models;
using BlazorAptit.Models.Dapper;
using BlazorAptit.Models.EfCore;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Pages.AptitManage
{
    public partial class ResultDetail4
    {
        [Inject]
        public IRepository RepositoryAsync { get; set; }

        [Inject]
        public IAptitRepository AptitRepository { get; set; }

        List<AptitReply> AptitReplys = new List<AptitReply>();


        protected override async Task OnInitializedAsync()
        {
            AptitReplys = await AptitRepository.GetUsersReply(AptitUserID);
            
         
        }




    }
}
