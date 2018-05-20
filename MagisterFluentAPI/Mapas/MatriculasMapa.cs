using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class MatriculasMapa : EntityTypeConfiguration<Matriculas>
    {
        public MatriculasMapa()
        {
            ToTable("Matriculas");
            HasKey(m => new { m.Ano, m.Semestre, m.MatriculaAluno, m.CodigoDisciplina }).
            Property(h => h.Nota1).IsRequired().HasColumnType("decimal");
            Property(h => h.Nota2).IsRequired().HasColumnType("decimal");
            Property(h => h.Nota3).IsRequired().HasColumnType("decimal");
            Property(h => h.Faltas1).IsRequired().HasColumnType("int");
            Property(h => h.Faltas2).IsRequired().HasColumnType("int");
            Property(h => h.Faltas3).IsRequired().HasColumnType("int");
            HasRequired(m => m.PeriodosLetivos).WithMany(p => p.ListaMatriculas).HasForeignKey(m => new { m.Ano, m.Semestre });
            HasRequired(m => m.Disciplinas).WithMany(d => d.ListaMatriculas).HasForeignKey(m => m.CodigoDisciplina);
            HasRequired(m => m.Alunos).WithMany(a => a.ListaMatriculas).HasForeignKey(m => m.MatriculaAluno);
        }
    }
}