using Microsoft.Extensions.DependencyModel;
using Sistema_Escolar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema_Escolar.Repositorio
{
    public interface IAlunoRepositorio
    {
        public Task<object> Adicionar(int Id, int Turma, int AnoLetivo, string NomeCompleto, string CPF, DateTime DataNascimento, string StatusCadastro, int CodigoTurma);

        public List<AlunosModel> BuscarTodos();

        public AlunosModel InfoAluno(int Id);

        public Task<Object> EditarAluno(int Id, string StatusCadastro, int Turma);

        public Task<Object> ApagarAluno(int Id);

    }
}
