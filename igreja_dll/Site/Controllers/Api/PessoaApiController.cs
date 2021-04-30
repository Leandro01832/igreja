﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using business.classes.Abstrato;
using repositorioEF;
using RepositorioEF;
using Site.Models.Api;

namespace Site.Controllers.Api
{
    public class PessoaApiController : ApiController
    {
        private DB db = new DB();

        // GET: api/PessoaApi
        [EnableQuery]
        public IQueryable<PessoaApi> Getpessoas()
        {
            var pessoas = db.pessoas.Include(p => p.Ministerios)
                .Include(p => p.Reuniao)
                .Include(p => p.Celula)
                .Include(p => p.Chamada);

            List<PessoaApi> lista = new List<PessoaApi>();

            foreach(var item in pessoas)
            {
                PessoaApi modelo = new PessoaApi
                {
                    Celula = item.Celula,
                    Chamada = item.Chamada,
                    celula_ = item.celula_,
                    Codigo = item.Codigo,
                    Email = item.Email,
                    Falta = item.Falta,
                    Historico = item.Historico,
                    Ministerios = item.Ministerios,
                    Nome = item.NomePessoa,
                    Reuniao = item.Reuniao
                };
                lista.Add(modelo);
            }

            IQueryable<PessoaApi> retorno = lista.AsQueryable();
            return retorno;
        }

        // GET: api/PessoaApi/5
        [HttpGet]
        [ResponseType(typeof(Pessoa))]
        public IHttpActionResult GetPessoa(int id)
        {
            Pessoa pessoa = db.pessoas.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            PessoaApi modelo = new PessoaApi
            {
                Celula = pessoa.Celula,
                Chamada = pessoa.Chamada,
                celula_ = pessoa.celula_,
                Codigo = pessoa.Codigo,
                Email = pessoa.Email,
                Falta = pessoa.Falta,
                Historico = pessoa.Historico,
                Ministerios = pessoa.Ministerios,
                Nome = pessoa.NomePessoa,
                Reuniao = pessoa.Reuniao
            };

            return Ok(modelo);
        }

        // PUT: api/PessoaApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPessoa(int id, Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoa.IdPessoa)
            {
                return BadRequest();
            }

            db.Entry(pessoa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
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

        // POST: api/PessoaApi
        [ResponseType(typeof(Pessoa))]
        public IHttpActionResult PostPessoa(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pessoas.Add(pessoa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pessoa.IdPessoa }, pessoa);
        }

        // DELETE: api/PessoaApi/5
        [ResponseType(typeof(Pessoa))]
        public IHttpActionResult DeletePessoa(int id)
        {
            Pessoa pessoa = db.pessoas.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(pessoa);
            db.SaveChanges();

            return Ok(pessoa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoaExists(int id)
        {
            return db.pessoas.Count(e => e.IdPessoa == id) > 0;
        }
    }
}