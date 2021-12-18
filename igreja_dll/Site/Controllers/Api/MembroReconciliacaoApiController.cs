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
using RepositorioEF;
using business.classes.Pessoas;
using System.Web.Http.OData;
using business.classes;

namespace Site.Controllers.Api
{
    public class MembroReconciliacaoApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/MembroReconciliacaoApi
        [EnableQuery]
        public IQueryable<Membro_Reconciliacao> GetPessoas()
        {
            return db.pessoas.OfType<Membro_Reconciliacao>();
        }

        // GET: api/MembroReconciliacaoApi/5
        [ResponseType(typeof(Membro_Reconciliacao))]
        public async Task<IHttpActionResult> GetMembro_Reconciliacao(int id)
        {
            Membro_Reconciliacao membro_Reconciliacao = (Membro_Reconciliacao) await db.pessoas.FindAsync(id);
            if (membro_Reconciliacao == null)
            {
                return NotFound();
            }

            return Ok(membro_Reconciliacao);
        }

        // PUT: api/MembroReconciliacaoApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembro_Reconciliacao(int id, Membro_Reconciliacao membro_Reconciliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membro_Reconciliacao.Id)
            {
                return BadRequest();
            }

            db.Entry(membro_Reconciliacao).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = membro_Reconciliacao.GetType().Name, IdDado = membro_Reconciliacao.Id });
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Membro_ReconciliacaoExists(id))
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

        // POST: api/MembroReconciliacaoApi
        [ResponseType(typeof(Membro_Reconciliacao))]
        public IHttpActionResult PostMembro_Reconciliacao(Membro_Reconciliacao membro_Reconciliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.pessoas.Add(membro_Reconciliacao);
                db.SaveChanges();
            }
            catch { return BadRequest("Cadastro não realizado"); }
            return CreatedAtRoute("DefaultApi", new { id = membro_Reconciliacao.Id }, membro_Reconciliacao);
        }

        // DELETE: api/MembroReconciliacaoApi/5
        [ResponseType(typeof(Membro_Reconciliacao))]
        public async Task<IHttpActionResult> DeleteMembro_Reconciliacao(int id)
        {
            Membro_Reconciliacao membro_Reconciliacao = (Membro_Reconciliacao) await db.pessoas.FindAsync(id);
            if (membro_Reconciliacao == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(membro_Reconciliacao);
            await db.SaveChangesAsync();
            db.DadoExcluido.Add(new DadoExcluido { Entidade = membro_Reconciliacao.GetType().Name, IdDado = id });
            await db.SaveChangesAsync();

            return Ok(membro_Reconciliacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Membro_ReconciliacaoExists(int id)
        {
            return db.pessoas.Count(e => e.Id == id) > 0;
        }
    }
}