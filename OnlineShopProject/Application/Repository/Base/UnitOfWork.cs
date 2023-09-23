using Application.Interface.Base;
using Application.Interface.Products;
using Application.Interface.Users;
using Application.Repository.Products;
using Application.Repository.Users;
using Persistence.Context;

namespace Application.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataBaseContext _ctx;
        public void Save()
        {
            try
            {
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                var str = "خطا در ذخیره اطلاعات : " + "<br />" + ex.Message + "<br />" + ex.InnerException?.Message;
                throw new Exception(str);
            }
        }
        public void Dispose()
        {
            _ctx.Dispose();
        }

        public UnitOfWork(IDataBaseContext Context)
        {
            _ctx = Context;
        }

        #region Interface
        private IRegisterUserRepository _registerUserRepository = null!;
        private IProductTypeRepository _productTypeRepository = null!;
        private IProductItemRepository _productItemRepository =null!;
        public IRegisterUserRepository RegisterUserRepository
        {
            get
            {
                _registerUserRepository ??= new RegisterUserRepository(_ctx);
                return _registerUserRepository;
            }
        }

        public IProductTypeRepository ProductTypeRepository
        {
            get
            {
                _productTypeRepository ??= new ProductTypeRepository(_ctx);
                return _productTypeRepository;
            }
        }

        public IProductItemRepository ProductItemRepository
        {
            get
            {
                _productItemRepository ??=new ProductItemRepository(_ctx);
                return _productItemRepository;
            }
        }
        #endregion
    }
}
