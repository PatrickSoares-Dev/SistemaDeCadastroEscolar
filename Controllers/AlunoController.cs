using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_Escolar.Models;
using Sistema_Escolar.Repositorio;
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
        public async Task<JsonResult> Adicionar(int Id, int Turma, int AnoLetivo, string NomeCompleto, string CPF, DateTime DataNascimento, string StatusCadastro, int CodigoTurma)
        {
            object response = await _alunoRepositorio.Adicionar(Id, Turma, AnoLetivo, NomeCompleto, CPF, DataNascimento, StatusCadastro, CodigoTurma);

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
        public async Task<JsonResult> InfoAluno(int Id)
        {
            AlunosModel alunoId = _alunoRepositorio.InfoAluno(Id);
            return Json(alunoId);
        }

        [HttpGet]
        [Route("/editaluno")]
        public async Task<JsonResult> EditarAluno(int Id ,string StatusCadastro, int Turma)
        {
            object response = await _alunoRepositorio.EditarAluno(Id, StatusCadastro, Turma);
            return Json(response);
        }

        [HttpGet]
        [Route("/apagaraluno")]
        public async Task<JsonResult> ApagarAluno(int Id)
        {
            object response = await _alunoRepositorio.ApagarAluno(Id);
            return Json(response);
        }
    }
}
