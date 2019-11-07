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
    public class Cargo_Lider_MinisterioController : Controller
    {
        private DB db = new DB();

        // GET: Cargo_Lider_Ministerio
        public ActionResult Index()
        {
            var cargo_Lider_Ministerio = db.Cargo_Lider_Ministerio.Include(c => c.Ministerio).Include(c => c.Pessoa);
            return View(cargo_Lider_Ministerio.ToList());
        }

        // GET: Cargo_Lider_Ministerio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Lider_Ministerio cargo_Lider_Ministerio = db.Cargo_Lider_Ministerio.Find(id);
            if (cargo_Lider_Ministerio == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Lider_Ministerio);
        }

        // GET: Cargo_Lider_Ministerio/Create
        public ActionResult Create()
        {
            ViewBag.Id_Lider_Ministerio = new SelectList(db.ministerio, "ministerioid", "Nome");
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome");
            return View();
        }

        // POST: Cargo_Lider_Ministerio/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Lider_Ministerio,pessoa_")] Cargo_Lider_Ministerio cargo_Lider_Ministerio)
        {
            if (ModelState.IsValid)
            {
                db.Cargo_Lider_Ministerio.Add(cargo_Lider_Ministerio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Lider_Ministerio = new SelectList(db.ministerio, "ministerioid", "Nome", cargo_Lider_Ministerio.Id_Lider_Ministerio);
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Lider_Ministerio.pessoa_);
            return View(cargo_Lider_Ministerio);
        }

        // GET: Cargo_Lider_Ministerio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Lider_Ministerio cargo_Lider_Ministerio = db.Cargo_Lider_Ministerio.Find(id);
            if (cargo_Lider_Ministerio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Lider_Ministerio = new SelectList(db.ministerio, "ministerioid", "Nome", cargo_Lider_Ministerio.Id_Lider_Ministerio);
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Lider_Ministerio.pessoa_);
            return View(cargo_Lider_Ministerio);
        }

        // POST: Cargo_Lider_Ministerio/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Lider_Ministerio,pessoa_")] Cargo_Lider_Ministerio cargo_Lider_Ministerio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo_Lider_Ministerio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Lider_Ministerio = new SelectList(db.ministerio, "ministerioid", "Nome", cargo_Lider_Ministerio.Id_Lider_Ministerio);
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Lider_Ministerio.pessoa_);
            return View(cargo_Lider_Ministerio);
        }

        // GET: Cargo_Lider_Ministerio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Lider_Ministerio cargo_Lider_Ministerio = db.Cargo_Lider_Ministerio.Find(id);
            if (cargo_Lider_Ministerio == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Lider_Ministerio);
        }

        // POST: Cargo_Lider_Ministerio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo_Lider_Ministerio cargo_Lider_Ministerio = db.Cargo_Lider_Ministerio.Find(id);
            db.Cargo_Lider_Ministerio.Remove(cargo_Lider_Ministerio);
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
