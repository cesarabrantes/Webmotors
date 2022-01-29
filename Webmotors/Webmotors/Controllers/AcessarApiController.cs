using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Business.Contracts;
using Webmotors.ViewModel;

namespace Webmotors.Controllers
{
    public class AcessarApiController : Controller
    {
        readonly IMapper vMapper;
        readonly ILogger<AcessarApiController> vLogger;
        readonly IAnuncioWebmotorsService vService;
        public AcessarApiController(
            IMapper pMapper,
            ILogger<AcessarApiController> pLogger,
            IAnuncioWebmotorsService pService
            )
        {
            this.vLogger = pLogger;
            this.vMapper = pMapper;
            this.vService = pService;
        }
        public IActionResult Index()
        {
            var vObjList = vService.LoadDataApi();
            var vObjListVM = vMapper.Map<List<AnuncioWebmotorsVM>>(vObjList);
            return View(vObjListVM);
        }
    }
}
