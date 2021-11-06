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
    public class MembroTransferenciaApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/MembroTransferenciaApi
        [EnableQuery]
        public IQueryable<Membro_Transferencia> GetPessoas()
        {
            return db.pessoas.OfType<Membro_Transferencia>();
        }

        // GET: api/MembroTransferenciaApi/5
        [ResponseType(typeof(Membro_Transferencia))]
        public async Task<IHttpActionResult> GetMembro_Transferencia(int id)
        {
            Membro_Transferencia membro_Transferencia = (Membro_Transferencia) await db.pessoas.FindAsync(id);
            if (membro_Transferencia == null)
            {
                return NotFound();
            }

            return Ok(membro_Transferencia);
        }

        // PUT: api/MembroTransferenciaApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembro_Transferencia(int id, Membro_Transferencia membro_Transferencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membro_Transferencia.IdPessoa)
            {
                return BadRequest();
            }

            db.Entry(membro_Transferencia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Membro_TransferenciaExists(id))
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

        // POST: api/MembroTransferenciaApi
        [ResponseType(typeof(Membro_Transferencia))]
        public IHttpActionResult PostMembro_Transferencia(Membro_Transferencia membro_Transferencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                membro_Transferencia.salvar();
            }
            catch { BadRequest("Cadastro não realizado"); }
            return CreatedAtRoute("DefaultApi", new { id = membro_Transferencia.IdPessoa }, membro_Transferencia);
        }

        // DELETE: api/MembroTransferenciaApi/5
        [ResponseType(typeof(Membro_Transferencia))]
        public async Task<IHttpActionResult> DeleteMembro_Transferencia(int id)
        {
            Membro_Transferencia membro_Transferencia = (Membro_Transferencia) await db.pessoas.FindAsync(id);
            if (membro_Transferencia == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(membro_Transferencia);
            await db.SaveChangesAsync();

            return Ok(membro_Transferencia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Membro_TransferenciaExists(int id)
        {
            return db.pessoas.Count(e => e.IdPessoa == id) > 0;
        }
    }
}