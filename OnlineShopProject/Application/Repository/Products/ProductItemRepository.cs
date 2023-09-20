using Application.Interface.Products;
using Application.Repository.Base;
using Application.ViewModel;
using Application.ViewModel.Products;
using Domain.Entity;
using Persistence.Context;
using Resx = Resoures;
namespace Application.Repository.Products
{
    public class ProductItemRepository : BaseRepository<ProductItem>, IProductItemRepository
    {
        private readonly IDataBaseContext _ctx;
        public ProductItemRepository(IDataBaseContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public BaseDto<List<ProductItemPDPViewModel>> GetProductItemPDPList()
        {
            try
            {
                var Result = _ctx.ProductItems.Select(p => new ProductItemPDPViewModel
                {
                    Id = p.ID,
                    Name = p.ProductItemName,
                    Note = p.Note,
                    Price = p.Price,
                    ProductTypeName = p.ProductTypeObject.ProductTypeName,
                    Images = p.Images.Select(p => p.Src).ToList(),
                    Features = p.Features.Select(p => new FeatureViewModel
                    {
                        Key = p.Key,
                        Value = p.Value
                    }).ToList()
                }).ToList();

                if (Result is null)
                    return new BaseDto<List<ProductItemPDPViewModel>>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = Resx.Messages.NoRecords
                    };
                else return new BaseDto<List<ProductItemPDPViewModel>>
                {
                    Data = Result,
                    IsSuccess = true,
                    Message = ""
                };
            }
            catch (Exception)
            {
                return new BaseDto<List<ProductItemPDPViewModel>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Resx.Messages.Error
                };
            }

        }

        public BaseDto<List<ProductItemPLPViewModel>> GetProductItemPLPList()
        {
            try
            {
                var Result = _ctx.ProductItems.Select(p => new ProductItemPLPViewModel
                {
                    Id = p.ID,
                    Name = p.ProductItemName,
                    Price = p.Price,
                    Image = p.Images.Select(p=>p.Src).First() ,
                    TotalPrice = p.Total
                }).ToList();

                if (Result is null)
                    return new BaseDto<List<ProductItemPLPViewModel>>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = Resx.Messages.NoRecords
                    };
                else return new BaseDto<List<ProductItemPLPViewModel>>
                {
                    Data = Result,
                    IsSuccess = true,
                    Message = ""
                };
            }
            catch (Exception)
            {
                return new BaseDto<List<ProductItemPLPViewModel>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Resx.Messages.Error
                };
            }
        }
    }
}

