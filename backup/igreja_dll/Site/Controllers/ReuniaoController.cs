using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepositorioEF;
using business.classes;

namespace Site.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ReuniaoController : Controller
    {
        private DB db = new DB();

        // GET: Reuniao
        public async Task<ActionResult> Index()
        {
            return View(await db.reuniao.ToListAsync());
        }

        // GET: Reuniao/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = await db.reuniao.FindAsync(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // GET: Reuniao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reuniao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdReuniao,Data_reuniao,Horario_inicio,Horario_fim,Local_reuniao")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                db.reuniao.Add(reuniao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reuniao);
        }

        // GET: Reuniao/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = await db.reuniao.FindAsync(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // POST: Reuniao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdReuniao,Data_reuniao,Horario_inicio,Horario_fim,Local_reuniao")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reuniao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reuniao);
        }

        // GET: Reuniao/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = await db.reuniao.FindAsync(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // POST: Reuniao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reuniao reuniao = await db.reuniao.FindAsync(id);
            db.reuniao.Remove(reuniao);
            await db.SaveChangesAsync();
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
