using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class AutoDisciplina
    {
        public int CodigoDisciplinaPai { get; set; }
        public virtual Disciplinas DisciplinaPai { get; set; }
        public int CodigoDisciplinaFilho { get; set; }
        public virtual Disciplinas DisciplinaFilho { get; set; }
    }
    public class ListaDisciplina
    {
        public int IdDisciplina { get; set; }
        public string Nome { get; set; }
    }
}