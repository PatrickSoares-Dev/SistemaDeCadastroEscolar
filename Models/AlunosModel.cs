namespace Sistema_Escolar.Models
{
    public class AlunosModel
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }
        public int CPF { get; set; }
        public int DataNascimento { get; set; }
        public string Escola { get; set; }
        public string Turma { get; set; }

    }
}
