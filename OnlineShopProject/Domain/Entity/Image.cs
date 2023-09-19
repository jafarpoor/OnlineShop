using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Image : BaseEntity
    {
        public string Src { get; set; } = string.Empty;
        public ProductItem ProductItemObject { get; set; } = new();
        public long ProductItemId { get; set; }
    }
}
