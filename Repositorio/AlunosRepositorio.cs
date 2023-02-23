using Sistema_Escolar.Data;
using Sistema_Escolar.Models;

namespace Sistema_Escolar.Repositorio
{
    public class AlunosRepositorio : IAlunoRepositorio
    {
        private readonly BancoContext _bancoContext;


        public AlunosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AlunosModel Adicionar(AlunosModel aluno)
        {
            // Inserção no banco de dados
            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();

            return aluno;
        }
    }
}
