using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_Escolar.Models;
using Sistema_Escolar.Repositorio.IServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Sistema_Escolar.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet]
        [Route("/aluno")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/alunoadd")]
        public async Task<JsonResult> Adicionar(int Escola, int Turma, string NomeCompleto, string CPF, DateTime DataNascimento)
        {            

            object response = await _alunoRepositorio.Adicionar(Escola, Turma, NomeCompleto, CPF, DataNascimento);

            return Json(response);
        }
        [HttpGet]
        [Route("/allalunos")]
        public IActionResult BuscarTodos()
        {
            var alunos = _alunoRepositorio.BuscarTodos();
            return Json(alunos);
        }

        //[HttpGet]
        //[Route("/buscarescolaeturma")]
        //public IActionResult BuscarEscolaETurma()
        //{
        //    var alunos = _alunoRepositorio.BuscarEscolaETurma();
        //    return Json(alunos);
        //}

        [HttpGet]
        [Route("/infoaluno")]
        public async Task<JsonResult> InfoAluno(string CPF)
        {
            AlunosModel alunoId = _alunoRepositorio.InfoAluno(CPF);
            return Json(alunoId);
        }

        [HttpGet]
        [Route("/editaluno")]
        public async Task<JsonResult> EditarAluno(string CPF, string StatusCadastro, string Turma, string Escola)
        {
            object response = await _alunoRepositorio.EditarAluno(CPF, StatusCadastro, Turma, Escola);
            return Json(response);
        }

        [HttpGet]
        [Route("/apagaraluno")]
        public async Task<JsonResult> ApagarAluno(string CPF)
        {
            object response = await _alunoRepositorio.ApagarAluno(CPF);
            return Json(response);
        }

        [HttpGet]
        [Route("/getnameturmaeescola")]
        public async Task<JsonResult> GetNameTurmaEEscola(int idEscola, int idTurma)
        {
            object response = await _alunoRepositorio.GetNameTurmaEEscola(idEscola, idTurma);
            return Json(response);
        }

    }
}
