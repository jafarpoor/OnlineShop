using Domain.Entity.Base;

namespace Domain.Entity
{
    public class PaymentStatus : BaseEntity
    {
        public string PaymentStatusName { get; set; } = string.Empty;
    }
}
