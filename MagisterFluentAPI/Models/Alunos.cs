using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class Alunos
    {
        [Display(Name = "Matrícula")]
        public int MatriculaAluno { get; set; }
        [Display(Name = "Nome do Aluno")]
        public string NomeAluno { get; set; }
        public int TotalCredito { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Mgp { get; set; }
        public int CodigoCurso { get; set; }
        public virtual Cursos Cursos { get; set; }
        public virtual IList<Matriculas> ListaMatriculas { get; set; }
        public virtual IList<Historicos> ListaHistoricos { get; set; }
    }
}