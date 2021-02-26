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
using business.classes.Intermediario;
using Site.Models.Api;

namespace Site.Controllers.Api
{
    public class MinisterioCelulaApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/MinisterioCelulaApi
        public IHttpActionResult GetMinisterioCelula()
        {
            var ministerioCelulas = db.MinisterioCelula.Include(e => e.Celula).Include(e => e.Ministerio);

            List<MinisterioCelulaApi> lista = new List<MinisterioCelulaApi>();

            foreach (var item in ministerioCelulas)
            {
                MinisterioCelulaApi modelo = new MinisterioCelulaApi
                {
                    Celula = item.Celula,
                    Ministerio = item.Ministerio,
                    CelulaId = item.CelulaId,
                    MinisterioId = item.MinisterioId
                };
                lista.Add(modelo);
            }

            return Ok(lista);
        }

        // GET: api/MinisterioCelulaApi/5
        [ResponseType(typeof(MinisterioCelula))]
        public async Task<IHttpActionResult> GetMinisterioCelula(int id)
        {
            MinisterioCelula ministerioCelula = await db.MinisterioCelula.FindAsync(id);
            if (ministerioCelula == null)
            {
                return NotFound();
            }

            return Ok(ministerioCelula);
        }

        // PUT: api/MinisterioCelulaApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMinisterioCelula(int id, MinisterioCelula ministerioCelula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ministerioCelula.CelulaId)
            {
                return BadRequest();
            }

            db.Entry(ministerioCelula).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinisterioCelulaExists(id))
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

        // POST: api/MinisterioCelulaApi
        [ResponseType(typeof(MinisterioCelula))]
        public async Task<IHttpActionResult> PostMinisterioCelula(MinisterioCelula ministerioCelula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MinisterioCelula.Add(ministerioCelula);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MinisterioCelulaExists(ministerioCelula.CelulaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ministerioCelula.CelulaId }, ministerioCelula);
        }

        // DELETE: api/MinisterioCelulaApi/5
        [ResponseType(typeof(MinisterioCelula))]
        public async Task<IHttpActionResult> DeleteMinisterioCelula(int id)
        {
            MinisterioCelula ministerioCelula = await db.MinisterioCelula.FindAsync(id);
            if (ministerioCelula == null)
            {
                return NotFound();
            }

            db.MinisterioCelula.Remove(ministerioCelula);
            await db.SaveChangesAsync();

            return Ok(ministerioCelula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MinisterioCelulaExists(int id)
        {
            return db.MinisterioCelula.Count(e => e.CelulaId == id) > 0;
        }
    }
}