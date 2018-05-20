using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MagisterFluentAPI.Models;
using MagisterFluentAPI.DAO;

namespace MagisterFluentAPI.Controllers
{
    public class AlunosController : Controller
    {
        private FluentAPIContext db = new FluentAPIContext();

        // GET: Alunos
        public ActionResult Index()
        {
            var alunos = db.Alunos.Include(a => a.Cursos);
            return View(alunos.ToList());
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            ViewBag.CodigoCurso = new SelectList(db.Cursos, "CodigoCurso", "NomeCurso");
            return View();
        }

        // POST: Alunos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatriculaAluno,NomeAluno,TotalCredito,DataNascimento,Mgp,CodigoCurso")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(alunos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoCurso = new SelectList(db.Cursos, "CodigoCurso", "NomeCurso", alunos.CodigoCurso);
            return View(alunos);
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoCurso = new SelectList(db.Cursos, "CodigoCurso", "NomeCurso", alunos.CodigoCurso);
            return View(alunos);
        }

        // POST: Alunos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatriculaAluno,NomeAluno,TotalCredito,DataNascimento,Mgp,CodigoCurso")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoCurso = new SelectList(db.Cursos, "CodigoCurso", "NomeCurso", alunos.CodigoCurso);
            return View(alunos);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alunos alunos = db.Alunos.Find(id);
            db.Alunos.Remove(alunos);
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
