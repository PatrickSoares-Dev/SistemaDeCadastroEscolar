using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sistema_Escolar.Data;
using Sistema_Escolar.Models;
using Sistema_Escolar.Repositorio.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Sistema_Escolar.Repositorio
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private readonly IEscolaRepositorio _escolaRepositorio;
        private readonly BancoContext _bancoContext;


        public TurmaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<TurmasModel> BuscarTodos()
        {
            return _bancoContext.Turmas.ToList();
        }

        public async Task<object> Adicionar(string NomeEscola, string NomeTurma)
        {

            EscolaModel escola = _bancoContext.Escolas.FirstOrDefault(x => x.Nome_Escola == NomeEscola);

            if (escola == null)
            {
                // retornar um erro ou lançar uma exceção, informando que a escola não foi encontrada
                // por exemplo:
                return BadRequest($"A escola '{NomeEscola}' não foi encontrada.");
            }

            // Obtém o ID da escola encontrada
            int idEscola = escola.ID_Escola;

            TurmasModel Turma = new TurmasModel() 
            {
                ID_Escola = idEscola,
                Nome_Escola = NomeEscola,
                Nome_Turma = NomeTurma
            };

            // Inserção no banco de dados
            _bancoContext.Turmas.Add(Turma);
            _bancoContext.SaveChanges();
            string sql = "CREATE OR ALTER VIEW EscolasTurmasAlunos AS SELECT e.*, t.Qtde_Turmas, t.Qtde_Alunos FROM Escolas e LEFT JOIN ( SELECT ID_Escola, COUNT(DISTINCT ID_Turma) AS Qtde_Turmas, SUM(Qtde_Alunos) AS Qtde_Alunos FROM ( SELECT t.ID_Escola, t.ID_Turma, COUNT(*) AS Qtde_Alunos FROM Turmas t INNER JOIN Alunos a ON a.ID_Turma = t.ID_Turma GROUP BY t.ID_Escola, t.ID_Turma ) a GROUP BY ID_Escola ) t ON t.ID_Escola = e.ID_Escola;";
            using (SqlConnection connection = new SqlConnection(_bancoContext.Database.GetConnectionString()))
            {
                
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return Turma;
        }

        private object BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        //public AlunosModel InfoEscola(string Matricula)
        //{
        //    return _bancoContext.Alunos.FirstOrDefault(x => x.Matricula == Matricula);
        //}

        //public Task<object> EditarAluno(string Matricula, string StatusCadastro, int Turma)
        //{
        //    AlunosModel alunoDB = InfoAluno(Matricula);

        //    if(alunoDB == null )
        //    {
        //        throw new SystemException("Não foi possível encontrar a Matricula do Aluno");
        //    }

        //    alunoDB.Status_Cadastro= StatusCadastro;
        //    alunoDB.ID_Turma = Turma;

        //    _bancoContext.Alunos.Update(alunoDB);
        //    _bancoContext.SaveChanges();

        //    AlunosModel alunoAtt = InfoAluno(Matricula);

        //    string response = JsonConvert.SerializeObject(alunoAtt);
        //    return Task.FromResult<object>(response);

        //}

        //public Task<object> ApagarAluno(string Matricula)
        //{
        //    AlunosModel alunoDB = InfoAluno(Matricula);

        //    if (alunoDB == null)
        //    {
        //        throw new SystemException("Não foi possível encontrar a Matricula do Aluno");
        //    }

        //    _bancoContext.Alunos.Remove(alunoDB);
        //    _bancoContext.SaveChanges();

        //    AlunosModel newAluno = InfoAluno(Matricula);
        //    string response = JsonConvert.SerializeObject(newAluno);

        //    return Task.FromResult<object>(response);

        //}
    }
}
