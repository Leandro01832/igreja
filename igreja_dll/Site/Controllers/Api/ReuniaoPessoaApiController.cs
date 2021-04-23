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
    public class ReuniaoPessoaApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/ReuniaoPessoaApi
        [EnableQuery]
        public IQueryable<ReuniaoPessoaApi> GetReuniaoPessoa()
        {
            var reuniaoPessoas = db.ReuniaoPessoa.Include(e => e.Reuniao).Include(e => e.Pessoa);
            List<ReuniaoPessoaApi> lista = new List<ReuniaoPessoaApi>();

            foreach (var item in reuniaoPessoas)
            {
                ReuniaoPessoaApi modelo = new ReuniaoPessoaApi
                {
                    Pessoa = item.Pessoa,
                    Reuniao = item.Reuniao,
                    PessoaId = item.PessoaId,
                    ReuniaoId = item.ReuniaoId
                };
                lista.Add(modelo);
            }
            IQueryable<ReuniaoPessoaApi> retorno = lista.AsQueryable();
            return retorno;
        }

        // GET: api/ReuniaoPessoaApi/5
        [ResponseType(typeof(ReuniaoPessoa))]
        public async Task<IHttpActionResult> GetReuniaoPessoa(int id)
        {
            ReuniaoPessoa reuniaoPessoa = await db.ReuniaoPessoa.FindAsync(id);
            if (reuniaoPessoa == null)
            {
                return NotFound();
            }

            return Ok(reuniaoPessoa);
        }

        // PUT: api/ReuniaoPessoaApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReuniaoPessoa(int id, ReuniaoPessoa reuniaoPessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reuniaoPessoa.PessoaId)
            {
                return BadRequest();
            }

            db.Entry(reuniaoPessoa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReuniaoPessoaExists(id))
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

        // POST: api/ReuniaoPessoaApi
        [ResponseType(typeof(ReuniaoPessoa))]
        public async Task<IHttpActionResult> PostReuniaoPessoa(ReuniaoPessoa reuniaoPessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReuniaoPessoa.Add(reuniaoPessoa);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReuniaoPessoaExists(reuniaoPessoa.PessoaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reuniaoPessoa.PessoaId }, reuniaoPessoa);
        }

        // DELETE: api/ReuniaoPessoaApi/5
        [ResponseType(typeof(ReuniaoPessoa))]
        public async Task<IHttpActionResult> DeleteReuniaoPessoa(int id)
        {
            ReuniaoPessoa reuniaoPessoa = await db.ReuniaoPessoa.FindAsync(id);
            if (reuniaoPessoa == null)
            {
                return NotFound();
            }

            db.ReuniaoPessoa.Remove(reuniaoPessoa);
            await db.SaveChangesAsync();

            return Ok(reuniaoPessoa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReuniaoPessoaExists(int id)
        {
            return db.ReuniaoPessoa.Count(e => e.PessoaId == id) > 0;
        }
    }
}