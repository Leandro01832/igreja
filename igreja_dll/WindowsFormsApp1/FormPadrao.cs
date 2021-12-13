using business;
using database;
using database.banco;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormPadrao : Form
    {
        public FormPadrao()
        {
            InitializeComponent();
        }

        public static string Email;
        public static string SenhaEmail;
        public static string PrimeiroAdminEmail = "leandro123";
        public static string PrimeiroAdminSenha = "sistema123";
        
        public static bool executar = true;

        private BDcomum bd = new BDcomum();
        public static string path = Directory.GetCurrentDirectory();
        

        private void FormPadrao_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon($@"{path}\favicon.ico");
            notifyIcon1.Icon = new Icon($@"{path}\favicon.ico");
        }
        
        public static async void UltimoRegistro()
        {
            FrmAutenticacao form = new FrmAutenticacao();
            form.Show();

            if (executar)
            {
                executar = false;

                FormProgressBar frm = new FormProgressBar();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Text = "Barra de processamento - Processando dados";
                frm.Show();

                var listaTypes = modelocrud.listTypesSon(typeof(modelocrud));
                var lista = listaTypes.Where(e => e.GetProperties()
                .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 0).ToList();
                foreach (var item in lista)
                {
                    var modelo = (modelocrud)Activator.CreateInstance(item);
                    await Task.Run(() => modelo.recuperar(true));
                }

                await Task.Run(() =>
                {
                    while (int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99)
                    { executar = false;  }
                });

                if (!frm.IsDisposed)
                    frm.Dispose();                              
            }

            var appSettings = ConfigurationManager.AppSettings;
            Email = appSettings["Email"];
            SenhaEmail = appSettings["Senha"];

            if (modelocrud.Modelos.OfType<Permissao>().FirstOrDefault() == null)
            {
                var arr = new string[]
                {
                    "EnviarEmail", "LerEmail", "AtualizarEmail", "DeletarEmail", "CadastrarAtualizarBody"
                };

                foreach (var item in arr)
                {
                    var permissao = new Permissao { Nome = item };
                    permissao.stringConexao = BDcomum.conecta1;
                    permissao.salvar();
                    modelocrud.Modelos.Add(permissao);
                    modelocrud.ModelosInseridos.Add(permissao);
                }
            }
        }              

        public static void LoadForm(Form form, string textoSufixo = "", string textoPrefixo = "")
        {
            form.Icon = new Icon($@"{path}\favicon.ico");

            string textoFormulario = modelocrud.formatarTexto(form.GetType().Name);

            if (textoPrefixo != "") textoFormulario = textoPrefixo + " " + textoFormulario;
            if (textoSufixo != "") textoFormulario = textoFormulario + " " + textoSufixo;

            form.Text = textoFormulario;
        }
    }
}
