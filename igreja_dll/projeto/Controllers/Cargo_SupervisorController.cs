using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using business.classes;
using repositorioEF;

namespace projeto.Controllers
{
    public class Cargo_SupervisorController : Controller
    {
        private DB db = new DB();

        // GET: Cargo_Supervisor
        public ActionResult Index()
        {
            var supervisor = db.supervisor.Include(c => c.Pessoa);
            return View(supervisor.ToList());
        }

        // GET: Cargo_Supervisor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Supervisor cargo_Supervisor = db.supervisor.Find(id);
            if (cargo_Supervisor == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Supervisor);
        }

        // GET: Cargo_Supervisor/Create
        public ActionResult Create()
        {
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome");
            return View();
        }

        // POST: Cargo_Supervisor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Supervisorid,Maximo_celula,pessoa_")] Cargo_Supervisor cargo_Supervisor)
        {
            if (ModelState.IsValid)
            {
                db.supervisor.Add(cargo_Supervisor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Supervisor.pessoa_);
            return View(cargo_Supervisor);
        }

        // GET: Cargo_Supervisor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Supervisor cargo_Supervisor = db.supervisor.Find(id);
            if (cargo_Supervisor == null)
            {
                return HttpNotFound();
            }
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Supervisor.pessoa_);
            return View(cargo_Supervisor);
        }

        // POST: Cargo_Supervisor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Supervisorid,Maximo_celula,pessoa_")] Cargo_Supervisor cargo_Supervisor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo_Supervisor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Supervisor.pessoa_);
            return View(cargo_Supervisor);
        }

        // GET: Cargo_Supervisor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Supervisor cargo_Supervisor = db.supervisor.Find(id);
            if (cargo_Supervisor == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Supervisor);
        }

        // POST: Cargo_Supervisor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo_Supervisor cargo_Supervisor = db.supervisor.Find(id);
            db.supervisor.Remove(cargo_Supervisor);
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
