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
    public class MembroTransferenciaLgpdApiController : ApiController
    {
        private DB db = new DB();
        ApplicationDbContext banco = new ApplicationDbContext();

        // GET: api/MembroTransferenciaLgpdApi
        public IQueryable<Membro_TransferenciaLgpd> GetPessoas()
        {
            return db.pessoas.OfType<Membro_TransferenciaLgpd>();
        }

        // GET: api/MembroTransferenciaLgpdApi/5
        [ResponseType(typeof(Membro_TransferenciaLgpd))]
        public async Task<IHttpActionResult> GetMembro_TransferenciaLgpd(int id)
        {
            Membro_TransferenciaLgpd membro_TransferenciaLgpd = (Membro_TransferenciaLgpd) await db.pessoas.FindAsync(id);
            if (membro_TransferenciaLgpd == null)
            {
                return NotFound();
            }

            return Ok(membro_TransferenciaLgpd);
        }

        // PUT: api/MembroTransferenciaLgpdApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembro_TransferenciaLgpd(int id, Membro_TransferenciaLgpd membro_TransferenciaLgpd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membro_TransferenciaLgpd.Id)
            {
                return BadRequest();
            }

            db.Entry(membro_TransferenciaLgpd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Membro_TransferenciaLgpdExists(id))
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

        [ResponseType(typeof(Membro_TransferenciaLgpd))]
        [Route("MembroTransferenciaCadastroApi")]
        public IHttpActionResult PostMembro_TransferenciaCadastro(Membro_TransferenciaLgpd membro)
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
            return CreatedAtRoute("DefaultApi", new { id = membro.Id }, membro);
        }

        // POST: api/MembroTransferenciaLgpdApi
        [ResponseType(typeof(Membro_TransferenciaLgpd))]
        public IHttpActionResult PostMembro_TransferenciaLgpd(Membro_TransferenciaLgpd membro)
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
            return CreatedAtRoute("DefaultApi", new { id = membro.Id }, membro);
        }

        // DELETE: api/MembroTransferenciaLgpdApi/5
        [ResponseType(typeof(Membro_TransferenciaLgpd))]
        public async Task<IHttpActionResult> DeleteMembro_TransferenciaLgpd(int id)
        {
            Membro_TransferenciaLgpd membro_TransferenciaLgpd = (Membro_TransferenciaLgpd) await db.pessoas.FindAsync(id);
            if (membro_TransferenciaLgpd == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(membro_TransferenciaLgpd);
            await db.SaveChangesAsync();

            return Ok(membro_TransferenciaLgpd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Membro_TransferenciaLgpdExists(int id)
        {
            return db.pessoas.Count(e => e.Id == id) > 0;
        }
    }
}