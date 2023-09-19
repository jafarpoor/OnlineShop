using Domain.Entity.Base;

namespace Domain.Entity
{
    public class ProductItem : BaseEntity
    {
        public string ProductItemName { get; set; } = string.Empty;
        public long ProductCode { get; set; }
        public ProductType ProductTypeObject { get; set; } = new();
        public long ProductTypeCode { get; set; }
        public long Price { get; set; }
        public long Qty { get; set; }
        public long DiscountPercent {get;set;}
        public string Note { get; set; } =string.Empty;
        public List<Color> Colors { get; set; }=new();
        public List<Feature> Features { get; set; }= new();
        public List<Image> Images { get; set; } = new();
        public long? Total
        {
            get
            {
                long? Result = null;
                if(DiscountPercent != 0)
                {
                    Result = (Price * DiscountPercent) / 100;
                    Result = Price - Result;
                }

                return Result;
            }
        }
    }
}
