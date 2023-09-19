using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Payment : BaseEntity
    {
        public Guid Id { get; set; }
        public long Amount { get; set; }
        public bool IsPay { get; set; } = false;
        public DateTime? DatePay { get; set; } = null;
        public string Authority { get; set; } = string.Empty;
        public long RefId { get; set; } = 0;
        public Order Order { get; set; } = new();
        public long OrderId { get; set; }
    }
}
