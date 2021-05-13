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
using System.Threading.Tasks;
using database;
using business.classes.PessoasLgpd;
using business.classes.Abstrato;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Http.Description;

namespace Site.Controllers.Api
{
    public class LoginApiController : ApiController
    {

        private DB db = new DB();
        ApplicationDbContext banco = new ApplicationDbContext();


        [HttpPost]
        [Route("Login")]
        public async Task<IHttpActionResult> Login(JObject form)
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
            var userASP = await usermaneger.FindAsync(email, password);

            if (userASP == null)
            {
                return this.BadRequest("Usuario não encontrado! Dados incorretos!");
            }

            var usuario = await db.pessoas.Where(c => c.Email == email).FirstOrDefaultAsync();
            var user = await db.pessoas
            .Include(p => p.Ministerios)
            .Include(p => p.Celula)
            .Include(p => p.Chamada)
            .Include(p => p.Historico)
            .Include(p => p.Reuniao)
            .Include(x => x.Reuniao.Select(y => y.Pessoa))
            .Include(x => x.Reuniao.Select(y => y.Reuniao))
            .FirstAsync(p => p.IdPessoa == usuario.IdPessoa);

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
                Nome = user.NomePessoa,
                Img = user.Img
            };

            return this.Ok(PessoaApi);
        }

        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(JObject form)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ProxyCreationEnabled = false;
                var email = string.Empty;
                var password = string.Empty;
                bool MembroAclamacao;
                bool MembroTransferencia;
                bool MembroReconciliacao;
                bool MembroBatismo;
                bool Visitante;
                bool Crianca;

                dynamic jsonobeject = form;

                try
                {
                    email = jsonobeject.Email.Value;
                    password = jsonobeject.Password.Value;
                    MembroAclamacao = jsonobeject.MembroAclamacao.Value;
                    Visitante = jsonobeject.Visitante.Value;
                    Crianca = jsonobeject.Crianca.Value;
                    MembroReconciliacao = jsonobeject.MembroReconciliacao.Value;
                    MembroTransferencia = jsonobeject.MembroTransferencia.Value;
                    MembroBatismo = jsonobeject.MembroBatismo.Value;
                }

                catch
                {
                    return BadRequest("Chamada incorreta, Preencha os campos corretamente.");
                }

                modelocrud m = null;
                if (Crianca)
                    m = new CriancaLgpd();
                if (Visitante)
                {
                    m = new VisitanteLgpd();
                    var v = (VisitanteLgpd)m;
                    v.Data_visita = DateTime.Now;
                    v.Condicao_religiosa = "Não registrado";
                }

                if (MembroAclamacao)
                    m = new Membro_AclamacaoLgpd();
                if (MembroBatismo)
                    m = new Membro_BatismoLgpd();
                if (MembroReconciliacao)
                    m = new Membro_ReconciliacaoLgpd();
                if (MembroTransferencia)
                    m = new Membro_TransferenciaLgpd();

                var p = (Pessoa)m;
                try
                {
                    p.Email = email;
                    p.NomePessoa = " - ";
                   // p.salvar();
                }
                catch { return this.BadRequest("Usuario não cadastrado!!!"); }


                var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(banco));
                var user = new ApplicationUser { UserName = email, Email = email, Codigo = p.Codigo };
                var result =  usermaneger.Create(user, password);
                if (result.Succeeded)
                {
                    return Ok();
                }

                p.excluir(p.IdPessoa);

                return this.BadRequest("Usuario não cadastrado! Usuario ja existente!!!");
            }
            
            return this.BadRequest("Usuario não cadastrado! Dados incorretos!");
        }

        

    }
}
