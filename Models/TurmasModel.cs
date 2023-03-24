using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sistema_Escolar.Models
{
    public class TurmasModel
    {
        [Key]
        public int ID_Turma { get; set; }

        public int ID_Escola { get; set; }

        public string Nome_Turma { get; set; }

        public string Nome_Escola { get; set; }

        public virtual EscolaModel Escola { get; set; }

        public virtual ICollection<AlunosModel> Alunos { get; set; }

        public int Qtd_Alunos
        {
            get { return Alunos?.Count ?? 0; } // Retorna o número de alunos na turma ou 0 se a lista de alunos for nula ou vazia
        }

        public TurmasModel()
        {

        }
    }
}
