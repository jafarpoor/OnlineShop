using System.ComponentModel.DataAnnotations;
using DD = Resoures.DataDictionary;
using Resx = Resoures;

namespace DTOs
{
    public class RegisterUserDto
    {

        [Display(ResourceType = typeof(DD), Name = nameof(DD.UserName))]
        [Required(ErrorMessageResourceType = typeof(Resx.General), ErrorMessageResourceName = nameof(Resx.General.Required))]
        public string UserName { get; set; }
       
        [Display(ResourceType = typeof(DD), Name = nameof(DD.FristName))]
        [Required(ErrorMessageResourceType = typeof(Resx.General), ErrorMessageResourceName = nameof(Resx.General.Required))]
        public string FristName { get; set; } = string.Empty;

        [Display(ResourceType = typeof(DD), Name = nameof(DD.LastName))]
        [Required(ErrorMessageResourceType = typeof(Resx.General), ErrorMessageResourceName = nameof(Resx.General.Required))]
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }

        [Display(ResourceType = typeof(DD), Name = nameof(DD.PhoneNumber))]
        [Required(ErrorMessageResourceType = typeof(Resx.General), ErrorMessageResourceName = nameof(Resx.General.Required))]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(ResourceType = typeof(DD), Name = nameof(DD.Password))]
        [Required(ErrorMessageResourceType = typeof(Resx.General), ErrorMessageResourceName = nameof(Resx.General.Required))]
        public string Password { get; set; } = string.Empty;

    }
}
