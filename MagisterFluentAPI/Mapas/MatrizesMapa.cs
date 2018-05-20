using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class MatrizesMapa : EntityTypeConfiguration<Matrizes>
    {
        public MatrizesMapa()
        {
            ToTable("Matrizes");
            HasKey(m => new { m.CodigoCurso, m.Periodo, m.CodigoDisciplina }).
            HasRequired(m => m.Disciplinas).WithMany(d => d.ListaMatrizes).HasForeignKey(m => m.CodigoDisciplina);
            HasRequired(m => m.Cursos).WithMany(a => a.ListaMatrizes).HasForeignKey(m => m.CodigoCurso);
        }
    }
}