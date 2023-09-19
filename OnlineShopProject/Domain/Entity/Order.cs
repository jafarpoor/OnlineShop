using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Order : BaseEntity
    {
        public long UserId { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        //public Address Address { get; private set; }
        //public PaymentMethod PaymentMethod { get; private set; }
        //public PaymentStatus PaymentStatus { get; private set; }
        //public OrderStatus OrderStatus { get; private set; }
        public List<OrderItem> OrderItems = new();
        public bool AppliedDiscount { get; set; } = false;
    }
}
