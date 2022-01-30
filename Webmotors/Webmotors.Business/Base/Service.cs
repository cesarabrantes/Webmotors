using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webmotors.Business.Contracts;
using Webmotors.Data.Dal.Contracts;

namespace Webmotors.Business
{
    public abstract class Service<T, TKey> : IService<T, TKey> where T : class
    {
        protected IRepository<T, TKey> vRepository;
        protected ILogger<Service<T, TKey>> vLogger;

        #region Get        
        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return vRepository.GetAll();
            }
            catch (Exception ex)
            {
                vLogger.LogError(ex, "Ocorreu um erro ao buscar todos os registros {@" + typeof(T).Name + "}");
                throw new Exception(typeof(T).Name, new Exception("Ocorreu um erro no processo de busca"));

            }
        }

        public virtual async Task<IList<TType>> GetByConditionanonymousAsync<TType>(Expression<Func<T, bool>> pPredicate, Expression<Func<T, TType>> pSelect) where TType : class
        {
            try
            {
                return await vRepository.GetByConditionanonymousAsync(pPredicate, pSelect);
            }
            catch (Exception ex)
            {
                vLogger.LogError(ex, "Ocorreu um erro ao buscar registro {@" + typeof(T).Name + "}");
                throw new Exception(typeof(T).Name, new Exception("Ocorreu um erro no processo de busca"));

            }
        }

        public virtual async Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> pPredicate)
        {
            try
            {
                return await vRepository.GetByConditionAsync(pPredicate);
            }
            catch (Exception ex)
            {
                vLogger.LogError(ex, "Ocorreu um erro ao buscar registro {@" + typeof(T).Name + "}");
                throw new Exception(typeof(T).Name, new Exception("Ocorreu um erro no processo de busca"));

            }
        }

        public virtual async Task<T> GetByIdAsync(TKey pId)
        {
            try
            {
                return await vRepository.GetByIdAsync(pId);
            }
            catch (Exception ex)
            {
                vLogger.LogError(ex, "Ocorreu um erro ao buscar registro {@" + typeof(T).Name + "}", pId);
                throw new Exception(typeof(T).Name, new Exception("Ocorreu um erro no processo de busca"));

            }
        }

        #endregion

        #region Alter

        public virtual async Task<T> DeleteAsync(TKey pId)
        {
            try
            {
                return await vRepository.DeleteAsync(pId);

            }
            catch (Exception ex)
            {
                vLogger.LogError(ex, "Ocorreu um erro no processo de exclusão {@" + typeof(T).Name + "}", pId);
                throw new Exception(typeof(T).Name, new Exception("Ocorreu um erro no processo de exclusão"));

            }
        }

        public virtual async Task<T> SaveAsync(T pObject)
        {
            try
            {
                return await vRepository.SaveAsync(pObject);

            }
            catch (Exception ex)
            {
                vLogger.LogError(ex, "Ocorreu um erro no processo de inclusão {@" + typeof(T).Name + "}", pObject);
                throw new Exception(typeof(T).Name, new Exception("Ocorreu um erro no processo de inclusão"));

            }
        }

        public virtual async Task<IList<T>> SaveAsync(IList<T> pObjectList)
        {
            try
            {
                return await vRepository.SaveAsync(pObjectList);

            }
            catch (Exception ex)
            {
                vLogger.LogError(ex, "Ocorreu um erro no processo de inclusão {@" + typeof(T).Name + "}", pObjectList);
                throw new Exception(typeof(T).Name, new Exception("Ocorreu um erro no processo de inclusão"));

            }
        }

        public virtual async Task UpdateAsync(T pObject)
        {
            try
            {
                await vRepository.UpdateAsync(pObject);

            }
            catch (Exception ex)
            {
                vLogger.LogError(ex, "Ocorreu um erro no processo de alteração {@" + typeof(T).Name + "}", pObject);
                throw new Exception(typeof(T).Name, new Exception("Ocorreu um erro no processo de alteração"));

            }
        }

        #endregion
    }
}
