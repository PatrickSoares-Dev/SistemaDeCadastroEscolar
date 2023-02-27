using Microsoft.EntityFrameworkCore;
using Sistema_Escolar.Models;


namespace Sistema_Escolar.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<EscolaModel> Escolas { get; set; }
        public DbSet<TurmasModel> Turmas { get; set; }
        public DbSet<AlunosModel> Alunos { get; set; }
        public DbSet<MateriasModel> Materias { get; set; }
        public DbSet<TurmaMateriaModel> TurmaMateria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TurmaMateriaModel>()
                .HasKey(tm => new { tm.ID_Turma, tm.ID_Materia });
        }

    }


}
