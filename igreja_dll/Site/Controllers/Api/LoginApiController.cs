using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Linq;
using repositorioEF;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Site.Models.Api;
using RepositorioEF;

namespace Site.Controllers.Api
{
    public class LoginApiController : ApiController
    {

        private DB db = new DB();


        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(JObject form)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var email = string.Empty;
            var password = string.Empty;

            dynamic jsonobeject = form;

            try
            {
                email = jsonobeject.Email.Value;
                password = jsonobeject.Password.Value;
            }

            catch
            {
                return BadRequest("Chamada incorreta, Preencha os campos corretamente.");
            }

            var usercontext = new ApplicationDbContext();
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(usercontext));
            var userASP = usermaneger.Find(email, password);

            if (userASP == null)
            {
                return this.BadRequest("Usuario não encontrado! Dados incorretos!");
            }

            var usuario = db.pessoas.Where(c => c.Email == email).FirstOrDefault();
            var user = db.pessoas
                .Include(p => p.Ministerios)
                .Include(p => p.Celula)
               // .Include(p => p.Chamada)
                .Include(p => p.Historico)
                .Include(p => p.Reuniao)
                .First(p => p.IdPessoa == usuario.IdPessoa);


            if (usuario == null)
            {
                return this.BadRequest("Usuario não encontrado! Dados incorretos!");
            }

            



            PessoaApi PessoaApi = new PessoaApi
            {
                Historico = user.Historico,
                Reuniao = user.Reuniao,
                Chamada = user.Chamada,
                Celula = user.Celula,
                celula_ = user.celula_,
                Codigo = user.Codigo,
                Email = user.Email,
                Falta = user.Falta,
                IdPessoa = user.IdPessoa,
                Ministerios = user.Ministerios,
                Nome = user.NomePessoa
            };

            return this.Ok(PessoaApi);
        }

    }
}
