using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class Historicos
    {
        public int Ano { get; set; }
        public int Semestre { get; set; }
        public virtual PeriodosLetivos PeriodosLetivos { get; set; }
        public int MatriculaAluno { get; set; }
        public virtual Alunos Alunos { get; set; }
        public int CodigoDisciplina { get; set; }
        public virtual Disciplinas Disciplinas { get; set; }
        public string Situacao { get; set; }
        public decimal Media { get; set; }
        public int Faltas { get; set; }
    }
}