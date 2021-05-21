using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
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

        private bool verificarLista = true;

        private BDcomum bd = new BDcomum();

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
                        listaAtualizadaMinisterios = await Task.Run(() => 
                        recuperarRegistrosMinisterio(bd.GetUltimoRegistroMinisterio(),
                        listaMinisterios.OrderBy(i => i.IdMinisterio).Last().IdMinisterio + 1));
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
                        var listaAtualizadaCelulas = await Task.Run(() => 
                        recuperarRegistrosCelula(bd.GetUltimoRegistroCelula(),
                        listaCelulas.OrderBy(i => i.IdCelula).Last().IdCelula + 1));
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
                        listaAtualizadaPessoas = await Task.Run(() => recuperarRegistrosPessoa(bd.GetUltimoRegistroPessoa(),
                            listaPessoas.OrderBy(i => i.IdPessoa).Last().IdPessoa + 1));
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

        private List<modelocrud> recuperarRegistrosPessoa(int v1, int v2)
        {
            List<modelocrud> lista = new List<modelocrud>();
            while (v2 <= v1)
            {
                var modelo = new Visitante().recuperar(v2);
                var modelo2 = new Crianca().recuperar(v2);
                var modelo3 = new Membro_Batismo().recuperar(v2);
                var modelo4 = new Membro_Aclamacao().recuperar(v2);
                var modelo5 = new Membro_Reconciliacao().recuperar(v2);
                var modelo6 = new Membro_Transferencia().recuperar(v2);
                var modelo7 = new VisitanteLgpd().recuperar(v2);
                var modelo8 = new CriancaLgpd().recuperar(v2);
                var modelo9 = new Membro_TransferenciaLgpd().recuperar(v2);
                var modelo10 = new Membro_BatismoLgpd().recuperar(v2);
                var modelo11 = new Membro_AclamacaoLgpd().recuperar(v2);
                var modelo12 = new Membro_ReconciliacaoLgpd().recuperar(v2);

                if (modelo.Count > 0) lista.Add((Visitante)modelo[0]);
                if (modelo2.Count > 0) lista.Add((Crianca)modelo2[0]);
                if (modelo3.Count > 0) lista.Add((Membro_Batismo)modelo3[0]);
                if (modelo4.Count > 0) lista.Add((Membro_Aclamacao)modelo4[0]);
                if (modelo5.Count > 0) lista.Add((Membro_Reconciliacao)modelo5[0]);
                if (modelo6.Count > 0) lista.Add((Membro_Transferencia)modelo6[0]);
                if (modelo7.Count > 0) lista.Add((VisitanteLgpd)modelo7[0]);
                if (modelo8.Count > 0) lista.Add((CriancaLgpd)modelo8[0]);
                if (modelo9.Count > 0) lista.Add((Membro_TransferenciaLgpd)modelo9[0]);
                if (modelo10.Count > 0) lista.Add((Membro_BatismoLgpd)modelo10[0]);
                if (modelo11.Count > 0) lista.Add((Membro_AclamacaoLgpd)modelo11[0]);
                if (modelo12.Count > 0) lista.Add((Membro_ReconciliacaoLgpd)modelo12[0]);

                v2++;
            }
            lista.AddRange(listaMinisterios);

            return lista;
        }

        private List<modelocrud> recuperarRegistrosCelula(int v1, int v2)
        {
            List<modelocrud> lista = new List<modelocrud>();
            while (v2 < v1)
            {
                var modelo = new Celula_Jovem().recuperar(v2);
                var modelo2 = new Celula_Adolescente().recuperar(v2);
                var modelo3 = new Celula_Casado().recuperar(v2);
                var modelo4 = new Celula_Crianca().recuperar(v2);
                var modelo5 = new Celula_Adulto().recuperar(v2);

                if (modelo.Count > 0) lista.Add((Celula_Jovem)modelo[0]);
                if (modelo2.Count > 0) lista.Add((Celula_Adolescente)modelo2[0]);
                if (modelo3.Count > 0) lista.Add((Celula_Casado)modelo3[0]);
                if (modelo4.Count > 0) lista.Add((Celula_Crianca)modelo4[0]);
                if (modelo5.Count > 0) lista.Add((Celula_Adulto)modelo5[0]);

                v2++;
            }
            lista.AddRange(listaCelulas);
            return lista;
        }

        private List<modelocrud> recuperarRegistrosMinisterio(int v, int idMinisterio)
        {
            List<modelocrud> lista = new List<modelocrud>();
            while (idMinisterio <= v)
            {
                var modelo = new Lider_Celula().recuperar(idMinisterio);
                var modelo2 = new Lider_Celula_Treinamento().recuperar(idMinisterio);
                var modelo3 = new Lider_Ministerio().recuperar(idMinisterio);
                var modelo4 = new Lider_Ministerio_Treinamento().recuperar(idMinisterio);
                var modelo5 = new Supervisor_Celula().recuperar(idMinisterio);
                var modelo6 = new Supervisor_Celula_Treinamento().recuperar(idMinisterio);
                var modelo7 = new Supervisor_Ministerio().recuperar(idMinisterio);
                var modelo8 = new Supervisor_Ministerio_Treinamento().recuperar(idMinisterio);

                if (modelo.Count > 0) lista.Add((Lider_Celula)modelo[0]);
                if (modelo2.Count > 0) lista.Add((Lider_Celula_Treinamento)modelo2[0]);
                if (modelo3.Count > 0) lista.Add((Lider_Ministerio)modelo3[0]);
                if (modelo4.Count > 0) lista.Add((Lider_Ministerio_Treinamento)modelo4[0]);
                if (modelo5.Count > 0) lista.Add((Supervisor_Celula)modelo5[0]);
                if (modelo6.Count > 0) lista.Add((Supervisor_Celula_Treinamento)modelo6[0]);
                if (modelo7.Count > 0) lista.Add((Supervisor_Ministerio)modelo7[0]);
                if (modelo8.Count > 0) lista.Add((Supervisor_Ministerio_Treinamento)modelo8[0]);

                idMinisterio++;
            }
            lista.AddRange(listaMinisterios);

            return lista;
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
