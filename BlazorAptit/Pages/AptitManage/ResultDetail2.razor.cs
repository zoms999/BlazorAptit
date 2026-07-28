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
    public partial class ResultDetail2 : AptitManageAuthBase
    {
         [Inject]
        public IRepository RepositoryAsync { get; set; }

        [Inject]
        public IAptitRepository AptitRepository { get; set; }

        List<AptitResult> AptitResults = new List<AptitResult>();

        protected  override  async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (!IsAuthorized) return;

            AptitResults = await AptitRepository.GetUsersResult(AptitAnswerID);

        }
    }
}
