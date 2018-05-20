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
    public class MatrizesController : Controller
    {
        private FluentAPIContext db = new FluentAPIContext();

        // GET: Matrizes
        public ActionResult Index()
        {
            var matrizes = db.Matrizes.Include(m => m.Cursos).Include(m => m.Disciplinas);
            return View(matrizes.ToList());
        }

        // GET: Matrizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matrizes matrizes = db.Matrizes.Find(id);
            if (matrizes == null)
            {
                return HttpNotFound();
            }
            return View(matrizes);
        }

        // GET: Matrizes/Create
        public ActionResult Create()
        {
            ViewBag.CodigoCurso = new SelectList(db.Cursos, "CodigoCurso", "NomeCurso");
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina");
            return View();
        }

        // POST: Matrizes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoCurso,Periodo,CodigoDisciplina")] Matrizes matrizes)
        {
            if (ModelState.IsValid)
            {
                db.Matrizes.Add(matrizes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoCurso = new SelectList(db.Cursos, "CodigoCurso", "NomeCurso", matrizes.CodigoCurso);
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", matrizes.CodigoDisciplina);
            return View(matrizes);
        }

        // GET: Matrizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matrizes matrizes = db.Matrizes.Find(id);
            if (matrizes == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoCurso = new SelectList(db.Cursos, "CodigoCurso", "NomeCurso", matrizes.CodigoCurso);
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", matrizes.CodigoDisciplina);
            return View(matrizes);
        }

        // POST: Matrizes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoCurso,Periodo,CodigoDisciplina")] Matrizes matrizes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matrizes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoCurso = new SelectList(db.Cursos, "CodigoCurso", "NomeCurso", matrizes.CodigoCurso);
            ViewBag.CodigoDisciplina = new SelectList(db.Disciplinas, "CodigoDisciplina", "NomeDisciplina", matrizes.CodigoDisciplina);
            return View(matrizes);
        }

        // GET: Matrizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matrizes matrizes = db.Matrizes.Find(id);
            if (matrizes == null)
            {
                return HttpNotFound();
            }
            return View(matrizes);
        }

        // POST: Matrizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matrizes matrizes = db.Matrizes.Find(id);
            db.Matrizes.Remove(matrizes);
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
