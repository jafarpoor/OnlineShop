using Application.Interface.User;

namespace Application.Interface.Base
{
    public interface IUnitOfWork
    {
        IRegisterUserRepository RegisterUserRepository { get; }
    }
}
