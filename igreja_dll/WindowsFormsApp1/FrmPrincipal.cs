using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Ministerio;
using database;
using database.banco;
using System;
using System.Configuration;
using System.Drawing;
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
                    var cel = new Celula_Adolescente();
                    if (cel.recuperar(i))
                        notifyIcon.ShowBalloonTip(5000, "Info", "Novo registro de uma celula. ID: " + cel.Id, ToolTipIcon.Info);
                    var cel2 = new Celula_Adolescente();
                    if (cel2.recuperar(i))
                        notifyIcon.ShowBalloonTip(5000, "Info", "Novo registro de uma celula. ID: " + cel2.Id, ToolTipIcon.Info);
                    var cel3 = new Celula_Adolescente();
                    if (cel3.recuperar(i))
                        notifyIcon.ShowBalloonTip(5000, "Info", "Novo registro de uma celula. ID: " + cel3.Id, ToolTipIcon.Info);
                    var cel4 = new Celula_Adolescente();
                    if (cel4.recuperar(i))
                        notifyIcon.ShowBalloonTip(5000, "Info", "Novo registro de uma celula. ID: " + cel4.Id, ToolTipIcon.Info);
                    var cel5 = new Celula_Adolescente();
                    if (cel5.recuperar(i))
                        notifyIcon.ShowBalloonTip(5000, "Info", "Novo registro de uma celula. ID: " + cel5.Id, ToolTipIcon.Info);
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
                    var minis = new Lider_Celula();
                    if (minis.recuperar(i))
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + minis.Id, ToolTipIcon.Info);

                    var minis2 = new Lider_Celula_Treinamento();
                    if (minis2.recuperar(i))
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + minis2.Id, ToolTipIcon.Info);

                    var minis3 = new Lider_Ministerio();
                    if (minis3.recuperar(i))
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + minis3.Id, ToolTipIcon.Info);

                    var minis4 = new Lider_Ministerio_Treinamento();
                    if (minis4.recuperar(i))
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + minis4.Id, ToolTipIcon.Info);

                    var minis5 = new Supervisor_Celula();
                    if (minis5.recuperar(i))
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + minis5.Id, ToolTipIcon.Info);

                    var minis6 = new Supervisor_Celula_Treinamento();
                    if (minis6.recuperar(i))
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + minis6.Id, ToolTipIcon.Info);

                    var minis7 = new Supervisor_Ministerio();
                    if (minis7.recuperar(i))
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + minis7.Id, ToolTipIcon.Info);

                    var minis8 = new Supervisor_Ministerio_Treinamento();
                    if (minis8.recuperar(i))
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + minis8.Id, ToolTipIcon.Info);

                }

                Ministerio.UltimoRegistro = modelocrud.GetUltimoRegistro(typeof(Ministerio));
            }

            var UltimoRegistroPessoa = modelocrud.GetUltimoRegistro(typeof(Pessoa));
            if (UltimoRegistroPessoa > Pessoa.UltimoRegistro)
            {
                for (var i = Pessoa.UltimoRegistro; i <= UltimoRegistroPessoa; i++)
                {
                    var Lista = modelocrud.listTypesSon(typeof(modelocrud));
                    foreach(var item in Lista)
                    {
                        var model = (modelocrud) Activator.CreateInstance(item);
                        if (model.recuperar(i))
                            notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de uma pessoa. ID: " + model.Id,
                                ToolTipIcon.Info);
                    }
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

            MessageBox.Show("Quantidade de funções no sistema: " + CrudForm.quantidade);
            CrudForm.quantidade = 0;
            CrudForm.contagem = false;

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

        private void Principal_Tick(object sender, EventArgs e)
        {
            var date2 = DateTime.Now.AddMilliseconds(Principal.Interval);
            lbl_horario.Text = date2.ToString("HH:mm:ss");

            var timer = new TimeSpan(date.Hour, date.Minute + 1, date.Second);

            if (date2.Minute > timer.Minutes && notifica)
            {
                timer = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute + 1, DateTime.Now.Second);
                Notificar();
            }
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
