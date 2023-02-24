using Sistema_Escolar.Models;
using System;
using System.Threading.Tasks;

namespace Sistema_Escolar.Repositorio
{
    public interface IAlunoRepositorio
    {
        public Task<object> Adicionar(int Id, string NomeCompleto, Int64 CPF, string DataNascimento, string Escola, string Turma);
    }
}
