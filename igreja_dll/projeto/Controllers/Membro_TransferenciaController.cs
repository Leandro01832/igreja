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
    public class Membro_TransferenciaController : Controller
    {
        private DB db = new DB();

        // GET: Membro_Transferencia
        public ActionResult Index()
        {
            var pessoas = db.membro_transferencia.Include(m => m.Celula).Include(m => m.Chamada).Include(m => m.Endereco).Include(m => m.Telefone);
            return View(pessoas.ToList());
        }

        // GET: Membro_Transferencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro_Transferencia membro_Transferencia = db.membro_transferencia.Find(id);
            if (membro_Transferencia == null)
            {
                return HttpNotFound();
            }
            return View(membro_Transferencia);
        }

        // GET: Membro_Transferencia/Create
        public ActionResult Create()
        {
            var email = User.Identity.GetUserName();
            ViewBag.email = email;
            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome");
            return View();
        }

        // POST: Membro_Transferencia/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Data_nascimento,Rg,Cpf,Estado_civil,Sexo_masculino,Sexo_feminino,Falescimento,Status,Email,Falta,celula_,Img,imgtipo,classe,Data_batismo,Desligamento,Motivo_desligamento,Nome_cidade_transferencia,Estado_transferencia,Nome_igreja_transferencia,Endereco,Telefone")] Membro_Transferencia membro_Transferencia)
        {
            if (ModelState.IsValid)
            {
                db.pessoas.Add(membro_Transferencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome", membro_Transferencia.celula_);
            
            return View(membro_Transferencia);
        }

        // GET: Membro_Transferencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro_Transferencia membro_Transferencia = db.membro_transferencia.Find(id);
            if (membro_Transferencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome", membro_Transferencia.celula_);
            
            return View(membro_Transferencia);
        }

        // POST: Membro_Transferencia/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Data_nascimento,Rg,Cpf,Estado_civil,Sexo_masculino,Sexo_feminino,Falescimento,Status,Email,Falta,celula_,Img,imgtipo,classe,Data_batismo,Desligamento,Motivo_desligamento,Nome_cidade_transferencia,Estado_transferencia,Nome_igreja_transferencia,Endereco,Telefone")] Membro_Transferencia membro_Transferencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membro_Transferencia.Endereco).State = EntityState.Modified;
                db.Entry(membro_Transferencia.Telefone).State = EntityState.Modified;
                db.Entry(membro_Transferencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.celula_ = new SelectList(db.celula, "Celulaid", "Nome", membro_Transferencia.celula_);
           
            return View(membro_Transferencia);
        }

        // GET: Membro_Transferencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro_Transferencia membro_Transferencia = db.membro_transferencia.Find(id);
            if (membro_Transferencia == null)
            {
                return HttpNotFound();
            }
            return View(membro_Transferencia);
        }

        // POST: Membro_Transferencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membro_Transferencia membro_Transferencia = db.membro_transferencia.Find(id);
            db.pessoas.Remove(membro_Transferencia);
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
