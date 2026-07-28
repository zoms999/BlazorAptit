namespace BlazorAptit.Services
{
    // Scoped to the Blazor Server circuit: a fresh browser tab/connection always starts
    // with IsManager == false, so navigating directly to an /AptitManage/* URL without
    // going through /account first is blocked before any data is loaded.
    public class AptitManageAuthState
    {
        public bool IsAuthenticated { get; set; }
        public bool IsManager { get; set; }
    }
}
