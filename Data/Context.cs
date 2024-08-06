using Microsoft.EntityFrameworkCore;
using TesteEscolaMVC.Models;

namespace TesteEscolaMVC.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<NotaModel> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoModel>()
                .HasMany(a => a.Cursos)
                .WithMany(c => c.Alunos)
                .UsingEntity<Dictionary<string, object>>(
                    "AlunoCurso",
                    j => j.HasOne<CursoModel>().WithMany().HasForeignKey("CursoId"),
                    j => j.HasOne<AlunoModel>().WithMany().HasForeignKey("AlunoId"));

            modelBuilder.Entity<NotaModel>()
                .HasOne(n => n.Aluno)
                .WithMany(a => a.Notas)
                .HasForeignKey(n => n.AlunoId);

            modelBuilder.Entity<NotaModel>()
                .HasOne(n => n.Curso)
                .WithMany(c => c.Notas)
                .HasForeignKey(n => n.CursoId);
        }
    }
}