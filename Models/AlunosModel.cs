using Sistema_Escolar.Repositorio.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Escolar.Models
{
    public class AlunosModel
    {
        [Key]
        public int ID_Aluno { get; set; }

        [Required(ErrorMessage = "A turma é obrigatória.")]
        public int ID_Turma { get; set; }

        [Required(ErrorMessage = "A escola é obrigatória.")]

        public int ID_Escola { get; set; }

        [Required(ErrorMessage = "O ano letivo é obrigatório.")]
        public int Ano_Letivo { get; set; } = DateTime.Now.Year;

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string Nome_Completo { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeNascimento { get; set; }

        [Required(ErrorMessage = "O status do cadastro é obrigatório.")]
        public string Status_Cadastro { get; set; }

        public virtual TurmasModel Turma { get; set; }

        public int qtd_Alunos { get; set; }

        public virtual EscolaModel Escola { get; set; }

        public string TurmaNome { get; set; } // Adicionar esta propriedade
        public string EscolaNome { get; set; } // Adicionar esta propriedade

        public string Matricula
        {
            get
            {
                var posicao = ID_Aluno.ToString("D2");
                return $"{posicao}{ID_Escola}{ID_Turma}{Ano_Letivo}";
            }
        }


        public AlunosModel()
        {
            Status_Cadastro = "Ativo";
        }
    }

}
