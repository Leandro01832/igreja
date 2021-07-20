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
using System.Web.Http.OData;

namespace Site.Controllers.Api
{
    public class CriancaApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/CriancaApi
        [EnableQuery]
        public IQueryable<Crianca> GetPessoas()
        {
            return db.pessoas.OfType<Crianca>();
        }

        // GET: api/CriancaApi/5
        [ResponseType(typeof(Crianca))]
        public async Task<IHttpActionResult> GetCrianca(int id)
        {
            Crianca crianca = (Crianca) await db.pessoas.FindAsync(id);
            if (crianca == null)
            {
                return NotFound();
            }

            return Ok(crianca);
        }

        // PUT: api/CriancaApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCrianca(int id, Crianca crianca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crianca.Id)
            {
                return BadRequest();
            }

            db.Entry(crianca).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriancaExists(id))
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

        // POST: api/CriancaApi
        [ResponseType(typeof(Crianca))]
        public  IHttpActionResult PostCrianca(Crianca crianca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                crianca.salvar();
            }
            catch { return BadRequest("Cadastro não realizado"); }
            return CreatedAtRoute("DefaultApi", new { id = crianca.Id }, crianca);
        }

        // DELETE: api/CriancaApi/5
        [ResponseType(typeof(Crianca))]
        public async Task<IHttpActionResult> DeleteCrianca(int id)
        {
            Crianca crianca = (Crianca) await db.pessoas.FindAsync(id);
            if (crianca == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(crianca);
            await db.SaveChangesAsync();

            return Ok(crianca);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CriancaExists(int id)
        {
            return db.pessoas.Count(e => e.Id == id) > 0;
        }
    }
}