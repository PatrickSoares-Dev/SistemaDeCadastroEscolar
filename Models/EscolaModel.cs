using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Escolar.Models
{
    public class EscolaModel
    {

        [Key]
        public int ID_Escola { get; set; }

        public string Nome_Escola { get; set; }

        private int _qtdeTurmas;
        public int Qtde_Turmas
        {
            get { return _qtdeTurmas > 0 ? _qtdeTurmas : Turmas?.Count ?? 0; }
            set { _qtdeTurmas = value; }
        }
        public int Qtde_Alunos { get; set; } = 0;

        public virtual ICollection<TurmasModel> Turmas { get; set; }

        public virtual ICollection<AlunosModel> Alunos { get; set; }

        public EscolaModel()
        {

        }

    }
    
}
