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
using System.Web.Http.OData;
using Site.Models.Api;
using business.classes;

namespace Site.Controllers.Api
{
    public class MinisterioCelulaApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/MinisterioCelulaApi
        [EnableQuery]
        public IQueryable<MinisterioCelulaApi> GetMinisterioCelula()
        {
            var MinisterioCelulas = db.MinisterioCelula.Include(rp => rp.Ministerio).Include(rp => rp.Celula);
            List<MinisterioCelulaApi> itens = new List<MinisterioCelulaApi>();

            foreach(var modelo in MinisterioCelulas)
            {
                itens.Add(new MinisterioCelulaApi
                {
                    Celula = modelo.Celula,
                    CelulaId = modelo.CelulaId,
                    Ministerio = modelo.Ministerio,
                    MinisterioId = modelo.MinisterioId,
                    Id = modelo.Id
                });
            }

            IQueryable<MinisterioCelulaApi> retorno = itens.AsQueryable();
            return retorno;
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

            if (id != ministerioCelula.Id)
            {
                return BadRequest();
            }

            db.Entry(ministerioCelula).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = ministerioCelula.GetType().Name, IdDado = ministerioCelula.Id });
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
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ministerioCelula.Id }, ministerioCelula);
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
            db.DadoExcluido.Add(new DadoExcluido { Entidade = ministerioCelula.GetType().Name, IdDado = id });
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
            return db.MinisterioCelula.Count(e => e.Id == id) > 0;
        }
    }
}