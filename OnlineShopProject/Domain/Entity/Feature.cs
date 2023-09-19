using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Feature : BaseEntity
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public ProductItem ProductItemObject { get; set; } = new();
        public long ProductId { get; set; }
    }
}
