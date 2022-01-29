using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Business.Contracts;
using Webmotors.Data.Dal.Contracts;
using Webmotors.Domain.Models;
using Webmotors.Mediator.Service.Contracts;

namespace Webmotors.Business
{
    public class AnuncioWebmotorsService : Service<AnuncioWebmotors, int>, IAnuncioWebmotorsService, IRegisterEscopoBusiness
    {
        private IChallengeService vChallengeService;
        private IMapper vMapper;
        public AnuncioWebmotorsService(IAnuncioWebmotorsRepository pRepository,
                                    ILogger<AnuncioWebmotorsService> pLogger,
                                    IChallengeService pChallengeService,
                                    IMapper pMapper)
        {
            this.vRepository = pRepository;
            vLogger = pLogger;
            vChallengeService = pChallengeService;
            vMapper = pMapper;
        }

        public async Task<List<AnuncioWebmotors>> LoadDataApi()
        {
            var vAnuncioWebmotorsDB = base.GetAll().ToList();
            if (vAnuncioWebmotorsDB.Count == 0)
            {
                var vVehicles = vChallengeService.GetAllVehicles();
                vAnuncioWebmotorsDB = vMapper.Map<List<AnuncioWebmotors>>(vVehicles);
                await base.SaveAsync(vAnuncioWebmotorsDB);
            }
            return vAnuncioWebmotorsDB;
        }
    }
}
