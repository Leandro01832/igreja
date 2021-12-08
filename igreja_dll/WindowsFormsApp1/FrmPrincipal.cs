using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Ministerio;
using business.classes.Pessoas;
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

            await Task.Run(() => verificaRegistros());

            notifica = true;
        }

        private void verificaRegistros()
        {
            var UltimoRegistroCelula = modelocrud.GetUltimoRegistro(typeof(Celula));
            if (UltimoRegistroCelula > Celula.UltimoRegistro)
            {
                for (var i = Celula.UltimoRegistro; i <= UltimoRegistroCelula; i++)
                {
                    modelocrud model = modelocrud.buscarConcreto(typeof(Celula), i);
                    if (model.recuperar(i))
                    notifyIcon.ShowBalloonTip(5000, "Info", "Novo registro de uma celula. ID: " + model.Id, ToolTipIcon.Info);
                }

                Celula.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Celula));
            }

            var UltimoRegistroReuniao = modelocrud.GetUltimoRegistro(typeof(Reuniao));
            if (UltimoRegistroReuniao > Reuniao.UltimoRegistro)
            {
                for (var i = Reuniao.UltimoRegistro; i <= UltimoRegistroReuniao; i++)
                {
                    var reu = new Reuniao();
                    if (reu.recuperar(i))
                    notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de uma reunião. ID: " + reu.Id, ToolTipIcon.Info);
                }
                Reuniao.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Reuniao));
            }

            var UltimoRegistroMinsterio = modelocrud.GetUltimoRegistro(typeof(Ministerio));
            if (UltimoRegistroMinsterio > Ministerio.UltimoRegistro)
            {

                for (var i = Ministerio.UltimoRegistro; i <= UltimoRegistroMinsterio; i++)
                {
                    modelocrud model = modelocrud.buscarConcreto(typeof(Ministerio), i);

                    if (model.recuperar(i))
                    notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + model.Id, ToolTipIcon.Info);

                }

                Ministerio.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Ministerio));
            }

            var UltimoRegistroPessoa = modelocrud.GetUltimoRegistro(typeof(Pessoa));
            if (UltimoRegistroPessoa > Pessoa.UltimoRegistro)
            {
                for (var i = Pessoa.UltimoRegistro; i <= UltimoRegistroPessoa; i++)
                {

                    modelocrud model = modelocrud.buscarConcreto(typeof(Pessoa), i);
                    if (model != null && model.recuperar(i))
                    notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de uma pessoa. ID: " + model.Id, ToolTipIcon.Info);

                }

                Pessoa.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Pessoa));
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

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

            MessageBox.Show("Quantidade de funções no sistema: " + MdiForm.quantidade);
            MdiForm.quantidade = 0;
            MdiForm.contagem = false;

            FormPadrao.UltimoRegistro();
            FormPadrao.LoadForm(this);

            try { Pessoa.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Pessoa)); }
            catch { Pessoa.UltimoRegistro = 0; }
            try { Reuniao.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Reuniao)); }
            catch { Reuniao.UltimoRegistro = 0; }
            try { Ministerio.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Ministerio)); }
            catch { Ministerio.UltimoRegistro = 0; }
            try { Celula.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Celula)); }
            catch { Celula.UltimoRegistro = 0; }


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
    }
}
