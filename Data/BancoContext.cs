using Microsoft.EntityFrameworkCore;
using Sistema_Escolar.Models;

namespace Sistema_Escolar.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<AlunosModel> Alunos { get; set; }

    }

}
