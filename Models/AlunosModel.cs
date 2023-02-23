using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Escolar.Models
{
    public class AlunosModel
    {        
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public int CPF { get; set; }
        public string DataNascimento { get; set; }
        public string Escola { get; set; }
        public string Turma { get; set; }
        
    }
}
