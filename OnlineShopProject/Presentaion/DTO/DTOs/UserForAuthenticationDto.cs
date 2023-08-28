using System.ComponentModel.DataAnnotations;
using DD = Resoures.DataDictionary;
using Resx = Resoures;
namespace DTOs
{
    public class UserForAuthenticationDto
    {
        [Display(ResourceType = typeof(DD), Name = nameof(DD.Email))]
        [Required(ErrorMessageResourceType = typeof(Resx.General), ErrorMessageResourceName = nameof(Resx.General.Required))]
        public string Email { get; set; } =string.Empty;
        [Display(ResourceType = typeof(DD), Name = nameof(DD.Password))]
        [Required(ErrorMessageResourceType = typeof(Resx.General), ErrorMessageResourceName = nameof(Resx.General.Required))]
        public string Password { get; set; } = string.Empty;
    }
}
