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
using Microsoft.AspNet.Identity;

namespace projeto.Controllers
{
    [Authorize(Roles ="Ministerio")]
    public class MinisterioController : Controller
    {
        private DB db = new DB();

        // GET: Ministerio
        [AllowAnonymous]
        public ActionResult Index()
        {
            var ministerio = db.ministerio;
            return View(ministerio.ToList());
        }

        // GET: Ministerio/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministerio ministerio = db.ministerio.Include(m => m.Pessoas).First(m => m.Ministerioid == id);
            ViewBag.pessoas = db.ministerio.Include(m => m.Pessoas).First(m => m.Ministerioid == id).Pessoas;
            if (ministerio == null)
            {
                return HttpNotFound();
            }
            return PartialView(ministerio);
        }

        // GET: Ministerio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ministerio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ministerioid,Nome,Proposito,Maximo_pessoa,Pessoas")] Ministerio ministerio)
        {
            if (ModelState.IsValid)
            {                
                db.ministerio.Add(ministerio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View(ministerio);
        }

        // GET: Ministerio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministerio ministerio = db.ministerio.Find(id);
            if (ministerio == null)
            {
                return HttpNotFound();
            }
          
            return View(ministerio);
        }

        // POST: Ministerio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ministerioid,Nome,Proposito,Maximo_pessoa")] Ministerio ministerio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministerio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lider_ministerio = new SelectList(db.pessoas, "Id", "Nome");
            return View(ministerio);
        }

        // GET: Ministerio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministerio ministerio = db.ministerio.Find(id);
            if (ministerio == null)
            {
                return HttpNotFound();
            }
            return View(ministerio);
        }

        // POST: Ministerio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ministerio ministerio = db.ministerio.Find(id);
            db.ministerio.Remove(ministerio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult participar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministerio ministerio = db.ministerio.Find(id);
            if (ministerio == null)
            {
                return HttpNotFound();
            }
         
            return View(ministerio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult participar([Bind(Include = "ministerioid,Nome,Proposito,Maximo_pessoa,Pessoas")] Ministerio mini)
        {
            var pessoas = db.ministerio.First(m => m.Ministerioid == mini.Ministerioid).Pessoas;

            if (pessoas != null)
            {               
                var email = User.Identity.GetUserName();
                var pessoa = db.pessoas.First(e => e.Email == email);
                pessoas.Add(pessoa);
                mini.Pessoas.AddRange(pessoas);
               
                db.SaveChanges();
            }
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
