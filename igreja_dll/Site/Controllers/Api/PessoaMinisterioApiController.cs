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
using System.Web.Http.OData;

namespace Site.Controllers.Api
{
    public class PessoaMinisterioApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/PessoaMinisterioApi
        [EnableQuery]
        public IQueryable<PessoaMinisterioApi> GetPessoaMinisterio()
        {
            var pessoaMinisterios = db.PessoaMinisterio.Include(e => e.Pessoa).Include(e => e.Ministerio);

            List<PessoaMinisterioApi> lista = new List<PessoaMinisterioApi>();

            foreach (var item in pessoaMinisterios)
            {
                PessoaMinisterioApi modelo = new PessoaMinisterioApi
                {
                    Pessoa = item.Pessoa,
                    Ministerio = item.Ministerio,
                    PessoaId = item.PessoaId,
                    MinisterioId = item.MinisterioId
                };
                lista.Add(modelo);
            }

            IQueryable<PessoaMinisterioApi> retorno = lista.AsQueryable();

            return retorno;
        }

        // GET: api/PessoaMinisterioApi/5
        [ResponseType(typeof(PessoaMinisterio))]
        public async Task<IHttpActionResult> GetPessoaMinisterio(int id)
        {
            PessoaMinisterio pessoaMinisterio = await db.PessoaMinisterio.FindAsync(id);
            if (pessoaMinisterio == null)
            {
                return NotFound();
            }

            return Ok(pessoaMinisterio);
        }

        // PUT: api/PessoaMinisterioApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPessoaMinisterio(int id, PessoaMinisterio pessoaMinisterio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoaMinisterio.PessoaId)
            {
                return BadRequest();
            }

            db.Entry(pessoaMinisterio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaMinisterioExists(id))
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

        // POST: api/PessoaMinisterioApi
        [ResponseType(typeof(PessoaMinisterio))]
        public async Task<IHttpActionResult> PostPessoaMinisterio(PessoaMinisterio pessoaMinisterio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PessoaMinisterio.Add(pessoaMinisterio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PessoaMinisterioExists(pessoaMinisterio.PessoaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pessoaMinisterio.PessoaId }, pessoaMinisterio);
        }

        // DELETE: api/PessoaMinisterioApi/5
        [ResponseType(typeof(PessoaMinisterio))]
        public async Task<IHttpActionResult> DeletePessoaMinisterio(int id)
        {
            PessoaMinisterio pessoaMinisterio = await db.PessoaMinisterio.FindAsync(id);
            if (pessoaMinisterio == null)
            {
                return NotFound();
            }

            db.PessoaMinisterio.Remove(pessoaMinisterio);
            await db.SaveChangesAsync();

            return Ok(pessoaMinisterio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoaMinisterioExists(int id)
        {
            return db.PessoaMinisterio.Count(e => e.PessoaId == id) > 0;
        }
    }
}