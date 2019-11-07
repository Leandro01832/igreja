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
    public class Cargo_LiderController : Controller
    {
        private DB db = new DB();

        // GET: Cargo_Lider
        public ActionResult Index()
        {
            var lider = db.lider.Include(c => c.Celula).Include(c => c.Pessoa);
            return View(lider.ToList());
        }

        // GET: Cargo_Lider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Lider cargo_Lider = db.lider.Find(id);
            if (cargo_Lider == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Lider);
        }

        // GET: Cargo_Lider/Create
        public ActionResult Create()
        {
            ViewBag.Liderid = new SelectList(db.celula, "Celulaid", "Nome");
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome");
            return View();
        }

        // POST: Cargo_Lider/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Liderid,pessoa_")] Cargo_Lider cargo_Lider)
        {
            if (ModelState.IsValid)
            {
                db.lider.Add(cargo_Lider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Liderid = new SelectList(db.celula, "Celulaid", "Nome", cargo_Lider.Liderid);
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Lider.pessoa_);
            return View(cargo_Lider);
        }

        // GET: Cargo_Lider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Lider cargo_Lider = db.lider.Find(id);
            if (cargo_Lider == null)
            {
                return HttpNotFound();
            }
            ViewBag.Liderid = new SelectList(db.celula, "Celulaid", "Nome", cargo_Lider.Liderid);
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Lider.pessoa_);
            return View(cargo_Lider);
        }

        // POST: Cargo_Lider/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Liderid,pessoa_")] Cargo_Lider cargo_Lider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo_Lider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Liderid = new SelectList(db.celula, "Celulaid", "Nome", cargo_Lider.Liderid);
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Lider.pessoa_);
            return View(cargo_Lider);
        }

        // GET: Cargo_Lider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Lider cargo_Lider = db.lider.Find(id);
            if (cargo_Lider == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Lider);
        }

        // POST: Cargo_Lider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo_Lider cargo_Lider = db.lider.Find(id);
            db.lider.Remove(cargo_Lider);
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
