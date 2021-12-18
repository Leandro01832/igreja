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
using business.classes;

namespace Site.Controllers.Api
{
    public class TelefoneApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/TelefoneApi
        public IQueryable<Telefone> GetTelefones()
        {
            return db.telefone;
        }

        // GET: api/TelefoneApi/5
        [ResponseType(typeof(Telefone))]
        public async Task<IHttpActionResult> GetTelefone(int id)
        {
            Telefone telefone = await db.telefone.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }

            return Ok(telefone);
        }

        // PUT: api/TelefoneApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTelefone(int id, Telefone telefone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefone.Id)
            {
                return BadRequest();
            }

            db.Entry(telefone).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = telefone.GetType().Name, IdDado = telefone.Id });
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(id))
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

        // POST: api/TelefoneApi
        [ResponseType(typeof(Telefone))]
        public async Task<IHttpActionResult> PostTelefone(Telefone telefone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.telefone.Add(telefone);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TelefoneExists(telefone.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = telefone.Id }, telefone);
        }

        // DELETE: api/TelefoneApi/5
        [ResponseType(typeof(Telefone))]
        public async Task<IHttpActionResult> DeleteTelefone(int id)
        {
            Telefone telefone = await db.telefone.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }

            db.telefone.Remove(telefone);
            await db.SaveChangesAsync();
            db.DadoExcluido.Add(new DadoExcluido { Entidade = telefone.GetType().Name, IdDado = id });
            await db.SaveChangesAsync();

            return Ok(telefone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefoneExists(int id)
        {
            return db.telefone.Count(e => e.Id == id) > 0;
        }
    }
}