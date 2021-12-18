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
using System.Web.Http.OData;
using business.classes;
using business.classes.Abstrato;
using database;
using RepositorioEF;
using Site.Models.Api;

namespace Site.Controllers.Api
{
    public class CelulaApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/CelulaApi
        [EnableQuery]
        public IQueryable<CelulaApi> Getcelula()
        {
            modelocrud.EntityCrud = true;
            var celulas = db.celula
                .Include(c => c.EnderecoCelula)
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
                    Id = item.Id,
                    Maximo_pessoa = item.Maximo_pessoa,
                    Nome = item.Nome
                };
                lista.Add(modelo);
            }

            IQueryable<CelulaApi> retorno = lista.AsQueryable();

            return retorno;
        }

        // GET: api/CelulaApi/5
        [ResponseType(typeof(Celula))]
        public async Task<IHttpActionResult> GetCelula(int id)
        {
            modelocrud.EntityCrud = true;
            Celula item = await db.celula
                .Include(c => c.Pessoas)
                .Include(c => c.Ministerios)
                .FirstAsync(c => c.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            CelulaApi modelo = new CelulaApi
            {
                Ministerios = item.Ministerios,
                Pessoas = item.Pessoas,
                Dia_semana = item.Dia_semana,
                EnderecoCelula = item.EnderecoCelula,
                Horario = item.Horario,
                Id = item.Id,
                Maximo_pessoa = item.Maximo_pessoa,
                Nome = item.Nome
            };

            return Ok(modelo);
        }

        // PUT: api/CelulaApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCelula(int id, Celula celula)
        {
            modelocrud.EntityCrud = true;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != celula.Id)
            {
                return BadRequest();
            }

            db.Entry(celula).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = celula.GetType().Name, IdDado = celula.Id });            

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
            modelocrud.EntityCrud = true;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.celula.Add(celula);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = celula.Id }, celula);
        }

        // DELETE: api/CelulaApi/5
        [ResponseType(typeof(Celula))]
        public async Task<IHttpActionResult> DeleteCelula(int id)
        {
            modelocrud.EntityCrud = true;
            Celula celula = await db.celula.FindAsync(id);
            if (celula == null)
            {
                return NotFound();
            }

            db.celula.Remove(celula);
            await db.SaveChangesAsync();
            db.DadoExcluido.Add(new DadoExcluido { Entidade = celula.GetType().Name, IdDado = id });
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
            return db.celula.Count(e => e.Id == id) > 0;
        }
    }
}