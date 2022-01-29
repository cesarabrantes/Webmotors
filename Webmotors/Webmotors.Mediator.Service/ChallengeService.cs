using System.Collections.Generic;
using Webmotors.Mediator.Api.Client;
using Webmotors.Mediator.Api.Models;
using Webmotors.Mediator.Service.Contracts;

namespace Webmotors.Mediator.Service
{
    public class ChallengeService: IChallengeService
    {
        private string vUri;
        public ChallengeService(string pUri)
        {
            vUri = pUri;
        }

        public IList<Vehicles> GetAllVehicles()
        {
            var vVehicles = new List<Vehicles>();
            var vApiClient = new ApiClient(vUri, EndPoints.Vehicles);
            int vPage = 1;
            bool vExistRecord = true;

            while (vExistRecord)
            {
                var vApiReturn = vApiClient.Get<List<Vehicles>>(vPage);
                if (vApiReturn.Count > 0)
                    vVehicles.AddRange(vApiReturn);

                vPage++;
                vExistRecord = vApiReturn.Count > 0;
            }
            return vVehicles;
        }
    }
}
