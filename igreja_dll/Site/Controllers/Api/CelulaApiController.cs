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
using business.classes.Abstrato;
using repositorioEF;
using RepositorioEF;
using Site.Models.Api;

namespace Site.Controllers.Api
{
    public class CelulaApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/CelulaApi
        public IHttpActionResult Getcelula()
        {
            var celulas = db.celula
                .Include(c => c.Pessoas)
                .Include(c => c.Ministerios);

                List<CelulaApi> lista = new List<CelulaApi>();

            foreach(var item in celulas)
            {
                CelulaApi modelo = new CelulaApi
                {
                    Ministerios = item.Ministerios,
                    Pessoas = item.Pessoas,
                    Dia_semana = item.Dia_semana,
                    EnderecoCelula = item.EnderecoCelula,
                    Horario = item.Horario,
                    IdCelula = item.IdCelula,
                    Maximo_pessoa = item.Maximo_pessoa,
                    Nome = item.Nome
                };
                lista.Add(modelo);
            }

            return Ok(lista);
        }

        // GET: api/CelulaApi/5
        [ResponseType(typeof(Celula))]
        public async Task<IHttpActionResult> GetCelula(int id)
        {
            Celula celula = await db.celula.FindAsync(id);
            if (celula == null)
            {
                return NotFound();
            }

            return Ok(celula);
        }

        // PUT: api/CelulaApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCelula(int id, Celula celula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != celula.IdCelula)
            {
                return BadRequest();
            }

            db.Entry(celula).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelulaExists(id))
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

        // POST: api/CelulaApi
        [ResponseType(typeof(Celula))]
        public async Task<IHttpActionResult> PostCelula(Celula celula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.celula.Add(celula);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = celula.IdCelula }, celula);
        }

        // DELETE: api/CelulaApi/5
        [ResponseType(typeof(Celula))]
        public async Task<IHttpActionResult> DeleteCelula(int id)
        {
            Celula celula = await db.celula.FindAsync(id);
            if (celula == null)
            {
                return NotFound();
            }

            db.celula.Remove(celula);
            await db.SaveChangesAsync();

            return Ok(celula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CelulaExists(int id)
        {
            return db.celula.Count(e => e.IdCelula == id) > 0;
        }
    }
}