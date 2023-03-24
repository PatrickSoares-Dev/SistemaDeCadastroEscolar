using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sistema_Escolar.Models
{
    public class TurmasComAlunosModel
    {
        public int ID_Turma { get; set; }
        public string Nome_Turma { get; set; }
        public string Nome_Escola { get; set; }
        public List<AlunosModel> Alunos { get; set; }
        public int Qtd_Alunos { get; set; }
    }


}
