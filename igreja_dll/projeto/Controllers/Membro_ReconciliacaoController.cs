using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using business.classes;
using Microsoft.AspNet.Identity;
using repositorioEF;

namespace projeto.Controllers
{
    public class Membro_ReconciliacaoController : Controller
    {
        private DB db = new DB();

        // GET: Membro_Reconciliacao
        public ActionResult Index()
        {
            var pessoas = db.pessoas.Include(m => m.Celula).Include(m => m.Chamada).Include(m => m.Endereco).Include(m => m.Telefone);
            return View(pessoas.ToList());
        }

        // GET: Membro_Reconciliacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro_Reconciliacao membro_Reconciliacao = db.membro_reconciliacao.Find(id);
            if (membro_Reconciliacao == null)
            {
                return HttpNotFound();
            }
            return View(membro_Reconciliacao);
        }

        // GET: Membro_Reconciliacao/Create
        public ActionResult Create()
        {
            var email = User.Identity.GetUserName();
            ViewBag.email = email;
            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome");
            return View();
        }

        // POST: Membro_Reconciliacao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Data_nascimento,Rg,Cpf,Estado_civil,Sexo_masculino,Sexo_feminino,Falescimento,Status,Email,Falta,celula_,Img,imgtipo,classe,Data_batismo,Desligamento,Motivo_desligamento,Data_reconciliacao,Endereco,Telefone")] Membro_Reconciliacao membro_Reconciliacao)
        {
            if (ModelState.IsValid)
            {
                db.pessoas.Add(membro_Reconciliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome", membro_Reconciliacao.celula_);
            return View(membro_Reconciliacao);
        }

        // GET: Membro_Reconciliacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro_Reconciliacao membro_Reconciliacao = db.membro_reconciliacao.Find(id);
            if (membro_Reconciliacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome", membro_Reconciliacao.celula_);
            return View(membro_Reconciliacao);
        }

        // POST: Membro_Reconciliacao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Data_nascimento,Rg,Cpf,Estado_civil,Sexo_masculino,Sexo_feminino,Falescimento,Status,Email,Falta,celula_,Img,imgtipo,classe,Data_batismo,Desligamento,Motivo_desligamento,Data_reconciliacao,Endereco,Telefone")] Membro_Reconciliacao membro_Reconciliacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membro_Reconciliacao.Endereco).State = EntityState.Modified;
                db.Entry(membro_Reconciliacao.Telefone).State = EntityState.Modified;
                db.Entry(membro_Reconciliacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome", membro_Reconciliacao.celula_);
            return View(membro_Reconciliacao);
        }

        // GET: Membro_Reconciliacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro_Reconciliacao membro_Reconciliacao = db.membro_reconciliacao.Find(id);
            if (membro_Reconciliacao == null)
            {
                return HttpNotFound();
            }
            return View(membro_Reconciliacao);
        }

        // POST: Membro_Reconciliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membro_Reconciliacao membro_Reconciliacao = db.membro_reconciliacao.Find(id);
            db.pessoas.Remove(membro_Reconciliacao);
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
