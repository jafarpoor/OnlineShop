using Application.Interface.Products;
using Application.Interface.Users;

namespace Application.Interface.Base
{
    public interface IUnitOfWork
    {
        void Save();
        IRegisterUserRepository RegisterUserRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        IProductItemRepository ProductItemRepository { get; }
    }
}
