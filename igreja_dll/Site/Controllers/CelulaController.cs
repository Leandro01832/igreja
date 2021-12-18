using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using RepositorioEF;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Site.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CelulaController : Controller
    {
        private DB db = new DB();

        // GET: Celula
        public async Task<ActionResult> Index()
        {
            var celulas = await db.celula.Include(c => c.EnderecoCelula).ToListAsync();
            return View(celulas);
        }

        // GET: Celula/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celula celula = await db.celula.FindAsync(id);
            if (celula == null)
            {
                return HttpNotFound();
            }
            return View(celula);
        }

        // GET: Celula/Create
        public ActionResult Create(string tipo)
        {
            Celula celula = null;

            if (tipo == "Celula_Adolescente") celula = new Celula_Adolescente();
            if (tipo == "Celula_Adulto") celula = new Celula_Adulto();
            if (tipo == "Celula_Casado") celula = new Celula_Casado();
            if (tipo == "Celula_Crianca") celula = new Celula_Crianca();
            if (tipo == "Celula_Jovem") celula = new Celula_Jovem();

            celula.EnderecoCelula = new EnderecoCelula();

            ViewBag.Id = new SelectList(db.EnderecoCelula, "Id", "Cep");
            return View(celula);
        }

        #region Create-Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CelulaAdolescente(Celula_Adolescente celula)
        {
            if (celula.Id == 0) return await Salvar(celula);
            else return await Editar(celula);           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CelulaAdulto(Celula_Adulto celula)
        {
            if (celula.Id == 0) return await Salvar(celula);
            else return await Editar(celula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Celula_Jovem(Celula_Jovem celula)
        {
            if (celula.Id == 0) return await Salvar(celula);
            else return await Editar(celula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Celula_Jovem(Celula_Crianca celula)
        {
            if (celula.Id == 0) return await Salvar(celula);
            else return await Editar(celula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Celula_Jovem(Celula_Casado celula)
        {
            if (celula.Id == 0) return await Salvar(celula);
            else return await Editar(celula);
        }

        private async Task<ActionResult> Editar(Celula celula)
        {
            db.Entry(celula).State = EntityState.Modified;
            db.Entry(celula.EnderecoCelula).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = celula.GetType().Name, IdDado = celula.Id });
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private async Task<ActionResult> Salvar(Celula celula)
        {
            db.celula.Add(celula);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion
       

        // GET: Celula/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celula celula = await db.celula.Include(c => c.EnderecoCelula).FirstAsync(c => c.Id == id);
            if (celula == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.EnderecoCelula, "Id", "Pais", celula.Id);
            return View(celula);
        }        

        // GET: Celula/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celula celula = await db.celula.FindAsync(id);
            if (celula == null)
            {
                return HttpNotFound();
            }
            return View(celula);
        }

        // POST: Celula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Celula celula = await db.celula.FindAsync(id);
            db.celula.Remove(celula);
            await db.SaveChangesAsync();
            db.DadoExcluido.Add(new DadoExcluido { Entidade = celula.GetType().Name, IdDado = id });
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
