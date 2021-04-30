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

namespace Site.Controllers.Api
{
    public class MembroAclamacaoLgpdApiController : ApiController
    {
        private DB db = new DB();
        ApplicationDbContext banco = new ApplicationDbContext();

        // GET: api/MembroAclamacaoLgpdApi
        public IQueryable<Membro_AclamacaoLgpd> GetPessoas()
        {
            return db.pessoas.OfType<Membro_AclamacaoLgpd>();
        }

        // GET: api/MembroAclamacaoLgpdApi/5
        [ResponseType(typeof(Membro_AclamacaoLgpd))]
        public async Task<IHttpActionResult> GetMembro_AclamacaoLgpd(int id)
        {
            Membro_AclamacaoLgpd membro_AclamacaoLgpd = (Membro_AclamacaoLgpd) await db.pessoas.FindAsync(id);
            if (membro_AclamacaoLgpd == null)
            {
                return NotFound();
            }

            return Ok(membro_AclamacaoLgpd);
        }

        // PUT: api/MembroAclamacaoLgpdApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembro_AclamacaoLgpd(int id, Membro_AclamacaoLgpd membro_AclamacaoLgpd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membro_AclamacaoLgpd.IdPessoa)
            {
                return BadRequest();
            }

            db.Entry(membro_AclamacaoLgpd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Membro_AclamacaoLgpdExists(id))
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

        // POST: api/MembroAclamacaoLgpdApi
        [ResponseType(typeof(Membro_AclamacaoLgpd))]
        public IHttpActionResult PostMembro_AclamacaoLgpd(Membro_AclamacaoLgpd membro)
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

            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(banco));
            var user = new ApplicationUser { UserName = membro.Email, Email = membro.Email, Codigo = membro.Codigo };
            var result = usermaneger.Create(user, membro.password);
            if (!result.Succeeded)
            {
                membro.excluir(membro.IdPessoa);
                return this.BadRequest("Usuario não cadastrado!!!");
            }

            return CreatedAtRoute("DefaultApi", new { id = membro.IdPessoa }, membro);
        }

        // DELETE: api/MembroAclamacaoLgpdApi/5
        [ResponseType(typeof(Membro_AclamacaoLgpd))]
        public async Task<IHttpActionResult> DeleteMembro_AclamacaoLgpd(int id)
        {
            Membro_AclamacaoLgpd membro_AclamacaoLgpd = (Membro_AclamacaoLgpd)await db.pessoas.FindAsync(id);
            if (membro_AclamacaoLgpd == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(membro_AclamacaoLgpd);
            await db.SaveChangesAsync();

            return Ok(membro_AclamacaoLgpd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Membro_AclamacaoLgpdExists(int id)
        {
            return db.Pessoas.Count(e => e.IdPessoa == id) > 0;
        }
    }
}