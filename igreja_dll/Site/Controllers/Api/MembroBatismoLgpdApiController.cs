using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RepositorioEF;
using business.classes.PessoasLgpd;
using Site.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using database.banco;

namespace Site.Controllers.Api
{
    public class MembroBatismoLgpdApiController : ApiController
    {
        private DB db = new DB();
        ApplicationDbContext banco = new ApplicationDbContext();

        // GET: api/MembroBatismoLgpdApi
        public IQueryable<Membro_BatismoLgpd> GetPessoas()
        {
            return db.pessoas.OfType<Membro_BatismoLgpd>();
        }

        // GET: api/MembroBatismoLgpdApi/5
        [ResponseType(typeof(Membro_BatismoLgpd))]
        public async Task<IHttpActionResult> GetMembro_BatismoLgpd(int id)
        {
            Membro_BatismoLgpd membro_BatismoLgpd = (Membro_BatismoLgpd) await db.pessoas.FindAsync(id);
            if (membro_BatismoLgpd == null)
            {
                return NotFound();
            }

            return Ok(membro_BatismoLgpd);
        }

        // PUT: api/MembroBatismoLgpdApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembro_BatismoLgpd(int id, Membro_BatismoLgpd membro_BatismoLgpd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membro_BatismoLgpd.IdPessoa)
            {
                return BadRequest();
            }

            db.Entry(membro_BatismoLgpd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Membro_BatismoLgpdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Membro_BatismoLgpd))]
        [Route("MembroBatismoCadastroApi")]
        public IHttpActionResult PostMembro_BatismoCadastro(Membro_BatismoLgpd membro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                membro.salvar();
            }
            catch { return this.BadRequest("Usuario não cadastrado!!!"); }
            return CreatedAtRoute("DefaultApi", new { id = membro.IdPessoa }, membro);
        }

        // POST: api/MembroBatismoLgpdApi
        [ResponseType(typeof(Membro_BatismoLgpd))]
        public IHttpActionResult PostMembro_BatismoLgpd(Membro_BatismoLgpd membro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ultimoRegistro = new BDcomum().GetUltimoRegistroPessoa();
            var Cod = ultimoRegistro + 1;

            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(banco));
            var user = new ApplicationUser { UserName = membro.Email, Email = membro.Email, Codigo = Cod };
            var result = usermaneger.Create(user, membro.password);
            if (!result.Succeeded)
            {
                return this.BadRequest("Usuario não cadastrado!!!");
            }
            membro.Codigo = Cod;
            membro.salvar();
            return CreatedAtRoute("DefaultApi", new { id = membro.IdPessoa }, membro);
        }

        // DELETE: api/MembroBatismoLgpdApi/5
        [ResponseType(typeof(Membro_BatismoLgpd))]
        public async Task<IHttpActionResult> DeleteMembro_BatismoLgpd(int id)
        {
            Membro_BatismoLgpd membro_BatismoLgpd = (Membro_BatismoLgpd)await db.pessoas.FindAsync(id);
            if (membro_BatismoLgpd == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(membro_BatismoLgpd);
            await db.SaveChangesAsync();

            return Ok(membro_BatismoLgpd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Membro_BatismoLgpdExists(int id)
        {
            return db.pessoas.Count(e => e.IdPessoa == id) > 0;
        }
    }
}