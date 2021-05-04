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
    public class MembroBatismoApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/MembroBatismoApi
        [EnableQuery]
        public IQueryable<Membro_Batismo> GetPessoas()
        {
            return db.pessoas.OfType<Membro_Batismo>();
        }

        // GET: api/MembroBatismoApi/5
        [ResponseType(typeof(Membro_Batismo))]
        public async Task<IHttpActionResult> GetMembro_Batismo(int id)
        {
            Membro_Batismo membro_Batismo = (Membro_Batismo) await db.pessoas.FindAsync(id);
            if (membro_Batismo == null)
            {
                return NotFound();
            }

            return Ok(membro_Batismo);
        }

        // PUT: api/MembroBatismoApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembro_Batismo(int id, Membro_Batismo membro_Batismo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membro_Batismo.IdPessoa)
            {
                return BadRequest();
            }

            db.Entry(membro_Batismo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Membro_BatismoExists(id))
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

        // POST: api/MembroBatismoApi
        [ResponseType(typeof(Membro_Batismo))]
        public async Task<IHttpActionResult> PostMembro_Batismo(Membro_Batismo membro_Batismo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pessoas.Add(membro_Batismo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = membro_Batismo.IdPessoa }, membro_Batismo);
        }

        // DELETE: api/MembroBatismoApi/5
        [ResponseType(typeof(Membro_Batismo))]
        public async Task<IHttpActionResult> DeleteMembro_Batismo(int id)
        {
            Membro_Batismo membro_Batismo = (Membro_Batismo) await db.pessoas.FindAsync(id);
            if (membro_Batismo == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(membro_Batismo);
            await db.SaveChangesAsync();

            return Ok(membro_Batismo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Membro_BatismoExists(int id)
        {
            return db.pessoas.Count(e => e.IdPessoa == id) > 0;
        }
    }
}