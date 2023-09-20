using Domain.Entity.Base;

namespace Domain.Entity
{
    public class OrderStatus : BaseEntity
    {
        public string OrderStatusName { get; set; } = string.Empty;
    }
}
