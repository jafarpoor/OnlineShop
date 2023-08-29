using DTO;
using DTOs;

namespace Authorize.Services;

public interface IAuthenticationService
{
    Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
    Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);
    Task Logout();
}
