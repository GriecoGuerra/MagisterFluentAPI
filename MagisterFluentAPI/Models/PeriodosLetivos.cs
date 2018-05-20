using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class PeriodosLetivos
    {
        public int Ano { get; set; }
        public int Semestre { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public virtual IList<Historicos> ListaHistoricos { get; set; }
        public virtual IList<Matriculas> ListaMatriculas { get; set; }
        public virtual IList<Turmas> ListaTurmas { get; set; }
    }
}