using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class Turmas
    {
        public int Ano { get; set; }
        public int Semestre { get; set; }
        public virtual PeriodosLetivos PeriodosLetivos { get; set; }
        public int CodigoDisciplina { get; set; }
        public virtual Disciplinas Disciplinas { get; set; }
        public string SequenciaTurma { get; set; }
        public int Vagas { get; set; }
        public int IdProfessor { get; set; }
        public virtual Professores Professores { get; set; }
    }
    public class ListaProfessor
    {
        public int Ano { get; set; }
        public int Semestre { get; set; }
        public int CodigoCurso { get; set; }
        public string NomeCurso { get; set; }
        public int IdProfessor { get; set; }
        public string NomeProfessor { get; set; }
        public int TotalCredito { get; set; }
    }
}