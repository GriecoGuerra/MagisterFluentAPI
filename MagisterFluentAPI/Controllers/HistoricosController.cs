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
    public class HistoricosController : Controller
    {
        private FluentAPIContext db = new FluentAPIContext();

        // GET: Historicos
        public ActionResult Index()
        {
            var historicos = db.Historicos.Include(h => h.Alunos).Include(h => h.Disciplinas).Include(h => h.PeriodosLetivos);
            return View(historicos.ToList());
        }

        // GET: Historicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historicos historicos = db.Historicos.Find(id);
            if (historicos == null)
            {
                return HttpNotFound();
            }
            return View(historicos);
        }

        // GET: Historicos/Create
        public ActionResult Create()
        {
            ViewBag.MatriculaAluno = new SelectList(db.Alunos, "MatriculaAluno", "NomeAluno");
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina");
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano");
            return View();
        }

        // POST: Historicos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ano,Semestre,MatriculaAluno,CodigoDisciplina,Situacao,Media,Faltas")] Historicos historicos)
        {
            if (ModelState.IsValid)
            {
                db.Historicos.Add(historicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatriculaAluno = new SelectList(db.Alunos, "MatriculaAluno", "NomeAluno", historicos.MatriculaAluno);
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", historicos.CodigoDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano", historicos.Ano);
            return View(historicos);
        }

        // GET: Historicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historicos historicos = db.Historicos.Find(id);
            if (historicos == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatriculaAluno = new SelectList(db.Alunos, "MatriculaAluno", "NomeAluno", historicos.MatriculaAluno);
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", historicos.CodigoDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano", historicos.Ano);
            return View(historicos);
        }

        // POST: Historicos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ano,Semestre,MatriculaAluno,CodigoDisciplina,Situacao,Media,Faltas")] Historicos historicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatriculaAluno = new SelectList(db.Alunos, "MatriculaAluno", "NomeAluno", historicos.MatriculaAluno);
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", historicos.CodigoDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano", historicos.Ano);
            return View(historicos);
        }

        // GET: Historicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historicos historicos = db.Historicos.Find(id);
            if (historicos == null)
            {
                return HttpNotFound();
            }
            return View(historicos);
        }

        // POST: Historicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historicos historicos = db.Historicos.Find(id);
            db.Historicos.Remove(historicos);
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
