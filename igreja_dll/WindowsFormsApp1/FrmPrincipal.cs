using business.classes;
using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmPrincipal : FormPadrao
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            date = DateTime.Now;
        }

        #region IdentityRegistryNews

        DateTime date;
        int UltimoRegistroPessoa;
        int UltimoRegistroCelula;
        int UltimoRegistroMinisterio;
        int UltimoRegistroReuniao;
        List<Pessoa> ListaPessoas;
        List<Ministerio> ListaMinisterios;
        List<Celula> ListaCelulas;
        List<Reuniao> ListaReunioes;
        #endregion


        private void fileMenu_Click(object sender, EventArgs e)
        {
            MDI mdi = MDISingleton.InstanciaMDI();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date2 = DateTime.Now.AddMilliseconds(timer1.Interval);
            lbl_horario.Text = date2.ToString("HH:mm:ss");

            var timer = new TimeSpan(date.Hour, date.Minute + 1, date.Second);

            if (date2.Hour == timer.Hours && date2.Minute == timer.Minutes && date2.Second == timer.Seconds)
            {
                Notificar();
                timer = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute + 1, DateTime.Now.Second);
            }

        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(10, "Info", "Este é seu programa sistema igreja.", ToolTipIcon.Info);
        }



        //identificar e notificar novos registros.
        private async void Notificar()
        {
            var lc = await Task.Run(() => Celula.recuperarTodasCelulas());
            var lm = await Task.Run(() => Ministerio.recuperarTodosMinisterios());
            var lp = await Task.Run(() => Pessoa.recuperarTodos());
            var lr = await Task.Run(() => new Reuniao().recuperar(null));
            ListaPessoas = lp.OfType<Pessoa>().Where(p => p.Codigo > UltimoRegistroPessoa).ToList();
            ListaMinisterios = lm.OfType<Ministerio>().Where(m => m.IdMinisterio > UltimoRegistroMinisterio).ToList();
            ListaCelulas = lc.OfType<Celula>().Where(c => c.IdCelula > UltimoRegistroCelula).ToList();
            ListaReunioes = lr.OfType<Reuniao>().Where(r => r.IdReuniao > UltimoRegistroReuniao).ToList();

            if (ListaPessoas != null)
                if (ListaPessoas.Count != 0)
                {
                    foreach (var p in ListaPessoas)
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de uma pessoa. ID: " + p.Codigo, ToolTipIcon.Info);

                    ListaPessoas.Clear();
                    UltimoRegistroPessoa = lp.OfType<Pessoa>().OrderBy(m => m.IdPessoa).Last().Codigo;
                }

            if (ListaReunioes != null)
                if (ListaReunioes.Count != 0)
                {
                    foreach (var p in ListaReunioes)
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de uma reunião. ID: " + p.IdReuniao, ToolTipIcon.Info);

                    ListaReunioes.Clear();
                    UltimoRegistroReuniao = lr.OfType<Reuniao>().Last().IdReuniao;
                }

            if (ListaMinisterios != null)
                if (ListaMinisterios.Count != 0)
                {
                    foreach (var p in ListaMinisterios)
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de um ministério. ID: " + p.IdMinisterio, ToolTipIcon.Info);

                    ListaMinisterios.Clear();
                    UltimoRegistroMinisterio = lm.OfType<Ministerio>().Last().IdMinisterio;
                }

            if (ListaCelulas != null)
                if (ListaCelulas.Count != 0)
                {
                    foreach (var p in ListaCelulas)
                        notifyIcon.ShowBalloonTip(2000, "Info", "Novo registro de uma celula. ID: " + p.IdCelula, ToolTipIcon.Info);

                    ListaCelulas.Clear();
                    UltimoRegistroCelula = lc.OfType<Celula>().Last().IdCelula;
                }
        }

        private async void UltimoRegistro()
        {
            var lc = await Task.Run(() => Celula.recuperarTodasCelulas());
            var lm = await Task.Run(() => Ministerio.recuperarTodosMinisterios());
            var lp = await Task.Run(() => Pessoa.recuperarTodos());
            var lr = await Task.Run(() => new Reuniao().recuperar(null));
            try{UltimoRegistroPessoa = lp.OfType<Pessoa>().OrderBy(m => m.IdPessoa).Last().Codigo;}
            catch { UltimoRegistroPessoa = 0; }
            try { UltimoRegistroReuniao = lr.OfType<Reuniao>().Last().IdReuniao; }
            catch { UltimoRegistroReuniao = 0; }
            try { UltimoRegistroMinisterio = lm.OfType<Ministerio>().Last().IdMinisterio; }
            catch { UltimoRegistroMinisterio = 0; }
            try { UltimoRegistroCelula = lc.OfType<Celula>().Last().IdCelula; }
            catch { UltimoRegistroCelula = 0; }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            UltimoRegistro();
        }
    }
}
