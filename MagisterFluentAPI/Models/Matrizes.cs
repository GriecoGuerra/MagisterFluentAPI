using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class Matrizes
    {
        public int CodigoCurso { get; set; }
        public virtual Cursos Cursos { get; set; }
        public int Periodo { get; set; }
        public int CodigoDisciplina { get; set; }
        public virtual Disciplinas Disciplinas { get; set; }
    }
}