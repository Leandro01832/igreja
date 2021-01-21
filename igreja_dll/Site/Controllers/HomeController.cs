using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using repositorioEF;
using Site.Models;
using Site.Models.Repository;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using business.classes.Abstrato;
using business.classes.PessoasLgpd;
using business.classes.Intermediario;
using business.classes;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        readonly ICelulaRepository CelulaRepository;
        private DB banco = new DB();
        ApplicationDbContext db = new ApplicationDbContext();

        public IMinisterioRepository MinisterioRepository { get; }
        public IReuniaoRepository ReuniaoRepository { get; }

        public HomeController(ICelulaRepository celulaRepository, IMinisterioRepository ministerioRepository,
            IReuniaoRepository reuniaoRepository)
        {
            CelulaRepository = celulaRepository;
            MinisterioRepository = ministerioRepository;
            ReuniaoRepository = reuniaoRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Celulas()
        {
            var celulas = CelulaRepository.GetAll();
            return View(celulas.ToList());
        }

        public ActionResult Ministerios()
        {
            var ministerios = MinisterioRepository.GetAll();
            return View(ministerios.ToList());
        }

        public ActionResult Reunioes()
        {
            var reunioes = ReuniaoRepository.GetAll();
            return View(reunioes.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ParticiparCelula(int id)
        {
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = usermaneger.Users.ToList();
            var user = users.FirstOrDefault(u => u.UserName == User.Identity.GetUserName());

            if (user != null)
            {
                var pessoa = banco.pessoas.First(p => p.Codigo == user.Codigo);
                pessoa.celula_ = id;
                db.Entry(pessoa).State = EntityState.Modified;
                banco.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public JsonResult ParticiparMinisterio(int Id)
        {
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = usermaneger.Users.ToList();
            var user = users.FirstOrDefault(u => u.UserName == User.Identity.GetUserName());

            if(user != null)
            {
                Ministerio ministerio = banco.ministerio.Find(Id);
                Pessoa pessoa = banco.pessoas.First(m => m.Codigo == user.Codigo);                
                pessoa = banco.pessoas.Find(pessoa.Id);
                banco.PessoaMinisterio
                .Add(new PessoaMinisterio { Pessoa = pessoa, Ministerio = ministerio });
                banco.SaveChanges();
            }
            return Json("");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ParticiparReuniao(int Id)
        {
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = usermaneger.Users.ToList();
            var user = users.FirstOrDefault(u => u.UserName == User.Identity.GetUserName());

            if (user != null)
            {
                Reuniao reuniao = banco.reuniao.Find(Id);
                Pessoa pessoa = banco.pessoas.First(m => m.Codigo == user.Codigo);
                pessoa = banco.pessoas.Find(pessoa.Id);
                banco.ReuniaoPessoa
                .Add(new ReuniaoPessoa { Pessoa = pessoa, Reuniao = reuniao });
                banco.SaveChanges();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Site da igreja.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contatos da igreja.";
            return View();
        }

    }
}