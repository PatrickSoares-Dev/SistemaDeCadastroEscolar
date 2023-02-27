using Microsoft.Extensions.DependencyModel;
using Sistema_Escolar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema_Escolar.Repositorio.IServices
{
    public interface IAlunoRepositorio
    {
        public Task<object> Adicionar(int Escola, int Turma, string NomeCompleto, string CPF, DateTime DataNascimento);

        public List<AlunosModel> BuscarTodos();

        public AlunosModel InfoAluno(string Matricula);

        public Task<object> EditarAluno(string Matricula, string StatusCadastro, int Turma);

        public Task<object> ApagarAluno(string Matricula);

    }
}
