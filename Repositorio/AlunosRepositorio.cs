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
    public class AlunosRepositorio : IAlunoRepositorio
    {
        private readonly BancoContext _bancoContext;



        public AlunosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<AlunosModel> BuscarTodos()
        {
            return _bancoContext.Alunos.ToList();
        }

        public async Task<object> Adicionar(int Escola, int Turma, string NomeCompleto, string CPF, DateTime DataNascimento)
        {



          AlunosModel Aluno = new AlunosModel() 
            {
                ID_Escola = Escola,
                ID_Turma = Turma,
                Nome_Completo = NomeCompleto,
                CPF = CPF,
                DataDeNascimento = DataNascimento

            };

            // Inserção no banco de dados
            _bancoContext.Alunos.Add(Aluno);
            _bancoContext.SaveChanges();

            return Aluno;
        }

        public AlunosModel InfoAluno(string Matricula)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.Matricula == Matricula);
        }

        public Task<object> EditarAluno(string Matricula, string StatusCadastro, int Turma)
        {
            AlunosModel alunoDB = InfoAluno(Matricula);

            if(alunoDB == null )
            {
                throw new SystemException("Não foi possível encontrar a Matricula do Aluno");
            }

            alunoDB.Status_Cadastro= StatusCadastro;
            alunoDB.ID_Turma = Turma;

            _bancoContext.Alunos.Update(alunoDB);
            _bancoContext.SaveChanges();

            AlunosModel alunoAtt = InfoAluno(Matricula);

            string response = JsonConvert.SerializeObject(alunoAtt);
            return Task.FromResult<object>(response);

        }

        public Task<object> ApagarAluno(string Matricula)
        {
            AlunosModel alunoDB = InfoAluno(Matricula);

            if (alunoDB == null)
            {
                throw new SystemException("Não foi possível encontrar a Matricula do Aluno");
            }

            _bancoContext.Alunos.Remove(alunoDB);
            _bancoContext.SaveChanges();

            AlunosModel newAluno = InfoAluno(Matricula);
            string response = JsonConvert.SerializeObject(newAluno);

            return Task.FromResult<object>(response);

        }
    }
}
