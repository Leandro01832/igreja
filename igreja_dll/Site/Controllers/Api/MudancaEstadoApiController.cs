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
using System.Web.Http.OData;
using business.implementacao;

namespace Site.Controllers.Api
{
    public class MudancaEstadoApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/MudancaEstadoApi
        [EnableQuery]
        public IQueryable<MudancaEstado> GetMudancaEstado()
        {
            return db.MudancaEstado;
        }

        // GET: api/MudancaEstadoApi/5
        [ResponseType(typeof(MudancaEstado))]
        public async Task<IHttpActionResult> GetMudancaEstado(int id)
        {
            MudancaEstado mudancaEstado = await db.MudancaEstado.FindAsync(id);
            if (mudancaEstado == null)
            {
                return NotFound();
            }

            return Ok(mudancaEstado);
        }

        // PUT: api/MudancaEstadoApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMudancaEstado(int id, MudancaEstado mudancaEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mudancaEstado.Id)
            {
                return BadRequest();
            }

            db.Entry(mudancaEstado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MudancaEstadoExists(id))
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

        // POST: api/MudancaEstadoApi
        [ResponseType(typeof(MudancaEstado))]
        public async Task<IHttpActionResult> PostMudancaEstado(MudancaEstado mudancaEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MudancaEstado.Add(mudancaEstado);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mudancaEstado.Id }, mudancaEstado);
        }

        // DELETE: api/MudancaEstadoApi/5
        [ResponseType(typeof(MudancaEstado))]
        public async Task<IHttpActionResult> DeleteMudancaEstado(int id)
        {
            MudancaEstado mudancaEstado = await db.MudancaEstado.FindAsync(id);
            if (mudancaEstado == null)
            {
                return NotFound();
            }

            db.MudancaEstado.Remove(mudancaEstado);
            await db.SaveChangesAsync();

            return Ok(mudancaEstado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MudancaEstadoExists(int id)
        {
            return db.MudancaEstado.Count(e => e.Id == id) > 0;
        }
    }
}