using Sistema_Escolar.Data;
using Sistema_Escolar.Models;
using System;
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

        public async Task<object> Adicionar(int Id, string NomeCompleto, Int64 CPF, string DataNascimento, string Escola, string Turma)
        {

            AlunosModel Aluno = new AlunosModel() 
            {
                Id = Id,
                NomeCompleto = NomeCompleto,
                CPF = CPF,
                DataNascimento = DataNascimento,
                Escola = Escola,
                Turma = Turma
                
            };

            // Inserção no banco de dados
            _bancoContext.Alunos.Add(Aluno);
            _bancoContext.SaveChanges();

            return Aluno;
        }
    }
}
