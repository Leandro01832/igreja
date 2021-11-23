using business;
using business.classes.Abstrato;
using business.classes.Esboco.Abstrato;
using business.classes.financeiro;
using database;
using database.banco;
using System;
using System.Collections.Generic;
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
               

        private static bool verificarLista = true;
        private static bool podeVerificar = false;
        public static bool executar = true;
        private static bool verificarTimer = true;

        private BDcomum bd = new BDcomum();
        public static string path = Directory.GetCurrentDirectory();

        Timer timer;

        private void FormPadrao_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon($@"{path}\favicon.ico");
            notifyIcon1.Icon = new Icon($@"{path}\favicon.ico");
            timer = new Timer();
            timer.Interval = 60000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

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
                foreach(var item in listaTypes.Where(e => e.BaseType == typeof(modelocrud)))
                {
                    var modelo = (modelocrud) Activator.CreateInstance(item);
                    await Task.Run(() => modelo.recuperar());
                }

                await Task.Run(() => Celula.recuperarTodasCelulas());

                 await Task.Run(() => Ministerio.recuperarTodosMinisterios());                

                 await Task.Run(() => Pessoa.recuperarTodos());                

                 await Task.Run(() => Movimentacao.recuperarTodos());

                 await Task.Run(() => Fonte.recuperarTodasFontes());

                var models = modelocrud.Modelos;

                await Task.Run(() =>
                {
                    while (int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99)
                    { executar = false; podeVerificar = false; }
                });

               // await Task.Run(() => modelocrud.buscarListas());


                if (!frm.IsDisposed)
                    frm.Dispose();

                executar = true; podeVerificar = true;
            }
                        
            var appSettings = ConfigurationManager.AppSettings;
            Email = appSettings["Email"];
            SenhaEmail = appSettings["Senha"];
                       
            if (modelocrud.Modelos.OfType<Permissao>().FirstOrDefault() == null)
            {
                var arr = new string[]
                {
                    "EnviarEmail", "LerEmail", "AtualizarEmail", "DeletarEmail", "CadastrarAtualizarBody",
                    "CadastrarPessoa", "AtulizarPessoa", "BuscarPessoa", "DeletarPessoa"
                };

                foreach (var item in arr)
                {
                    var permissao = new Permissao { Nome = item };
                    permissao.salvar();
                    modelocrud.Modelos.Add(permissao);
                }
            }
        }

        private async void verifica()
        {
            if (verificarLista && podeVerificar && BDcomum.podeAbrir)
            {
                verificarLista = false;
                await verificarListagem();
                verificarLista = true;
            }
        }

        private async Task verificarListagem()
        {
            try
            {
                if (modelocrud.TotalRegistro(typeof(Ministerio)) != modelocrud.Modelos.OfType<Ministerio>().ToList().Count)
                {
                    FormProgressBar2 form = new FormProgressBar2();

                    form.MdiParent = this.MdiParent;
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Text = "Barra de processamento - Ministerios";
                    form.Show();
                    await Task.Run(() => recuperarRegistrosMinisterio(bd.GetUltimoRegistroMinisterio()));

                    if (!form.IsDisposed)
                        form.Dispose();

                    Ministerio.UltimoRegistro = modelocrud.Modelos.OfType<Ministerio>().ToList().OrderBy(m => m.Id).Last().Id;
                }
            }
            catch { }

            try
            {
                if (modelocrud.TotalRegistro(typeof(Celula)) != modelocrud.Modelos.OfType<Celula>().ToList().Count)
                {
                    FormProgressBar2 form = new FormProgressBar2();

                    form.MdiParent = this.MdiParent;
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Text = "Barra de processamento - Celulas";
                    form.Show();
                    await Task.Run(() => recuperarRegistrosCelula(bd.GetUltimoRegistroCelula()));

                    if (!form.IsDisposed)
                        form.Dispose();

                    Celula.UltimoRegistro = modelocrud.Modelos.OfType<Celula>().ToList().OrderBy(m => m.Id).Last().Id;
                }
            }
            catch { }

            try
            {
                if (modelocrud.TotalRegistro(typeof(Pessoa)) != modelocrud.Modelos.OfType<Pessoa>().ToList().Count)
                {
                    FormProgressBar2 form = new FormProgressBar2();

                    form.MdiParent = this.MdiParent;
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Text = "Barra de processamento - Pessoas";
                    form.Show();
                    await Task.Run(() => recuperarRegistrosPessoa(bd.GetUltimoRegistroPessoa()));

                    if (!form.IsDisposed)
                        form.Dispose();

                    Pessoa.UltimoRegistro = modelocrud.Modelos.OfType<Pessoa>().ToList().OrderBy(m => m.Id).Last().Codigo;
                }
            }
            catch { }
        }

        private void recuperarRegistrosPessoa(int v1)
        {
            var v2 = v1 + 10;
            while (v1 <= v2)
            {
                if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(i => i.Id == v1) == null)
                {
                    Pessoa m = null;
                    var listaTypes = modelocrud.listTypesSon(typeof(Pessoa));
                    foreach (var i in listaTypes)
                    {
                        m = (Pessoa)Activator.CreateInstance(i);
                        if (m.recuperar(v1))
                            modelocrud.Modelos.Add(m);
                    }
                }

                v1++;
            }
        }

        private void recuperarRegistrosCelula(int v1)
        {
            var v2 = v1 + 10;
            while (v1 <= v2)
            {
                if (modelocrud.Modelos.OfType<Celula>().ToList().FirstOrDefault(i => i.Id == v1) == null)
                {
                    Celula m = null;
                    var listaTypes = modelocrud.listTypesSon(typeof(Celula));
                    foreach (var i in listaTypes)
                    {
                        m = (Celula)Activator.CreateInstance(i);
                        if (m.recuperar(v1))
                            modelocrud.Modelos.Add(m);
                    }
                }
                v1++;
            }
        }

        private void recuperarRegistrosMinisterio(int v1)
        {
            var v2 = v1 + 10;
            while (v1 <= v2)
            {
                if (modelocrud.Modelos.OfType<Ministerio>().ToList().FirstOrDefault(i => i.Id == v1) == null)
                {
                    Ministerio m = null;
                    var listaTypes = modelocrud.listTypesSon(typeof(Ministerio));
                    foreach (var i in listaTypes)
                    {
                        m = (Ministerio)Activator.CreateInstance(i);
                        if(m.recuperar(v1))
                        modelocrud.Modelos.Add(m);
                    }
                }
                v1++;
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (verificarTimer)
            {
                verificarTimer = false;
                verifica();
                

                if (int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99)
                    await Task.Run(() => modelocrud.calcularPorcentagem());

                verificarTimer = true;
            }

           // if (this is FormularioListView && Width < 150)
           //     Width = 470;
        }

        public static async Task<List<modelocrud>> AtualizarComModelo(Type Tipo)
        {
            modelocrud modelo = retornaModelo(Tipo);
            var retorno = await Task.Run(() => modelo.recuperar());

            if (retorno)
            {
                return RetornaModelos(modelo);
            }

            return new List<modelocrud>();
        }

        public static async Task<List<modelocrud>> AtualizarComProgressBar(Type Tipo)
        {
            bool condicao = false;

            if (modelocrud.Modelos.Where(m => m.GetType() == Tipo).ToList().Count == 0)
                condicao = true;

            if (condicao)
            {
                var modelo = retornaModelo(Tipo);
                FormProgressBar2 form = new FormProgressBar2();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Text = $"Barra de processamento - {modelo.GetType().Name}";
                form.Show();
                var retorno = await Task.Run(() => modelo.recuperar());

                if (!form.IsDisposed)
                    form.Dispose();

                if (!modelocrud.Erro_Conexao)
                {
                    if (retorno)
                    {
                        return RetornaModelos(modelo);
                    }
                }
            }
            return null;
        }

        private static modelocrud retornaModelo(Type tipo)
        {
            var listaTypes = modelocrud.listTypesSon(typeof(modelocrud));
            foreach (var i in listaTypes)
                if (tipo == i)
                    return (modelocrud)Activator.CreateInstance(i);

            return null;
        }

        private static List<modelocrud> RetornaModelos(modelocrud modelo)
        {
            var listaTypes = modelocrud.listTypesSon(typeof(modelocrud));
            foreach (var i in listaTypes)
                if (modelo.GetType() == i) return modelocrud.Modelos.Where(m => m.GetType() == i).ToList(); 

            return null;
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
