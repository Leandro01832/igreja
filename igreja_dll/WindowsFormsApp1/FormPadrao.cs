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
    public partial class FormPadrao : Form
    {
        public FormPadrao()
        {
            InitializeComponent();
        }        

        public static List<Pessoa> listaPessoas;
        public static List<Ministerio> listaMinisterios;
        public static List<Celula> listaCelulas;
        public static List<Reuniao> listaReuniao;

       private int ultimoRegistroPessoa;
       private int ultimoRegistroCelula;
       private int ultimoRegistroMinisterio;
       private int ultimoRegistroReuniao;

        public int UltimoRegistroPessoa { get => ultimoRegistroPessoa; set => ultimoRegistroPessoa = value; }
        public int UltimoRegistroCelula { get => ultimoRegistroCelula; set => ultimoRegistroCelula = value; }
        public int UltimoRegistroMinisterio { get => ultimoRegistroMinisterio; set => ultimoRegistroMinisterio = value; }
        public int UltimoRegistroReuniao { get => ultimoRegistroReuniao; set => ultimoRegistroReuniao = value; }

        private void FormPadrao_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("D:\\Downloads\\favicon.ico");

        }

        public async void UltimoRegistro()
        {
            FormProgressBar form = new FormProgressBar();
          //  form.MdiParent = this.MdiParent;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Barra de processamento - Processando dados";
            form.Show();
            var lc = await Task.Run(() => Celula.recuperarTodasCelulas());
            var lm = await Task.Run(() => Ministerio.recuperarTodosMinisterios());
            var lp = await Task.Run(() => Pessoa.recuperarTodos());
            var lr = await Task.Run(() => new Reuniao().recuperar(null));
            form.Close();
            try { UltimoRegistroPessoa = lp.OfType<Pessoa>().OrderBy(m => m.IdPessoa).Last().Codigo; }
            catch { UltimoRegistroPessoa = 0; }
            try { UltimoRegistroReuniao = lr.OfType<Reuniao>().OrderBy(m => m.IdReuniao).Last().IdReuniao; }
            catch { UltimoRegistroReuniao = 0; }
            try { UltimoRegistroMinisterio = lm.OfType<Ministerio>().OrderBy(m => m.IdMinisterio).Last().IdMinisterio; }
            catch { UltimoRegistroMinisterio = 0; }
            try { UltimoRegistroCelula = lc.OfType<Celula>().OrderBy(m => m.IdCelula).Last().IdCelula; }
            catch { UltimoRegistroCelula = 0; }
            Pessoa.UltimoRegistro = UltimoRegistroPessoa;
            Ministerio.UltimoRegistro = UltimoRegistroMinisterio;
            Celula.UltimoRegistro = UltimoRegistroCelula;
            Reuniao.UltimoRegistro = UltimoRegistroReuniao;
            listaPessoas = lp.OfType<Pessoa>().ToList();
            listaMinisterios = lm.OfType<Ministerio>().ToList();
            listaCelulas = lc.OfType<Celula>().ToList();
            listaReuniao = lr.OfType<Reuniao>().ToList();
        }

        public async void AtualizarListaPessoa()
        {
            FormProgressBar form = new FormProgressBar();
            form.MdiParent = this.MdiParent;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Barra de processamento - Pessoas";
            form.Show();
            var lp = await Task.Run(() => Pessoa.recuperarTodos());
            form.Close();
            listaPessoas = lp.OfType<Pessoa>().ToList();
            Pessoa.UltimoRegistro = listaPessoas.OrderBy(m => m.IdPessoa).Last().Codigo;
        }        

        public async void AtualizarListaMinisterio()
        {
            FormProgressBar form = new FormProgressBar();
            form.MdiParent = this.MdiParent;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Barra de processamento - Ministérios";
            form.Show();
            var lm = await Task.Run(() => Ministerio.recuperarTodosMinisterios());
            form.Close();
             listaMinisterios = lm.OfType<Ministerio>().ToList();
             Ministerio.UltimoRegistro = listaMinisterios.OrderBy(m => m.IdMinisterio).Last().IdMinisterio;
        }

        public async void AtualizarListaCelula()
        {
            FormProgressBar form = new FormProgressBar();
            form.MdiParent = this.MdiParent;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Barra de processamento - Celulas";
            form.Show();
            var lc = await Task.Run(() => Celula.recuperarTodasCelulas());
            form.Close();
            listaCelulas = lc.OfType<Celula>().ToList();
            Ministerio.UltimoRegistro = listaCelulas.OrderBy(m => m.IdCelula).Last().IdCelula;
        }

        public async void AtualizarListaReuniao()
        {
            FormProgressBar form = new FormProgressBar();
            form.MdiParent = this.MdiParent;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Barra de processamento - Celulas";
            form.Show();
            var lr = await Task.Run(() => new Reuniao().recuperar(null));
            form.Close();
            listaReuniao = lr.OfType<Reuniao>().ToList();
            Reuniao.UltimoRegistro = listaReuniao.OrderBy(m => m.IdReuniao).Last().IdReuniao;
        }

        private void verifica()
        {

            try
            {
                if (listaPessoas != null)
                    if (listaPessoas.OrderBy(m => m.IdPessoa).Last().Codigo < Pessoa.UltimoRegistro)
                        AtualizarListaPessoa();
            }
            catch { }

            try
            {
                if (listaMinisterios != null)
                    if (listaMinisterios.OrderBy(m => m.IdMinisterio).Last().IdMinisterio < Ministerio.UltimoRegistro)
                        AtualizarListaMinisterio();
            }
            catch { }

            try
            {
                if (listaCelulas != null)
                    if (listaCelulas.OrderBy(m => m.IdCelula).Last().IdCelula < Celula.UltimoRegistro)
                        AtualizarListaCelula();
            }
            catch { }

            try
            {
                if (listaReuniao != null)
                    if (listaReuniao.OrderBy(m => m.IdReuniao).Last().IdReuniao < Reuniao.UltimoRegistro)
                        AtualizarListaCelula();
            }
            catch { }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            verifica();
        }
    }
}
