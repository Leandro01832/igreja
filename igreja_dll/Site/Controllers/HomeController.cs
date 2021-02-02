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
using business.classes.Ministerio;
using RepositorioEF;

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
                var lista = Pessoa.recuperarTodos();
                var pe = lista.OfType<Pessoa>().First(p => p.Codigo == user.Codigo);
                pe = (Pessoa)pe.recuperar(pe.IdPessoa)[0];
                pe.celula_ = id;
                pe.alterar(pe.IdPessoa);
            }
            ViewBag.mensagem = "Parabêns você esta participando da celula!!!";
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ParticiparMinisterio(int Id)
        {
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = usermaneger.Users.ToList();
            var user = users.FirstOrDefault(u => u.UserName == User.Identity.GetUserName());

            if(user != null)
            {
                Pessoa pessoa = banco.pessoas.First(m => m.Codigo == user.Codigo);
                Ministerio ministerio = banco.ministerio.Find(Id);
                ministerio.RemoverDaLista("PessoaMinisterio", ministerio, new VisitanteLgpd(), pessoa.IdPessoa + ", ");

                ministerio.alterar(Id);
            }

            ViewBag.mensagem = "Parabêns você esta participando do ministério!!!";

            return View("Index");
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
                Pessoa pessoa = banco.pessoas.First(m => m.Codigo == user.Codigo);
                Reuniao reuniao = banco.reuniao.Find(Id);
                reuniao.RemoverDaLista("ReuniaoPessoa", reuniao, new VisitanteLgpd(), pessoa.IdPessoa + ", ");

                reuniao.alterar(Id);
            }

            ViewBag.mensagem = "Parabêns você esta participando da reunião!!!";

            return View("Index");
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