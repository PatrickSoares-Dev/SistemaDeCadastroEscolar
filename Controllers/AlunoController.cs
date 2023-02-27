using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_Escolar.Models;
using Sistema_Escolar.Repositorio.IServices;
using System;
using System.Collections.Generic;
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
        public async Task<JsonResult> BuscarTodos()
        {
            List<AlunosModel> alunos =  _alunoRepositorio.BuscarTodos();
           return Json(alunos);
        }

        [HttpGet]
        [Route("/infoaluno")]
        public async Task<JsonResult> InfoAluno(string Matricula)
        {
            AlunosModel alunoId = _alunoRepositorio.InfoAluno(Matricula);
            return Json(alunoId);
        }

        [HttpGet]
        [Route("/editaluno")]
        public async Task<JsonResult> EditarAluno(string Matricula, string StatusCadastro, int Turma)
        {
            object response = await _alunoRepositorio.EditarAluno(Matricula, StatusCadastro, Turma);
            return Json(response);
        }

        [HttpGet]
        [Route("/apagaraluno")]
        public async Task<JsonResult> ApagarAluno(string Matricula)
        {
            object response = await _alunoRepositorio.ApagarAluno(Matricula);
            return Json(response);
        }
    }
}
