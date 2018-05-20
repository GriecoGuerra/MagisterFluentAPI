using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class Professores
    {
        public int IdProfessor { get; set; }
        public int MatriculaProfessor { get; set; }
        public string NomeProfessor { get; set; }
        public virtual IList<Cursos> ListaCursos { get; set; }
        public virtual IList<Turmas> ListaTurmas { get; set; }
    }
}