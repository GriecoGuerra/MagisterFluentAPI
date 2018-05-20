using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class Matriculas
    {
        public int Ano { get; set; }
        public int Semestre { get; set; }
        public virtual PeriodosLetivos PeriodosLetivos { get; set; }
        public int MatriculaAluno { get; set; }
        public virtual Alunos Alunos { get; set; }
        public int CodigoDisciplina { get; set; }
        public virtual Disciplinas Disciplinas { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public int Faltas1 { get; set; }
        public int Faltas2 { get; set; }
        public int Faltas3 { get; set; }
    }
}