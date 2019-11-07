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
    public class Endereco_CelulaController : Controller
    {
        private DB db = new DB();

        // GET: Endereco_Celula
        public ActionResult Index()
        {
            var endereco_celula = db.endereco_celula.Include(e => e.Celula);
            return View(endereco_celula.ToList());
        }

        // GET: Endereco_Celula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco_Celula endereco_Celula = db.endereco_celula.Find(id);
            if (endereco_Celula == null)
            {
                return HttpNotFound();
            }
            return View(endereco_Celula);
        }

        // GET: Endereco_Celula/Create
        public ActionResult Create()
        {
            ViewBag.enderecoid = new SelectList(db.celula, "Celulaid", "Nome");
            return View();
        }

        // POST: Endereco_Celula/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "enderecoid,Cel_bairro,Cel_rua,Cel_numero")] Endereco_Celula endereco_Celula)
        {
            if (ModelState.IsValid)
            {
                db.endereco_celula.Add(endereco_Celula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.enderecoid = new SelectList(db.celula, "Celulaid", "Nome", endereco_Celula.enderecoid);
            return View(endereco_Celula);
        }

        // GET: Endereco_Celula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco_Celula endereco_Celula = db.endereco_celula.Find(id);
            if (endereco_Celula == null)
            {
                return HttpNotFound();
            }
            ViewBag.enderecoid = new SelectList(db.celula, "Celulaid", "Nome", endereco_Celula.enderecoid);
            return View(endereco_Celula);
        }

        // POST: Endereco_Celula/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "enderecoid,Cel_bairro,Cel_rua,Cel_numero")] Endereco_Celula endereco_Celula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco_Celula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.enderecoid = new SelectList(db.celula, "Celulaid", "Nome", endereco_Celula.enderecoid);
            return View(endereco_Celula);
        }

        // GET: Endereco_Celula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco_Celula endereco_Celula = db.endereco_celula.Find(id);
            if (endereco_Celula == null)
            {
                return HttpNotFound();
            }
            return View(endereco_Celula);
        }

        // POST: Endereco_Celula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco_Celula endereco_Celula = db.endereco_celula.Find(id);
            db.endereco_celula.Remove(endereco_Celula);
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
