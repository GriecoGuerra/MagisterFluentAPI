using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagisterFluentAPI.Models;
using MagisterFluentAPI.DAO;

namespace MagisterFluentAPI.Controllers
{
    public class MatriculasController : Controller
    {
        private FluentAPIContext db = new FluentAPIContext();

        // GET: Matriculas
        public ActionResult Index()
        {
            var matriculas = db.Matriculas.Include(m => m.Alunos).Include(m => m.Disciplinas).Include(m => m.PeriodosLetivos);
            return View(matriculas.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.MatriculaAluno = new SelectList(db.Alunos, "MatriculaAluno", "NomeAluno");
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina");
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano");
            return View();
        }

        // POST: Matriculas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ano,Semestre,MatriculaAluno,CodigoDisciplina,Nota1,Nota2,Nota3,Faltas1,Faltas2,Faltas3")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matriculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatriculaAluno = new SelectList(db.Alunos, "MatriculaAluno", "NomeAluno", matriculas.MatriculaAluno);
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", matriculas.CodigoDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano", matriculas.Ano);
            return View(matriculas);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatriculaAluno = new SelectList(db.Alunos, "MatriculaAluno", "NomeAluno", matriculas.MatriculaAluno);
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", matriculas.CodigoDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano", matriculas.Ano);
            return View(matriculas);
        }

        // POST: Matriculas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ano,Semestre,MatriculaAluno,CodigoDisciplina,Nota1,Nota2,Nota3,Faltas1,Faltas2,Faltas3")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matriculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatriculaAluno = new SelectList(db.Alunos, "MatriculaAluno", "NomeAluno", matriculas.MatriculaAluno);
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", matriculas.CodigoDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano", matriculas.Ano);
            return View(matriculas);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matriculas matriculas = db.Matriculas.Find(id);
            db.Matriculas.Remove(matriculas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
