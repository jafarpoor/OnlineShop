using Domain.Entity.Base;

namespace Domain.Entity
{
    public class OrderItem :BaseEntity
    {
        public ProductItem ProductItemObject { get; set; } = new();
        public long ProductItemId { get; set; }
        public string PictureUri { get; set; } = string.Empty;
        public long UnitPrice { get; set; }
        public int Qty { get; set; }
    }
}
