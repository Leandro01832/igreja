﻿using System;
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
    public class MinisterioApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/MinisterioApi
        public IHttpActionResult Getministerio()
        {
            var ministerios = db.ministerio
                .Include(m => m.Pessoas)
                .Include(m => m.Celulas);

            List<MinisterioApi> lista = new List<MinisterioApi>();

            foreach(var item in ministerios)
            {
                MinisterioApi modelo = new MinisterioApi
                {
                    Celulas = item.Celulas,
                    Pessoas = item.Pessoas,
                    IdMinisterio = item.IdMinisterio,
                    Maximo_pessoa = item.Maximo_pessoa,
                    Ministro_ = item.Ministro_,
                    Nome = item.Nome,
                    Proposito = item.Proposito
                };
                lista.Add(modelo);
            }

            return Ok(lista);
        }

        // GET: api/MinisterioApi/5
        [ResponseType(typeof(Ministerio))]
        public async Task<IHttpActionResult> GetMinisterio(int id)
        {
            Ministerio ministerio = await db.ministerio.FindAsync(id);
            if (ministerio == null)
            {
                return NotFound();
            }

            return Ok(ministerio);
        }

        // PUT: api/MinisterioApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMinisterio(int id, Ministerio ministerio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ministerio.IdMinisterio)
            {
                return BadRequest();
            }

            db.Entry(ministerio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinisterioExists(id))
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

        // POST: api/MinisterioApi
        [ResponseType(typeof(Ministerio))]
        public async Task<IHttpActionResult> PostMinisterio(Ministerio ministerio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ministerio.Add(ministerio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ministerio.IdMinisterio }, ministerio);
        }

        // DELETE: api/MinisterioApi/5
        [ResponseType(typeof(Ministerio))]
        public async Task<IHttpActionResult> DeleteMinisterio(int id)
        {
            Ministerio ministerio = await db.ministerio.FindAsync(id);
            if (ministerio == null)
            {
                return NotFound();
            }

            db.ministerio.Remove(ministerio);
            await db.SaveChangesAsync();

            return Ok(ministerio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MinisterioExists(int id)
        {
            return db.ministerio.Count(e => e.IdMinisterio == id) > 0;
        }
    }
}