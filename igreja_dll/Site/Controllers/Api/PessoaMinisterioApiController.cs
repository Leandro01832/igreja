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
    public class PessoaMinisterioApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/PessoaMinisterioApi
        [EnableQuery]
        public IQueryable<PessoaMinisterioApi> GetPessoaMinisterio()
        {
            var Ministerios = db.PessoaMinisterio.Include(rp => rp.Ministerio).Include(rp => rp.Pessoa);
            List<PessoaMinisterioApi> itens = new List<PessoaMinisterioApi>();

            foreach(var modelo in Ministerios)
            {
                itens.Add(new PessoaMinisterioApi
                {
                    Id = modelo.Id,
                    Ministerio = modelo.Ministerio,
                    MinisterioId = modelo.MinisterioId,
                    Pessoa = modelo.Pessoa,
                    PessoaId = modelo.PessoaId
                });
            }

            IQueryable<PessoaMinisterioApi> retorno = itens.AsQueryable();
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

            if (id != pessoaMinisterio.Id)
            {
                return BadRequest();
            }

            db.Entry(pessoaMinisterio).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = pessoaMinisterio.GetType().Name, IdDado = pessoaMinisterio.Id });
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
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pessoaMinisterio.Id }, pessoaMinisterio);
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
            db.DadoExcluido.Add(new DadoExcluido { Entidade = pessoaMinisterio.GetType().Name, IdDado = id });
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
            return db.PessoaMinisterio.Count(e => e.Id == id) > 0;
        }
    }
}