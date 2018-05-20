using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterFluentAPI.Models
{
    public class Disciplinas
    {
        public int CodigoDisciplina { get; set; }
        public string NomeDisciplina { get; set; }
        public int Creditos { get; set; }
        public string TipoDisciplina { get; set; }
        public int CargaHoraria { get; set; }
        public int LimiteFaltas { get; set; }
        public virtual IList<Historicos> ListaHistoricos { get; set; }
        public virtual IList<Matriculas> ListaMatriculas { get; set; }
        public virtual IList<Matrizes> ListaMatrizes { get; set; }
        public virtual IList<Turmas> ListaTurmas { get; set; }
        public virtual ICollection<AutoDisciplina> ListaPai { get; set; }
        public virtual ICollection<AutoDisciplina> ListaFilho { get; set; }
    }
}