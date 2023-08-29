using Application.ViewModel;
using Domain.Entity.Base;
using System.Linq.Expressions;

namespace Application.Interface.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// افزودن موجودیت
        /// </summary>
        BaseDto<T> Insert(T entity);


        /// <summary>
        /// آپدیت موجودیت
        /// </summary>
        BaseDto Update(T entity);

        /// <summary>
        /// حذف موجودیت
        /// </summary>
        BaseDto Delete(T entity);

        /// <summary>
        ///   واکشی اطلاعات حذف نشده
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Get();

        /// <summary>
        /// واکشی اطلاعات با گزاره
        /// </summary>
        /// <param name="predicate">گزاره</param>
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// واکشی اطلاعات با دستورات اس کیو ال
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        List<T> Get(string query, params object[] parameters);
    }
}
