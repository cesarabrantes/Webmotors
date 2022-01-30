using System.Collections.Generic;
using Webmotors.Mediator.Api.Models;

namespace Webmotors.Mediator.Service.Contracts
{
    public interface IChallengeService
    {
        /// <summary>
        /// Busca todos os registro da API
        /// </summary>
        /// <returns>Retona uma coleção de registros</returns>
        IList<Vehicles> GetAllVehicles();
    }
}
