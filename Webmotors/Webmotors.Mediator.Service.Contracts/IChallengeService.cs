using System.Collections.Generic;
using Webmotors.Mediator.Api.Models;

namespace Webmotors.Mediator.Service.Contracts
{
    public interface IChallengeService
    {
        IList<Vehicles> GetAllVehicles();
    }
}
