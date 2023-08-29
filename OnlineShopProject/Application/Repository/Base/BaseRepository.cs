using Application.Interface.Base;
using Application.ViewModel;
using Domain.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Data;
using System.Linq.Expressions;
using  Resx = Resoures;
namespace Application.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// کانتکس پروژه تعریف شده در کلاس ریپازیتوری اصلی
        /// </summary>
        protected IDataBaseContext Context { get; set; }
        protected DbSet<T> Set { get; set; }

        public BaseRepository(IDataBaseContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Context = context;
            Set = Context.Set<T>();
        }

        public virtual IQueryable<T> Get()
        {
            return Set;
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return this.Get().Where(predicate);
        }
        public BaseDto<T> Insert(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Set.Add(entity);

            return new BaseDto<T>(true, "", entity);

        }

        public BaseDto Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Entry(entity).State = EntityState.Modified;

            return new BaseDto
            {
                IsSuccess = true,
                Message = Resx.Messages.SuccessUpdateMsg
            };
        }

        public BaseDto Delete(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return new BaseDto
            {
                IsSuccess = true,
                Message = Resx.Messages.SuccessDeleteMsg
            };
        }

        public List<T> Get(string query, params object[] parameters)
        {
            return this.Set.FromSqlRaw(query, parameters).ToList();
        }

    }
}
