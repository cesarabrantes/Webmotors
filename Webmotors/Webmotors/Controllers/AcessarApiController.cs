﻿using AutoMapper;
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

        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind] AnuncioWebmotorsVM anuncioWebmotors)
        {
            if (ModelState.IsValid)
            {
                var vAnuncioWebmotors = vMapper.Map<AnuncioWebmotors>(anuncioWebmotors);
                await vService.SaveAsync( vAnuncioWebmotors );                
                return RedirectToAction("Index");
            }
            
            return View(anuncioWebmotors);
        }

        #endregion

        #region Edit
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Id do registro não pode ser vazio");
                }

                //Método já popula o objeto da View Model
                var vAnuncioWebmotors = await vService.GetByConditionanonymousAsync(o => o.Id == id, 
                    s => new AnuncioWebmotorsVM {
                        Id = s.Id,
                        Ano =s.Ano,
                        Marca=s.Marca,
                        Modelo=s.Modelo,
                        Observacao =s.Observacao,
                        Quilometragem=s.Quilometragem,
                        Versao =s.Versao
                    });

                if(vAnuncioWebmotors.Count == 0)
                {
                    throw new Exception("Anúncio não encontrado");
                }

                return View(vAnuncioWebmotors.FirstOrDefault());

            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind] AnuncioWebmotorsVM anuncioWebmotors)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var vAnuncioWebmotors = vMapper.Map<AnuncioWebmotors>(anuncioWebmotors);
                    await vService.UpdateAsync(vAnuncioWebmotors);
                    return RedirectToAction("Index");
                }

                return View(anuncioWebmotors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion



        #region Details

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Id do registro não pode ser vazio");
                }

                //Método já popula o objeto da View Model
                var vAnuncioWebmotors = await vService.GetByConditionanonymousAsync(o => o.Id == id,
                    s => new AnuncioWebmotorsVM
                    {
                        Id = s.Id,
                        Ano = s.Ano,
                        Marca = s.Marca,
                        Modelo = s.Modelo,
                        Observacao = s.Observacao,
                        Quilometragem = s.Quilometragem,
                        Versao = s.Versao
                    });

                if (vAnuncioWebmotors.Count == 0)
                {
                    throw new Exception("Anúncio não encontrado");
                }

                return View(vAnuncioWebmotors.FirstOrDefault());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}
