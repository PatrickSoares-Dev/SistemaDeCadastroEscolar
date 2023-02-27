using Microsoft.Extensions.DependencyModel;
using Sistema_Escolar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema_Escolar.Repositorio.IServices
{
    public interface IEscolaRepositorio
    {
        public Task<object> Adicionar(string NomeEscola);

        public Task<List<EscolaModel>> GetEscolasTurmasAlunos();

        public EscolaModel InfoEscola(string NomeEscola);

        //public Task<object> EditarAluno(string Matricula, string StatusCadastro, int Turma);

        //public Task<object> ApagarAluno(string Matricula);

    }
}
