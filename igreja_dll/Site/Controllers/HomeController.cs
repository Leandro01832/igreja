using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Site.Models;
using Site.Models.Repository;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using business.classes.Abstrato;
using business.classes.PessoasLgpd;
using business.classes.Intermediario;
using business.classes;
using RepositorioEF;
using System.Threading.Tasks;
using Ecommerce.Classes;
using business.classes.Pessoas;

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
                var pe = banco.pessoas.First(p => p.Codigo == user.Codigo);
                pe.celula_ = id;
                pe.alterar(pe.Id);
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
                PessoaMinisterio pm = new PessoaMinisterio { PessoaId = pessoa.Id, MinisterioId = ministerio.Id };
                pm.salvar();
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
                ReuniaoPessoa rp = new ReuniaoPessoa { PessoaId = pessoa.Id, ReuniaoId = reuniao.Id };
                rp.salvar();
            }

            ViewBag.mensagem = "Parabêns você esta participando da reunião!!!";

            return View("Index");
        }
        

        [Authorize]
        public async Task<ActionResult> Perfil()
        {
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = usermaneger.Users.ToList();
            var user = users.FirstOrDefault(u => u.UserName == User.Identity.GetUserName());
            var pessoa = await banco.pessoas.FirstAsync(p => p.Email == user.Email);

            var tipo = "";

            if (pessoa is PessoaLgpd)
                tipo = "PessoaLgpd";
            else if (pessoa is PessoaDado)
                tipo = "PessoaDado";

            ViewBag.perfil = tipo;

            ViewBag.Message = "Site da igreja.";
            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Perfil(int? id)
        {
            string email = User.Identity.GetUserName();
            Pessoa pessoa =  banco.pessoas.Include(p => p.Chamada).First(c => c.Email == email);

                    

                if (Request.Files[0] != null)
                {
                    var pic = string.Empty;
                    var folder = "/Content/Imagens";
                    var file = string.Format("{0}.jpg", pessoa.Id);

                    var response = FileHelpers.UploadPhoto(Request.Files[0], folder, file);
                    if (response)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        pessoa.Img = pic;
                    }

                banco.Entry(pessoa).State = EntityState.Modified;
                banco.Entry(pessoa.Chamada).State = EntityState.Modified;
                banco.SaveChanges();
            }

                

                return View("Perfil", pessoa);
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
        
        [Authorize]
        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(RegisterViewModel model)
        {
            var user =  User.Identity.GetUserName();
            var pessoa =  banco.pessoas.Include(i => i.Chamada).First(i => i.Email == user);            

            Pessoa p = null;

            if (pessoa is PessoaLgpd)
            {
                if (model.MembroAclamacao) p = new Membro_Aclamacao();
                if (model.MembroBatismo) p = new Membro_Batismo();
                if (model.MembroReconciliacao) p = new Membro_Reconciliacao();
                if (model.MembroTransferencia) p = new Membro_Transferencia();
                if (model.Visitante) p = new Visitante();
                if (model.Crianca) p = new Crianca();
            }
            else if (pessoa is PessoaDado)
            {
                if (model.MembroAclamacao) p = new Membro_AclamacaoLgpd();
                if (model.MembroBatismo) p = new Membro_BatismoLgpd();
                if (model.MembroReconciliacao) p = new Membro_ReconciliacaoLgpd();
                if (model.MembroTransferencia) p = new Membro_TransferenciaLgpd();
                if (model.Visitante) p = new VisitanteLgpd();
                if (model.Crianca) p = new CriancaLgpd();
            }

            


            ViewBag.celula_ = new SelectList(banco.celula.ToList(), "Id", "Nome");

            return View("CadastrarPerfil", p);
        }

        [Authorize]
        public ActionResult CadastrarPerfil(Pessoa p)
        {
            return View(p);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crianca(Crianca pes)
        {
           var result =  await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else  return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CriancaLgpd(CriancaLgpd pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MembroAclamacao(Membro_Aclamacao pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MembroAclamacaoLgpd(Membro_AclamacaoLgpd pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Visitante(Visitante pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VisitanteLgpd(VisitanteLgpd pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MembroReconciliacao(Membro_Reconciliacao pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MembroReconciliacaoLgpd(Membro_ReconciliacaoLgpd pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MembroTransferencia(Membro_Transferencia pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MembroTransferenciaLgpd(Membro_TransferenciaLgpd pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MembroBatismo(Membro_Batismo pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MembroBatismoLgpd(Membro_BatismoLgpd pes)
        {
            var result = await NovoPerfil(pes);
            if (result) return View("Perfil", pes);
            else return View(pes);
        }

        public async Task<bool> NovoPerfil(Pessoa pes)
        {
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = usermaneger.Users.ToList();
            var user = users.FirstOrDefault(u => u.UserName == User.Identity.GetUserName());
            var pessoa = await banco.pessoas.FirstAsync(p => p.Email == user.Email);
            try
            {
                pes.Chamada = new Chamada();
                pes.Chamada.Data_inicio = pessoa.Chamada.Data_inicio;
                pes.Chamada.Numero_chamada = pessoa.Chamada.Numero_chamada;
                pes.Email = pessoa.Email;

                pes.MudarEstado(pessoa.Id, pes);
                var tipo = "";

                if (pes is PessoaLgpd)
                    tipo = "PessoaLgpd";
                else if (pes is PessoaDado)
                    tipo = "PessoaDado";

                ViewBag.perfil = tipo;
                return true;
            }
            catch { return false; }             
        }

    }
}