using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_Escolar.Models;
using Sistema_Escolar.Repositorio;
using System;
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
        public async Task<JsonResult> Adicionar(int Id, string NomeCompleto, Int64 CPF, string DataNascimento, string Escola, string Turma)
        {
            object response = await _alunoRepositorio.Adicionar(Id, NomeCompleto, CPF, DataNascimento, Escola, Turma);

            return Json(response);
        }
    }
}
