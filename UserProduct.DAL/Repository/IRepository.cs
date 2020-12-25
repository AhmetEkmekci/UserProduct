using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserProduct.DAL.Entity;

namespace UserProduct.DAL.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> Get();
        Task<List<T>> Get(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task DeleteRange(Expression<Func<T, bool>> predicate);
    }
}
