using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using business.classes.Abstrato;
using repositorioEF;

namespace Site.Controllers
{
    public class PessoaController : Controller
    {
        private DB db = new DB();

        // GET: Pessoa
        public ActionResult Index()
        {
            var pessoas = db.pessoas.Include(p => p.Celula)
                .Include(p => p.Chamada)
                .Include(p => p.Endereco)
                .Include(p => p.Telefone);
            return View(pessoas.ToList());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            ViewBag.celula_ = new SelectList(db.celula, "Id", "Nome");
            ViewBag.Id = new SelectList(db.Chamadas, "Id", "Id");
            ViewBag.Id = new SelectList(db.endereco, "Id", "Pais");
            ViewBag.Id = new SelectList(db.telefone, "Id", "Fone");
            return View();
        }

        // POST: Pessoa/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Data_nascimento,Rg,Cpf,Estado_civil,Sexo_masculino,Sexo_feminino,Falescimento,Status,Email,Falta,celula_,Img")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.celula_ = new SelectList(db.celula, "Id", "Nome", pessoa.celula_);
            ViewBag.Id = new SelectList(db.Chamadas, "Id", "Id", pessoa.Id);
            ViewBag.Id = new SelectList(db.endereco, "Id", "Pais", pessoa.Id);
            ViewBag.Id = new SelectList(db.telefone, "Id", "Fone", pessoa.Id);
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.celula_ = new SelectList(db.celula, "Id", "Nome", pessoa.celula_);
            ViewBag.Id = new SelectList(db.Chamadas, "Id", "Id", pessoa.Id);
            ViewBag.Id = new SelectList(db.endereco, "Id", "Pais", pessoa.Id);
            ViewBag.Id = new SelectList(db.telefone, "Id", "Fone", pessoa.Id);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Data_nascimento,Rg,Cpf,Estado_civil,Sexo_masculino,Sexo_feminino,Falescimento,Status,Email,Falta,celula_,Img")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.celula_ = new SelectList(db.celula, "Id", "Nome", pessoa.celula_);
            ViewBag.Id = new SelectList(db.Chamadas, "Id", "Id", pessoa.Id);
            ViewBag.Id = new SelectList(db.endereco, "Id", "Pais", pessoa.Id);
            ViewBag.Id = new SelectList(db.telefone, "Id", "Fone", pessoa.Id);
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.pessoas.Find(id);
            db.pessoas.Remove(pessoa);
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
