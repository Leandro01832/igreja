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
    public class EnderecoApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/EnderecoApi
        public IQueryable<Endereco> GetEnderecoes()
        {
            return db.endereco;
        }

        // GET: api/EnderecoApi/5
        [ResponseType(typeof(Endereco))]
        public async Task<IHttpActionResult> GetEndereco(int id)
        {
            Endereco endereco = await db.endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }

        // PUT: api/EnderecoApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEndereco(int id, Endereco endereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != endereco.IdEndereco)
            {
                return BadRequest();
            }

            db.Entry(endereco).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
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

        // POST: api/EnderecoApi
        [ResponseType(typeof(Endereco))]
        public async Task<IHttpActionResult> PostEndereco(Endereco endereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.endereco.Add(endereco);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EnderecoExists(endereco.IdEndereco))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = endereco.IdEndereco }, endereco);
        }

        // DELETE: api/EnderecoApi/5
        [ResponseType(typeof(Endereco))]
        public async Task<IHttpActionResult> DeleteEndereco(int id)
        {
            Endereco endereco = await db.endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            db.endereco.Remove(endereco);
            await db.SaveChangesAsync();

            return Ok(endereco);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnderecoExists(int id)
        {
            return db.endereco.Count(e => e.IdEndereco == id) > 0;
        }
    }
}