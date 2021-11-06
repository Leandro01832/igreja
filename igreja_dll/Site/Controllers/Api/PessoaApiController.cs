using business.classes.Abstrato;
using business.classes.Pessoas;
using RepositorioEF;
using Site.Models.Api;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;

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
                .Include(p => p.Historicos);

            List<PessoaApi> lista = new List<PessoaApi>();

            foreach(var item in pessoas)
            {
                PessoaApi modelo = new PessoaApi
                {
                    Celula = item.Celula,
                    celula_ = item.celula_,
                    Codigo = item.Codigo,
                    Email = item.Email,
                    Falta = item.Falta,
                    Historico = item.Historicos,
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

            return Ok(pessoa);
        }

        // PUT: api/PessoaApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPessoa(int id, Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoa.Id)
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

            return CreatedAtRoute("DefaultApi", new { id = pessoa.Id }, pessoa);
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
            if(pessoa is PessoaDado)
            {
                var p = (PessoaDado)pessoa;
                db.endereco.Remove(p.Endereco);
                db.telefone.Remove(p.Telefone);
            }

            db.Chamadas.Remove(pessoa.Chamada);
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
            return db.pessoas.Count(e => e.Id == id) > 0;
        }
    }
}