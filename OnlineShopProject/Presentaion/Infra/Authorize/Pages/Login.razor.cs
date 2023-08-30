using Authorize.Services;
using DTOs;
using Microsoft.AspNetCore.Components;

namespace Authorize.Pages
{
    public partial class Login
    {
        private UserForAuthenticationDto _userForAuthentication { get; set; } = new();
        public bool ShowAuthError { get; set; }

        public string? Error { get; set; }

        public async Task ExecuteLogin()
        {
            ShowAuthError = false;
            var result = await AuthenticationService.Login(_userForAuthentication);
            if (!result.IsAuthSuccessful)
            {
                Error = result.ErrorMessage;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
