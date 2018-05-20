using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class Cursos
    {
        public int CodigoCurso { get; set; }
        public string NomeCurso { get; set; }
        public int TotalCredito { get; set; }
        public int IdProfessor { get; set; }
        public virtual Professores Professores { get; set; }
        public virtual IList<Alunos> ListaAlunos { get; set; }
        public virtual IList<Matrizes> ListaMatrizes { get; set; }
    }
}