using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Sistema_Escolar.Repositorio.IServices;
using Sistema_Escolar.Models;
using System.Collections.Generic;

namespace Sistema_Escolar.Controllers
{
    public class TurmaController : Controller
    {

        private readonly ITurmaRepositorio _turmaRepositorio;
        public TurmaController(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        [HttpGet]
        [Route("/turma")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/turmaadd")]
        public async Task<JsonResult> Adicionar(string NomeEscola, string NomeTurma)
        {
            object response = await _turmaRepositorio.Adicionar(NomeEscola, NomeTurma);
            return Json(response);
        }

        [HttpGet]
        [Route("/allturma")]
        public async Task<JsonResult> BuscarTodos()
        {
            List<TurmasModel> Turma = _turmaRepositorio.BuscarTodos();
            return Json(Turma);
        }

        //[HttpGet]
        //[Route("/infoaluno")]
        //public async Task<JsonResult> InfoAluno(string Matricula)
        //{
        //    AlunosModel alunoId = _escolaRepositorio.InfoAluno(Matricula);
        //    return Json(alunoId);
        //}

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
