using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using RepositorioEF;
using business.classes.Abstrato;
using business.classes.Ministerio;
using database;

namespace Site.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MinisterioController : Controller
    {
        private DB db = new DB();

        // GET: Ministerio
        public async Task<ActionResult> Index()
        {
            modelocrud.EntityCrud = true;
            return View(await db.ministerio.ToListAsync());
        }

        // GET: Ministerio/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int? id)
        {
            modelocrud.EntityCrud = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministerio ministerio = await db.ministerio.FindAsync(id);
            if (ministerio == null)
            {
                return HttpNotFound();
            }
            return View(ministerio);
        }

        // GET: Ministerio/Create
        public ActionResult Create(string tipo)
        {
            Ministerio ministerio = null;
            if (tipo == "Lider_Celula") ministerio = new Lider_Celula();
            if (tipo == "Lider_Celula_Treinamento") ministerio = new Lider_Celula_Treinamento();
            if (tipo == "Lider_Ministerio") ministerio = new Lider_Ministerio();
            if (tipo == "Lider_Ministerio_Treinamento") ministerio = new Lider_Ministerio_Treinamento();
            if (tipo == "Supervisor_Celula") ministerio = new Supervisor_Celula();
            if (tipo == "Supervisor_Celula_Treinamento") ministerio = new Supervisor_Celula_Treinamento();
            if (tipo == "Supervisor_Ministerio") ministerio = new Supervisor_Ministerio();
            if (tipo == "Supervisor_Ministerio_Treinamento") ministerio = new Supervisor_Ministerio_Treinamento();
            
            return View(ministerio);
        }
       
        #region Create-Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LiderCelula(Lider_Celula ministerio)
        {
            if (ministerio.Id == 0) return await Create(ministerio);
            else return await Editar(ministerio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LiderCelulaTreinamento(Lider_Celula_Treinamento ministerio)
        {
            if (ministerio.Id == 0) return await Create(ministerio);
            else return await Editar(ministerio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LiderMinisterio(Lider_Ministerio ministerio)
        {
            if (ministerio.Id == 0) return await Create(ministerio);
            else return await Editar(ministerio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LiderMinisterioTreinamento(Lider_Ministerio_Treinamento ministerio)
        {
            if (ministerio.Id == 0) return await Create(ministerio);
            else return await Editar(ministerio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SupervisorCelula(Supervisor_Celula ministerio)
        {
            if (ministerio.Id == 0) return await Create(ministerio);
            else return await Editar(ministerio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SupervisorCelula(Supervisor_Celula_Treinamento ministerio)
        {
            if (ministerio.Id == 0) return await Create(ministerio);
            else return await Editar(ministerio);
        }

        
        private async Task<ActionResult> Editar(Ministerio ministerio)
        {
            modelocrud.EntityCrud = true;
            db.Entry(ministerio).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        private async Task<ActionResult> Create(Ministerio ministerio)
        {
            modelocrud.EntityCrud = true;
            db.ministerio.Add((Ministerio)ministerio);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        // GET: Ministerio/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministerio ministerio = await db.ministerio.FindAsync(id);
            if (ministerio == null)
            {
                return HttpNotFound();
            }
            return View(ministerio);
        }
       

        // GET: Ministerio/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministerio ministerio = await db.ministerio.FindAsync(id);
            if (ministerio == null)
            {
                return HttpNotFound();
            }
            return View(ministerio);
        }

        // POST: Ministerio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            modelocrud.EntityCrud = true;
            Ministerio ministerio = await db.ministerio.FindAsync(id);
            db.ministerio.Remove(ministerio);
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
