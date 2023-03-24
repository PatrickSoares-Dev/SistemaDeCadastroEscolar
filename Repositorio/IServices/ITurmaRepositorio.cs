using Sistema_Escolar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema_Escolar.Repositorio.IServices
{
    public interface ITurmaRepositorio
    {
        Task<object> Adicionar(string NomeEscola, string NomeTurma);
        Task<TurmasModel> ObterTurma(int idTurma);
        Task<List<TurmasModel>> ObterTurmas();
        Task<List<AlunosModel>> ObterAlunosDaTurma(int idTurma);
        Task<int> ContarAluno(int idTurma);
        List<TurmasModel> BuscarTodos();
        public Task<object> ObterTurmasDaEscola(int idEscola);


    }
}