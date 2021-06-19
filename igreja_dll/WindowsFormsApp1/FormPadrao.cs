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
using WindowsFormsApp1.Formulario;

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

        private static bool verificarLista = true;
        private static bool podeVerificar = false;
        private static bool executar = true;
        private static bool verificarTimer = true;

        private BDcomum bd = new BDcomum();

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

                var lm = await Task.Run(() => Ministerio.recuperarTodosMinisterios());

                var lme = await Task.Run(() => new MudancaEstado().recuperar(null));

                var lr = await Task.Run(() => new Reuniao().recuperar(null));

                var lp = await Task.Run(() => Pessoa.recuperarTodos());

                await Task.Run(() => {

                    while (int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99)
                    { executar = false; podeVerificar = false; }
                });

                
                if(!form.IsDisposed)
                form.Dispose();                             

                executar = true; podeVerificar = true;
            }
        }

        private async void verifica()
        {
            if (verificarLista && podeVerificar && BDcomum.podeAbrir)
            {
                verificarLista = false;
                await verificarListagem();
                verificarLista = true;
            }
        }

        private async Task verificarListagem()
        {
            var registrosMinisterios = modelocrud.GeTotalRegistrosMinisterios();
            var registrosPessoas = modelocrud.GeTotalRegistrosPessoas();
            var registrosCelulas = modelocrud.GeTotalRegistrosCelulas();
            try
            {
                if (registrosMinisterios != Ministerio.listaMinisterios.Count)
                {
                    FormProgressBar2 form = new FormProgressBar2();
                    
                        form.MdiParent = this.MdiParent;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Text = "Barra de processamento - Ministerios";
                        form.Show();
                        await Task.Run(() => recuperarRegistrosMinisterio(bd.GetUltimoRegistroMinisterio() + 10));

                    if (!form.IsDisposed)
                        form.Dispose();

                    Ministerio.UltimoRegistro = Ministerio.listaMinisterios.OrderBy(m => m.IdMinisterio).Last().IdMinisterio;
                }
            }
            catch { }

            try
            {
                if (registrosCelulas != Celula.listaCelulas.Count)
                {
                    FormProgressBar2 form = new FormProgressBar2();
                    
                        form.MdiParent = this.MdiParent;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Text = "Barra de processamento - Celulas";
                        form.Show();
                        await Task.Run(() => recuperarRegistrosCelula(bd.GetUltimoRegistroCelula() + 10));
                        
                    if (!form.IsDisposed)
                        form.Dispose();

                    Celula.UltimoRegistro = Celula.listaCelulas.OrderBy(m => m.IdCelula).Last().IdCelula;
                }
            }
            catch { }

            try
            {
                if (registrosPessoas != Pessoa.listaPessoas.Count)
                {
                    FormProgressBar2 form = new FormProgressBar2();
                    
                        form.MdiParent = this.MdiParent;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Text = "Barra de processamento - Pessoas";
                        form.Show();
                        await Task.Run(() => recuperarRegistrosPessoa(bd.GetUltimoRegistroPessoa() + 10));

                        if(!form.IsDisposed)
                        form.Dispose();
                    
                    Pessoa.UltimoRegistro = Pessoa.listaPessoas.OrderBy(m => m.IdPessoa).Last().Codigo;
                }
            }
            catch { }
        }

        private void recuperarRegistrosPessoa(int v1)
        {
            var v2 = 1;
            List<modelocrud> lista = new List<modelocrud>();
            while (v1 >= v2)
            {
                if (Pessoa.listaPessoas.FirstOrDefault(i => i.IdPessoa == v2) == null)
                {
                    var model = new  Visitante                (); var modelo = model.recuperar(v2);
                    var model2 = new Crianca                  (); var modelo2 = model2.recuperar(v2);
                    var model3 = new Membro_Batismo           (); var modelo3 = model3.recuperar(v2);
                    var model4 = new Membro_Aclamacao         (); var modelo4 = model4.recuperar(v2);
                    var model5 = new Membro_Reconciliacao     (); var modelo5 = model5.recuperar(v2);
                    var model6 = new Membro_Transferencia     (); var modelo6 = model6.recuperar(v2);
                    var model7 = new VisitanteLgpd            (); var modelo7 = model7.recuperar(v2);
                    var model8 = new CriancaLgpd              (); var modelo8 = model8.recuperar(v2);
                    var model9 = new Membro_TransferenciaLgpd (); var modelo9 = model9.recuperar(v2);
                    var model10 = new Membro_BatismoLgpd      (); var modelo10 = model10.recuperar(v2);
                    var model11 = new Membro_AclamacaoLgpd    (); var modelo11 = model11.recuperar(v2);
                    var model12 = new Membro_ReconciliacaoLgpd(); var modelo12 = model12.recuperar(v2);

                    if (modelo  ) Pessoa.listaPessoas.Add(model);
                    if (modelo2 ) Pessoa.listaPessoas.Add(model2);
                    if (modelo3 ) Pessoa.listaPessoas.Add(model3);
                    if (modelo4 ) Pessoa.listaPessoas.Add(model4);
                    if (modelo5 ) Pessoa.listaPessoas.Add(model5);
                    if (modelo6 ) Pessoa.listaPessoas.Add(model6);
                    if (modelo7 ) Pessoa.listaPessoas.Add(model7);
                    if (modelo8 ) Pessoa.listaPessoas.Add(model8);
                    if (modelo9 ) Pessoa.listaPessoas.Add(model9);
                    if (modelo10) Pessoa.listaPessoas.Add(model10);
                    if (modelo11) Pessoa.listaPessoas.Add(model11);
                    if (modelo12) Pessoa.listaPessoas.Add(model12);
                }

                v2++;
            }
        }

        private void recuperarRegistrosCelula(int v1)
        {
            var v2 = 1;
            List<modelocrud> lista = new List<modelocrud>();
            while (v1 > v2)
            {
                if (Celula.listaCelulas.FirstOrDefault(i => i.IdCelula == v2) == null)
                {
                    var model =  new Celula_Jovem      (); var modelo = model.recuperar(v2);
                    var model2 = new Celula_Adolescente(); var modelo2 = model2.recuperar(v2);
                    var model3 = new Celula_Casado     (); var modelo3 = model3.recuperar(v2);
                    var model4 = new Celula_Crianca    (); var modelo4 = model4.recuperar(v2);
                    var model5 = new Celula_Adulto     (); var modelo5 = model5.recuperar(v2);

                    if (modelo ) Celula.listaCelulas.Add(model);
                    if (modelo2) Celula.listaCelulas.Add(model2);
                    if (modelo3) Celula.listaCelulas.Add(model3);
                    if (modelo4) Celula.listaCelulas.Add(model4);
                    if (modelo5) Celula.listaCelulas.Add(model5);
                }

                v2++;
            }
        }

        private  void recuperarRegistrosMinisterio(int v1)
        {
            var v2 = 1;
            while (v1 >= v2)
            {
                if (Ministerio.listaMinisterios.FirstOrDefault(i => i.IdMinisterio == v2) == null)
                {
                    var model =  new Lider_Celula                     (); var modelo = model.recuperar(v2);
                    var model2 = new Lider_Celula_Treinamento         (); var modelo2 = model2.recuperar(v2);
                    var model3 = new Lider_Ministerio                 (); var modelo3 = model3.recuperar(v2);
                    var model4 = new Lider_Ministerio_Treinamento     (); var modelo4 = model4.recuperar(v2);
                    var model5 = new Supervisor_Celula                (); var modelo5 = model5.recuperar(v2);
                    var model6 = new Supervisor_Celula_Treinamento    (); var modelo6 = model6.recuperar(v2);
                    var model7 = new Supervisor_Ministerio            (); var modelo7 = model7.recuperar(v2);
                    var model8 = new Supervisor_Ministerio_Treinamento(); var modelo8 = model8.recuperar(v2);

                    if (modelo ) Ministerio.listaMinisterios.Add(model);
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

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (verificarTimer)
            {
                verificarTimer = false;
                verifica();

                if (int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99)
                    await Task.Run(() => verificarBoleanos());

                if (int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99)
                    await Task.Run(() => modelocrud.calcularPorcentagem());

                verificarTimer = true;
            }

            if (this is FormularioListView && Width < 150)
                Width = 470;
        }

        private static void verificarBoleanos()
        {
            if (Pessoa.visitantesLgpd != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new VisitanteLgpd().GetType().Name) != null)
                carregandoVisitanteLgpd = true;
            else carregandoVisitanteLgpd = false;
            if (Pessoa.criancasLgpd != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new CriancaLgpd().GetType().Name) != null)
                carregandoCriancaLgpd = true;
            else carregandoCriancaLgpd = false;
            if (Pessoa.membros_BatismoLgpd != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Membro_BatismoLgpd().GetType().Name) != null)
                carregandoMembroBatismoLgpd = true;
            else carregandoMembroBatismoLgpd = false;
            if (Pessoa.membros_ReconciliacaoLgpd != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Membro_ReconciliacaoLgpd().GetType().Name) != null)
                carregandoMembroReconciliacaoLgpd = true;
            else carregandoMembroReconciliacaoLgpd = false;
            if (Pessoa.membros_TransferenciaLgpd != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Membro_TransferenciaLgpd().GetType().Name) != null)
                carregandoMembroTransferenciaLgpd = true;
            else carregandoMembroTransferenciaLgpd = false;
            if (Pessoa.membros_AclamacaoLgpd != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Membro_AclamacaoLgpd().GetType().Name) != null)
                carregandoMembroAclamacaoLgpd = true;
            else carregandoMembroAclamacaoLgpd = false;
            if (Pessoa.visitantes != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Visitante().GetType().Name) != null)
                carregandoVisitante = true;
            else carregandoVisitante = false;
            if (Pessoa.criancas != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Crianca().GetType().Name) != null)
                carregandoCrianca = true;
            else carregandoCrianca = false;
            if (Pessoa.membros_Batismo != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Membro_Batismo().GetType().Name) != null)
                carregandoMembroBatismo = true;
            else carregandoMembroBatismo = false;
            if (Pessoa.membros_Reconciliacao != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Membro_Reconciliacao().GetType().Name) != null)
                carregandoMembroReconciliacao = true;
            else carregandoMembroReconciliacao = false;
            if (Pessoa.membros_Transferencia != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Membro_Transferencia().GetType().Name) != null)
                carregandoMembroTransferencia = true;
            else carregandoMembroTransferencia = false;
            if (Pessoa.membros_Aclamacao != null ||
            Pessoa.listaPessoas.FirstOrDefault(p => p.GetType().Name == new Membro_Aclamacao().GetType().Name) != null)
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

            if (Tipo.IsSubclassOf(typeof(Pessoa)) && Pessoa.listaPessoas.FirstOrDefault(m => m.GetType().Name == Tipo.Name) == null)
            {
                if (Tipo == typeof(Visitante) && Pessoa.visitantes == null) condicao = true;
                if (Tipo == typeof(Crianca) && Pessoa.criancas == null) condicao = true;
                if (Tipo == typeof(Membro_Aclamacao) && Pessoa.membros_Aclamacao == null) condicao = true;
                if (Tipo == typeof(Membro_Batismo) && Pessoa.membros_Batismo == null) condicao = true;
                if (Tipo == typeof(Membro_Reconciliacao) && Pessoa.membros_Reconciliacao == null) condicao = true;
                if (Tipo == typeof(Membro_Transferencia) && Pessoa.membros_Transferencia == null) condicao = true;
                if (Tipo == typeof(VisitanteLgpd) && Pessoa.visitantesLgpd == null) condicao = true;
                if (Tipo == typeof(CriancaLgpd) && Pessoa.criancasLgpd == null) condicao = true;
                if (Tipo == typeof(Membro_AclamacaoLgpd) && Pessoa.membros_AclamacaoLgpd == null) condicao = true;
                if (Tipo == typeof(Membro_BatismoLgpd) && Pessoa.membros_BatismoLgpd == null) condicao = true;
                if (Tipo == typeof(Membro_ReconciliacaoLgpd) && Pessoa.membros_ReconciliacaoLgpd == null) condicao = true;
                if (Tipo == typeof(Membro_TransferenciaLgpd) && Pessoa.membros_TransferenciaLgpd == null) condicao = true;
            }

            if (Tipo.IsSubclassOf(typeof(Ministerio)) && Ministerio.listaMinisterios.FirstOrDefault(m => m.GetType().Name == Tipo.Name) == null)
            {
                if (Tipo == typeof(Lider_Celula) && Ministerio.lideresCelula == null) condicao = true;
                if (Tipo == typeof(Lider_Celula_Treinamento) && Ministerio.LideresCelulaTreinamento == null) condicao = true;
                if (Tipo == typeof(Lider_Ministerio) && Ministerio.lideresMinisterio == null) condicao = true;
                if (Tipo == typeof(Lider_Ministerio_Treinamento) && Ministerio.lideresMinisterioTreinamento == null) condicao = true;
                if (Tipo == typeof(Supervisor_Celula) && Ministerio.supervisoresCelula == null) condicao = true;
                if (Tipo == typeof(Supervisor_Celula_Treinamento) && Ministerio.supervisoresCelulaTreinamento == null) condicao = true;
                if (Tipo == typeof(Supervisor_Ministerio) && Ministerio.supervisoresMinisterio == null) condicao = true;
                if (Tipo == typeof(Supervisor_Ministerio_Treinamento) && Ministerio.supervisoresMinisterioTreinamento == null) condicao = true;
            }

            if (Tipo.IsSubclassOf(typeof(Celula)) && Celula.listaCelulas.FirstOrDefault(m => m.GetType().Name == Tipo.Name) == null)
            {
                if (Tipo == typeof(Celula_Adolescente) && Celula.celulasAdolescente == null) condicao = true;
                if (Tipo == typeof(Celula_Adulto) && Celula.celulasAdulto == null) condicao = true;
                if (Tipo == typeof(Celula_Crianca) && Celula.celulasCrianca == null) condicao = true;
                if (Tipo == typeof(Celula_Jovem) && Celula.celulasJovem == null) condicao = true;
                if (Tipo == typeof(Celula_Casado) && Celula.celulasCasado == null) condicao = true;
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
                    && Pessoa.listaPessoas.FirstOrDefault(m => m.GetType().Name == Tipo.Name) == null)
                {
                    List<Pessoa> pessoas = new List<Pessoa>();
                    if (retorno && modelo is Visitante)                Pessoa.listaPessoas.AddRange(Pessoa.visitantes               );
                    if (retorno && modelo is Crianca)                  Pessoa.listaPessoas.AddRange(Pessoa.criancas                 );
                    if (retorno && modelo is Membro_Aclamacao)         Pessoa.listaPessoas.AddRange(Pessoa.membros_Aclamacao        );
                    if (retorno && modelo is Membro_Batismo)           Pessoa.listaPessoas.AddRange(Pessoa.membros_Batismo          );
                    if (retorno && modelo is Membro_Reconciliacao)     Pessoa.listaPessoas.AddRange(Pessoa.membros_Reconciliacao    );
                    if (retorno && modelo is Membro_Transferencia)     Pessoa.listaPessoas.AddRange(Pessoa.membros_Transferencia    );
                    if (retorno && modelo is VisitanteLgpd)            Pessoa.listaPessoas.AddRange(Pessoa.visitantesLgpd           );
                    if (retorno && modelo is CriancaLgpd)              Pessoa.listaPessoas.AddRange(Pessoa.criancasLgpd             );
                    if (retorno && modelo is Membro_AclamacaoLgpd)     Pessoa.listaPessoas.AddRange(Pessoa.membros_AclamacaoLgpd    );
                    if (retorno && modelo is Membro_BatismoLgpd)       Pessoa.listaPessoas.AddRange(Pessoa.membros_BatismoLgpd      );
                    if (retorno && modelo is Membro_ReconciliacaoLgpd) Pessoa.listaPessoas.AddRange(Pessoa.membros_ReconciliacaoLgpd);
                    if (retorno && modelo is Membro_TransferenciaLgpd) Pessoa.listaPessoas.AddRange(Pessoa.membros_TransferenciaLgpd);
                }

                if (Tipo.IsSubclassOf(typeof(Ministerio)) && !modelocrud.Erro_Conexao
                    && Ministerio.listaMinisterios.FirstOrDefault(m => m.GetType().Name == Tipo.Name) == null)
                {
                    if (retorno && modelo is Lider_Celula) Ministerio.listaMinisterios.AddRange                     (Ministerio.lideresCelula                    );
                    if (retorno && modelo is Lider_Celula_Treinamento) Ministerio.listaMinisterios.AddRange         (Ministerio.LideresCelulaTreinamento         );
                    if (retorno && modelo is Lider_Ministerio) Ministerio.listaMinisterios.AddRange                 (Ministerio.lideresMinisterio                );
                    if (retorno && modelo is Lider_Ministerio_Treinamento) Ministerio.listaMinisterios.AddRange     (Ministerio.lideresMinisterioTreinamento     );
                    if (retorno && modelo is Supervisor_Celula) Ministerio.listaMinisterios.AddRange                (Ministerio.supervisoresCelula               );
                    if (retorno && modelo is Supervisor_Celula_Treinamento) Ministerio.listaMinisterios.AddRange    (Ministerio.supervisoresCelulaTreinamento    );
                    if (retorno && modelo is Supervisor_Ministerio) Ministerio.listaMinisterios.AddRange            (Ministerio.supervisoresMinisterio           );
                    if (retorno && modelo is Supervisor_Ministerio_Treinamento) Ministerio.listaMinisterios.AddRange(Ministerio.supervisoresMinisterioTreinamento);
                }

                if (Tipo.IsSubclassOf(typeof(Celula)) && !modelocrud.Erro_Conexao
                    && Celula.listaCelulas.FirstOrDefault(m => m.GetType().Name == Tipo.Name) == null)
                {
                    if (retorno && modelo is Celula_Adolescente) Celula.listaCelulas.AddRange(Celula.celulasAdolescente);
                    if (retorno && modelo is Celula_Adulto) Celula.listaCelulas.AddRange     (Celula.celulasAdulto     );
                    if (retorno && modelo is Celula_Casado) Celula.listaCelulas.AddRange     (Celula.celulasCasado     );
                    if (retorno && modelo is Celula_Jovem) Celula.listaCelulas.AddRange      (Celula.celulasJovem      );
                    if (retorno && modelo is Celula_Crianca) Celula.listaCelulas.AddRange    (Celula.celulasCrianca    );
                }

                if (Tipo == typeof(Reuniao) && !modelocrud.Erro_Conexao)
                    if (retorno && modelo is Reuniao && Reuniao.Reunioes != null) Reuniao.Reunioes.AddRange(Reuniao.Reunioes);

                if (Tipo == typeof(MudancaEstado) && !modelocrud.Erro_Conexao)
                    if (retorno && modelo is MudancaEstado & MudancaEstado.Mudancas != null) MudancaEstado.Mudancas.AddRange(MudancaEstado.Mudancas);

                if (!form.IsDisposed)
                form.Dispose();

                if (!modelocrud.Erro_Conexao)
                {
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
                }                
            }
            return null;
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
