using Authorize.Services;
using DTOs;
using Microsoft.AspNetCore.Components;

namespace Authorize.Pages
{
    public partial class Register
    {
        private RegisterUserDto _registerUserDto { get; set; } = new();
        public bool ShowAuthError { get; set; }

        public string? Error { get; set; }

        public async Task RegisterUser()
        {
            //ShowAuthError = false;
            //var result = await AuthenticationService.Login(_registerUserDto);
            //if (!result.IsAuthSuccessful)
            //{
            //    Error = result.ErrorMessage;
            //    ShowAuthError = true;
            //}
            //else
            //{
            //    NavigationManager.NavigateTo("/");
            //}
            ///////////////////////
            ///
            //var result = await payTypeService.Add("PayType/Add", PayTypeAddObject);
            //_modalMessage = result.Message;
            //if (result.IsSuccess)
            //{
            //    _mainModal.Close();
            //    await _success.Open();
            //}
            //else
            //{
            //    _alert.Open();
            //}

            //await LoadGrid();
        }
    }
}