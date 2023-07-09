using Application.Interface;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class DataBaseContext : DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

    }
}
