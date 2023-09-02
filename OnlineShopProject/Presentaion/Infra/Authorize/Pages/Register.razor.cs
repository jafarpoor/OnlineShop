using Application.ViewModel.Users;
using Authorize.Services;
using Components.Modal;
using DTOs;
using Microsoft.AspNetCore.Components;

namespace Authorize.Pages;

    public partial class Register
    {
        private TMModalBox _mainModal = null!;
        private TMModalBoxSuccess _success = null!;
        private string _modalMessage = "";
        private TMModalBoxAlert _alert = null!;
       private  RegisterUserViewModel _registerUserViewModel { get; set; } = new();
        public bool ShowAuthError { get; set; }

        public string? Error { get; set; }

        public async Task RegisterUser()
        {
            var result = await UserServices.Add("Account/Register", _registerUserViewModel);
            _modalMessage = result.Message;
            if (result.IsSuccess)
            {
                _mainModal.Close();
                await _success.Open();
            }
            else
            {
                _alert.Open();
            }
        }
    }
