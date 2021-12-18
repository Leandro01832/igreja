using business;
using business.classes;
using business.classes.Abstrato;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFEsboco;

namespace WindowsFormsApp1
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            date = DateTime.Now;
        }

        BDcomum bd = new BDcomum();
        public static MyUserSettings mus;

        public static string Email;
        public static string SenhaEmail;
        public static string PrimeiroAdminEmail = "leandro123";
        public static string PrimeiroAdminSenha = "sistema123";
        public static string path = Directory.GetCurrentDirectory();
        public static bool executar = false;
        public static bool Processando = false;

        #region IdentityRegistryNews

        DateTime date;
        #endregion

        private void fileMenu_Click(object sender, EventArgs e)
        {
            MDI mdi = new MDI();
            mdi.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(10, "Info", "Este é seu programa sistema igreja.", ToolTipIcon.Info);
        }

        private async void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Processando = true;
            executarProcessamentoToolStripMenuItem.Enabled = false;

            mus = new MyUserSettings(this);
            this.DataBindings.Add(new Binding("BackColor", mus, "BackgroundColorPrincipal"));
            this.Icon = new Icon($@"{path}\favicon.ico");
            notifyIcon.Icon = new Icon($@"{path}\favicon.ico");

            Form form = new MDI();
            Type tipo = form.GetType();
            ExecutarFuncoes(sender, e, form, tipo);
            form = new MDIAdmin();
            tipo = form.GetType();
            ExecutarFuncoes(sender, e, form, tipo);
            form = new MDIEsboco();
            tipo = form.GetType();
            ExecutarFuncoes(sender, e, form, tipo);
            form = new MDIFinanceiro();
            tipo = form.GetType();
            ExecutarFuncoes(sender, e, form, tipo);
            form = new MDIEmail();
            tipo = form.GetType();
            ExecutarFuncoes(sender, e, form, tipo);

            MessageBox.Show("Seja bem vindo ao sistema para igreja." +
            " Neste sistema você poderá fazer gerenciamento de pessoas," +
            " gerenciamento financeiro, gerenciamento de e-mails e gerenciamento de esboço." +
            " Quantidade de funções no sistema: " + MdiForm.quantidade);
            MdiForm.quantidade = 0;
            MdiForm.contagem = false;

            LoadForm(this);

            FrmAutenticacao formAutenticacao = new FrmAutenticacao();
            formAutenticacao.Show();

            MessageBox.Show("O processamento será executado.");
            FormProgressBar frm = new FormProgressBar();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Text = "Barra de processamento - Processando dados";
            frm.Show();

            var listaTypes = modelocrud.listTypesSon(typeof(modelocrud));
            var lista = listaTypes.Where(el => el.GetProperties()
            .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 0).ToList();
            foreach (var item in lista)
            {
                var modelo = (modelocrud)Activator.CreateInstance(item);
                await Task.Run(() => modelo.recuperar());
            }

            await Task.Run(() =>
            {
                while (int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99)
                { }
            });

            if (!frm.IsDisposed)
                frm.Dispose();


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
                    permissao.salvar();
                    modelocrud.Modelos.Add(permissao);
                }
            }

            try { Pessoa.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Pessoa), BDcomum.conecta1); }
            catch { Pessoa.UltimoRegistro = 0; }
            try { Reuniao.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Reuniao), BDcomum.conecta1); }
            catch { Reuniao.UltimoRegistro = 0; }
            try { Ministerio.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Ministerio), BDcomum.conecta1); }
            catch { Ministerio.UltimoRegistro = 0; }
            try { Celula.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Celula), BDcomum.conecta1); }
            catch { Celula.UltimoRegistro = 0; }

            await iniciarPrograma();
            await Task.Run(() => alterarDadosRemotos(lista));
        }

        private  void alterarDadosRemotos(List<Type> lista)
        {
            var models = modelocrud.Modelos.OfType<DadoAlterado>().ToList();
            foreach (var item in models)
            {
                foreach (var item2 in lista)
                {
                    if (item2.Name == item.Entidade)
                    {
                        var model = (modelocrud)Activator.CreateInstance(item2);
                        var model2 = (modelocrud)Activator.CreateInstance(item2);
                        model.stringConexao = BDcomum.conecta1;
                        model2.stringConexao = BDcomum.conecta2;
                        if (model2.recuperar(item.IdDado))
                        {
                            model = model2;
                            model.alterar(item.IdDado);
                            break;
                        }
                    }
                }
            }
            notifyIcon.ShowBalloonTip(5000, "Info", "Os dados estão de acordo com banco de dados remoto!!!",
                ToolTipIcon.Info);
        }

        public async Task AtualizarDadosRemotos()
        {            
            var types = modelocrud.listTypesSon(typeof(modelocrud));
            var lista = types.Where(el => el.GetProperties()
            .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 0).ToList();
            foreach (var item in lista)
            {
                await Task.Run(() => recuperarSalvarRegistros(modelocrud.GetUltimoRegistro(item, BDcomum.conecta1),
                modelocrud.GetUltimoRegistro(item, BDcomum.conecta2), item));
            }

            var models = modelocrud.Modelos.OfType<DadoExcluido>().ToList();
            foreach (var item in models)
            {
                foreach (var item2 in lista)
                {
                    if(item2.Name == item.Entidade)
                    {
                        var model = (modelocrud) Activator.CreateInstance(item2);
                        model.stringConexao = BDcomum.conecta1;
                        if (model.recuperar(item.IdDado))
                        {
                            model.excluir(item.IdDado, BDcomum.conecta1);
                            break;
                        }
                    }
                }
            }
        }

        private static void ExecutarFuncoes(object sender, EventArgs e, Form form, Type tipo)
        {
            var lista = modelocrud.listTypesAll(typeof(modelocrud));
            var methods = tipo.GetMethods().Where(m => m.ReturnType == typeof(void)).ToList();
            foreach (MethodInfo method in methods)
                foreach (var item in lista)
                    if (method.Name == item.Name + "Imprimir" + "_Click")
                        tipo.InvokeMember(method.Name,
                            BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance,
                            null, form, new object[] { sender, e });
                    else
                if (method.Name == item.Name + "Cadastrar" + "_Click")
                        tipo.InvokeMember(method.Name,
                            BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance,
                            null, form, new object[] { sender, e });
                    else
                if (method.Name == item.Name + "Pesquisar" + "_Click")
                        tipo.InvokeMember(method.Name,
                            BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance,
                            null, form, new object[] { sender, e });
                    else
                if (method.Name == item.Name + "Listar" + "_Click")
                        tipo.InvokeMember(method.Name,
                            BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance,
                            null, form, new object[] { sender, e });
        }

        private async void Principal_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => modelocrud.calcularPorcentagem());
            await Task.Run(() => verificarListagem());
        }

        private void sistemaFinanceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIFinanceiro form = new MDIFinanceiro();
            form.Show();
        }

        private void esboçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIEsboco form = new MDIEsboco();
            form.Show();
        }


        private async Task verificarListagem()
        {
            try
            {                
                await AtualizarDadosRemotos();
            }
            catch (Exception)
            {                
                MessageBox.Show("conecte-se a internet.");
            }
        }

        private  void recuperarSalvarRegistros(int v1, int v2, Type item)
        {
            if (modelocrud.TotalRegistro(item, BDcomum.conecta2) >
                modelocrud.Modelos.Where(m => m.GetType() == item || m.GetType().IsSubclassOf(item)).ToList().Count)
                while (v1 <= v2)
                {
                    if (modelocrud.Modelos.Where(m => m.GetType() == item).ToList().FirstOrDefault(i => i.Id == v1) == null)
                    {
                        modelocrud m = null;
                        modelocrud m2 = null;
                        var listaTypes = modelocrud.listTypesSon(modelocrud.ReturnBase(item));
                        foreach (var i in listaTypes)
                        {
                            m = (modelocrud)Activator.CreateInstance(i);
                            m2 = (modelocrud)Activator.CreateInstance(i);
                            m.stringConexao = BDcomum.conecta2;
                            m2.stringConexao = BDcomum.conecta1;
                            if (m.recuperar(v1) && !m2.recuperar(v1))
                            {
                                m.Id = 0;
                                m.stringConexao = BDcomum.conecta1;
                                m.salvar(BDcomum.conecta1);
                                modelocrud.Modelos.Add(m);
                                notifyIcon.ShowBalloonTip(5000, "Info",
                                $"Uma informação do banco de dados remoto foi inserida neste programa. - {m.GetType().Name} - {m.Id}",
                                ToolTipIcon.Info);
                            }
                        }
                    }
                    v1++;
                }
        }        

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfiguracao form = new FrmConfiguracao();
            form.Text = "Configuração";
            form.Show();
        }

        public static void LoadForm(Form form, string textoSufixo = "", string textoPrefixo = "")
        {
            form.Icon = new Icon($@"{path}\favicon.ico");

            string textoFormulario = modelocrud.formatarTexto(form.GetType().Name);

            if (textoPrefixo != "") textoFormulario = textoPrefixo + " " + textoFormulario;
            if (textoSufixo != "") textoFormulario = textoFormulario + " " + textoSufixo;

            form.Text = textoFormulario;
        }

        private async void executarProcessamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await iniciarPrograma();
        }

        private async Task iniciarPrograma()
        {
            try
            {
                if (!BDcomum.TestarConexao())
                {
                    MessageBox.Show("Conecte-se a internet.");
                    executarProcessamentoToolStripMenuItem.Enabled = true;
                    Processando = false;
                    executar = false;
                    return;
                }
                Processando = true;
                MessageBox.Show("O processamento será executado.");
                await AtualizarDadosRemotos();
                executar = true;
                executarProcessamentoToolStripMenuItem.Enabled = false;
                notifyIcon.ShowBalloonTip(5000, "Info", "Dados processados com sucesso!!! Você já pode abrir as listas. ",
                ToolTipIcon.Info);
            }
            catch (Exception)
            {
                Processando = false;
                executar = false;
                executarProcessamentoToolStripMenuItem.Enabled = true;
                MessageBox.Show("conecte-se a internet.");
            }
        }
    }
}
