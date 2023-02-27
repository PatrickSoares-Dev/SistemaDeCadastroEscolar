using System.ComponentModel.DataAnnotations;

namespace Sistema_Escolar.Models
{
    public class TurmaMateriaModel
    {
        [Key]
        public int ID_Turma { get; set; }

        [Key]
        public int ID_Materia { get; set; }

        public virtual TurmasModel Turma { get; set; }

        public virtual MateriasModel Materia { get; set; }
    }
}
