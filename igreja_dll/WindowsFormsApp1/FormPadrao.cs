using business.classes;
using business.classes.Abstrato;
using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private int indicePessoa = 0;
        private int indiceMinisterio = 0;
        private int indiceCelula = 0;

        private bool verificarLista = true;

        public static List<Pessoa> listaPessoas;
        public static List<Ministerio> listaMinisterios;
        public static List<Celula> listaCelulas;
        public static List<Reuniao> listaReuniao;

        public static List<modelocrud> listaAtualizadaPessoas;
        public static List<modelocrud> listaAtualizadaMinisterios;
        public static List<modelocrud> listaAtualizadaCelulas;

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
            listaCelulas = lc.OfType<Celula>().ToList();
            var lm = await Task.Run(() => Ministerio.recuperarTodosMinisterios());
            listaMinisterios = lm.OfType<Ministerio>().ToList();
            var lr = await Task.Run(() => new Reuniao().recuperar(null));
            listaReuniao = lr.OfType<Reuniao>().ToList();
            var lp = await Task.Run(() => Pessoa.recuperarTodos());
            listaPessoas = lp.OfType<Pessoa>().ToList();
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
            
            
            
        }

        private async void verifica()
        {
            if (verificarLista)
            {
                verificarLista = false;
                try
                {
                    if(listaMinisterios != null)
                    if (GeTotalRegistrosMinisterios() != listaMinisterios.Count)
                    {
                        FormProgressBar form = new FormProgressBar();
                        form.MdiParent = this.MdiParent;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Text = "Barra de processamento - Ministerios";
                        form.Show();
                        listaAtualizadaMinisterios = await Task.Run(() => Ministerio.recuperarTodosMinisterios());
                        form.Close();
                        listaMinisterios.Clear();
                        var lista = listaAtualizadaMinisterios;
                        foreach (var item in lista.OfType<Ministerio>())
                        listaMinisterios.Add(item);
                        
                        Ministerio.UltimoRegistro = listaMinisterios.OrderBy(m => m.IdMinisterio).Last().IdMinisterio;
                    }
                }
                catch { }

                try
                {
                    if (listaCelulas != null)
                    if (GeTotalRegistrosCelulas() != listaCelulas.Count)
                    {
                        FormProgressBar form = new FormProgressBar();
                        form.MdiParent = this.MdiParent;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Text = "Barra de processamento - Celulas";
                        form.Show();
                        var listaAtualizadaCelulas = await Task.Run(() => Celula.recuperarTodasCelulas());
                        form.Close();
                        var lista = listaAtualizadaCelulas;
                        foreach (var item in lista.OfType<Celula>())
                        if (listaCelulas.FirstOrDefault(e => e.IdCelula == item.IdCelula) == null)
                        listaCelulas.Add(item);
                        
                        Celula.UltimoRegistro = listaCelulas.OrderBy(m => m.IdCelula).Last().IdCelula;
                    }
                }
                catch { }

                try
                {
                    if (listaPessoas != null)
                    if (GeTotalRegistrosPessoas() != listaPessoas.Count)
                    {
                        FormProgressBar form = new FormProgressBar();
                        form.MdiParent = this.MdiParent;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Text = "Barra de processamento - Pessoas";
                        form.Show();
                        listaAtualizadaPessoas = await Task.Run(() => Pessoa.recuperarTodos());
                        form.Close();
                        var lista = listaAtualizadaPessoas;
                        foreach (var item in lista.OfType<Pessoa>())
                        {
                            if (listaPessoas.FirstOrDefault(e => e.IdPessoa == item.IdPessoa) == null)
                                listaPessoas.Add(item);
                        }
                        Pessoa.UltimoRegistro = listaPessoas.OrderBy(m => m.IdPessoa).Last().Codigo;
                    }
                }
                catch { }
                verificarLista = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            verifica();
        }

       public async Task<List<modelocrud>> AtualizarComModelo(modelocrud modelo)
        {
            var models = await Task.Run(() => modelo.recuperar(null));            
            return models;
        }

        public async Task<List<modelocrud>> AtualizarComProgressBar(modelocrud modelo)
        {
            FormProgressBar form = new FormProgressBar();
            form.MdiParent = this.MdiParent;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = $"Barra de processamento - {modelo.GetType().Name}";
            form.Show();
            var models = await Task.Run(() => modelo.recuperar(null));
            form.Close();
            return models;
        }

        private int GeTotalRegistrosPessoas()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                using (con = new SqlConnection(BDcomum.conecta2))
                {
                    cmd = new SqlCommand("SELECT COUNT(*) FROM Pessoa", con);
                    con.Open();
                    _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return _TotalRegistros;
        }

        private int GeTotalRegistrosCelulas()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                using (con = new SqlConnection(BDcomum.conecta2))
                {
                    cmd = new SqlCommand("SELECT COUNT(*) FROM Celula", con);
                    con.Open();
                    _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return _TotalRegistros;
        }

        private int GeTotalRegistrosMinisterios()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                using (con = new SqlConnection(BDcomum.conecta2))
                {
                    cmd = new SqlCommand("SELECT COUNT(*) FROM Ministerio", con);
                    con.Open();
                    _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return _TotalRegistros;
        }
    }
}
