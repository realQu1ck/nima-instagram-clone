namespace Nima.Instagram.Server.Middleware.IdentityServer.ViewModel.Account
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
