using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Webmotors.Business.Contracts;
using Webmotors.Data.Dal.Contracts;
using Webmotors.Domain.Models;
using Webmotors.Mediator.Service.Contracts;

namespace Webmotors.Business
{
    public class AnuncioWebmotorsService : Service<AnuncioWebmotors, int>, IAnuncioWebmotorsService
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

        public async void LoadDataApi()
        {
            var vVehicles = vChallengeService.GetAllVehicles();
            var vAnuncioWebmotors = vMapper.Map<List<AnuncioWebmotors>>(vVehicles);
            await base.SaveAsync(vAnuncioWebmotors);
        }
    }
}
