using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sistema_Escolar.Data;
using Sistema_Escolar.Models;
using Sistema_Escolar.Repositorio.IServices;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var alunos = _bancoContext.Alunos
                .Include(a => a.Turma)
                .Include(a => a.Escola)
                .ToList();

            var result = alunos.Select(aluno => new AlunosModel
            {
                ID_Aluno = aluno.ID_Aluno,
                Nome_Completo = aluno.Nome_Completo,
                CPF = aluno.CPF,
                DataDeNascimento = aluno.DataDeNascimento,
                Status_Cadastro = aluno.Status_Cadastro,
                Ano_Letivo = aluno.Ano_Letivo,
                qtd_Alunos = aluno.qtd_Alunos,
                ID_Turma = aluno.ID_Turma,
                ID_Escola = aluno.ID_Escola,
                TurmaNome = aluno.Turma.Nome_Turma,
                EscolaNome = aluno.Escola.Nome_Escola
            }).ToList();

            return result;
        }


        public async Task<object> Adicionar(int Escola, int Turma, string NomeCompleto, string CPF, DateTime DataNascimento)
        {
            //string dataNascimentoString = DataNascimento.ToString("dd/MM/yyyy");
            //DateTime dataNascimento = DateTime.ParseExact(dataNascimentoString, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

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

        public AlunosModel InfoAluno(string CPF)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.CPF == CPF);
        }

        public async Task<object> EditarAluno(string CPF, string StatusCadastro, string Turma, string Escola)
        {
            AlunosModel alunoDB = InfoAluno(CPF);
            string nomeTurma = Turma;
            int idTurma = ObterIdTurmaPorNome(nomeTurma);

            string nomeEscola = Escola;
            int idEscola = ObterIdEscolaPorNome(nomeEscola);


            if (alunoDB == null)
            {
                throw new SystemException("Não foi possível encontrar a Matricula do Aluno");
            }

            alunoDB.Status_Cadastro = StatusCadastro;
            alunoDB.ID_Turma = idTurma;
            alunoDB.ID_Escola = idEscola;

            _bancoContext.Alunos.Update(alunoDB);
            _bancoContext.SaveChanges();

            AlunosModel alunoAtt = InfoAluno(CPF);

            string response = JsonConvert.SerializeObject(alunoAtt);
            return Task.FromResult<object>(response);

        }

        public int ObterIdTurmaPorNome(string nomeTurma)
        {
            var turma = _bancoContext.Turmas.SingleOrDefault(t => t.Nome_Turma == nomeTurma);

            if (turma == null)
            {
                throw new SystemException("Não foi possível encontrar a turma com o nome informado.");
            }

            return turma.ID_Turma;
        }


        public int ObterIdEscolaPorNome(string nomeEscola)
        {
            var Escolas = _bancoContext.Escolas.SingleOrDefault(t => t.Nome_Escola == nomeEscola);

            if (Escolas == null)
            {
                throw new SystemException("Não foi possível encontrar a escola com o nome informado.");
            }

            return Escolas.ID_Escola;
        }

        public Task<object> ApagarAluno(string CPF)
        {
            AlunosModel alunoDB = InfoAluno(CPF);

            if (alunoDB == null)
            {
                throw new SystemException("Não foi possível encontrar a Matricula do Aluno");
            }

            _bancoContext.Alunos.Remove(alunoDB);
            _bancoContext.SaveChanges();

            AlunosModel newAluno = InfoAluno(CPF);
            string response = JsonConvert.SerializeObject(newAluno);

            return Task.FromResult<object>(response);

        }

        public class TurmaEscolaInfo
        {
            public string TurmaNome { get; set; }
            public string EscolaNome { get; set; }
        }


        public async Task<TurmaEscolaInfo> GetNameTurmaEEscola(int idEscola, int idTurma)
        {
            var Turma = await _bancoContext.Turmas.SingleOrDefaultAsync(t => t.ID_Turma == idTurma);



            if (Turma == null)
            {
                throw new SystemException("Não foi possível encontrar a turma com o ID informado.");
            }

            var Escolas = await _bancoContext.Escolas.SingleOrDefaultAsync(t => t.ID_Escola == idEscola);

            if (Escolas == null)
            {
                throw new SystemException("Não foi possível encontrar a escola com o ID informado.");
            }

            var TurmaNome = Turma.Nome_Turma;
            var EscolaNome = Escolas.Nome_Escola;

            var turmaEscolaInfo = new TurmaEscolaInfo
            {
                TurmaNome = TurmaNome,
                EscolaNome = EscolaNome
            };

            return turmaEscolaInfo;
        }
    }
}

