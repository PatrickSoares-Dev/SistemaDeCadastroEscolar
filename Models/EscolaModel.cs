using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Escolar.Models
{
    public class EscolaModel
    {

        [Key]
        public int Codigo_Escola { get; set; }
        public string Nome_Escola { get; set; }
        public int Qtde_Turmas { get; set; }
        public int Qtde_Alunos { get; set; }

        public virtual ICollection<TurmaModel> Turmas { get; set; }

        public EscolaModel()
        {

        }

    }
}
