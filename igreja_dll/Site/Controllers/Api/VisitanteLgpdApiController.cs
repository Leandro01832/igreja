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
using business.classes.Abstrato;
using database;
using business.classes;

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

            if (id != visitanteLgpd.Id)
            {
                return BadRequest();
            }

            db.Entry(visitanteLgpd).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = visitanteLgpd.GetType().Name, IdDado = visitanteLgpd.Id });
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

        [ResponseType(typeof(VisitanteLgpd))]
        [Route("VisitanteCadastroApi")]
        public IHttpActionResult PostVisitanteCadastro(VisitanteLgpd visitante)
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
            return CreatedAtRoute("DefaultApi", new { id = visitante.Id }, visitante);
        }

        // POST: api/VisitanteLgpdApi
        [ResponseType(typeof(VisitanteLgpd))]
        public IHttpActionResult PostVisitanteLgpd(VisitanteLgpd visitante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ultimoRegistro = modelocrud.GetUltimoRegistro(typeof(Pessoa), BDcomum.conecta2);
            var Cod = ultimoRegistro + 1;

            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(banco));
            var user = new ApplicationUser { UserName = visitante.Email, Email = visitante.Email, Codigo = Cod };
            var result = usermaneger.Create(user, visitante.password);
            if (!result.Succeeded)
            {
                return this.BadRequest("Usuario não cadastrado!!!");
            }
            visitante.Codigo = Cod;
            db.pessoas.Add(visitante);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = visitante.Id }, visitante);
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
            db.DadoExcluido.Add(new DadoExcluido { Entidade = visitanteLgpd.GetType().Name, IdDado = id });
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
            return db.pessoas.Count(e => e.Id == id) > 0;
        }
    }
}