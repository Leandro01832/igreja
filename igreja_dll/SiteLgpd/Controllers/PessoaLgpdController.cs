using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using business.classes.Abstrato;
using repositorioEFLgpd;

namespace SiteLgpd.Controllers
{
    public class PessoaLgpdController : Controller
    {
        private DBLgpd db = new DBLgpd();

        // GET: PessoaLgpd
        public ActionResult Index()
        {
            var pessoaLgpd = db.PessoaLgpd.Include(p => p.Celula);
            return View(pessoaLgpd.ToList());
        }

        // GET: PessoaLgpd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaLgpd pessoaLgpd = db.PessoaLgpd.Find(id);
            if (pessoaLgpd == null)
            {
                return HttpNotFound();
            }
            return View(pessoaLgpd);
        }

        // GET: PessoaLgpd/Create
        public ActionResult Create()
        {
            ViewBag.celula_ = new SelectList(db.celula, "Id", "Nome");
            return View();
        }

        // POST: PessoaLgpd/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Falta,celula_,Img,Insert_padrao,Update_padrao,Delete_padrao,Select_padrao")] PessoaLgpd pessoaLgpd)
        {
            if (ModelState.IsValid)
            {
                db.PessoaLgpd.Add(pessoaLgpd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.celula_ = new SelectList(db.celula, "Id", "Nome", pessoaLgpd.celula_);
            return View(pessoaLgpd);
        }

        // GET: PessoaLgpd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaLgpd pessoaLgpd = db.PessoaLgpd.Find(id);
            if (pessoaLgpd == null)
            {
                return HttpNotFound();
            }
            ViewBag.celula_ = new SelectList(db.celula, "Id", "Nome", pessoaLgpd.celula_);
            return View(pessoaLgpd);
        }

        // POST: PessoaLgpd/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Falta,celula_,Img,Insert_padrao,Update_padrao,Delete_padrao,Select_padrao")] PessoaLgpd pessoaLgpd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaLgpd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.celula_ = new SelectList(db.celula, "Id", "Nome", pessoaLgpd.celula_);
            return View(pessoaLgpd);
        }

        // GET: PessoaLgpd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaLgpd pessoaLgpd = db.PessoaLgpd.Find(id);
            if (pessoaLgpd == null)
            {
                return HttpNotFound();
            }
            return View(pessoaLgpd);
        }

        // POST: PessoaLgpd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PessoaLgpd pessoaLgpd = db.PessoaLgpd.Find(id);
            db.PessoaLgpd.Remove(pessoaLgpd);
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
