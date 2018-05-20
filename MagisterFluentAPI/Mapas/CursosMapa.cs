using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class CursosMapa : EntityTypeConfiguration<Cursos>
    {
        public CursosMapa()
        {
            ToTable("Cursos");
            HasKey(c => c.CodigoCurso).
            Property(c => c.CodigoCurso).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.NomeCurso).IsRequired().HasColumnType("varchar").HasMaxLength(40);
            Property(c => c.TotalCredito).IsRequired().HasColumnName("TotalCredito");
            HasRequired(c => c.Professores).WithMany(p => p.ListaCursos).HasForeignKey(c => c.IdProfessor);
        }
    }
}