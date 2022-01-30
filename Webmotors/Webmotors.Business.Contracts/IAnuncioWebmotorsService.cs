using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Domain.Models;

namespace Webmotors.Business.Contracts
{
    public interface IAnuncioWebmotorsService : IService<AnuncioWebmotors, int>
    {
        /// <summary>
        /// Verifica se existe registros na tabela, na negativa busca da API e persiste no banco, se existir apenas retorna a coleção
        /// </summary>
        /// <returns>Retorna uma coleção de objetos do tipo AnuncioWebmotors</returns>
        Task<List<AnuncioWebmotors>> LoadDataApi();
    }
}
