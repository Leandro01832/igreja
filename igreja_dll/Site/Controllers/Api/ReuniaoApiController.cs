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
using business.classes;
using System.Web.Http.OData;
using Site.Models.Api;

namespace Site.Controllers.Api
{
    public class ReuniaoApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/ReuniaoApi
        [EnableQuery]
        public IQueryable<ReuniaoApi> Getreuniao()
        {
            var Reunioes = db.reuniao.Include(e => e.Pessoas);

            List<ReuniaoApi> lista = new List<ReuniaoApi>();

            foreach (var item in Reunioes)
            {
                ReuniaoApi modelo = new ReuniaoApi
                {
                    Data_reuniao = item.Data_reuniao,
                    Pessoas = item.Pessoas,
                    Horario_fim = item.Horario_fim,
                    Horario_inicio = item.Horario_inicio,
                    Id = item.Id,
                    Local_reuniao = item.Local_reuniao
                };
                lista.Add(modelo);
            }

            IQueryable<ReuniaoApi> retorno = lista.AsQueryable();

            return retorno;
        }

        // GET: api/ReuniaoApi/5
        [ResponseType(typeof(Reuniao))]
        public async Task<IHttpActionResult> GetReuniao(int id)
        {
            Reuniao reuniao = await db.reuniao.FindAsync(id);
            if (reuniao == null)
            {
                return NotFound();
            }

            return Ok(reuniao);
        }

        // PUT: api/ReuniaoApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReuniao(int id, Reuniao reuniao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reuniao.Id)
            {
                return BadRequest();
            }

            db.Entry(reuniao).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = reuniao.GetType().Name, IdDado = reuniao.Id });
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReuniaoExists(id))
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

        // POST: api/ReuniaoApi
        [ResponseType(typeof(Reuniao))]
        public async Task<IHttpActionResult> PostReuniao(Reuniao reuniao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.reuniao.Add(reuniao);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reuniao.Id }, reuniao);
        }

        // DELETE: api/ReuniaoApi/5
        [ResponseType(typeof(Reuniao))]
        public async Task<IHttpActionResult> DeleteReuniao(int id)
        {
            Reuniao reuniao = await db.reuniao.FindAsync(id);
            if (reuniao == null)
            {
                return NotFound();
            }

            db.reuniao.Remove(reuniao);
            await db.SaveChangesAsync();
            db.DadoExcluido.Add(new DadoExcluido { Entidade = reuniao.GetType().Name, IdDado = id });
            await db.SaveChangesAsync();

            return Ok(reuniao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReuniaoExists(int id)
        {
            return db.reuniao.Count(e => e.Id == id) > 0;
        }
    }
}