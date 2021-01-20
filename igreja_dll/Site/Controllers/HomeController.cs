using Site.Models.Repository;
using System.Linq;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        readonly ICelulaRepository CelulaRepository;

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

        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ParticiparCelula(int id)
        {

            var celulas = CelulaRepository.GetAll();
            return View(celulas.ToList());
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ParticiparMinisterio(int id)
        {
            var celulas = CelulaRepository.GetAll();
            return View(celulas.ToList());
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ParticiparReuniao(int id)
        {
            var celulas = CelulaRepository.GetAll();
            return View(celulas.ToList());
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