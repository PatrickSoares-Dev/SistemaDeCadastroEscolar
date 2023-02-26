using Newtonsoft.Json;
using Sistema_Escolar.Data;
using Sistema_Escolar.Models;
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

        public async Task<object> Adicionar(int Id, int Turma, int AnoLetivo, string NomeCompleto, string CPF, DateTime DataNascimento, string StatusCadastro, int CodigoTurma )
        {

          AlunosModel Aluno = new AlunosModel() 
            {
                ID_ALUNO = Id,
                ID_TURMA = Turma,
                Nome_Completo = NomeCompleto,
                CPF = CPF,
                Data_Nascimento = DataNascimento

            };

            // Inserção no banco de dados
            _bancoContext.Alunos.Add(Aluno);
            _bancoContext.SaveChanges();

            AlunosModel newAluno = InfoAluno(Id);
            string response = JsonConvert.SerializeObject(newAluno);

            return Task.FromResult<object>(response);
        }

        public AlunosModel InfoAluno(int Id)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.ID_ALUNO == Id);
        }

        public Task<object> EditarAluno(int Id, string StatusCadastro, int Turma)
        {
            AlunosModel alunoDB = InfoAluno(Id);

            if(alunoDB == null )
            {
                throw new SystemException("Não foi possível encontrar a Matricula do Aluno");
            }

            alunoDB.Status_Cadastro= StatusCadastro;
            alunoDB.Codigo_Turma = Turma;

            _bancoContext.Alunos.Update(alunoDB);
            _bancoContext.SaveChanges();

            AlunosModel alunoAtt = InfoAluno(Id);

            string response = JsonConvert.SerializeObject(alunoAtt);
            return Task.FromResult<object>(response);

        }

        public Task<object> ApagarAluno(int Id)
        {
            AlunosModel alunoDB = InfoAluno(Id);

            if (alunoDB == null)
            {
                throw new SystemException("Não foi possível encontrar a Matricula do Aluno");
            }

            _bancoContext.Alunos.Remove(alunoDB);
            _bancoContext.SaveChanges();

            AlunosModel newAluno = InfoAluno(Id);
            string response = JsonConvert.SerializeObject(newAluno);

            return Task.FromResult<object>(response);

        }
    }
}
