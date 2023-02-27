using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Sistema_Escolar.Repositorio.IServices;
using Sistema_Escolar.Models;
using Sistema_Escolar.Repositorio;
using System.Collections.Generic;

namespace Sistema_Escolar.Controllers
{
    public class EscolaController : Controller
    {

        public readonly IEscolaRepositorio _escolaRepositorio;
        public EscolaController(IEscolaRepositorio escolaRepositorio)
        {
            _escolaRepositorio = escolaRepositorio;
        }


        [HttpGet]
        [Route("/escola")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/escolaadd")]
        public async Task<JsonResult> Adicionar(string NomeEscola)
        {
            object response = await _escolaRepositorio.Adicionar(NomeEscola);

            return Json(response);
        }

        [HttpGet]
        [Route("/allescolas")]
        public async Task<IActionResult> GetEscolasTurmasAlunos()
        {
            var escolasTurmasAlunos = await _escolaRepositorio.GetEscolasTurmasAlunos();
            return Json(escolasTurmasAlunos);
        }

        [HttpGet]
        [Route("/infoescola")]
        public async Task<JsonResult> InfoEscola(string NomeEscola)
        {
            EscolaModel escolaID = _escolaRepositorio.InfoEscola(NomeEscola);
            string Id = escolaID.ID_Escola.ToString();
            return Json(escolaID);
        }

        //[HttpGet]
        //[Route("/editaluno")]
        //public async Task<JsonResult> EditarAluno(string Matricula, string StatusCadastro, int Turma)
        //{
        //    object response = await _escolaRepositorio.EditarEscola(Matricula, StatusCadastro, Turma);
        //    return Json(response);
        //}

        //[HttpGet]
        //[Route("/apagaraluno")]
        //public async Task<JsonResult> ApagarAluno(string Matricula)
        //{
        //    object response = await _escolaRepositorio.ApagarEscola(Matricula);
        //    return Json(response);
        //}

    }
}
