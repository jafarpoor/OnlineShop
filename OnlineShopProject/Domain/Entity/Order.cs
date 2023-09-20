using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Order : BaseEntity
    {
        public User UserObject { get; set; } = new();
        public long UserId { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public PaymentStatus PaymentStatus { get; set; } = new();
        public OrderStatus OrderStatus { get; set; } = new();

        public List<OrderItem> OrderItems = new();
        public bool AppliedDiscount { get; set; } = false;
    }
}
