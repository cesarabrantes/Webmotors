using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Webmotors.Data.Dal.Contracts
{
    public interface IRepository<T, in TKey> where T : class
    {
        Task<T> SaveAsync(T pObject);
        Task<IList<T>> SaveAsync(IList<T> pObjectList);
        Task<T> DeleteAsync(TKey pId);        
        Task UpdateAsync(T pObject);
        Task<T> GetByIdAsync(TKey pId);
        IQueryable<T> GetAll();
        Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> pPredicate);
        Task<IList<TType>> GetByConditionanonymousAsync<TType>(Expression<Func<T, bool>> pPredicate, Expression<Func<T, TType>> pSelect) where TType : class;        
    }
}
