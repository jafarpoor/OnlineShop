using Application.Interface.Base;
using Application.ViewModel;
using Application.ViewModel.Products;
using Domain.Entity;

namespace Application.Interface.Products
{
    public interface IProductItemRepository : IBaseRepository<ProductItem>
    {
       BaseDto<List<ProductItemPLPViewModel>> GetProductItemPLPList();
       BaseDto<List<ProductItemPDPViewModel>> GetProductItemPDPList();
    }
}
