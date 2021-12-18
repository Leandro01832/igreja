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
    public class ReuniaoPessoaApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/ReuniaoPessoaApi
        [EnableQuery]
        public IQueryable<ReuniaoPessoaApi> GetReuniaoPessoa()
        {
            var Reunioes = db.ReuniaoPessoa.Include(rp => rp.Reuniao).Include(rp => rp.Pessoa);

            List<ReuniaoPessoaApi> itens = new List<ReuniaoPessoaApi>();

            foreach(var modelo in Reunioes)
            {
                itens.Add(new ReuniaoPessoaApi
                {
                    Id = modelo.Id,
                    Pessoa = modelo.Pessoa,
                    PessoaId = modelo.PessoaId,
                    Reuniao = modelo.Reuniao,
                    ReuniaoId = modelo.ReuniaoId
                });
            }

            IQueryable<ReuniaoPessoaApi> retorno = itens.AsQueryable();

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

            if (id != reuniaoPessoa.Id)
            {
                return BadRequest();
            }

            db.Entry(reuniaoPessoa).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = reuniaoPessoa.GetType().Name, IdDado = reuniaoPessoa.Id });
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
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reuniaoPessoa.Id }, reuniaoPessoa);
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
            db.DadoExcluido.Add(new DadoExcluido { Entidade = reuniaoPessoa.GetType().Name, IdDado = id });
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
            return db.ReuniaoPessoa.Count(e => e.Id == id) > 0;
        }
    }
}