using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Webmotors.Data.Dal.Contracts
{
    public interface IRepository<T, in TKey> where T : class
    {
        /// <summary>
        /// Persiste o objeto no banco de dados
        /// </summary>
        /// <param name="pObject">Objeto do tipo T</param>               
        /// <returns>Retorna o objeto persistido</returns>
        Task<T> SaveAsync(T pObject);

        /// <summary>
        /// Persiste uma coleção de objetos no banco de dados
        /// </summary>
        /// <param name="pObjectList">Coleção des objetos do tipo T</param>
        /// <returns>Retorna a coleção de objetos persistidos</returns>
        Task<IList<T>> SaveAsync(IList<T> pObjectList);

        /// <summary>
        /// Apaga um objeto do banco buscando pelo Id
        /// </summary>
        /// <param name="pId">Id do registro a ser apagado</param>
        /// <returns>Retorna o objeto apagado</returns>
        Task<T> DeleteAsync(TKey pId);

        /// <summary>
        /// Atualiza o objeto alterado
        /// </summary>
        /// <param name="pObject">Objeto  do tipo T alterado</param>
        /// <returns>Retorna o objeto alterado</returns>
        Task UpdateAsync(T pObject);

        /// <summary>
        /// Busca o registro no banco pelo Id
        /// </summary>
        /// <param name="pId">Id do registro</param>
        /// <returns>Retorna o registro localizado</returns>
        Task<T> GetByIdAsync(TKey pId);

        /// <summary>
        /// Lista todos os registros da tabela
        /// </summary>
        /// <returns>Coleção de registros</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Retorna uma coleção de objetos do tipo T utilizando uma expressão como filtro
        /// </summary>
        /// <param name="pPredicate">Expressão dem linq para filtro</param>
        /// <returns>Coleção de objetos do tipo T</returns>
        Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> pPredicate);

        /// <summary>
        /// Realiza uma busca anânima no banco de dados
        /// </summary>
        /// <typeparam name="TType">Tipo de objeto que será retornado</typeparam>
        /// <param name="pPredicate">Expressão dem linq para filtro</param>
        /// <param name="pSelect">Propriedades do objeto que será preenchido</param>
        /// <returns>Retornará uma lista do tipo TType</returns>
        Task<IList<TType>> GetByConditionanonymousAsync<TType>(Expression<Func<T, bool>> pPredicate, Expression<Func<T, TType>> pSelect) where TType : class;        
    }
}
