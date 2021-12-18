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
using business.classes.PessoasLgpd;
using Site.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using database.banco;
using business.classes.Abstrato;
using database;
using business.classes;

namespace Site.Controllers.Api
{
    public class MembroAclamacaoLgpdApiController : ApiController
    {
        private DB db = new DB();
        ApplicationDbContext banco = new ApplicationDbContext();

        // GET: api/MembroAclamacaoLgpdApi
        public IQueryable<Membro_AclamacaoLgpd> GetPessoas()
        {
            return db.pessoas.OfType<Membro_AclamacaoLgpd>();
        }

        // GET: api/MembroAclamacaoLgpdApi/5
        [ResponseType(typeof(Membro_AclamacaoLgpd))]
        public async Task<IHttpActionResult> GetMembro_AclamacaoLgpd(int id)
        {
            Membro_AclamacaoLgpd membro_AclamacaoLgpd = (Membro_AclamacaoLgpd) await db.pessoas.FindAsync(id);
            if (membro_AclamacaoLgpd == null)
            {
                return NotFound();
            }

            return Ok(membro_AclamacaoLgpd);
        }

        // PUT: api/MembroAclamacaoLgpdApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembro_AclamacaoLgpd(int id, Membro_AclamacaoLgpd membro_AclamacaoLgpd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membro_AclamacaoLgpd.Id)
            {
                return BadRequest();
            }

            db.Entry(membro_AclamacaoLgpd).State = EntityState.Modified;
            db.DadoAlterado.Add(new DadoAlterado { Entidade = membro_AclamacaoLgpd.GetType().Name, IdDado = membro_AclamacaoLgpd.Id });
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Membro_AclamacaoLgpdExists(id))
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

        [ResponseType(typeof(Membro_AclamacaoLgpd))]
        [Route("MembroAclamacaoCadastroApi")]
        public IHttpActionResult PostMembro_AclamacaoCadastro(Membro_AclamacaoLgpd membro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.pessoas.Add(membro);
                db.SaveChanges();
            }
            catch { return this.BadRequest("Usuario não cadastrado!!!"); }
            return CreatedAtRoute("DefaultApi", new { id = membro.Id }, membro);
        }

        // POST: api/MembroAclamacaoLgpdApi
        [ResponseType(typeof(Membro_AclamacaoLgpd))]
        public IHttpActionResult PostMembro_AclamacaoLgpd(Membro_AclamacaoLgpd membro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ultimoRegistro = modelocrud.GetUltimoRegistro(typeof(Pessoa), BDcomum.conecta2);
            var Cod = ultimoRegistro + 1;

            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(banco));
            var user = new ApplicationUser { UserName = membro.Email, Email = membro.Email, Codigo = Cod };
            var result = usermaneger.Create(user, membro.password);
            if (!result.Succeeded)
            {
                return this.BadRequest("Usuario não cadastrado!!!");
            }
            membro.Codigo = Cod;
            db.pessoas.Add(membro);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = membro.Id }, membro);
        }

        // DELETE: api/MembroAclamacaoLgpdApi/5
        [ResponseType(typeof(Membro_AclamacaoLgpd))]
        public async Task<IHttpActionResult> DeleteMembro_AclamacaoLgpd(int id)
        {
            Membro_AclamacaoLgpd membro_AclamacaoLgpd = (Membro_AclamacaoLgpd)await db.pessoas.FindAsync(id);
            if (membro_AclamacaoLgpd == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(membro_AclamacaoLgpd);
            await db.SaveChangesAsync();
            db.DadoExcluido.Add(new DadoExcluido { Entidade = membro_AclamacaoLgpd.GetType().Name, IdDado = id });
            await db.SaveChangesAsync();

            return Ok(membro_AclamacaoLgpd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Membro_AclamacaoLgpdExists(int id)
        {
            return db.pessoas.Count(e => e.Id == id) > 0;
        }
    }
}