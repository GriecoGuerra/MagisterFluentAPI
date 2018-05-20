using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class PeriodosLetivosMapa : EntityTypeConfiguration<PeriodosLetivos>
    {
        public PeriodosLetivosMapa()
        {
            ToTable("PeriodosLetivos");
            HasKey(p => new { p.Ano, p.Semestre }).
            Property(p => p.DataInicio).IsRequired().HasColumnName("DataInicio");
            Property(p => p.DataFim).IsRequired().HasColumnName("DataFim");
        }
    }
}