namespace Application.ViewModel.Products
{
    public class ProductItemPDPViewModel
    {
        //detail
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProductTypeName { get; set; } = string.Empty; 
        public long Price { get; set; }
        public long Total { get; set; }   
        public List<string> Images { get; set; } = new List<string>();
        public string Note { get; set; } = string.Empty;
        public List<FeatureViewModel> Features { get; set; } = new();
    }
}
