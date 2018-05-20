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
    public class ProfessoresController : Controller
    {
        private FluentAPIContext db = new FluentAPIContext();

        // GET: Professores
        public ActionResult Index()
        {
            return View(db.Professores.ToList());
        }

        // GET: Professores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professores professores = db.Professores.Find(id);
            if (professores == null)
            {
                return HttpNotFound();
            }
            return View(professores);
        }

        // GET: Professores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProfessor,MatriculaProfessor,NomeProfessor")] Professores professores)
        {
            if (ModelState.IsValid)
            {
                db.Professores.Add(professores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professores);
        }

        // GET: Professores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professores professores = db.Professores.Find(id);
            if (professores == null)
            {
                return HttpNotFound();
            }
            return View(professores);
        }

        // POST: Professores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProfessor,MatriculaProfessor,NomeProfessor")] Professores professores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professores);
        }

        // GET: Professores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professores professores = db.Professores.Find(id);
            if (professores == null)
            {
                return HttpNotFound();
            }
            return View(professores);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professores professores = db.Professores.Find(id);
            db.Professores.Remove(professores);
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
