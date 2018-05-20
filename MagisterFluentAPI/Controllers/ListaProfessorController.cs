using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MagisterFluentAPI.Models;
using MagisterFluentAPI.DAO;

namespace MagisterFluentAPI.Controllers
{
    [RoutePrefix("listaprofessor")]
    public class ListaProfessorController : Controller
    {
        private FluentAPIContext db = new FluentAPIContext();

        // GET: ListaProfessor
        [Route("consulta")]
        public ActionResult Index(string codigoCurso, string Ano, string Semestre, string Filtrar)
        {
            if (String.IsNullOrEmpty(codigoCurso))
            {
                codigoCurso = "0";
            }
            if (String.IsNullOrEmpty(Ano))
            {
                Ano = "0";
            }
            if (String.IsNullOrEmpty(Semestre))
            {
                Semestre = "0";
            }

            int CodigoCurso = int.Parse(codigoCurso);
            int ano = int.Parse(Ano);
            int semestre = int.Parse(Semestre);

            var result = from t in db.Turmas
                         join m in db.Matrizes on t.CodigoDisciplina equals m.CodigoDisciplina
                         join c in db.Cursos on m.CodigoCurso equals c.CodigoCurso
                         join p in db.Professores on t.IdProfessor equals p.IdProfessor
                         join d in db.Disciplinas on t.CodigoDisciplina equals d.CodigoDisciplina
                         where t.Ano == ano && t.Semestre == semestre && m.CodigoCurso == CodigoCurso
                         select new  { t.Ano, t.Semestre, c.NomeCurso, p.NomeProfessor, d.Creditos };

            var professor = new List<ListaProfessor>();

            if (Filtrar != null)
            {
                foreach (var t in result)
                {
                    ListaProfessor lista = new ListaProfessor();
                    lista.Ano = t.Ano;
                    lista.Semestre = t.Semestre;
                    lista.NomeCurso = t.NomeCurso;
                    lista.NomeProfessor=t.NomeProfessor;
                    lista.TotalCredito = t.Creditos;
                    professor.Add(lista);
                }
            }
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano");
            ViewBag.Semestre = new SelectList(db.PeriodosLetivos, "Semestre", "Semestre");
            ViewBag.CodigoCurso = new SelectList(db.Cursos, "CodigoCurso", "CodigoCurso");

            ViewBag.Lista = professor.ToList();
            return View();
        }
    }
}
