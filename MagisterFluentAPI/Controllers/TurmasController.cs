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
    public class TurmasController : Controller
    {
        private FluentAPIContext db = new FluentAPIContext();

        // GET: Turmas
        public ActionResult Index()
        {
            var turmas = db.Turmas.Include(t => t.Disciplinas).Include(t => t.PeriodosLetivos).Include(t => t.Professores);
            return View(turmas.ToList());
        }

        // GET: Turmas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turmas turmas = db.Turmas.Find(id);
            if (turmas == null)
            {
                return HttpNotFound();
            }
            return View(turmas);
        }

        // GET: Turmas/Create
        public ActionResult Create()
        {
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina");
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano");
            ViewBag.IdProfessor = new SelectList(db.Professores, "IdProfessor", "NomeProfessor");
            return View();
        }

        // POST: Turmas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ano,Semestre,CodigoDisciplina,SequenciaTurma,Vagas,IdProfessor")] Turmas turmas)
        {
            if (ModelState.IsValid)
            {
                db.Turmas.Add(turmas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", turmas.CodigoDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano", turmas.Ano);
            ViewBag.IdProfessor = new SelectList(db.Professores, "IdProfessor", "NomeProfessor", turmas.IdProfessor);
            return View(turmas);
        }

        // GET: Turmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turmas turmas = db.Turmas.Find(id);
            if (turmas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", turmas.CodigoDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano", turmas.Ano);
            ViewBag.IdProfessor = new SelectList(db.Professores, "IdProfessor", "NomeProfessor", turmas.IdProfessor);
            return View(turmas);
        }

        // POST: Turmas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ano,Semestre,CodigoDisciplina,SequenciaTurma,Vagas,IdProfessor")] Turmas turmas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turmas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", turmas.CodigoDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodosLetivos, "Ano", "Ano", turmas.Ano);
            ViewBag.IdProfessor = new SelectList(db.Professores, "IdProfessor", "NomeProfessor", turmas.IdProfessor);
            return View(turmas);
        }

        // GET: Turmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turmas turmas = db.Turmas.Find(id);
            if (turmas == null)
            {
                return HttpNotFound();
            }
            return View(turmas);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turmas turmas = db.Turmas.Find(id);
            db.Turmas.Remove(turmas);
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
