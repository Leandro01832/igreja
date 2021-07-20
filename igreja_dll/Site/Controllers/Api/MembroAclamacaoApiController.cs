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
    public class MembroAclamacaoApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/MembroAclamacaoApi
        [EnableQuery]
        public IQueryable<Membro_Aclamacao> GetPessoas()
        {
            return db.pessoas.OfType<Membro_Aclamacao>();
        }

        // GET: api/MembroAclamacaoApi/5
        [ResponseType(typeof(Membro_Aclamacao))]
        public async Task<IHttpActionResult> GetMembro_Aclamacao(int id)
        {
            Membro_Aclamacao membro_Aclamacao = (Membro_Aclamacao) await db.pessoas.FindAsync(id);
            if (membro_Aclamacao == null)
            {
                return NotFound();
            }

            return Ok(membro_Aclamacao);
        }

        // PUT: api/MembroAclamacaoApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembro_Aclamacao(int id, Membro_Aclamacao membro_Aclamacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membro_Aclamacao.Id)
            {
                return BadRequest();
            }

            db.Entry(membro_Aclamacao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Membro_AclamacaoExists(id))
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

        // POST: api/MembroAclamacaoApi
        [ResponseType(typeof(Membro_Aclamacao))]
        public IHttpActionResult PostMembro_Aclamacao(Membro_Aclamacao membro_Aclamacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                membro_Aclamacao.salvar();
            }
            catch { return BadRequest("Cadastro não realizado"); }
            return CreatedAtRoute("DefaultApi", new { id = membro_Aclamacao.Id }, membro_Aclamacao);
        }

        // DELETE: api/MembroAclamacaoApi/5
        [ResponseType(typeof(Membro_Aclamacao))]
        public async Task<IHttpActionResult> DeleteMembro_Aclamacao(int id)
        {
            Membro_Aclamacao membro_Aclamacao = (Membro_Aclamacao) await db.pessoas.FindAsync(id);
            if (membro_Aclamacao == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(membro_Aclamacao);
            await db.SaveChangesAsync();

            return Ok(membro_Aclamacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Membro_AclamacaoExists(int id)
        {
            return db.pessoas.Count(e => e.Id == id) > 0;
        }
    }
}