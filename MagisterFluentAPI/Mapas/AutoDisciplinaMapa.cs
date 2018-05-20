using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MagisterFluentAPI.Models;

namespace MagisterFluentAPI.Mapas
{
    public class AutoDisciplinaMapa : EntityTypeConfiguration<AutoDisciplina>
    {
        public AutoDisciplinaMapa()
        {
            ToTable("AutoDisciplina");
            HasKey(ad => new { ad.CodigoDisciplinaPai, ad.CodigoDisciplinaFilho }).
            HasRequired(ad => ad.DisciplinaPai).WithMany(d => d.ListaPai).HasForeignKey(ad => ad.CodigoDisciplinaPai).WillCascadeOnDelete(false);
            HasRequired(ad => ad.DisciplinaFilho).WithMany(d => d.ListaFilho).HasForeignKey(ad => ad.CodigoDisciplinaFilho).WillCascadeOnDelete(false);
        }
    }
}