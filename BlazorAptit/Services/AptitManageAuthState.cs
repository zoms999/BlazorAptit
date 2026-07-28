namespace BlazorAptit.Services
{
    // Scoped to the Blazor Server circuit: a fresh browser tab/connection always starts
    // with IsManager == false, so navigating directly to an /AptitManage/* URL without
    // going through /account first is blocked before any data is loaded.
    public class AptitManageAuthState
    {
        public bool IsAuthenticated { get; set; }
        public bool IsManager { get; set; }

        // The Group_ID the user actually authenticated with. Group-scoped pages must
        // filter using this (server-held, per-circuit) value instead of the client-side
        // sessionStorage "USERID", which a user can freely rewrite via devtools to view
        // another organization's results.
        public string GroupId { get; set; }
    }
}
