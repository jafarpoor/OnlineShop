using Application.Interface.Base;
using Application.Interface.Products;
using Application.Repository.Base;
using Domain.Entity;
using Persistence.Context;

namespace Application.Repository.Products
{
    public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
    {
        private readonly IDataBaseContext _ctx;
        public ProductTypeRepository(IDataBaseContext context) : base(context)
        {
            _ctx = context;
        }
    }
}
