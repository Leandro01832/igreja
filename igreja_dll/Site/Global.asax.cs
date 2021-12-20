using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using Site.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RepositorioEF;
using business.classes.Pessoas;
using Ecommerce.Classes;
using business.classes.PessoasLgpd;

namespace Site
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RepositorioEF.DB, RepositorioEF.Migrations.Configuration>());
            ApplicationDbContext db = new ApplicationDbContext();
            checkedRolesAndSuperUser();
           // criaroles(db);
            criarsuperuser(db);
           // AddPermissoesSuperUser(db);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           UnityConfig.RegistraComponentes();
        }

        private void checkedRolesAndSuperUser()
        {
            UserHelper.UsersHelper.CheckRole("Admin");
            UserHelper.UsersHelper.CheckRole("User");
            UserHelper.UsersHelper.CheckSuperUser();
        }

        private async void criarUsuario(DB banco)
        {
            banco.pessoas.Add(new VisitanteLgpd
            {
                celula_ = null,
                Chamada = new business.classes.Chamada
                {
                    Data_inicio = DateTime.Now,
                    Numero_chamada = 0
                },
                Imagem = "",
                Historicos = new List<business.classes.Historico>(),
                Ministerio = new List<business.classes.Intermediario.PessoaMinisterio>(),
                Nome = "",
                Condicao_religiosa = " - ",
                Data_visita = DateTime.Now,
                Email = "leandroleanleo@gmail.com",
                Falta = 0,
                Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>()
            });
            await banco.SaveChangesAsync();
        }

        private void criarsuperuser(ApplicationDbContext db)
        {
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = usermaneger.FindByName("leandroleanleo@gmail.com");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "leandroleanleo@gmail.com",
                    Email = "leandroleanleo@gmail.com"
                };

                usermaneger.Create(user, "Manequim1991");
            }



            DB banco = new DB();
            if (banco.pessoas.FirstOrDefault(u => u.Email == "leandroleanleo@gmail.com") == null)
                criarUsuario(banco);

        }
    }
}
