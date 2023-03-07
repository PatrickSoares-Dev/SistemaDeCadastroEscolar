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

namespace Sistema_Escolar.Repositorio
{
    public class EscolaRepositorio : IEscolaRepositorio
    {

        private readonly BancoContext _bancoContext;

        public EscolaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }

        public List<EscolaModel> BuscarTodos()
        {
            return _bancoContext.Escolas.ToList();
        }

        public async Task<object> Adicionar(string NomeEscola)
        {

            EscolaModel Escola = new EscolaModel()
            {
                Nome_Escola = NomeEscola,

            };

            // Inserção no banco de dados
            _bancoContext.Escolas.Add(Escola);
            _bancoContext.SaveChanges();

             return Escola;
        }

        public EscolaModel InfoEscola(string NomeEscola)
        {
            return _bancoContext.Escolas.FirstOrDefault(x => x.Nome_Escola == NomeEscola);

        }

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

        public async Task<List<EscolaModel>> GetEscolasTurmasAlunos()
        {
            string sql = "SELECT * FROM EscolasTurmasAlunos";
            List<EscolaModel> result = new List<EscolaModel>();
            using (SqlConnection connection = new SqlConnection(_bancoContext.Database.GetConnectionString()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EscolaModel viewModel = new EscolaModel();
                            viewModel.ID_Escola = (int)reader["ID_Escola"];
                            viewModel.Nome_Escola = (string)reader["Nome_Escola"];
                            viewModel.Qtde_Turmas = reader.IsDBNull(reader.GetOrdinal("Qtde_Turmas")) ? 0 : (int)reader["Qtde_Turmas"];
                            viewModel.Qtde_Alunos = reader.IsDBNull(reader.GetOrdinal("Qtde_Alunos")) ? 0 : (int)reader["Qtde_Alunos"];
                            result.Add(viewModel);
                        }
                    }
                }
            }
            return await Task.FromResult(result);
        }
    }
}

