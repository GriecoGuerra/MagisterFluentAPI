using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class DisciplinasMapa : EntityTypeConfiguration<Disciplinas>
    {
        public DisciplinasMapa()
        {
            ToTable("Disciplinas");
            HasKey(d => d.CodigoDisciplina).
            Property(d => d.CodigoDisciplina).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(d => d.NomeDisciplina).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            Property(d => d.Creditos).IsRequired().HasColumnType("int").HasColumnName("Credito");
            Property(d => d.TipoDisciplina).IsRequired().HasColumnType("varchar").HasMaxLength(1);
            Property(d => d.CargaHoraria).IsRequired().HasParameterName("CargaHoraria");
            Property(d => d.LimiteFaltas).IsRequired().HasParameterName("LimiteFaltas");
        }
    }
}