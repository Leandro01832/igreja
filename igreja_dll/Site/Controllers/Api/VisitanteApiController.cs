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
using business.classes.Pessoas;
using business.classes.Abstrato;
using System.Web.Http.OData;
using business.classes;

namespace Site.Controllers.Api
{
    public class VisitanteApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/VisitanteApi
        [EnableQuery]
        public IQueryable<Visitante> GetPessoas()
        {
            return db.pessoas.OfType<Visitante>();
        }

        // GET: api/VisitanteApi/5
        [ResponseType(typeof(Visitante))]
        public async Task<IHttpActionResult> GetVisitante(int id)
        {
            Visitante visitante = (Visitante) await db.pessoas.FindAsync(id);
            if (visitante == null)
            {
                return NotFound();
            }

            return Ok(visitante);
        }

        // PUT: api/VisitanteApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVisitante(int id, Visitante visitante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitante.Id)
            {
                return BadRequest();
            }

            db.Entry(visitante).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = visitante.GetType().Name, IdDado = visitante.Id });
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitanteExists(id))
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

        // POST: api/VisitanteApi
        [ResponseType(typeof(Visitante))]
        public IHttpActionResult PostVisitante(Visitante visitante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.pessoas.Add(visitante);
                db.SaveChanges();
            }
            catch { BadRequest("Cadastro não realizado."); }
            return CreatedAtRoute("DefaultApi", new { id = visitante.Id }, visitante);
        }

        // DELETE: api/VisitanteApi/5
        [ResponseType(typeof(Visitante))]
        public async Task<IHttpActionResult> DeleteVisitante(int id)
        {
            Visitante visitante = (Visitante)await db.pessoas.FindAsync(id);
            if (visitante == null)
            {
                return NotFound();
            }

            db.pessoas.Remove((Pessoa)visitante);
            await db.SaveChangesAsync();
            db.DadoExcluido.Add(new DadoExcluido { Entidade = visitante.GetType().Name, IdDado = id });
            await db.SaveChangesAsync();

            return Ok(visitante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitanteExists(int id)
        {
            return db.pessoas.Count(e => e.Id == id) > 0;
        }
    }
}