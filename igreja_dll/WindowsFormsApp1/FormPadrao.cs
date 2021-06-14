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
        private static bool executar = true;
        

        private BDcomum bd = new BDcomum();

       // public static List<Pessoa> listaPessoas;
       // public static List<Ministerio> listaMinisterios;
       // public static List<Celula> listaCelulas;
       // public static List<Reuniao> listaReuniao;
       // public static List<MudancaEstado> listaMudancaEstado;

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
            if (executar)
            {
                executar = false;

                FormProgressBar form = new FormProgressBar();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Text = "Barra de processamento - Processando dados";
                form.Show();

                var lc = await Task.Run(() => Celula.recuperarTodasCelulas());
                ExecutarVerificacoes();

                var lm = await Task.Run(() => Ministerio.recuperarTodosMinisterios());
                ExecutarVerificacoes();

                var lme = await Task.Run(() => new MudancaEstado().recuperar(null));
                ExecutarVerificacoes();

                var lr = await Task.Run(() => new Reuniao().recuperar(null));
                ExecutarVerificacoes();

                var lp = await Task.Run(() => Pessoa.recuperarTodos());
                ExecutarVerificacoes();

                try { UltimoRegistroPessoa = Pessoa.listaPessoas.OrderBy(m => m.IdPessoa).Last().Codigo; }
                catch { UltimoRegistroPessoa = 0; }
                try { UltimoRegistroReuniao = Reuniao.Reunioes.OrderBy(m => m.IdReuniao).Last().IdReuniao; }
                catch { UltimoRegistroReuniao = 0; }
                try { UltimoRegistroMinisterio = Ministerio.listaMinisterios.OrderBy(m => m.IdMinisterio).Last().IdMinisterio; }
                catch { UltimoRegistroMinisterio = 0; }
                try { UltimoRegistroCelula = Celula.listaCelulas.OrderBy(m => m.IdCelula).Last().IdCelula; }
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

                executar = true;
            }
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
                    if (registrosMinisterios != Ministerio.listaMinisterios.Count)
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
                        Ministerio.UltimoRegistro = Ministerio.listaMinisterios.OrderBy(m => m.IdMinisterio).Last().IdMinisterio;
                    }
                }
                catch { }

                try
                {
                    if (registrosCelulas != Celula.listaCelulas.Count)
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

                        Celula.UltimoRegistro = Celula.listaCelulas.OrderBy(m => m.IdCelula).Last().IdCelula;
                    }
                }
                catch { }

                try
                {
                    if (registrosPessoas != Pessoa.listaPessoas.Count)
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
                        Pessoa.UltimoRegistro = Pessoa.listaPessoas.OrderBy(m => m.IdPessoa).Last().Codigo;
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
                     Pessoa.listaPessoas.Count + Celula.listaCelulas.Count + Ministerio.listaMinisterios.Count +
                     Reuniao.Reunioes.Count;
                    

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
                if (Pessoa.listaPessoas.FirstOrDefault(i => i.IdPessoa == v2) == null)
                {
                    var model  = new Visitante()                ; var modelo =   model   .recuperar(v2);
                    var model2 = new Crianca()                  ; var modelo2 =  model2  .recuperar(v2);
                    var model3 = new Membro_Batismo()           ; var modelo3 =  model3  .recuperar(v2);
                    var model4 = new Membro_Aclamacao()         ; var modelo4 =  model4  .recuperar(v2);
                    var model5 = new Membro_Reconciliacao()     ; var modelo5 =  model5  .recuperar(v2);
                    var model6 = new Membro_Transferencia()     ; var modelo6 =  model6  .recuperar(v2);
                    var model7 = new VisitanteLgpd()            ; var modelo7 =  model7  .recuperar(v2);
                    var model8 = new CriancaLgpd()              ; var modelo8 =  model8  .recuperar(v2);
                    var model9 = new Membro_TransferenciaLgpd() ; var modelo9 =  model9  .recuperar(v2);
                    var model10 = new Membro_BatismoLgpd()      ; var modelo10 = model10 .recuperar(v2);
                    var model11 = new Membro_AclamacaoLgpd()    ; var modelo11 = model11 .recuperar(v2);
                    var model12 = new Membro_ReconciliacaoLgpd(); var modelo12 = model12.recuperar(v2);

                    if (modelo  ) Pessoa.listaPessoas.Add(model  );
                    if (modelo2 ) Pessoa.listaPessoas.Add(model2 );
                    if (modelo3 ) Pessoa.listaPessoas.Add(model3 );
                    if (modelo4 ) Pessoa.listaPessoas.Add(model4 );
                    if (modelo5 ) Pessoa.listaPessoas.Add(model5 );
                    if (modelo6 ) Pessoa.listaPessoas.Add(model6 );
                    if (modelo7 ) Pessoa.listaPessoas.Add(model7 );
                    if (modelo8 ) Pessoa.listaPessoas.Add(model8 );
                    if (modelo9 ) Pessoa.listaPessoas.Add(model9 );
                    if (modelo10) Pessoa.listaPessoas.Add(model10);
                    if (modelo11) Pessoa.listaPessoas.Add(model11);
                    if (modelo12) Pessoa.listaPessoas.Add(model12);
                }

                v2++;
            }
        }

        private void recuperarRegistrosCelula(int v1, int v2)
        {
            List<modelocrud> lista = new List<modelocrud>();
            while (v1 > v2)
            {
                if (Celula.listaCelulas.FirstOrDefault(i => i.IdCelula == v2) == null)
                {
                    var model = new Celula_Jovem()       ; var modelo =  model  .recuperar(v2);
                    var model2 = new Celula_Adolescente(); var modelo2 = model2 .recuperar(v2);
                    var model3 = new Celula_Casado()     ; var modelo3 = model3 .recuperar(v2);
                    var model4 = new Celula_Crianca()    ; var modelo4 = model4 .recuperar(v2);
                    var model5 = new Celula_Adulto()     ; var modelo5 = model5.recuperar(v2);

                    if (modelo ) Celula.listaCelulas.Add(model );
                    if (modelo2) Celula.listaCelulas.Add(model2);
                    if (modelo3) Celula.listaCelulas.Add(model3);
                    if (modelo4) Celula.listaCelulas.Add(model4);
                    if (modelo5) Celula.listaCelulas.Add(model5);
                }

                v2++;
            }
        }

        private void recuperarRegistrosMinisterio(int v1, int v2)
        {
            while (v1 >= v2)
            {
                if (Ministerio.listaMinisterios.FirstOrDefault(i => i.IdMinisterio == v2) == null)
                {
                    var model  = new Lider_Celula()                     ; var modelo  = model .recuperar(v2);
                    var model2 = new Lider_Celula_Treinamento()         ; var modelo2 = model2.recuperar(v2);
                    var model3 = new Lider_Ministerio()                 ; var modelo3 = model3.recuperar(v2);
                    var model4 = new Lider_Ministerio_Treinamento()     ; var modelo4 = model4.recuperar(v2);
                    var model5 = new Supervisor_Celula()                ; var modelo5 = model5.recuperar(v2);
                    var model6 = new Supervisor_Celula_Treinamento()    ; var modelo6 = model6.recuperar(v2);
                    var model7 = new Supervisor_Ministerio()            ; var modelo7 = model7.recuperar(v2);
                    var model8 = new Supervisor_Ministerio_Treinamento(); var modelo8 = model8.recuperar(v2);

                    if (modelo ) Ministerio.listaMinisterios.Add(model );
                    if (modelo2) Ministerio.listaMinisterios.Add(model2);
                    if (modelo3) Ministerio.listaMinisterios.Add(model3);
                    if (modelo4) Ministerio.listaMinisterios.Add(model4);
                    if (modelo5) Ministerio.listaMinisterios.Add(model5);
                    if (modelo6) Ministerio.listaMinisterios.Add(model6);
                    if (modelo7) Ministerio.listaMinisterios.Add(model7);
                    if (modelo8) Ministerio.listaMinisterios.Add(model8);
                }
                v2++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                verifica();

                if (Pessoa.visitantesLgpd != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new VisitanteLgpd().GetType().Name).ToList().Count > 0)
                    carregandoVisitanteLgpd = true;
                else carregandoVisitanteLgpd = false;
                if (Pessoa.criancasLgpd != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new CriancaLgpd().GetType().Name).ToList().Count > 0)
                    carregandoCriancaLgpd = true;
                else carregandoCriancaLgpd = false;
                if (Pessoa.membros_BatismoLgpd != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Membro_BatismoLgpd().GetType().Name).ToList().Count > 0)
                    carregandoMembroBatismoLgpd = true;
                else carregandoMembroBatismoLgpd = false;
                if (Pessoa.membros_ReconciliacaoLgpd != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Membro_ReconciliacaoLgpd().GetType().Name).ToList().Count > 0)
                    carregandoMembroReconciliacaoLgpd = true;
                else carregandoMembroReconciliacaoLgpd = false;
                if (Pessoa.membros_TransferenciaLgpd != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Membro_TransferenciaLgpd().GetType().Name).ToList().Count > 0)
                    carregandoMembroTransferenciaLgpd = true;
                else carregandoMembroTransferenciaLgpd = false;
                if (Pessoa.membros_AclamacaoLgpd != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Membro_AclamacaoLgpd().GetType().Name).ToList().Count > 0)
                    carregandoMembroAclamacaoLgpd = true;
                else carregandoMembroAclamacaoLgpd = false;
                if (Pessoa.visitantes != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Visitante().GetType().Name).ToList().Count > 0)
                    carregandoVisitante = true;
                else carregandoVisitante = false;
                if (Pessoa.criancas != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Crianca().GetType().Name).ToList().Count > 0)
                    carregandoCrianca = true;
                else carregandoCrianca = false;
                if (Pessoa.membros_Batismo != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Membro_Batismo().GetType().Name).ToList().Count > 0)
                    carregandoMembroBatismo = true;
                else carregandoMembroBatismo = false;
                if (Pessoa.membros_Reconciliacao != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Membro_Reconciliacao().GetType().Name).ToList().Count > 0)
                    carregandoMembroReconciliacao = true;
                else carregandoMembroReconciliacao = false;
                if (Pessoa.membros_Transferencia != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Membro_Transferencia().GetType().Name).ToList().Count > 0)
                    carregandoMembroTransferencia = true;
                else carregandoMembroTransferencia = false;
                if (Pessoa.membros_Aclamacao != null ||
                Pessoa.listaPessoas.Where(p => p.GetType().Name == new Membro_Aclamacao().GetType().Name).ToList().Count > 0)
                    carregandoMembroAclamacao = true;
                else carregandoMembroAclamacao = false;

        }

        public async Task<List<modelocrud>> AtualizarComModelo(Type Tipo)
        {
            modelocrud modelo = retornaModelo(Tipo);
            var retorno = await Task.Run(() => modelo.recuperar(null));

            if (retorno && modelo is Visitante) return Pessoa.visitantes.Cast<modelocrud>().ToList();
            if (retorno && modelo is Crianca) return Pessoa.criancas.Cast<modelocrud>().ToList();
            if (retorno && modelo is Membro_Aclamacao) return Pessoa.membros_Aclamacao.Cast<modelocrud>().ToList();
            if (retorno && modelo is Membro_Batismo) return Pessoa.membros_Batismo.Cast<modelocrud>().ToList();
            if (retorno && modelo is Membro_Reconciliacao) return Pessoa.membros_Reconciliacao.Cast<modelocrud>().ToList();
            if (retorno && modelo is Membro_Transferencia) return Pessoa.membros_Transferencia.Cast<modelocrud>().ToList();
            if (retorno && modelo is VisitanteLgpd) return Pessoa.visitantesLgpd.Cast<modelocrud>().ToList();
            if (retorno && modelo is CriancaLgpd) return Pessoa.criancasLgpd.Cast<modelocrud>().ToList();
            if (retorno && modelo is Membro_AclamacaoLgpd) return Pessoa.membros_AclamacaoLgpd.Cast<modelocrud>().ToList();
            if (retorno && modelo is Membro_BatismoLgpd) return Pessoa.membros_BatismoLgpd.Cast<modelocrud>().ToList();
            if (retorno && modelo is Membro_ReconciliacaoLgpd) return Pessoa.membros_ReconciliacaoLgpd.Cast<modelocrud>().ToList();
            if (retorno && modelo is Membro_TransferenciaLgpd) return Pessoa.membros_TransferenciaLgpd.Cast<modelocrud>().ToList();

            if (retorno && modelo is Lider_Celula) return Ministerio.lideresCelula.Cast<modelocrud>().ToList();
            if (retorno && modelo is Lider_Celula_Treinamento) return Ministerio.LideresCelulaTreinamento.Cast<modelocrud>().ToList();
            if (retorno && modelo is Lider_Ministerio) return Ministerio.lideresMinisterio.Cast<modelocrud>().ToList();
            if (retorno && modelo is Lider_Ministerio_Treinamento) return Ministerio.lideresMinisterioTreinamento.Cast<modelocrud>().ToList();
            if (retorno && modelo is Supervisor_Celula) return Ministerio.supervisoresCelula.Cast<modelocrud>().ToList();
            if (retorno && modelo is Supervisor_Celula_Treinamento) return Ministerio.supervisoresCelulaTreinamento.Cast<modelocrud>().ToList();
            if (retorno && modelo is Supervisor_Ministerio) return Ministerio.supervisoresMinisterio.Cast<modelocrud>().ToList();
            if (retorno && modelo is Supervisor_Ministerio_Treinamento) return Ministerio.supervisoresMinisterioTreinamento.Cast<modelocrud>().ToList();

            if (retorno && modelo is Celula_Adolescente) return Celula.celulasAdolescente.Cast<modelocrud>().ToList();
            if (retorno && modelo is Celula_Adulto) return Celula.celulasAdulto.Cast<modelocrud>().ToList();
            if (retorno && modelo is Celula_Casado) return Celula.celulasCasado.Cast<modelocrud>().ToList();
            if (retorno && modelo is Celula_Jovem) return Celula.celulasJovem.Cast<modelocrud>().ToList();
            if (retorno && modelo is Celula_Crianca) return Celula.celulasCrianca.Cast<modelocrud>().ToList();

            if (retorno && modelo is Reuniao) return Reuniao.Reunioes.Cast<modelocrud>().ToList();
            if (retorno && modelo is MudancaEstado) return MudancaEstado.Mudancas.Cast<modelocrud>().ToList();

            return new List<modelocrud>();
        }        

        public async Task<List<modelocrud>> AtualizarComProgressBar(Type Tipo)
        {
            bool condicao = false;

            if (Tipo.IsSubclassOf(typeof(Pessoa)) && Pessoa.listaPessoas.Where(m => m.GetType().Name == Tipo.Name).ToList().Count == 0)
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

            if (Tipo.IsSubclassOf(typeof(Ministerio)) && Ministerio.listaMinisterios.Where(m => m.GetType().Name == Tipo.Name).ToList().Count == 0)
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

            if (Tipo.IsSubclassOf(typeof(Celula)) && Celula.listaCelulas.Where(m => m.GetType().Name == Tipo.Name).ToList().Count == 0)
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

            if (Tipo == typeof(Reuniao) && Reuniao.Reunioes.Count == 0) condicao = true;

            if (Tipo == typeof(MudancaEstado) && MudancaEstado.Mudancas.Count == 0) condicao = true;

            if (condicao)
            {
                var modelo = retornaModelo(Tipo);
                FormProgressBar2 form = new FormProgressBar2();
                form.MdiParent = this.MdiParent;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Text = $"Barra de processamento - {modelo.GetType().Name}";
                form.Show();
                var retorno = await Task.Run(() => modelo.recuperar(null));

                if (Tipo.IsSubclassOf(typeof(Pessoa)) && !modelocrud.Erro_Conexao
                    && Pessoa.listaPessoas.Where(m => m.GetType().Name == Tipo.Name).ToList().Count == 0)
                {
                    List<Pessoa> pessoas = new List<Pessoa>();
                    if (retorno && modelo is Visitante               ) Pessoa.listaPessoas.AddRange(Pessoa.visitantes               );
                    if (retorno && modelo is Crianca                 ) Pessoa.listaPessoas.AddRange(Pessoa.criancas                 );
                    if (retorno && modelo is Membro_Aclamacao        ) Pessoa.listaPessoas.AddRange(Pessoa.membros_Aclamacao        );
                    if (retorno && modelo is Membro_Batismo          ) Pessoa.listaPessoas.AddRange(Pessoa.membros_Batismo          );
                    if (retorno && modelo is Membro_Reconciliacao    ) Pessoa.listaPessoas.AddRange(Pessoa.membros_Reconciliacao    );
                    if (retorno && modelo is Membro_Transferencia    ) Pessoa.listaPessoas.AddRange(Pessoa.membros_Transferencia    );
                    if (retorno && modelo is VisitanteLgpd           ) Pessoa.listaPessoas.AddRange(Pessoa.visitantesLgpd           );
                    if (retorno && modelo is CriancaLgpd             ) Pessoa.listaPessoas.AddRange(Pessoa.criancasLgpd             );
                    if (retorno && modelo is Membro_AclamacaoLgpd    ) Pessoa.listaPessoas.AddRange(Pessoa.membros_AclamacaoLgpd    );
                    if (retorno && modelo is Membro_BatismoLgpd      ) Pessoa.listaPessoas.AddRange(Pessoa.membros_BatismoLgpd      );
                    if (retorno && modelo is Membro_ReconciliacaoLgpd) Pessoa.listaPessoas.AddRange(Pessoa.membros_ReconciliacaoLgpd);
                    if (retorno && modelo is Membro_TransferenciaLgpd) Pessoa.listaPessoas.AddRange(Pessoa.membros_TransferenciaLgpd);
                }

                if (Tipo.IsSubclassOf(typeof(Ministerio)) && !modelocrud.Erro_Conexao
                    && Ministerio.listaMinisterios.Where(m => m.GetType().Name == Tipo.Name).ToList().Count == 0)
                {
                    if (retorno && modelo is Lider_Celula                     ) Ministerio.listaMinisterios.AddRange(Ministerio.lideresCelula                    );
                    if (retorno && modelo is Lider_Celula_Treinamento         ) Ministerio.listaMinisterios.AddRange(Ministerio.LideresCelulaTreinamento         );
                    if (retorno && modelo is Lider_Ministerio                 ) Ministerio.listaMinisterios.AddRange(Ministerio.lideresMinisterio                );
                    if (retorno && modelo is Lider_Ministerio_Treinamento     ) Ministerio.listaMinisterios.AddRange(Ministerio.lideresMinisterioTreinamento     );
                    if (retorno && modelo is Supervisor_Celula                ) Ministerio.listaMinisterios.AddRange(Ministerio.supervisoresCelula               );
                    if (retorno && modelo is Supervisor_Celula_Treinamento    ) Ministerio.listaMinisterios.AddRange(Ministerio.supervisoresCelulaTreinamento    );
                    if (retorno && modelo is Supervisor_Ministerio            ) Ministerio.listaMinisterios.AddRange(Ministerio.supervisoresMinisterio           );
                    if (retorno && modelo is Supervisor_Ministerio_Treinamento) Ministerio.listaMinisterios.AddRange(Ministerio.supervisoresMinisterioTreinamento);
                }

                if (Tipo.IsSubclassOf(typeof(Celula)) && !modelocrud.Erro_Conexao
                    && Celula.listaCelulas.Where(m => m.GetType().Name == Tipo.Name).ToList().Count == 0)
                {
                    if (retorno && modelo is Celula_Adolescente) Celula.listaCelulas.AddRange(Celula.celulasAdolescente);
                    if (retorno && modelo is Celula_Adulto     ) Celula.listaCelulas.AddRange(Celula.celulasAdulto     );
                    if (retorno && modelo is Celula_Casado     ) Celula.listaCelulas.AddRange(Celula.celulasCasado     );
                    if (retorno && modelo is Celula_Jovem      ) Celula.listaCelulas.AddRange(Celula.celulasJovem      );
                    if (retorno && modelo is Celula_Crianca    ) Celula.listaCelulas.AddRange(Celula.celulasCrianca    );
                }

                if (Tipo == typeof(Reuniao) && !modelocrud.Erro_Conexao)
                    if (retorno && modelo is Reuniao && Reuniao.Reunioes != null) Reuniao.Reunioes.AddRange(Reuniao.Reunioes);

                if (Tipo == typeof(MudancaEstado) && !modelocrud.Erro_Conexao)
                    if (retorno && modelo is MudancaEstado & MudancaEstado.Mudancas != null) MudancaEstado.Mudancas.AddRange(MudancaEstado.Mudancas);

                form.Dispose();
                ExecutarVerificacoes();

                if (!modelocrud.Erro_Conexao)
                {
                    if (retorno && modelo is Visitante               ) return Pessoa.visitantes               .Cast<modelocrud>().ToList();              
                    if (retorno && modelo is Crianca                 ) return Pessoa.criancas                 .Cast<modelocrud>().ToList();                
                    if (retorno && modelo is Membro_Aclamacao        ) return Pessoa.membros_Aclamacao        .Cast<modelocrud>().ToList();       
                    if (retorno && modelo is Membro_Batismo          ) return Pessoa.membros_Batismo          .Cast<modelocrud>().ToList();         
                    if (retorno && modelo is Membro_Reconciliacao    ) return Pessoa.membros_Reconciliacao    .Cast<modelocrud>().ToList();   
                    if (retorno && modelo is Membro_Transferencia    ) return Pessoa.membros_Transferencia    .Cast<modelocrud>().ToList();   
                    if (retorno && modelo is VisitanteLgpd           ) return Pessoa.visitantesLgpd           .Cast<modelocrud>().ToList();          
                    if (retorno && modelo is CriancaLgpd             ) return Pessoa.criancasLgpd             .Cast<modelocrud>().ToList();            
                    if (retorno && modelo is Membro_AclamacaoLgpd    ) return Pessoa.membros_AclamacaoLgpd    .Cast<modelocrud>().ToList();   
                    if (retorno && modelo is Membro_BatismoLgpd      ) return Pessoa.membros_BatismoLgpd      .Cast<modelocrud>().ToList();     
                    if (retorno && modelo is Membro_ReconciliacaoLgpd) return Pessoa.membros_ReconciliacaoLgpd.Cast<modelocrud>().ToList();
                    if (retorno && modelo is Membro_TransferenciaLgpd) return Pessoa.membros_TransferenciaLgpd.Cast<modelocrud>().ToList();

                    if (retorno && modelo is Lider_Celula                     ) return  Ministerio.lideresCelula                    .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Lider_Celula_Treinamento         ) return  Ministerio.LideresCelulaTreinamento         .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Lider_Ministerio                 ) return  Ministerio.lideresMinisterio                .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Lider_Ministerio_Treinamento     ) return  Ministerio.lideresMinisterioTreinamento     .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Supervisor_Celula                ) return  Ministerio.supervisoresCelula               .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Supervisor_Celula_Treinamento    ) return  Ministerio.supervisoresCelulaTreinamento    .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Supervisor_Ministerio            ) return  Ministerio.supervisoresMinisterio           .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Supervisor_Ministerio_Treinamento) return Ministerio.supervisoresMinisterioTreinamento .Cast<modelocrud>().ToList();

                    if (retorno && modelo is Celula_Adolescente) return Celula.celulasAdolescente  .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Celula_Adulto     ) return Celula.celulasAdulto       .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Celula_Casado     ) return Celula.celulasCasado       .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Celula_Jovem      ) return Celula.celulasJovem        .Cast<modelocrud>().ToList();
                    if (retorno && modelo is Celula_Crianca    ) return Celula.celulasCrianca       .Cast<modelocrud>().ToList();

                    if (retorno && modelo is Reuniao) return Reuniao.Reunioes.Cast<modelocrud>().ToList();
                    if(retorno && modelo is MudancaEstado) return MudancaEstado.Mudancas.Cast<modelocrud>().ToList();
                }                                                                                                                  
            }                                                                                                                      
            return null;                                                                                                           
        }                                                                                                                           

        private void ExecutarVerificacoes()
        {
            #region verificacoes
            if (Pessoa.visitantesLgpd != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new VisitanteLgpd().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.visitantesLgpd);


            if (Pessoa.visitantes != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Visitante().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.visitantes);

            if (Pessoa.criancas != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Crianca().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.criancas);

            if (Pessoa.criancasLgpd != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new CriancaLgpd().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.criancasLgpd);

            if (Pessoa.membros_Aclamacao != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Membro_Aclamacao().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.membros_Aclamacao);

            if (Pessoa.membros_AclamacaoLgpd != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Membro_AclamacaoLgpd().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.membros_AclamacaoLgpd);

            if (Pessoa.membros_Batismo != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Membro_Batismo().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.membros_Batismo);

            if (Pessoa.membros_BatismoLgpd != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Membro_BatismoLgpd().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.membros_BatismoLgpd);

            if (Pessoa.membros_Reconciliacao != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Membro_Reconciliacao().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.membros_Reconciliacao);

            if (Pessoa.membros_ReconciliacaoLgpd != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Membro_ReconciliacaoLgpd().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.membros_ReconciliacaoLgpd);

            if (Pessoa.membros_Transferencia != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Membro_Transferencia().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.membros_Transferencia);

            if (Pessoa.membros_TransferenciaLgpd != null
            && Pessoa.listaPessoas.Where(m => m.GetType().Name == new Membro_TransferenciaLgpd().GetType().Name).ToList().Count == 0)
                Pessoa.listaPessoas.AddRange(Pessoa.membros_TransferenciaLgpd);

            if (Ministerio.lideresCelula != null
            && Ministerio.listaMinisterios.Where(m => m.GetType().Name == new Lider_Celula().GetType().Name).ToList().Count == 0)
                Ministerio.listaMinisterios.AddRange(Ministerio.lideresCelula);

            if (Ministerio.LideresCelulaTreinamento != null
            && Ministerio.listaMinisterios.Where(m => m.GetType().Name == new Lider_Celula_Treinamento().GetType().Name).ToList().Count == 0)
                Ministerio.listaMinisterios.AddRange(Ministerio.LideresCelulaTreinamento);

            if (Ministerio.lideresMinisterio != null
            && Ministerio.listaMinisterios.Where(m => m.GetType().Name == new Lider_Ministerio().GetType().Name).ToList().Count == 0)
                Ministerio.listaMinisterios.AddRange(Ministerio.lideresMinisterio);

            if (Ministerio.lideresMinisterioTreinamento != null
            && Ministerio.listaMinisterios.Where(m => m.GetType().Name == new Lider_Ministerio_Treinamento().GetType().Name).ToList().Count == 0)
                Ministerio.listaMinisterios.AddRange(Ministerio.lideresMinisterioTreinamento);

            if (Ministerio.supervisoresCelula != null
            && Ministerio.listaMinisterios.Where(m => m.GetType().Name == new Supervisor_Celula().GetType().Name).ToList().Count == 0)
                Ministerio.listaMinisterios.AddRange(Ministerio.supervisoresCelula);

            if (Ministerio.supervisoresCelulaTreinamento != null
            && Ministerio.listaMinisterios.Where(m => m.GetType().Name == new Supervisor_Celula_Treinamento().GetType().Name).ToList().Count == 0)

                Ministerio.listaMinisterios.AddRange(Ministerio.supervisoresCelulaTreinamento);

            if (Ministerio.supervisoresMinisterio != null
            && Ministerio.listaMinisterios.Where(m => m.GetType().Name == new Supervisor_Ministerio().GetType().Name).ToList().Count == 0)
                Ministerio.listaMinisterios.AddRange(Ministerio.supervisoresMinisterio);

            if (Ministerio.supervisoresMinisterioTreinamento != null
            && Ministerio.listaMinisterios.Where(m => m.GetType().Name == new Supervisor_Ministerio_Treinamento().GetType().Name).ToList().Count == 0)
                Ministerio.listaMinisterios.AddRange(Ministerio.supervisoresMinisterioTreinamento);

            if (Celula.celulasAdolescente != null
            && Celula.listaCelulas.Where(m => m.GetType().Name == new Celula_Adolescente().GetType().Name).ToList().Count == 0)
                Celula.listaCelulas.AddRange(Celula.celulasAdolescente);

            if (Celula.celulasAdulto != null
            && Celula.listaCelulas.Where(m => m.GetType().Name == new Celula_Adulto().GetType().Name).ToList().Count == 0)
                Celula.listaCelulas.AddRange(Celula.celulasAdulto);

            if (Celula.celulasCasado != null
            && Celula.listaCelulas.Where(m => m.GetType().Name == new Celula_Casado().GetType().Name).ToList().Count == 0)
                Celula.listaCelulas.AddRange(Celula.celulasCasado);

            if (Celula.celulasCrianca != null
            && Celula.listaCelulas.Where(m => m.GetType().Name == new Celula_Crianca().GetType().Name).ToList().Count == 0)
                Celula.listaCelulas.AddRange(Celula.celulasCrianca);

            if (Celula.celulasJovem != null
            && Celula.listaCelulas.Where(m => m.GetType().Name == new Celula_Jovem().GetType().Name).ToList().Count == 0)
                Celula.listaCelulas.AddRange(Celula.celulasJovem);
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
