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
    public class PeriodosLetivosController : Controller
    {
        private FluentAPIContext db = new FluentAPIContext();

        // GET: PeriodosLetivos
        public ActionResult Index()
        {
            return View(db.PeriodosLetivos.ToList());
        }

        // GET: PeriodosLetivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodosLetivos periodosLetivos = db.PeriodosLetivos.Find(id);
            if (periodosLetivos == null)
            {
                return HttpNotFound();
            }
            return View(periodosLetivos);
        }

        // GET: PeriodosLetivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeriodosLetivos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ano,Semestre,DataInicio,DataFim")] PeriodosLetivos periodosLetivos)
        {
            if (ModelState.IsValid)
            {
                db.PeriodosLetivos.Add(periodosLetivos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periodosLetivos);
        }

        // GET: PeriodosLetivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodosLetivos periodosLetivos = db.PeriodosLetivos.Find(id);
            if (periodosLetivos == null)
            {
                return HttpNotFound();
            }
            return View(periodosLetivos);
        }

        // POST: PeriodosLetivos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ano,Semestre,DataInicio,DataFim")] PeriodosLetivos periodosLetivos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodosLetivos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodosLetivos);
        }

        // GET: PeriodosLetivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodosLetivos periodosLetivos = db.PeriodosLetivos.Find(id);
            if (periodosLetivos == null)
            {
                return HttpNotFound();
            }
            return View(periodosLetivos);
        }

        // POST: PeriodosLetivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeriodosLetivos periodosLetivos = db.PeriodosLetivos.Find(id);
            db.PeriodosLetivos.Remove(periodosLetivos);
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
