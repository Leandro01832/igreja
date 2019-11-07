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
    public class CelulaController : Controller
    {
        private DB db = new DB();

        public JsonResult GetSupervisor(int Id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var sup = db.supervisor.Include(s => s.Pessoa).FirstOrDefault(b => b.Supervisorid == Id).Pessoa;
            if (sup != null)
            {
                return Json(sup.Nome);
            }
            return Json("");
        }

        public JsonResult GetSupervisorTreinamento(int Id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var sup = db.supervisor_treinamento.Include(s => s.Pessoa).FirstOrDefault(b => b.Supervisortreinamentoid == Id).Pessoa;

            if(sup != null)
            {
                return Json(sup.Nome);
            }

            return Json("");
        }

        // GET: Celula
        public ActionResult Index()
        {
            var celula = db.celula.Include(c => c.Endereco_Celula).Include(c => c.Lider).Include(c => c.Lider_treinamento).Include(c => c.Supervisor).Include(c => c.Supervisor_treianamento);
            return View(celula.ToList());
        }

        // GET: Celula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celula celula = db.celula.Find(id);
            if (celula == null)
            {
                return HttpNotFound();
            }
            return View(celula);
        }

        // GET: Celula/Create
        public ActionResult Create()
        {
            ViewBag.pessoa_lider = new SelectList(db.pessoas, "Id", "Nome");
            ViewBag.pessoa_lider_treinamento = new SelectList(db.pessoas, "Id", "Nome");
            ViewBag.Supervisor_ = new SelectList(db.supervisor, "Supervisorid", "Supervisorid");
            ViewBag.Supervisortreinamento_ = new SelectList(db.supervisor_treinamento, "Supervisortreinamentoid", "Supervisortreinamentoid");
            return View();
        }

        // POST: Celula/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Celulaid,Nome,Dia_semana,Horario,Maximo_pessoa,Supervisor_,Supervisortreinamento_,Endereco_Celula,Lider,Lider_treinamento")] Celula celula)
        {
            if (ModelState.IsValid)
            {
                celula.Supervisor = db.supervisor.Include(s => s.Celulas).First(s => s.Supervisorid == celula.Supervisor_);
                if( celula.Supervisor.Celulas.Count > celula.Supervisor.Maximo_celula)
                {
                    ViewBag.ErroSupervisor = "Este cargo já supervisiona varias celulas";
                    ViewBag.pessoa_lider = new SelectList(db.pessoas, "Id", "Nome");
                    ViewBag.pessoa_lider_treinamento = new SelectList(db.pessoas, "Id", "Nome");
                    ViewBag.Supervisor_ = new SelectList(db.supervisor, "Supervisorid", "Supervisorid", celula.Supervisor_);
                    ViewBag.Supervisortreinamento_ = new SelectList(db.supervisor_treinamento, "Supervisortreinamentoid", "Supervisortreinamentoid", celula.Supervisortreinamento_);
                    return View(celula);
                }

                celula.Supervisor_treianamento = db.supervisor_treinamento.Include(s => s.Celulas).First(s => s.Supervisortreinamentoid == celula.Supervisortreinamento_);
                if (celula.Supervisor_treianamento.Celulas.Count > celula.Supervisor_treianamento.Maximo_celula)
                {
                    ViewBag.ErroSupervisorTreinamento = "Este cargo já supervisiona varias celulas";
                    ViewBag.pessoa_lider = new SelectList(db.pessoas, "Id", "Nome");
                    ViewBag.pessoa_lider_treinamento = new SelectList(db.pessoas, "Id", "Nome");
                    ViewBag.Supervisor_ = new SelectList(db.supervisor, "Supervisorid", "Supervisorid", celula.Supervisor_);
                    ViewBag.Supervisortreinamento_ = new SelectList(db.supervisor_treinamento, "Supervisortreinamentoid", "Supervisortreinamentoid", celula.Supervisortreinamento_);
                    return View(celula);
                }

                celula.Lider = new Cargo_Lider();
                celula.Lider_treinamento = new Cargo_Lider_Treinamento();
                if (Request["pessoa_lider"].ToString() != "")
                {
                    celula.Lider.pessoa_ = int.Parse(Request["pessoa_lider"].ToString());
                }
                else { celula.Lider.pessoa_ = null; }
                if (Request["pessoa_lider_treinamento"].ToString() != "")
                {
                    celula.Lider_treinamento.pessoa_ = int.Parse(Request["pessoa_lider_treinamento"].ToString());
                }
                else { celula.Lider_treinamento.pessoa_ = null; }
                db.celula.Add(celula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.pessoa_lider = new SelectList(db.pessoas, "Id", "Nome", celula.Lider.pessoa_);
            ViewBag.pessoa_lider_treinamento = new SelectList(db.pessoas, "Id", "Nome", celula.Lider_treinamento.pessoa_);
            ViewBag.Supervisor_ = new SelectList(db.supervisor, "Supervisorid", "Supervisorid", celula.Supervisor_);
            ViewBag.Supervisortreinamento_ = new SelectList(db.supervisor_treinamento, "Supervisortreinamentoid", "Supervisortreinamentoid", celula.Supervisortreinamento_);
            return View(celula);
        }

        // GET: Celula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celula celula = db.celula.Find(id);
            if (celula == null)
            {
                return HttpNotFound();
            }

            ViewBag.pessoa_lider = new SelectList(db.pessoas, "Id", "Nome", celula.Lider.pessoa_);
            ViewBag.pessoa_lider_treinamento = new SelectList(db.pessoas, "Id", "Nome", celula.Lider_treinamento.pessoa_);
            ViewBag.Supervisor_ = new SelectList(db.supervisor, "Supervisorid", "Supervisorid", celula.Supervisor_);
            ViewBag.Supervisortreinamento_ = new SelectList(db.supervisor_treinamento, "Supervisortreinamentoid", "Supervisortreinamentoid", celula.Supervisortreinamento_);
            return View(celula);
        }

        // POST: Celula/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Celulaid,Nome,Dia_semana,Horario,Maximo_pessoa,Supervisor_,Supervisortreinamento_,Endereco_Celula,Lider,Lider_treinamento")] Celula celula)
        {
            if (ModelState.IsValid)
            {
                celula.Supervisor = db.supervisor.Include(s => s.Celulas).First(s => s.Supervisorid == celula.Supervisor_);
                if (celula.Supervisor.Celulas.Count > celula.Supervisor.Maximo_celula)
                {
                    ViewBag.ErroSupervisor = "Este cargo já supervisiona varias celulas";
                    ViewBag.pessoa_lider = new SelectList(db.pessoas, "Id", "Nome");
                    ViewBag.pessoa_lider_treinamento = new SelectList(db.pessoas, "Id", "Nome");
                    ViewBag.Supervisor_ = new SelectList(db.supervisor, "Supervisorid", "Supervisorid", celula.Supervisor_);
                    ViewBag.Supervisortreinamento_ = new SelectList(db.supervisor_treinamento, "Supervisortreinamentoid", "Supervisortreinamentoid", celula.Supervisortreinamento_);
                    return View(celula);
                }

                celula.Supervisor_treianamento = db.supervisor_treinamento.Include(s => s.Celulas).First(s => s.Supervisortreinamentoid == celula.Supervisortreinamento_);
                if (celula.Supervisor_treianamento.Celulas.Count > celula.Supervisor_treianamento.Maximo_celula)
                {
                    ViewBag.ErroSupervisorTreinamento = "Este cargo já supervisiona varias celulas";
                    ViewBag.pessoa_lider = new SelectList(db.pessoas, "Id", "Nome");
                    ViewBag.pessoa_lider_treinamento = new SelectList(db.pessoas, "Id", "Nome");
                    ViewBag.Supervisor_ = new SelectList(db.supervisor, "Supervisorid", "Supervisorid", celula.Supervisor_);
                    ViewBag.Supervisortreinamento_ = new SelectList(db.supervisor_treinamento, "Supervisortreinamentoid", "Supervisortreinamentoid", celula.Supervisortreinamento_);
                    return View(celula);
                }


                if (Request["pessoa_lider"].ToString() != "")
                {
                    celula.Lider.pessoa_ = int.Parse(Request["pessoa_lider"].ToString());
                }
                else { celula.Lider.pessoa_ = null; }
                if (Request["pessoa_lider_treinamento"].ToString() != "")
                {
                    celula.Lider_treinamento.pessoa_ = int.Parse(Request["pessoa_lider_treinamento"].ToString());
                }
                else { celula.Lider_treinamento.pessoa_ = null; }
                
                db.Entry(celula.Lider).State = EntityState.Modified;
                db.Entry(celula.Lider_treinamento).State = EntityState.Modified;
                db.Entry(celula.Endereco_Celula).State = EntityState.Modified;
                db.Entry(celula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pessoa_lider = new SelectList(db.lider, "Liderid", "Nome", celula.Lider.pessoa_);
            ViewBag.pessoa_lider_treinamento = new SelectList(db.lider_treinamento, "Lidertreinamentoid", "Nome", celula.Lider_treinamento.pessoa_);
            ViewBag.Supervisor_ = new SelectList(db.supervisor, "Supervisorid", "Supervisorid", celula.Supervisor_);
            ViewBag.Supervisortreinamento_ = new SelectList(db.supervisor_treinamento, "Supervisortreinamentoid", "Supervisortreinamentoid", celula.Supervisortreinamento_);
            return View(celula);
        }

        // GET: Celula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celula celula = db.celula.Find(id);
            if (celula == null)
            {
                return HttpNotFound();
            }
            return View(celula);
        }

        // POST: Celula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Celula celula = db.celula.Find(id);
            db.celula.Remove(celula);
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
