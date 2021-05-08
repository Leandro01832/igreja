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

namespace Site.Controllers.Api
{
    public class CriancaLgpdApiController : ApiController
    {
        private DB db = new DB();
        ApplicationDbContext banco = new ApplicationDbContext();

        // GET: api/CriancaLgpdApi
        public IQueryable<CriancaLgpd> GetPessoas()
        {
            return db.pessoas.OfType<CriancaLgpd>();
        }

        // GET: api/CriancaLgpdApi/5
        [ResponseType(typeof(CriancaLgpd))]
        public async Task<IHttpActionResult> GetCriancaLgpd(int id)
        {
            CriancaLgpd criancaLgpd = (CriancaLgpd) await db.pessoas.FindAsync(id);
            if (criancaLgpd == null)
            {
                return NotFound();
            }

            return Ok(criancaLgpd);
        }

        // PUT: api/CriancaLgpdApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCriancaLgpd(int id, CriancaLgpd criancaLgpd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != criancaLgpd.IdPessoa)
            {
                return BadRequest();
            }

            db.Entry(criancaLgpd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriancaLgpdExists(id))
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

        [ResponseType(typeof(CriancaLgpd))]
        [Route("CriancaCadastroApi")]
        public IHttpActionResult PostCriancaCadastro(CriancaLgpd crianca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                crianca.salvar();
            }
            catch { return this.BadRequest("Usuario não cadastrado!!!"); }
            return CreatedAtRoute("DefaultApi", new { id = crianca.IdPessoa }, crianca);
        }

        // POST: api/CriancaLgpdApi
        [ResponseType(typeof(CriancaLgpd))]
        public IHttpActionResult PostCriancaLgpd(CriancaLgpd crianca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                crianca.salvar();
            }
            catch { return this.BadRequest("Usuario não cadastrado!!!"); }

            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(banco));
            var user = new ApplicationUser { UserName = crianca.Email, Email = crianca.Email, Codigo = crianca.Codigo };
            var result = usermaneger.Create(user, crianca.password);
            if (!result.Succeeded)
            {
                crianca.excluir(crianca.IdPessoa);
                return this.BadRequest("Usuario não cadastrado!!!");
            }

            return CreatedAtRoute("DefaultApi", new { id = crianca.IdPessoa }, crianca);
        }

        // DELETE: api/CriancaLgpdApi/5
        [ResponseType(typeof(CriancaLgpd))]
        public async Task<IHttpActionResult> DeleteCriancaLgpd(int id)
        {
            CriancaLgpd criancaLgpd = (CriancaLgpd) await db.pessoas.FindAsync(id);
            if (criancaLgpd == null)
            {
                return NotFound();
            }

            db.pessoas.Remove(criancaLgpd);
            await db.SaveChangesAsync();

            return Ok(criancaLgpd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CriancaLgpdExists(int id)
        {
            return db.pessoas.Count(e => e.IdPessoa == id) > 0;
        }
    }
}