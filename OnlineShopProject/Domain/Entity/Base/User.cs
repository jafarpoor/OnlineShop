namespace Domain.Entity.Base
{
    public class User : BaseEntity
    {
        public string FristName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
