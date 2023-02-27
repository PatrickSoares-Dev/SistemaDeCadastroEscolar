using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Escolar.Models
{
    public class MateriasModel
    {
        [Key]
        public int ID_Materia { get; set; }

        [Required(ErrorMessage = "O nome da matéria é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome da matéria deve ter no máximo 50 caracteres.")]
        public string Nome_Materia { get; set; }

        [Required(ErrorMessage = "O nome do professor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do professor deve ter no máximo 100 caracteres.")]
        public string Professor { get; set; }

        public virtual ICollection<TurmaMateriaModel> TurmasMaterias { get; set; }
    }
}
