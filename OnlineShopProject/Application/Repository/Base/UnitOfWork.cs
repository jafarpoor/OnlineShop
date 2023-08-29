using Application.Interface.Base;
using Application.Interface.User;
using Application.Repository.User;
using Persistence.Context;

namespace Application.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataBaseContext _ctx;
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

        public IRegisterUserRepository RegisterUserRepository
        {
            get
            {
                _registerUserRepository ??= new RegisterUserRepository(_ctx);
                return _registerUserRepository;
            }
        }
        #endregion
    }
}
