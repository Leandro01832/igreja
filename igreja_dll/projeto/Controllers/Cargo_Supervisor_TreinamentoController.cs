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
    public class Cargo_Supervisor_TreinamentoController : Controller
    {
        private DB db = new DB();

        // GET: Cargo_Supervisor_Treinamento
        public ActionResult Index()
        {
            var supervisor_treinamento = db.supervisor_treinamento.Include(c => c.Pessoa);
            return View(supervisor_treinamento.ToList());
        }

        // GET: Cargo_Supervisor_Treinamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Supervisor_Treinamento cargo_Supervisor_Treinamento = db.supervisor_treinamento.Find(id);
            if (cargo_Supervisor_Treinamento == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Supervisor_Treinamento);
        }

        // GET: Cargo_Supervisor_Treinamento/Create
        public ActionResult Create()
        {
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome");
            return View();
        }

        // POST: Cargo_Supervisor_Treinamento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Supervisortreinamentoid,Maximo_celula,pessoa_")] Cargo_Supervisor_Treinamento cargo_Supervisor_Treinamento)
        {
            if (ModelState.IsValid)
            {
                db.supervisor_treinamento.Add(cargo_Supervisor_Treinamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Supervisor_Treinamento.pessoa_);
            return View(cargo_Supervisor_Treinamento);
        }

        // GET: Cargo_Supervisor_Treinamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Supervisor_Treinamento cargo_Supervisor_Treinamento = db.supervisor_treinamento.Find(id);
            if (cargo_Supervisor_Treinamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Supervisor_Treinamento.pessoa_);
            return View(cargo_Supervisor_Treinamento);
        }

        // POST: Cargo_Supervisor_Treinamento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Supervisortreinamentoid,Maximo_celula,pessoa_")] Cargo_Supervisor_Treinamento cargo_Supervisor_Treinamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo_Supervisor_Treinamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pessoa_ = new SelectList(db.pessoas, "Id", "Nome", cargo_Supervisor_Treinamento.pessoa_);
            return View(cargo_Supervisor_Treinamento);
        }

        // GET: Cargo_Supervisor_Treinamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Supervisor_Treinamento cargo_Supervisor_Treinamento = db.supervisor_treinamento.Find(id);
            if (cargo_Supervisor_Treinamento == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Supervisor_Treinamento);
        }

        // POST: Cargo_Supervisor_Treinamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo_Supervisor_Treinamento cargo_Supervisor_Treinamento = db.supervisor_treinamento.Find(id);
            db.supervisor_treinamento.Remove(cargo_Supervisor_Treinamento);
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
