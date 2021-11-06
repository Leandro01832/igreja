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
    public class MembroReconciliacaoLgpdApiController : ApiController
    {
        private DB db = new DB();
        ApplicationDbContext banco = new ApplicationDbContext();

        // GET: api/MembroReconciliacaoLgpdApi
        public IQueryable<Membro_ReconciliacaoLgpd> GetPessoas()
        {
            return db.pessoas.OfType<Membro_ReconciliacaoLgpd>();
        }

        // GET: api/MembroReconciliacaoLgpdApi/5
        [ResponseType(typeof(Membro_ReconciliacaoLgpd))]
        public async Task<IHttpActionResult> GetMembro_ReconciliacaoLgpd(int id)
        {
            Membro_ReconciliacaoLgpd membro_ReconciliacaoLgpd = (Membro_ReconciliacaoLgpd) await db.pessoas.FindAsync(id);
            if (membro_ReconciliacaoLgpd == null)
            {
                return NotFound();
            }

            return Ok(membro_ReconciliacaoLgpd);
        }

        // PUT: api/MembroReconciliacaoLgpdApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembro_ReconciliacaoLgpd(int id, Membro_ReconciliacaoLgpd membro_ReconciliacaoLgpd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membro_ReconciliacaoLgpd.IdPessoa)
            {
                return BadRequest();
            }

            db.Entry(membro_ReconciliacaoLgpd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Membro_ReconciliacaoLgpdExists(id))
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

        [ResponseType(typeof(Membro_ReconciliacaoLgpd))]
        [Route("MembroReconciliacaoCadastroApi")]
        public IHttpActionResult PostMembro_ReconciliacaoCadastro(Membro_ReconciliacaoLgpd membro)
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

        // POST: api/MembroReconciliacaoLgpdApi
        [ResponseType(typeof(Membro_ReconciliacaoLgpd))]
        public IHttpActionResult PostMembro_ReconciliacaoLgpd(Membro_ReconciliacaoLgpd membro)
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

        // DELETE: api/MembroReconciliacaoLgpdApi/5
        [ResponseType(typeof(Membro_ReconciliacaoLgpd))]
        public async Task<IHttpActionResult> DeleteMembro_ReconciliacaoLgpd(int id)
        {
            Membro_ReconciliacaoLgpd membro_ReconciliacaoLgpd = (Membro_ReconciliacaoLgpd)await db.pessoas.FindAsync(id);
            if (membro_ReconciliacaoLgpd == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(membro_ReconciliacaoLgpd);
            await db.SaveChangesAsync();

            return Ok(membro_ReconciliacaoLgpd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Membro_ReconciliacaoLgpdExists(int id)
        {
            return db.pessoas.Count(e => e.IdPessoa == id) > 0;
        }
    }
}