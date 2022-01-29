using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Business.Contracts;
using Webmotors.Domain.Models;
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
        public async Task<IActionResult> Index()
        {
            var vObjList = await vService.LoadDataApi();
            var vObjListVM = vMapper.Map<List<AnuncioWebmotorsVM>>(vObjList);
            return View(vObjListVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind] AnuncioWebmotorsVM anuncioWebmotors)
        {
            if (ModelState.IsValid)
            {
                var AnuncioWebmotorsD = vMapper.Map<AnuncioWebmotors>(anuncioWebmotors);
                await vService.SaveAsync( AnuncioWebmotorsD );                
                return RedirectToAction("Index");
            }
            
            return View(anuncioWebmotors);
        }
    }
}
