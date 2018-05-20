using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class HistoricosMapa : EntityTypeConfiguration<Historicos>
    {
        public HistoricosMapa()
        {
            ToTable("Historicos");
            HasKey(h => new { h.Ano, h.Semestre, h.MatriculaAluno, h.CodigoDisciplina }).
            Property(h => h.Faltas).IsRequired().HasColumnType("int");
            Property(h => h.Media).IsRequired().HasColumnType("decimal");
            Property(h => h.Situacao).IsRequired().HasColumnType("varchar").HasMaxLength(2).HasParameterName("Situacao");
            HasRequired(h => h.PeriodosLetivos).WithMany(p => p.ListaHistoricos).HasForeignKey(h => new { h.Ano, h.Semestre });
            HasRequired(h => h.Disciplinas).WithMany(d => d.ListaHistoricos).HasForeignKey(h => h.CodigoDisciplina);
            HasRequired(m => m.Alunos).WithMany(a => a.ListaHistoricos).HasForeignKey(m => m.MatriculaAluno);
        }
    }
}