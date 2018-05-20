using System.Data.Entity;
using MagisterFluentAPI.Mapas;

namespace MagisterFluentAPI.DAO
{
    public class FluentAPIContext : DbContext
    {
        public FluentAPIContext() : base("name=FluentAPIContext") { }

        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.Alunos> Alunos { get; set; }
        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.Cursos> Cursos { get; set; }
        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.Disciplinas> Disciplinas { get; set; }
        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.Historicos> Historicos { get; set; }
        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.Matriculas> Matriculas { get; set; }
        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.Matrizes> Matrizes { get; set; }
        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.PeriodosLetivos> PeriodosLetivos { get; set; }
        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.Professores> Professores { get; set; }
        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.Turmas> Turmas { get; set; }
        public System.Data.Entity.DbSet<MagisterFluentAPI.Models.AutoDisciplina> AutoDisciplina { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunosMapa());
            modelBuilder.Configurations.Add(new CursosMapa());
            modelBuilder.Configurations.Add(new DisciplinasMapa());
            modelBuilder.Configurations.Add(new HistoricosMapa());
            modelBuilder.Configurations.Add(new MatriculasMapa());
            modelBuilder.Configurations.Add(new MatrizesMapa());
            modelBuilder.Configurations.Add(new PeriodosLetivosMapa());
            modelBuilder.Configurations.Add(new ProfessoresMapa());
            modelBuilder.Configurations.Add(new TurmasMapa());
            modelBuilder.Configurations.Add(new AutoDisciplinaMapa());

            base.OnModelCreating(modelBuilder);
        }
    }
}