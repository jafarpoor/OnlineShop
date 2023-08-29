namespace Application.ViewModel.User
{
    public class RegisterUserViewModel
    {
        public string FristName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
