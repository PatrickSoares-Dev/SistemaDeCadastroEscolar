using Sistema_Escolar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema_Escolar.Repositorio.IServices
{
    public interface ITurmaRepositorio
    {

        public Task<object> Adicionar(string NomeEscola, string NomeTurma);

        public List<TurmasModel> BuscarTodos();

        //public AlunosModel InfoAluno(string Matricula);

        //public Task<object> EditarAluno(string Matricula, string StatusCadastro, int Turma);

        //public Task<object> ApagarAluno(string Matricula);

    }
}