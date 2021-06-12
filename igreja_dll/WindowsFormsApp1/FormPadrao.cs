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

        public static bool carregandoVisitanteLgpd = false;
        public static bool carregandoCriancaLgpd = false;
        public static bool carregandoMembroBatismoLgpd = false;
        public static bool carregandoMembroReconciliacaoLgpd = false;
        public static bool carregandoMembroTransferenciaLgpd = false;
        public static bool carregandoMembroAclamacaoLgpd = false;
        public static bool carregandoVisitante = false;
        public static bool carregandoCrianca = false;
        public static bool carregandoMembroBatismo = false;
        public static bool carregandoMembroReconciliacao = false;
        public static bool carregandoMembroTransferencia = false;
        public static bool carregandoMembroAclamacao = false;

        private bool verificarLista = true;
        private bool podeVerificar = false;
        private bool calcular = true;
        private bool executar = true;
        

        private BDcomum bd = new BDcomum();

        public static List<Pessoa> listaPessoas;
        public static List<Ministerio> listaMinisterios;
        public static List<Celula> listaCelulas;
        public static List<Reuniao> listaReuniao;
        public static List<MudancaEstado> listaMudancaEstado;

        public static string textoPorcentagem = "0%";

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
            listaPessoas = new List<Pessoa>();
            listaMinisterios = new List<Ministerio>();
            listaCelulas = new List<Celula>();
            listaReuniao = new List<Reuniao>();
            listaMudancaEstado = new List<MudancaEstado>();

            FormProgressBar form = new FormProgressBar();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Barra de processamento - Processando dados";
            form.Show();


            var lc = await Task.Run(() => Celula.recuperarTodasCelulas());
            ExecutarVerificacoes();

            var lm = await Task.Run(() => Ministerio.recuperarTodosMinisterios());
            ExecutarVerificacoes();

            var lme = await Task.Run(() => new MudancaEstado().recuperar(null));
            listaMudancaEstado = lme.OfType<MudancaEstado>().ToList();
            ExecutarVerificacoes();

            var lr = await Task.Run(() => new Reuniao().recuperar(null));
            listaReuniao = lr.OfType<Reuniao>().ToList();
            ExecutarVerificacoes();

            var lp = await Task.Run(() => Pessoa.recuperarTodos());
            ExecutarVerificacoes();

            try { UltimoRegistroPessoa = lp.OfType<Pessoa>().OrderBy(m => m.IdPessoa).Last().Codigo; }
            catch { UltimoRegistroPessoa = 0; }
            try { UltimoRegistroReuniao = lr.OfType<Reuniao>().OrderBy(m => m.IdReuniao).Last().IdReuniao; }
            catch { UltimoRegistroReuniao = 0; }
            try { UltimoRegistroMinisterio = lm.OfType<Ministerio>().OrderBy(m => m.IdMinisterio).Last().IdMinisterio; }
            catch { UltimoRegistroMinisterio = 0; }
            try { UltimoRegistroCelula = lc.OfType<Celula>().OrderBy(m => m.IdCelula).Last().IdCelula; }
            catch { UltimoRegistroCelula = 0; }

            form.Dispose();



            Pessoa.UltimoRegistro = UltimoRegistroPessoa;
            Ministerio.UltimoRegistro = UltimoRegistroMinisterio;
            Celula.UltimoRegistro = UltimoRegistroCelula;
            Reuniao.UltimoRegistro = UltimoRegistroReuniao;

            if (Pessoa.visitantes == null || Pessoa.criancas == null ||
                Pessoa.membros_Aclamacao == null || Pessoa.membros_Batismo == null ||
                Pessoa.membros_Reconciliacao == null || Pessoa.membros_Transferencia == null ||
                Pessoa.visitantesLgpd == null || Pessoa.criancasLgpd == null ||
                Pessoa.membros_AclamacaoLgpd == null || Pessoa.membros_BatismoLgpd == null ||
                Pessoa.membros_ReconciliacaoLgpd == null || Pessoa.membros_TransferenciaLgpd == null ||

                Ministerio.lideresCelula == null || Ministerio.LideresCelulaTreinamento == null ||
                Ministerio.lideresMinisterio == null || Ministerio.lideresMinisterioTreinamento == null ||

                Celula.celulasAdolescente == null || Celula.celulasAdulto == null ||
                Celula.celulasCasado == null || Celula.celulasCrianca == null || Celula.celulasJovem == null)
                podeVerificar = false;
            else
                podeVerificar = true;
        }

        private async void verifica()
        {
            

            if (verificarLista && podeVerificar && BDcomum.podeAbrir)
            {
                verificarLista = false;
                var registrosMinisterios = GeTotalRegistrosMinisterios();
                var registrosPessoas = GeTotalRegistrosPessoas();
                var registrosCelulas = GeTotalRegistrosCelulas();
                try
                {
                    if (registrosMinisterios != listaMinisterios.Count)
                    {
                        using (FormProgressBar2 form = new FormProgressBar2())
                        {
                            form.MdiParent = this.MdiParent;
                            form.StartPosition = FormStartPosition.CenterScreen;
                            form.Text = "Barra de processamento - Ministerios";
                            form.Show();
                            await Task.Run(() => recuperarRegistrosMinisterio(bd.GetUltimoRegistroMinisterio() + 10, 1));
                            form.Close();
                        }
                        Ministerio.UltimoRegistro = listaMinisterios.OrderBy(m => m.IdMinisterio).Last().IdMinisterio;
                    }
                }
                catch { }

                try
                {
                    if (registrosCelulas != listaCelulas.Count)
                    {
                        using (FormProgressBar2 form = new FormProgressBar2())
                        {
                            form.MdiParent = this.MdiParent;
                            form.StartPosition = FormStartPosition.CenterScreen;
                            form.Text = "Barra de processamento - Celulas";
                            form.Show();
                            await Task.Run(() => recuperarRegistrosCelula(bd.GetUltimoRegistroCelula() + 10, 1));
                            form.Close();
                        }

                        Celula.UltimoRegistro = listaCelulas.OrderBy(m => m.IdCelula).Last().IdCelula;
                    }
                }
                catch { }

                try
                {
                    if (registrosPessoas != listaPessoas.Count)
                    {
                        using (FormProgressBar2 form = new FormProgressBar2())
                        {
                            form.MdiParent = this.MdiParent;
                            form.StartPosition = FormStartPosition.CenterScreen;
                            form.Text = "Barra de processamento - Pessoas";
                            form.Show();
                            await Task.Run(() => recuperarRegistrosPessoa(bd.GetUltimoRegistroPessoa() + 10, 1));
                            form.Close();
                        }
                        Pessoa.UltimoRegistro = listaPessoas.OrderBy(m => m.IdPessoa).Last().Codigo;
                    }
                }
                catch { }
                verificarLista = true;
            }

            
        }

        private void CalcularPorcentagem()
        {
            var erro = 0;
            if (calcular)
            {
                try
                {
                    var pessoas = GeTotalRegistrosPessoas();
                    var celulas = GeTotalRegistrosCelulas();
                    var ministerios = GeTotalRegistrosMinisterios();
                    var reunioes = GeTotalRegistrosReunioes();
                    var mudancas = GeTotalRegistrosMudancaEstado();
                    var totalRegistros = pessoas + celulas + ministerios + reunioes + mudancas;
                   

                    var quantidadeCarregada = 
                     listaPessoas.Count + listaCelulas.Count + listaMinisterios.Count + listaReuniao.Count;
                    

                    var porcentagem = (int)((100 * quantidadeCarregada) / totalRegistros);
                    textoPorcentagem = porcentagem.ToString() + "%";
                }
                catch
                {
                    erro++;
                    if(erro  == 1)
                    MessageBox.Show("Erro ao fazer calculo de porcentagem. Verifique sua conexão!!!");
                    calcular = false;                    
                    return;
                }
            }
        }

        private void recuperarRegistrosPessoa(int v1, int v2)
        {
            List<modelocrud> lista = new List<modelocrud>();
            while (v1 >= v2)
            {
                if (listaPessoas.FirstOrDefault(i => i.IdPessoa == v2) == null)
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

                    if (modelo.Count > 0) listaPessoas.Add((Visitante)modelo[0]);
                    if (modelo2.Count > 0) listaPessoas.Add((Crianca)modelo2[0]);
                    if (modelo3.Count > 0) listaPessoas.Add((Membro_Batismo)modelo3[0]);
                    if (modelo4.Count > 0) listaPessoas.Add((Membro_Aclamacao)modelo4[0]);
                    if (modelo5.Count > 0) listaPessoas.Add((Membro_Reconciliacao)modelo5[0]);
                    if (modelo6.Count > 0) listaPessoas.Add((Membro_Transferencia)modelo6[0]);
                    if (modelo7.Count > 0) listaPessoas.Add((VisitanteLgpd)modelo7[0]);
                    if (modelo8.Count > 0) listaPessoas.Add((CriancaLgpd)modelo8[0]);
                    if (modelo9.Count > 0) listaPessoas.Add((Membro_TransferenciaLgpd)modelo9[0]);
                    if (modelo10.Count > 0) listaPessoas.Add((Membro_BatismoLgpd)modelo10[0]);
                    if (modelo11.Count > 0) listaPessoas.Add((Membro_AclamacaoLgpd)modelo11[0]);
                    if (modelo12.Count > 0) listaPessoas.Add((Membro_ReconciliacaoLgpd)modelo12[0]);
                }

                v2++;
            }
        }

        private void recuperarRegistrosCelula(int v1, int v2)
        {
            List<modelocrud> lista = new List<modelocrud>();
            while (v1 > v2)
            {
                if (listaCelulas.FirstOrDefault(i => i.IdCelula == v2) == null)
                {
                    var modelo = new Celula_Jovem().recuperar(v2);
                    var modelo2 = new Celula_Adolescente().recuperar(v2);
                    var modelo3 = new Celula_Casado().recuperar(v2);
                    var modelo4 = new Celula_Crianca().recuperar(v2);
                    var modelo5 = new Celula_Adulto().recuperar(v2);

                    if (modelo.Count > 0) listaCelulas.Add((Celula_Jovem)modelo[0]);
                    if (modelo2.Count > 0) listaCelulas.Add((Celula_Adolescente)modelo2[0]);
                    if (modelo3.Count > 0) listaCelulas.Add((Celula_Casado)modelo3[0]);
                    if (modelo4.Count > 0) listaCelulas.Add((Celula_Crianca)modelo4[0]);
                    if (modelo5.Count > 0) listaCelulas.Add((Celula_Adulto)modelo5[0]);
                }

                v2++;
            }
        }

        private void recuperarRegistrosMinisterio(int v1, int v2)
        {
            while (v1 >= v2)
            {
                if (listaMinisterios.FirstOrDefault(i => i.IdMinisterio == v2) == null)
                {
                    var modelo = new Lider_Celula().recuperar(v2);
                    var modelo2 = new Lider_Celula_Treinamento().recuperar(v2);
                    var modelo3 = new Lider_Ministerio().recuperar(v2);
                    var modelo4 = new Lider_Ministerio_Treinamento().recuperar(v2);
                    var modelo5 = new Supervisor_Celula().recuperar(v2);
                    var modelo6 = new Supervisor_Celula_Treinamento().recuperar(v2);
                    var modelo7 = new Supervisor_Ministerio().recuperar(v2);
                    var modelo8 = new Supervisor_Ministerio_Treinamento().recuperar(v2);

                    if (modelo.Count > 0) listaMinisterios.Add((Lider_Celula)modelo[0]);
                    if (modelo2.Count > 0) listaMinisterios.Add((Lider_Celula_Treinamento)modelo2[0]);
                    if (modelo3.Count > 0) listaMinisterios.Add((Lider_Ministerio)modelo3[0]);
                    if (modelo4.Count > 0) listaMinisterios.Add((Lider_Ministerio_Treinamento)modelo4[0]);
                    if (modelo5.Count > 0) listaMinisterios.Add((Supervisor_Celula)modelo5[0]);
                    if (modelo6.Count > 0) listaMinisterios.Add((Supervisor_Celula_Treinamento)modelo6[0]);
                    if (modelo7.Count > 0) listaMinisterios.Add((Supervisor_Ministerio)modelo7[0]);
                    if (modelo8.Count > 0) listaMinisterios.Add((Supervisor_Ministerio_Treinamento)modelo8[0]);
                }
                v2++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (executar)
            {
                executar = false;
                verifica();

                if (Pessoa.visitantesLgpd != null ||
                listaPessoas.Where(p => p.GetType().Name == new VisitanteLgpd().GetType().Name).ToList().Count > 0)
                    carregandoVisitanteLgpd = true;
                else carregandoVisitanteLgpd = false;
                if (Pessoa.criancasLgpd != null ||
                listaPessoas.Where(p => p.GetType().Name == new CriancaLgpd().GetType().Name).ToList().Count > 0)
                    carregandoCriancaLgpd = true;
                else carregandoCriancaLgpd = false;
                if (Pessoa.membros_BatismoLgpd != null ||
                listaPessoas.Where(p => p.GetType().Name == new Membro_BatismoLgpd().GetType().Name).ToList().Count > 0)
                    carregandoMembroBatismoLgpd = true;
                else carregandoMembroBatismoLgpd = false;
                if (Pessoa.membros_ReconciliacaoLgpd != null ||
                listaPessoas.Where(p => p.GetType().Name == new Membro_ReconciliacaoLgpd().GetType().Name).ToList().Count > 0)
                    carregandoMembroReconciliacaoLgpd = true;
                else carregandoMembroReconciliacaoLgpd = false;
                if (Pessoa.membros_TransferenciaLgpd != null ||
                listaPessoas.Where(p => p.GetType().Name == new Membro_TransferenciaLgpd().GetType().Name).ToList().Count > 0)
                    carregandoMembroTransferenciaLgpd = true;
                else carregandoMembroTransferenciaLgpd = false;
                if (Pessoa.membros_AclamacaoLgpd != null ||
                listaPessoas.Where(p => p.GetType().Name == new Membro_AclamacaoLgpd().GetType().Name).ToList().Count > 0)
                    carregandoMembroAclamacaoLgpd = true;
                else carregandoMembroAclamacaoLgpd = false;
                if (Pessoa.visitantes != null ||
                listaPessoas.Where(p => p.GetType().Name == new Visitante().GetType().Name).ToList().Count > 0)
                    carregandoVisitante = true;
                else carregandoVisitante = false;
                if (Pessoa.criancas != null ||
                listaPessoas.Where(p => p.GetType().Name == new Crianca().GetType().Name).ToList().Count > 0)
                    carregandoCrianca = true;
                else carregandoCrianca = false;
                if (Pessoa.membros_Batismo != null ||
                listaPessoas.Where(p => p.GetType().Name == new Membro_Batismo().GetType().Name).ToList().Count > 0)
                    carregandoMembroBatismo = true;
                else carregandoMembroBatismo = false;
                if (Pessoa.membros_Reconciliacao != null ||
                listaPessoas.Where(p => p.GetType().Name == new Membro_Reconciliacao().GetType().Name).ToList().Count > 0)
                    carregandoMembroReconciliacao = true;
                else carregandoMembroReconciliacao = false;
                if (Pessoa.membros_Transferencia != null ||
                listaPessoas.Where(p => p.GetType().Name == new Membro_Transferencia().GetType().Name).ToList().Count > 0)
                    carregandoMembroTransferencia = true;
                else carregandoMembroTransferencia = false;
                if (Pessoa.membros_Aclamacao != null ||
                listaPessoas.Where(p => p.GetType().Name == new Membro_Aclamacao().GetType().Name).ToList().Count > 0)
                    carregandoMembroAclamacao = true;
                else carregandoMembroAclamacao = false;

                executar = true;
            }
        }

        public async Task<List<modelocrud>> AtualizarComModelo(Type Tipo)
        {
            modelocrud modelo = retornaModelo(Tipo);
            var models = await Task.Run(() => modelo.recuperar(null));
            return models;
        }        

        public async Task<List<modelocrud>> AtualizarComProgressBar(Type Tipo)
        {
            bool condicao = false;

            if (Tipo.IsSubclassOf(typeof(Pessoa)) && listaPessoas.Where(m => m.GetType().Name == Tipo.GetType().Name).ToList().Count == 0)
            {
                if (Tipo == typeof(Visitante) && Pessoa.visitantes == null)
                { Pessoa.visitantes = new List<Visitante>(); condicao = true; }
                if (Tipo == typeof(Crianca) && Pessoa.criancas == null)
                { Pessoa.criancas = new List<Crianca>(); condicao = true; }
                if (Tipo == typeof(Membro_Aclamacao) && Pessoa.membros_Aclamacao == null)
                { Pessoa.membros_Aclamacao = new List<Membro_Aclamacao>(); condicao = true; }
                if (Tipo == typeof(Membro_Batismo) && Pessoa.membros_Batismo == null)
                { Pessoa.membros_Batismo = new List<Membro_Batismo>(); condicao = true; }
                if (Tipo == typeof(Membro_Reconciliacao) && Pessoa.membros_Reconciliacao == null)
                { Pessoa.membros_Reconciliacao = new List<Membro_Reconciliacao>(); condicao = true; }
                if (Tipo == typeof(Membro_Transferencia) && Pessoa.membros_Transferencia == null)
                { Pessoa.membros_Transferencia = new List<Membro_Transferencia>(); condicao = true; }
                if (Tipo == typeof(VisitanteLgpd) && Pessoa.visitantesLgpd == null)
                { Pessoa.visitantesLgpd = new List<VisitanteLgpd>(); condicao = true; }
                if (Tipo == typeof(CriancaLgpd) && Pessoa.criancasLgpd == null)
                { Pessoa.criancasLgpd = new List<CriancaLgpd>(); condicao = true; }
                if (Tipo == typeof(Membro_AclamacaoLgpd) && Pessoa.membros_AclamacaoLgpd == null)
                { Pessoa.membros_AclamacaoLgpd = new List<Membro_AclamacaoLgpd>(); condicao = true; }
                if (Tipo == typeof(Membro_BatismoLgpd) && Pessoa.membros_BatismoLgpd == null)
                { Pessoa.membros_BatismoLgpd = new List<Membro_BatismoLgpd>(); condicao = true; }
                if (Tipo == typeof(Membro_ReconciliacaoLgpd) && Pessoa.membros_ReconciliacaoLgpd == null)
                { Pessoa.membros_ReconciliacaoLgpd = new List<Membro_ReconciliacaoLgpd>(); condicao = true; }
                if (Tipo == typeof(Membro_TransferenciaLgpd) && Pessoa.membros_TransferenciaLgpd == null)
                { Pessoa.membros_TransferenciaLgpd = new List<Membro_TransferenciaLgpd>(); condicao = true; }
            }

            if (Tipo.IsSubclassOf(typeof(Ministerio)) && listaMinisterios.Where(m => m.GetType().Name == Tipo.GetType().Name).ToList().Count == 0)
            {
                if (Tipo == typeof(Lider_Celula) && Ministerio.lideresCelula == null)
                { Ministerio.lideresCelula = new List<Lider_Celula>(); condicao = true; }
                if (Tipo == typeof(Lider_Celula_Treinamento) && Ministerio.LideresCelulaTreinamento == null)
                { Ministerio.LideresCelulaTreinamento = new List<Lider_Celula_Treinamento>(); condicao = true; }
                if (Tipo == typeof(Lider_Ministerio) && Ministerio.lideresMinisterio == null)
                { Ministerio.lideresMinisterio = new List<Lider_Ministerio>(); condicao = true; }
                if (Tipo == typeof(Lider_Ministerio_Treinamento) && Ministerio.lideresMinisterioTreinamento == null)
                { Ministerio.lideresMinisterioTreinamento = new List<Lider_Ministerio_Treinamento>(); condicao = true; }
                if (Tipo == typeof(Supervisor_Celula) && Ministerio.supervisoresCelula == null)
                { Ministerio.supervisoresCelula = new List<Supervisor_Celula>(); condicao = true; }
                if (Tipo == typeof(Supervisor_Celula_Treinamento) && Ministerio.supervisoresCelulaTreinamento == null)
                { Ministerio.supervisoresCelulaTreinamento = new List<Supervisor_Celula_Treinamento>(); condicao = true; }
                if (Tipo == typeof(Supervisor_Ministerio) && Ministerio.supervisoresMinisterio == null)
                { Ministerio.supervisoresMinisterio = new List<Supervisor_Ministerio>(); condicao = true; }
                if (Tipo == typeof(Supervisor_Ministerio_Treinamento) && Ministerio.supervisoresMinisterioTreinamento == null)
                { Ministerio.supervisoresMinisterioTreinamento = new List<Supervisor_Ministerio_Treinamento>(); condicao = true; }
            }

            if (Tipo.IsSubclassOf(typeof(Celula)) && listaCelulas.Where(m => m.GetType().Name == Tipo.GetType().Name).ToList().Count == 0)
            {
                if (Tipo == typeof(Celula_Adolescente) && Celula.celulasAdolescente == null)
                { Celula.celulasAdolescente = new List<Celula_Adolescente>(); condicao = true; }
                if (Tipo == typeof(Celula_Adulto) && Celula.celulasAdulto == null)
                { Celula.celulasAdulto = new List<Celula_Adulto>(); condicao = true; }
                if (Tipo == typeof(Celula_Crianca) && Celula.celulasCrianca == null)
                { Celula.celulasCrianca = new List<Celula_Crianca>(); condicao = true; }
                if (Tipo == typeof(Celula_Jovem) && Celula.celulasJovem == null)
                { Celula.celulasJovem = new List<Celula_Jovem>(); condicao = true; }
                if (Tipo == typeof(Celula_Casado) && Celula.celulasCasado == null)
                { Celula.celulasCasado = new List<Celula_Casado>(); condicao = true; }
            }

            if (Tipo == typeof(Reuniao) && listaReuniao.Count == 0) condicao = true;

            if (Tipo == typeof(MudancaEstado) && listaMudancaEstado.Count == 0) condicao = true;

            if (condicao)
            {
                var modelo = retornaModelo(Tipo);
                FormProgressBar2 form = new FormProgressBar2();
                form.MdiParent = this.MdiParent;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Text = $"Barra de processamento - {modelo.GetType().Name}";
                form.Show();
                var models = await Task.Run(() => modelo.recuperar(null));

                if (Tipo.IsSubclassOf(typeof(Pessoa)) && !modelocrud.Erro_Conexao
                    && listaPessoas.Where(m => m.GetType().Name == Tipo.GetType().Name).ToList().Count == 0)
                    listaPessoas.AddRange(models.OfType<Pessoa>().OrderBy(p => p.Codigo).ToList());

                if (Tipo.IsSubclassOf(typeof(Ministerio)) && !modelocrud.Erro_Conexao
                    && listaMinisterios.Where(m => m.GetType().Name == Tipo.GetType().Name).ToList().Count == 0)
                    listaMinisterios.AddRange(models.OfType<Ministerio>().OrderBy(p => p.IdMinisterio).ToList());

                if (Tipo.IsSubclassOf(typeof(Celula)) && !modelocrud.Erro_Conexao
                    && listaCelulas.Where(m => m.GetType().Name == Tipo.GetType().Name).ToList().Count == 0)
                    listaCelulas.AddRange(models.OfType<Celula>().OrderBy(p => p.IdCelula).ToList());

                if (Tipo == typeof(Reuniao) && !modelocrud.Erro_Conexao)
                    listaReuniao.AddRange(models.OfType<Reuniao>().OrderBy(p => p.IdReuniao).ToList());

                if (Tipo == typeof(MudancaEstado) && !modelocrud.Erro_Conexao)
                    listaMudancaEstado.AddRange(models.OfType<MudancaEstado>().OrderBy(p => p.IdMudanca).ToList());

                form.Dispose();
                ExecutarVerificacoes();

               if(!modelocrud.Erro_Conexao)
                return models;
            }
            return null;
        }

        private void ExecutarVerificacoes()
        {
            #region verificacoes
            if (Pessoa.visitantesLgpd != null
            && listaPessoas.Where(m => m.GetType().Name == new VisitanteLgpd().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.visitantesLgpd);


            if (Pessoa.visitantes != null
            && listaPessoas.Where(m => m.GetType().Name == new Visitante().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.visitantes);

            if (Pessoa.criancas != null
            && listaPessoas.Where(m => m.GetType().Name == new Crianca().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.criancas);

            if (Pessoa.criancasLgpd != null
            && listaPessoas.Where(m => m.GetType().Name == new CriancaLgpd().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.criancasLgpd);

            if (Pessoa.membros_Aclamacao != null
            && listaPessoas.Where(m => m.GetType().Name == new Membro_Aclamacao().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.membros_Aclamacao);

            if (Pessoa.membros_AclamacaoLgpd != null
            && listaPessoas.Where(m => m.GetType().Name == new Membro_AclamacaoLgpd().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.membros_AclamacaoLgpd);

            if (Pessoa.membros_Batismo != null
            && listaPessoas.Where(m => m.GetType().Name == new Membro_Batismo().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.membros_Batismo);

            if (Pessoa.membros_BatismoLgpd != null
            && listaPessoas.Where(m => m.GetType().Name == new Membro_BatismoLgpd().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.membros_BatismoLgpd);

            if (Pessoa.membros_Reconciliacao != null
            && listaPessoas.Where(m => m.GetType().Name == new Membro_Reconciliacao().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.membros_Reconciliacao);

            if (Pessoa.membros_ReconciliacaoLgpd != null
            && listaPessoas.Where(m => m.GetType().Name == new Membro_ReconciliacaoLgpd().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.membros_ReconciliacaoLgpd);

            if (Pessoa.membros_Transferencia != null
            && listaPessoas.Where(m => m.GetType().Name == new Membro_Transferencia().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.membros_Transferencia);

            if (Pessoa.membros_TransferenciaLgpd != null
            && listaPessoas.Where(m => m.GetType().Name == new Membro_TransferenciaLgpd().GetType().Name).ToList().Count == 0)
                listaPessoas.AddRange(Pessoa.membros_TransferenciaLgpd);

            if (Ministerio.lideresCelula != null
            && listaMinisterios.Where(m => m.GetType().Name == new Lider_Celula().GetType().Name).ToList().Count == 0)
                listaMinisterios.AddRange(Ministerio.lideresCelula);

            if (Ministerio.LideresCelulaTreinamento != null
            && listaMinisterios.Where(m => m.GetType().Name == new Lider_Celula_Treinamento().GetType().Name).ToList().Count == 0)
                listaMinisterios.AddRange(Ministerio.LideresCelulaTreinamento);

            if (Ministerio.lideresMinisterio != null
            && listaMinisterios.Where(m => m.GetType().Name == new Lider_Ministerio().GetType().Name).ToList().Count == 0)
                listaMinisterios.AddRange(Ministerio.lideresMinisterio);

            if (Ministerio.lideresMinisterioTreinamento != null
            && listaMinisterios.Where(m => m.GetType().Name == new Lider_Ministerio_Treinamento().GetType().Name).ToList().Count == 0)
                listaMinisterios.AddRange(Ministerio.lideresMinisterioTreinamento);

            if (Ministerio.supervisoresCelula != null
            && listaMinisterios.Where(m => m.GetType().Name == new Supervisor_Celula().GetType().Name).ToList().Count == 0)
                listaMinisterios.AddRange(Ministerio.supervisoresCelula);

            if (Ministerio.supervisoresCelulaTreinamento != null
            && listaMinisterios.Where(m => m.GetType().Name == new Supervisor_Celula_Treinamento().GetType().Name).ToList().Count == 0)

                listaMinisterios.AddRange(Ministerio.supervisoresCelulaTreinamento);

            if (Ministerio.supervisoresMinisterio != null
            && listaMinisterios.Where(m => m.GetType().Name == new Supervisor_Ministerio().GetType().Name).ToList().Count == 0)
                listaMinisterios.AddRange(Ministerio.supervisoresMinisterio);

            if (Ministerio.supervisoresMinisterioTreinamento != null
            && listaMinisterios.Where(m => m.GetType().Name == new Supervisor_Ministerio_Treinamento().GetType().Name).ToList().Count == 0)
                listaMinisterios.AddRange(Ministerio.supervisoresMinisterioTreinamento);

            if (Celula.celulasAdolescente != null
            && listaCelulas.Where(m => m.GetType().Name == new Celula_Adolescente().GetType().Name).ToList().Count == 0)
                listaCelulas.AddRange(Celula.celulasAdolescente);

            if (Celula.celulasAdulto != null
            && listaCelulas.Where(m => m.GetType().Name == new Celula_Adulto().GetType().Name).ToList().Count == 0)
                listaCelulas.AddRange(Celula.celulasAdulto);

            if (Celula.celulasCasado != null
            && listaCelulas.Where(m => m.GetType().Name == new Celula_Casado().GetType().Name).ToList().Count == 0)
                listaCelulas.AddRange(Celula.celulasCasado);

            if (Celula.celulasCrianca != null
            && listaCelulas.Where(m => m.GetType().Name == new Celula_Crianca().GetType().Name).ToList().Count == 0)
                listaCelulas.AddRange(Celula.celulasCrianca);

            if (Celula.celulasJovem != null
            && listaCelulas.Where(m => m.GetType().Name == new Celula_Jovem().GetType().Name).ToList().Count == 0)
                listaCelulas.AddRange(Celula.celulasJovem);
            #endregion

            CalcularPorcentagem();
        }

        public int GeTotalRegistrosPessoas()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
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
                catch { calcular = false; }
            }


            return _TotalRegistros;
        }

        public int GeTotalRegistrosCelulas()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
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
                catch { calcular = false; }
            }
            return _TotalRegistros;
        }

        public int GeTotalRegistrosMinisterios()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
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
                catch { calcular = false; }
            }
            return _TotalRegistros;
        }

        public int GeTotalRegistrosReunioes()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    using (con = new SqlConnection(BDcomum.conecta2))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Reuniao", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch { calcular = false; }
            }
            return _TotalRegistros;
        }

        public int GeTotalRegistrosMudancaEstado()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    using (con = new SqlConnection(BDcomum.conecta2))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM MudancaEstado", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch { calcular = false; }
            }
            return _TotalRegistros;
        }

        private modelocrud retornaModelo(Type tipo)
        {
            if (tipo == typeof(Visitante)) return new Visitante();
            if (tipo == typeof(Crianca)) return new Crianca();
            if (tipo == typeof(Membro_Aclamacao)) return new Membro_Aclamacao();
            if (tipo == typeof(Membro_Batismo)) return new Membro_Batismo();
            if (tipo == typeof(Membro_Reconciliacao)) return new Membro_Reconciliacao();
            if (tipo == typeof(Membro_Transferencia)) return new Membro_Transferencia();

            if (tipo == typeof(VisitanteLgpd)) return new VisitanteLgpd();
            if (tipo == typeof(CriancaLgpd)) return new CriancaLgpd();
            if (tipo == typeof(Membro_AclamacaoLgpd)) return new Membro_AclamacaoLgpd();
            if (tipo == typeof(Membro_BatismoLgpd)) return new Membro_BatismoLgpd();
            if (tipo == typeof(Membro_ReconciliacaoLgpd)) return new Membro_ReconciliacaoLgpd();
            if (tipo == typeof(Membro_TransferenciaLgpd)) return new Membro_TransferenciaLgpd();

            if (tipo == typeof(Lider_Celula)) return new Lider_Celula();
            if (tipo == typeof(Lider_Celula_Treinamento)) return new Lider_Celula();
            if (tipo == typeof(Lider_Ministerio)) return new Lider_Celula();
            if (tipo == typeof(Lider_Ministerio_Treinamento)) return new Lider_Celula();
            if (tipo == typeof(Supervisor_Celula)) return new Lider_Celula();
            if (tipo == typeof(Supervisor_Celula_Treinamento)) return new Lider_Celula();
            if (tipo == typeof(Supervisor_Ministerio)) return new Lider_Celula();
            if (tipo == typeof(Supervisor_Ministerio_Treinamento)) return new Lider_Celula();

            if (tipo == typeof(Celula_Adolescente)) return new Celula_Adolescente();
            if (tipo == typeof(Celula_Adulto)) return new Celula_Adulto();
            if (tipo == typeof(Celula_Casado)) return new Celula_Casado();
            if (tipo == typeof(Celula_Jovem)) return new Celula_Jovem();
            if (tipo == typeof(Celula_Crianca)) return new Celula_Crianca();

            if (tipo == typeof(Reuniao)) return new Reuniao();
            if (tipo == typeof(MudancaEstado)) return new MudancaEstado();

            return null;
        }
    }
}
