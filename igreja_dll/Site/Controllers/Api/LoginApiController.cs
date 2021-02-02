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

            var usuario = db.pessoas.Where(c => c.Email == email)
                .Include(usu => usu.Ministerios)
                .Include(usu => usu.Celula)
                .Include(usu => usu.Chamada)
                .Include(usu => usu.Reuniao)
                .Include(usu => usu.Historico)
                .FirstOrDefault();


            if (usuario == null)
            {
                return this.BadRequest("Usuario não encontrado! Dados incorretos!");
            }

            usuario = db.pessoas.Where(c => c.Email == email)
               .Include(usu => usu.Ministerios)
                .Include(usu => usu.Celula)
                .Include(usu => usu.Chamada)
                .Include(usu => usu.Reuniao)
                .Include(usu => usu.Historico)
               .FirstOrDefault();



            PessoaApi PessoaApi = new PessoaApi
            {
                Historico = usuario.Historico,
                Reuniao = usuario.Reuniao,
                Chamada = usuario.Chamada,
                Celula = usuario.Celula,
                celula_ = usuario.celula_,
                Codigo = usuario.Codigo,
                Email = usuario.Email,
                Falta = usuario.Falta,
                IdPessoa = usuario.IdPessoa,
                Ministerios = usuario.Ministerios,
                Nome = usuario.NomePessoa
            };

            return this.Ok(PessoaApi);
        }

    }
}
