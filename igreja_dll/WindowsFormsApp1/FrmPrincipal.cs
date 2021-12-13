using business.classes;
using business.classes.Abstrato;
using database;
using database.banco;
using System;
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

        #region IdentityRegistryNews
        bool notifica;

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

        //identificar e notificar novos registros.
        private async void Notificar()
        {
            notifica = false;
            await Task.Run(() => verificarListagem());
            notifica = true;
        }
        

        private async void FrmPrincipal_Load(object sender, EventArgs e)
        {
            mus = new MyUserSettings(this);
            this.DataBindings.Add(new Binding("BackColor", mus, "BackgroundColorPrincipal"));

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

            FormPadrao.LoadForm(this);
            FormPadrao.UltimoRegistro();

            try { Pessoa.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Pessoa), BDcomum.conecta1); }
            catch { Pessoa.UltimoRegistro = 0; }
            try { Reuniao.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Reuniao), BDcomum.conecta1); }
            catch { Reuniao.UltimoRegistro = 0; }
            try { Ministerio.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Ministerio), BDcomum.conecta1); }
            catch { Ministerio.UltimoRegistro = 0; }
            try { Celula.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Celula), BDcomum.conecta1); }
            catch { Celula.UltimoRegistro = 0; }

            var types = modelocrud.listTypesSon(typeof(modelocrud));
            var lista = types.Where(el => el.GetProperties()
            .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 0).ToList();
            foreach (var item in lista)
                if (modelocrud.TotalRegistro(modelocrud.ReturnBase(item), BDcomum.conecta2) >
                modelocrud.Modelos.Where(m => m.GetType() == item || m.GetType().IsSubclassOf(item)).ToList().Count)
                    await Task.Run(() => recuperarSalvarRegistros(modelocrud.GetUltimoRegistro(item, BDcomum.conecta1), item));
            else
                if (modelocrud.TotalRegistro(modelocrud.ReturnBase(item), BDcomum.conecta2) <
                modelocrud.Modelos.Where(m => m.GetType() == item || m.GetType().IsSubclassOf(item)).ToList().Count)
                    await Task.Run(() => recuperarSalvarRegistrosRemoto());
            else
                if (modelocrud.TotalRegistro(modelocrud.ReturnBase(item), BDcomum.conecta2) !=
                modelocrud.Modelos.Where(m => m.GetType() == item || m.GetType().IsSubclassOf(item)).ToList().Count)
                    await Task.Run(() => excluiRegistrosRemotos());

           FormPadrao.executar = true;

            notifyIcon.ShowBalloonTip(5000, "Info", "Dados processados com sucesso!!! Você já pode abrir as listas. ",
            ToolTipIcon.Info);
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

                Notificar();
            
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
                FormProgressBar2 form = null;
                var types = modelocrud.listTypesSon(typeof(modelocrud));
                var lista = types.Where(e => e.GetProperties()
                .Where(p => p.ReflectedType == p.DeclaringType && p.Name == "Id").ToList().Count == 0).ToList();
                foreach (var item in lista)
                    if (modelocrud.TotalRegistro(modelocrud.ReturnBase(item), BDcomum.conecta2) >
                    modelocrud.Modelos.Where(m => m.GetType() == item || m.GetType().IsSubclassOf(item)).ToList().Count)
                    await Task.Run(() => recuperarSalvarRegistros(modelocrud.GetUltimoRegistro(item, BDcomum.conecta1), item));                    
                else
                    if (modelocrud.TotalRegistro(modelocrud.ReturnBase(item), BDcomum.conecta2) <
                    modelocrud.Modelos.Where(m => m.GetType() == item || m.GetType().IsSubclassOf(item)).ToList().Count)
                    await Task.Run(() => recuperarSalvarRegistrosRemoto());    
                else
                    if (modelocrud.TotalRegistro(modelocrud.ReturnBase(item), BDcomum.conecta2) !=
                    modelocrud.Modelos.Where(m => m.GetType() == item || m.GetType().IsSubclassOf(item)).ToList().Count)
                    await Task.Run(() => excluiRegistrosRemotos());   
                
                    await Task.Run(() => alteraRegistrosRemotos());                    

                if (!form.IsDisposed)
                    form.Dispose();
            }
            catch { }
        }

        private void alteraRegistrosRemotos()
        {
            bool teste = false;
            foreach (var item in modelocrud.ModelosAlterados)
            {
                var modelo = item;
                var modelo2 = item;
                modelo.stringConexao = BDcomum.conecta1;
                modelo2.stringConexao = BDcomum.conecta2;

                if (modelo.recuperar(modelo.Id) && modelo2.recuperar(modelo2.Id))
                {
                    modelo2.alterar(modelo2.Id);
                    notifyIcon.ShowBalloonTip(5000, "Info",
                    "Uma informação no banco de dados remoto foi alterada. ", ToolTipIcon.Info);
                }
                if (item == modelocrud.ModelosAlterados.Last())
                    teste = true;
            }
            if(teste)
            modelocrud.ModelosAlterados.Clear();
        }

        private void excluiRegistrosRemotos()
        {
            bool teste = false;
            foreach (var item in modelocrud.ModelosExcluidos)
            {
                var modelo = item;
                var modelo2 = item;
                modelo.stringConexao = BDcomum.conecta1;
                modelo2.stringConexao = BDcomum.conecta2;

                if (!modelo.recuperar(modelo.Id) && modelo2.recuperar(modelo2.Id))
                {
                    modelo2.excluir(modelo2.Id);
                    notifyIcon.ShowBalloonTip(5000, "Info",
                    "Uma informação no banco de dados remoto foi excluida. ", ToolTipIcon.Info);
                }

                if (item == modelocrud.ModelosExcluidos.Last())
                    teste = true;
            }  
            if(teste)
                modelocrud.ModelosExcluidos.Clear();
        }

        private void recuperarSalvarRegistros(int v1, Type item)
        {
            var v2 = v1 + 10;
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
                            m.salvar();
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

        private void recuperarSalvarRegistrosRemoto()
        {
            bool teste = false;
            foreach (var item in modelocrud.ModelosInseridos)
            {
                item.stringConexao = BDcomum.conecta2;
                    item.salvar();
                    notifyIcon.ShowBalloonTip(5000, "Info",
                    "Uma informação no banco de dados remoto foi excluida. ", ToolTipIcon.Info);

                if (item == modelocrud.ModelosInseridos.Last())
                    teste = true;            
            }
            if (teste)
                modelocrud.ModelosInseridos.Clear();
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfiguracao form = new FrmConfiguracao();
            form.Text = "Configuração";
            form.Show();
        }
    }
}
