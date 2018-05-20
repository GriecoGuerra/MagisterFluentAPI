using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class ProfessoresMapa : EntityTypeConfiguration<Professores>
    {
        public ProfessoresMapa()
        {
            ToTable("Professor");
            HasKey(p => p.IdProfessor).
            Property(p => p.MatriculaProfessor).IsRequired().HasColumnType("int");
            Property(p => p.NomeProfessor).IsRequired().HasColumnName("NomeProfessor").HasMaxLength(50);
        }
    }
}