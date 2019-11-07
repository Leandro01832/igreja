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
    public class Membro_AclamacaoController : Controller
    {
        private DB db = new DB();
        
        public ActionResult Index()
        {
            var pessoas = db.membro_aclamacao.Include(m => m.Celula).Include(m => m.Chamada).Include(m => m.Endereco).Include(m => m.Telefone);
            return View(pessoas.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro_Aclamacao membro_Aclamacao = db.membro_aclamacao.Find(id);
            if (membro_Aclamacao == null)
            {
                return HttpNotFound();
            }
            return View(membro_Aclamacao);
        }
                
        [Authorize]
        public ActionResult Create()
        {
            var email = User.Identity.GetUserName();
            ViewBag.email = email;
            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Nome,Data_nascimento,Rg,Cpf,Estado_civil,Sexo_masculino,Sexo_feminino,Falescimento,Status,Email,Falta,celula_,Img,imgtipo,classe,Data_batismo,Desligamento,Motivo_desligamento,Denominacao,Endereco,Telefone")] Membro_Aclamacao membro_Aclamacao)
        {
            if (ModelState.IsValid)
            {
                db.pessoas.Add(membro_Aclamacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome", membro_Aclamacao.celula_);
            return View(membro_Aclamacao);
        }

        // GET: Membro_Aclamacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro_Aclamacao membro_Aclamacao = db.membro_aclamacao.Find(id);
            if (membro_Aclamacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome", membro_Aclamacao.celula_);
            return View(membro_Aclamacao);
        }

        // POST: Membro_Aclamacao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Data_nascimento,Rg,Cpf,Estado_civil,Sexo_masculino,Sexo_feminino,Falescimento,Status,Email,Falta,celula_,Img,imgtipo,classe,Data_batismo,Desligamento,Motivo_desligamento,Denominacao,Endereco,Telefone")] Membro_Aclamacao membro_Aclamacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membro_Aclamacao.Endereco).State = EntityState.Modified;
                db.Entry(membro_Aclamacao.Telefone).State = EntityState.Modified;
                db.Entry(membro_Aclamacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome", membro_Aclamacao.celula_);
            return View(membro_Aclamacao);
        }

        // GET: Membro_Aclamacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro_Aclamacao membro_Aclamacao = db.membro_aclamacao.Find(id);
            if (membro_Aclamacao == null)
            {
                return HttpNotFound();
            }
            return View(membro_Aclamacao);
        }

        // POST: Membro_Aclamacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membro_Aclamacao membro_Aclamacao = db.membro_aclamacao.Find(id);
            db.pessoas.Remove(membro_Aclamacao);
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
