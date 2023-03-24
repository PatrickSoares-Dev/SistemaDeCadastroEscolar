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
        [Route("/turmas")]
        public async Task<JsonResult> ObterTurmasEContarAlunos()
        {
            var turmas = await _turmaRepositorio.ObterTurmas();
            var turmasComAlunos = new List<TurmasComAlunosModel>();

            foreach (var turma in turmas)
            {
                var alunos = await _turmaRepositorio.ObterAlunosDaTurma(turma.ID_Turma);
                var turmaComAlunos = new TurmasComAlunosModel
                {
                    ID_Turma = turma.ID_Turma,
                    Nome_Turma = turma.Nome_Turma,
                    Nome_Escola = turma.Nome_Escola, // novo atributo para armazenar o nome da escola
                    Alunos = alunos,
                    Qtd_Alunos = alunos.Count
                };


                turmasComAlunos.Add(turmaComAlunos);
            }

            return Json(new { Turmas = turmasComAlunos });
        }


        [HttpGet]
        [Route("/turmaescola")]
        public async Task<JsonResult> ObterTurmasDaEscola(int idEscola)
        {
            var turmas = (List<TurmasModel>)await _turmaRepositorio.ObterTurmasDaEscola(idEscola);
            var turmasComAlunos = new List<TurmasComAlunosModel>();

            foreach (var turma in turmas)
            {
                var alunos = await _turmaRepositorio.ObterAlunosDaTurma(turma.ID_Turma);
                var turmaComAlunos = new TurmasComAlunosModel
                {
                    ID_Turma = turma.ID_Turma,
                    Nome_Turma = turma.Nome_Turma,
                    Nome_Escola = turma.Nome_Escola, // novo atributo para armazenar o nome da escola
                    Alunos = alunos,
                    Qtd_Alunos = alunos.Count
                };

                turmasComAlunos.Add(turmaComAlunos);
            }

            return Json(new { Turmas = turmasComAlunos });
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
