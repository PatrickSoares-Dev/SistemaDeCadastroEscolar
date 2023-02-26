using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Escolar.Models
{
    public class AlunosModel
    {
        [Key]
        public int ID_ALUNO { get; set; }
        public int ID_TURMA { get; set; }
        public int ANO_LETIVO => DateTime.Now.Year;
        public string Nome_Completo { get; set; }
        public string CPF { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Status_Cadastro { get; set; }
        public int Codigo_Turma { get; set; }

        public virtual TurmaModel Turma { get; set; }
        public string Nome_Escola => Turma?.Escola?.Nome_Escola; // Propriedade de navegação para acessar o nome da escola

        public AlunosModel()
        {
            Status_Cadastro = "Ativo";
        }
    }
}
