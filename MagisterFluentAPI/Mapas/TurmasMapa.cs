using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class TurmasMapa : EntityTypeConfiguration<Turmas>
    {
        public TurmasMapa()
        {
            ToTable("Turmas");
            HasKey(t => new { t.Ano, t.Semestre, t.CodigoDisciplina, t.SequenciaTurma }).
            Property(t => t.SequenciaTurma).IsRequired().HasColumnType("varchar");
            Property(t => t.Vagas).IsRequired();
            HasRequired(t => t.PeriodosLetivos).WithMany(p => p.ListaTurmas).HasForeignKey(t => new { t.Ano, t.Semestre });
            HasRequired(t => t.Disciplinas).WithMany(d => d.ListaTurmas).HasForeignKey(t => t.CodigoDisciplina);
            HasRequired(t => t.Professores).WithMany(d => d.ListaTurmas).HasForeignKey(t => t.IdProfessor);
        }
    }
}