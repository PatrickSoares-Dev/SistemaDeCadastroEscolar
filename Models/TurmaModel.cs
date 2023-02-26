using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Escolar.Models
{
    public class TurmaModel
    {
        [Key]
        public int Codigo_Turma { get; set; }
        public int ID_ESCOLA { get; set; }
        public int ID_MATERIA { get; set; }

        public virtual EscolaModel Escola { get; set; }
        public virtual ICollection<AlunosModel> Alunos { get; set; }

        public TurmaModel()
        {

        }
    }
}
