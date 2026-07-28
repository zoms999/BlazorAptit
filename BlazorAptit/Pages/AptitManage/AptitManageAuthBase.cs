using BlazorAptit.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorAptit.Pages.AptitManage
{
    // Every /AptitManage/* page must inherit this and, as the first line of its own
    // OnInitializedAsync override, call `await base.OnInitializedAsync()` then
    // `if (!IsAuthorized) return;` before loading any data. This closes the gap where
    // pages previously loaded and rendered admin data before an OnAfterRenderAsync
    // check (which never fired for a session with no role at all) had a chance to redirect.
    public class AptitManageAuthBase : ComponentBase
    {
        // Override to true in pages restricted to the manager ("admin") login only,
        // e.g. GroupList, UserList, Home, Index, ReplyManage, EditTest, Chart(2), TendencyChart, ChartStats/*.
        protected virtual bool RequireManager => false;

        [Inject] protected AptitManageAuthState AuthState { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }

        protected bool IsAuthorized { get; private set; }

        protected override Task OnInitializedAsync()
        {
            IsAuthorized = AuthState.IsAuthenticated && (!RequireManager || AuthState.IsManager);
            if (!IsAuthorized)
            {
                NavigationManager.NavigateTo("/account");
            }
            return Task.CompletedTask;
        }
    }
}
