using Application.Interface.User;
using Persistence.Context;

namespace Application.Repository.User
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly IDataBaseContext _ctx;

        public RegisterUserRepository(IDataBaseContext ctx) 
        {
            _ctx = ctx;
        }
    }
}
