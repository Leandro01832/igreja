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
    public class VisitanteLgpdApiController : ApiController
    {
        private DB db = new DB();
        ApplicationDbContext banco = new ApplicationDbContext();

        // GET: api/VisitanteLgpdApi
        public IQueryable<VisitanteLgpd> GetPessoas()
        {
            return db.pessoas.OfType<VisitanteLgpd>();
        }

        // GET: api/VisitanteLgpdApi/5
        [ResponseType(typeof(VisitanteLgpd))]
        public async Task<IHttpActionResult> GetVisitanteLgpd(int id)
        {
            VisitanteLgpd visitanteLgpd = (VisitanteLgpd) await db.pessoas.FindAsync(id);
            if (visitanteLgpd == null)
            {
                return NotFound();
            }

            return Ok(visitanteLgpd);
        }

        // PUT: api/VisitanteLgpdApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVisitanteLgpd(int id, VisitanteLgpd visitanteLgpd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitanteLgpd.IdPessoa)
            {
                return BadRequest();
            }

            db.Entry(visitanteLgpd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitanteLgpdExists(id))
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

        // POST: api/VisitanteLgpdApi
        [ResponseType(typeof(VisitanteLgpd))]
        public IHttpActionResult PostVisitanteLgpd(VisitanteLgpd visitante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                visitante.salvar();
            }
            catch { return this.BadRequest("Usuario não cadastrado!!!"); }

            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(banco));
            var user = new ApplicationUser { UserName = visitante.Email, Email = visitante.Email, Codigo = visitante.Codigo };
            var result = usermaneger.Create(user, visitante.password);
            if (!result.Succeeded)
            {
                visitante.excluir(visitante.IdPessoa);
                return this.BadRequest("Usuario não cadastrado!!!");
            }

            return CreatedAtRoute("DefaultApi", new { id = visitante.IdPessoa }, visitante);
        }

        // DELETE: api/VisitanteLgpdApi/5
        [ResponseType(typeof(VisitanteLgpd))]
        public async Task<IHttpActionResult> DeleteVisitanteLgpd(int id)
        {
            VisitanteLgpd visitanteLgpd = (VisitanteLgpd) await db.pessoas.FindAsync(id);
            if (visitanteLgpd == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(visitanteLgpd);
            await db.SaveChangesAsync();

            return Ok(visitanteLgpd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitanteLgpdExists(int id)
        {
            return db.pessoas.Count(e => e.IdPessoa == id) > 0;
        }
    }
}