using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class AlunosMapa : EntityTypeConfiguration<Alunos>
    {
        public AlunosMapa()
        {
            ToTable("Alunos");
            HasKey(a => a.MatriculaAluno).
            Property(a => a.NomeAluno).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            Property(a => a.DataNascimento).IsRequired().HasColumnType("datetime").HasColumnName("DataNascimento");
            Property(a => a.CodigoCurso).IsRequired().HasColumnName("CodigoCurso");
            Property(a => a.Mgp).HasParameterName("MGP");
            HasRequired(a => a.Cursos).WithMany(c => c.ListaAlunos).HasForeignKey(a => a.CodigoCurso);
        }
    }
}