using Application.Interface.Users;
using Application.Repository.Base;
using Domain.Entity.Base;
using Persistence.Context;

namespace Application.Repository.Users
{
    public class RegisterUserRepository : BaseRepository<User>, IRegisterUserRepository 
    {
        private readonly IDataBaseContext _ctx;

        public RegisterUserRepository(IDataBaseContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
