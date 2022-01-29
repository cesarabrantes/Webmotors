using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Domain.Models;

namespace Webmotors.Business.Contracts
{
    public interface IAnuncioWebmotorsService : IService<AnuncioWebmotors, int>
    {
        Task<List<AnuncioWebmotors>> LoadDataApi();
    }
}
