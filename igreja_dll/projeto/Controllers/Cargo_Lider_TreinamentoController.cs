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
    public class Cargo_Lider_TreinamentoController : Controller
    {
        private DB db = new DB();

        // GET: Cargo_Lider_Treinamento
        public ActionResult Index()
        {
            var lider_treinamento = db.lider_treinamento.Include(c => c.Celula).Include(c => c.Pessoa);
            return View(lider_treinamento.ToList());
        }

        // GET: Cargo_Lider_Treinamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Lider_Treinamento cargo_Lider_Treinamento = db.lider_treinamento.Find(id);
            if (cargo_Lider_Treinamento == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Lider_Treinamento);
        }

        // GET: Cargo_Lider_Treinamento/Create
        public ActionResult Create()
        {
            ViewBag.Lidertreinamentoid = new SelectList(db.celula, "Celulaid", "Nome");
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome");
            return View();
        }

        // POST: Cargo_Lider_Treinamento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lidertreinamentoid,pessoa_")] Cargo_Lider_Treinamento cargo_Lider_Treinamento)
        {
            if (ModelState.IsValid)
            {
                db.lider_treinamento.Add(cargo_Lider_Treinamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lidertreinamentoid = new SelectList(db.celula, "Celulaid", "Nome", cargo_Lider_Treinamento.Lidertreinamentoid);
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Lider_Treinamento.pessoa_);
            return View(cargo_Lider_Treinamento);
        }

        // GET: Cargo_Lider_Treinamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Lider_Treinamento cargo_Lider_Treinamento = db.lider_treinamento.Find(id);
            if (cargo_Lider_Treinamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lidertreinamentoid = new SelectList(db.celula, "Celulaid", "Nome", cargo_Lider_Treinamento.Lidertreinamentoid);
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Lider_Treinamento.pessoa_);
            return View(cargo_Lider_Treinamento);
        }

        // POST: Cargo_Lider_Treinamento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lidertreinamentoid,pessoa_")] Cargo_Lider_Treinamento cargo_Lider_Treinamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo_Lider_Treinamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lidertreinamentoid = new SelectList(db.celula, "Celulaid", "Nome", cargo_Lider_Treinamento.Lidertreinamentoid);
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Lider_Treinamento.pessoa_);
            return View(cargo_Lider_Treinamento);
        }

        // GET: Cargo_Lider_Treinamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Lider_Treinamento cargo_Lider_Treinamento = db.lider_treinamento.Find(id);
            if (cargo_Lider_Treinamento == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Lider_Treinamento);
        }

        // POST: Cargo_Lider_Treinamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo_Lider_Treinamento cargo_Lider_Treinamento = db.lider_treinamento.Find(id);
            db.lider_treinamento.Remove(cargo_Lider_Treinamento);
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
