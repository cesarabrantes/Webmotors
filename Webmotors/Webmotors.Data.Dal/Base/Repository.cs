using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webmotors.Data.Dal.Contracts;

namespace Webmotors.Data.Dal
{
    public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected ISession vSession;

        #region Get

        public virtual IQueryable<T> GetAll()
        {
            return vSession.Query<T>();
        }

        public virtual async Task<IList<TType>> GetByConditionanonymousAsync<TType>(Expression<Func<T, bool>> pPredicate, Expression<Func<T, TType>> pSelect) where TType : class
        {
            return await vSession.Query<T>().Where(pPredicate).Select(pSelect).ToListAsync();
        }

        public virtual async Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> pPredicate)
        {
            return await vSession.Query<T>().Where(pPredicate).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(TKey pId)
        {
            return await vSession.GetAsync<T>(pId);
        }

        #endregion

        #region Alter
        public virtual async Task<T> DeleteAsync(TKey pId)
        {
            try
            {
                using (var vTransaction = vSession.BeginTransaction())
                {
                    var vObjeto = await vSession.GetAsync<T>(pId);
                    await vSession.DeleteAsync(vObjeto);
                    await vTransaction.CommitAsync();
                    return vObjeto;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public virtual async Task<T> SaveAsync(T pObject)
        {
            try
            {
                using (var vTransaction = vSession.BeginTransaction())
                {
                    //this.AdicionaData(pObjeto);
                    await vSession.SaveAsync(pObject);
                    await vTransaction.CommitAsync();
                    return pObject;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<T>> SaveAsync(IList<T> pObjectList)
        {
            try
            {
                using (var vTransaction = vSession.BeginTransaction())
                {

                    foreach (var pObjeto in pObjectList)
                    {
                        await vSession.SaveAsync(pObjeto);
                    }

                    await vTransaction.CommitAsync();
                    return pObjectList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task UpdateAsync(T pObject)
        {
            try
            {
                using (var vTransaction = vSession.BeginTransaction())
                {
                    await vSession.SaveOrUpdateAsync(pObject);
                    await vTransaction.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }        

        #endregion
    }
}
