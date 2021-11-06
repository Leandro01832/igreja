using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Pessoas;

namespace WindowsFormsApp1
{
    public partial class FormProcessamento :  FormPadrao
    {
        Label statusVisitanteLgpd;
        Label statusCriancaLgpd;
        Label statusMembroBatismoLgpd;
        Label statusMembroTransferenciaLgpd;
        Label statusMembroAclamacaoLgpd;
        Label statusMembroReconciliacaoLgpd;
        Label statusVisitante;
        Label statusCrianca;
        Label statusMembroBatismo;
        Label statusMembroTransferencia;
        Label statusMembroAclamacao;
        Label statusMembroReconciliacao;

        BDcomum bd;

        bool verifica = true;

        public FormProcessamento()
        {
            bd = new BDcomum();           

            statusVisitanteLgpd = new Label();
            statusVisitanteLgpd.Text = "Status de processamento de Visitante Lgpd: ";
            statusVisitanteLgpd.Location = new Point(5, 50);
            statusVisitanteLgpd.Width = 550;
            statusVisitanteLgpd.Height = 65;
            statusVisitanteLgpd.Font = new System.Drawing.Font("Arial", 15);

            statusCriancaLgpd = new Label();
            statusCriancaLgpd.Text = "Status de processamento de Criança Lgpd: ";
            statusCriancaLgpd.Location = new Point(5, 115);
            statusCriancaLgpd.Width = 550;
            statusCriancaLgpd.Height = 65;
            statusCriancaLgpd.Font = new System.Drawing.Font("Arial", 15);

            statusMembroBatismoLgpd = new Label();
            statusMembroBatismoLgpd.Text = "Status de processamento de Membro por Batismo Lgpd: ";
            statusMembroBatismoLgpd.Location = new Point(5, 180);
            statusMembroBatismoLgpd.Width = 550;
            statusMembroBatismoLgpd.Height = 65;
            statusMembroBatismoLgpd.Font = new System.Drawing.Font("Arial", 15);

            statusMembroTransferenciaLgpd = new Label();
            statusMembroTransferenciaLgpd.Text = "Status de processamento de Membro por Transferência Lgpd: ";
            statusMembroTransferenciaLgpd.Location = new Point(5, 245);
            statusMembroTransferenciaLgpd.Width = 550;
            statusMembroTransferenciaLgpd.Height = 65;
            statusMembroTransferenciaLgpd.Font = new System.Drawing.Font("Arial", 15);

            statusMembroAclamacaoLgpd = new Label();
            statusMembroAclamacaoLgpd.Text = "Status de processamento de Membro por aclamação Lgpd: ";
            statusMembroAclamacaoLgpd.Location = new Point(5, 310);
            statusMembroAclamacaoLgpd.Width = 550;
            statusMembroAclamacaoLgpd.Height = 65;
            statusMembroAclamacaoLgpd.Font = new System.Drawing.Font("Arial", 15);

            statusMembroReconciliacaoLgpd = new Label();
            statusMembroReconciliacaoLgpd.Text = "Status de processamento de Membro por reconciliação Lgpd: ";
            statusMembroReconciliacaoLgpd.Location = new Point(5, 375);
            statusMembroReconciliacaoLgpd.Width = 550;
            statusMembroReconciliacaoLgpd.Height = 65;
            statusMembroReconciliacaoLgpd.Font = new System.Drawing.Font("Arial", 15);


            //////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////



            statusVisitante = new Label();
            statusVisitante.Text = "Status de processamento de Visitante: ";
            statusVisitante.Location = new Point(680, 50);
            statusVisitante.Width = 550;
            statusVisitante.Height = 65;
            statusVisitante.Font = new System.Drawing.Font("Arial", 15);

            statusCrianca = new Label();
            statusCrianca.Text = "Status de processamento de Criança: ";
            statusCrianca.Location = new Point(680, 115);
            statusCrianca.Width = 550;
            statusCrianca.Height = 65;
            statusCrianca.Font = new System.Drawing.Font("Arial", 15);

            statusMembroBatismo = new Label();
            statusMembroBatismo.Text = "Status de processamento de Membro por Batismo: ";
            statusMembroBatismo.Location = new Point(680, 180);
            statusMembroBatismo.Width = 550;
            statusMembroBatismo.Height = 65;
            statusMembroBatismo.Font = new System.Drawing.Font("Arial", 15);

            statusMembroTransferencia = new Label();
            statusMembroTransferencia.Text = "Status de processamento de Membro por Transferência: ";
            statusMembroTransferencia.Location = new Point(680, 245);
            statusMembroTransferencia.Width = 550;
            statusMembroTransferencia.Height = 65;
            statusMembroTransferencia.Font = new System.Drawing.Font("Arial", 15);

            statusMembroAclamacao = new Label();
            statusMembroAclamacao.Text = "Status de processamento de Membro por aclamação: ";
            statusMembroAclamacao.Location = new Point(680, 310);
            statusMembroAclamacao.Width = 550;
            statusMembroAclamacao.Height = 65;
            statusMembroAclamacao.Font = new System.Drawing.Font("Arial", 15);

            statusMembroReconciliacao = new Label();
            statusMembroReconciliacao.Text = "Status de processamento de Membro por reconciliação: ";
            statusMembroReconciliacao.Location = new Point(680, 375);
            statusMembroReconciliacao.Width = 550;
            statusMembroReconciliacao.Height = 65;
            statusMembroReconciliacao.Font = new System.Drawing.Font("Arial", 15);

            this.Controls.Add(statusVisitanteLgpd);
            this.Controls.Add(statusCriancaLgpd);
            this.Controls.Add(statusMembroBatismoLgpd);
            this.Controls.Add(statusMembroTransferenciaLgpd);
            this.Controls.Add(statusMembroAclamacaoLgpd);
            this.Controls.Add(statusMembroReconciliacaoLgpd);
            this.Controls.Add(statusVisitante);
            this.Controls.Add(statusCrianca);
            this.Controls.Add(statusMembroBatismo);
            this.Controls.Add(statusMembroTransferencia);
            this.Controls.Add(statusMembroAclamacao);
            this.Controls.Add(statusMembroReconciliacao);

            InitializeComponent();
            btn_processo_inicial.Enabled = bd.TestarConexao() && int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99;
            btn_processa_pessoa.Enabled = bd.TestarConexao() && int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99;

        }

        private void FormProcessamento_Load(object sender, EventArgs e)
        {

        }

        private void btn_processa_pessoa_Click(object sender, EventArgs e)
        {
            if (modelocrud.Modelos.OfType<Visitante               >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Crianca)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Criança"; form.Show(); }
            if (modelocrud.Modelos.OfType<Crianca                 >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Visitante)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Visitante"; form.Show(); }
            if (modelocrud.Modelos.OfType<Membro_Aclamacao        >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Membro_Aclamacao)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Membro por Aclamação"; form.Show(); }
            if (modelocrud.Modelos.OfType<Membro_Batismo          >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Membro_Batismo)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Membro por batismo"; form.Show(); }
            if (modelocrud.Modelos.OfType<Membro_Reconciliacao    >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Membro_Reconciliacao)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Membro por Reconciliação"; form.Show(); }
            if (modelocrud.Modelos.OfType<Membro_Transferencia    >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Membro_Transferencia)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Membro por Transferencia"; form.Show(); }
            if (modelocrud.Modelos.OfType<VisitanteLgpd           >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(CriancaLgpd)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Criança Lgpd"; form.Show(); }
            if (modelocrud.Modelos.OfType<CriancaLgpd             >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(VisitanteLgpd)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Visitante Lgpd"; form.Show(); }
            if (modelocrud.Modelos.OfType<Membro_AclamacaoLgpd    >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Membro_AclamacaoLgpd)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Membro por Aclamação Lgpd"; form.Show(); }
            if (modelocrud.Modelos.OfType<Membro_BatismoLgpd      >().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Membro_BatismoLgpd)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Membro por batismo Lgpd"; form.Show(); }
            if (modelocrud.Modelos.OfType<Membro_ReconciliacaoLgpd>().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Membro_ReconciliacaoLgpd)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Membro por Reconciliação Lgpd"; form.Show(); }
            if (modelocrud.Modelos.OfType<Membro_TransferenciaLgpd>().FirstOrDefault() == null) { var form = new FrmPessoa(typeof(Membro_TransferenciaLgpd)); form.MdiParent = this.MdiParent; form.Text = "Processando dados - Membro por Transferência Lgpd"; form.Show(); }
        }

        private void btn_processo_inicial_Click(object sender, EventArgs e)
        {
            UltimoRegistro();
        }

        private void timerProcessamento_Tick(object sender, EventArgs e)
        {
            this.Text = "Processamento: " + modelocrud.textoPorcentagem;

            btn_processo_inicial.Enabled = bd.TestarConexao() && int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99;
            btn_processa_pessoa.Enabled = bd.TestarConexao() && int.Parse(modelocrud.textoPorcentagem.Replace("%", "")) < 99;
            
            if (verifica)
            {
                verifica = false;

                if (!carregandoCriancaLgpd)
                    statusCriancaLgpd.Text = "Status de processamento de criança Lgpd: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new CriancaLgpd().GetType().Name) != null)
                    statusCriancaLgpd.Text = "Status de processamento de criança Lgpd: processado.";
                else statusCriancaLgpd.Text = "Status de processamento de criança Lgpd: Processando.";

                if (!carregandoVisitanteLgpd)
                    statusVisitanteLgpd.Text = "Status de processamento de visitante Lgpd: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new VisitanteLgpd().GetType().Name) != null)
                    statusVisitanteLgpd.Text = "Status de processamento de visitante Lgpd: processado.";
                else statusVisitanteLgpd.Text = "Status de processamento de visitante Lgpd: Processando.";

                if (!carregandoMembroBatismoLgpd)
                    statusMembroBatismoLgpd.Text = "Status de processamento de Membro por Batismo Lgpd: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Membro_BatismoLgpd().GetType().Name) != null)
                    statusMembroBatismoLgpd.Text = "Status de processamento de Membro por Batismo Lgpd: processado.";
                else statusMembroBatismoLgpd.Text = "Status de processamento de Membro por Batismo Lgpd: Processando.";

                if (!carregandoMembroTransferenciaLgpd)
                    statusMembroTransferenciaLgpd.Text = "Status de processamento de Membro por Transferência Lgpd: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Membro_TransferenciaLgpd().GetType().Name) != null)
                    statusMembroTransferenciaLgpd.Text = "Status de processamento de Membro por Transferência Lgpd: processado.";
                else statusMembroTransferenciaLgpd.Text = "Status de processamento de Membro por Transferência Lgpd: Processando.";

                if (!carregandoMembroAclamacaoLgpd)
                    statusMembroAclamacaoLgpd.Text = "Status de processamento de Membro por aclamação Lgpd: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Membro_AclamacaoLgpd().GetType().Name) != null)
                    statusMembroAclamacaoLgpd.Text = "Status de processamento de Membro por aclamação Lgpd: processado.";
                else statusMembroAclamacaoLgpd.Text = "Status de processamento de Membro por aclamação Lgpd: Processando.";

                if (!carregandoMembroReconciliacaoLgpd)
                    statusMembroReconciliacaoLgpd.Text = "Status de processamento de Membro por reconciliação Lgpd: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Membro_ReconciliacaoLgpd().GetType().Name) != null)
                    statusMembroReconciliacaoLgpd.Text = "Status de processamento de Membro por reconciliação Lgpd: processado.";
                else statusMembroReconciliacaoLgpd.Text = "Status de processamento de Membro por reconciliação Lgpd: Processando.";



                if (!carregandoCrianca)
                    statusCrianca.Text = "Status de processamento de criança: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Crianca().GetType().Name) != null)
                    statusCrianca.Text = "Status de processamento de criança: processado.";
                else statusCrianca.Text = "Status de processamento de criança: Processando.";

                if (!carregandoVisitante)
                    statusVisitante.Text = "Status de processamento de visitante: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Visitante().GetType().Name) != null)
                    statusVisitante.Text = "Status de processamento de visitante: processado.";
                else statusVisitante.Text = "Status de processamento de visitante: Processando.";

                if (!carregandoMembroBatismo)
                    statusMembroBatismo.Text = "Status de processamento de membro por batismo: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Membro_Batismo().GetType().Name) != null)
                    statusMembroBatismo.Text = "Status de processamento de membro por batismo: processado.";
                else statusMembroBatismo.Text = "Status de processamento de membro por batismo: Processando.";

                if (!carregandoMembroTransferencia)
                    statusMembroTransferencia.Text = "Status de processamento de membro por transferência: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Membro_Transferencia().GetType().Name) != null)
                    statusMembroTransferencia.Text = "Status de processamento de membro por transferência: processado.";
                else statusMembroTransferencia.Text = "Status de processamento de membro por transferência: Processando.";

                if (!carregandoMembroAclamacao)
                    statusMembroAclamacao.Text = "Status de processamento de membro por aclamação: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Membro_Aclamacao().GetType().Name) != null)
                    statusMembroAclamacao.Text = "Status de processamento de membro por aclamação: processado.";
                else statusMembroAclamacao.Text = "Status de processamento de membro por aclamação: Processando.";

                if (!carregandoMembroReconciliacao)
                    statusMembroReconciliacao.Text = "Status de processamento de membro por reconciliação: Não processado.";
                else if (modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(p => p.GetType().Name == new Membro_Reconciliacao().GetType().Name) != null)
                    statusMembroReconciliacao.Text = "Status de processamento de membro por reconciliação: processado.";
                else statusMembroReconciliacao.Text = "Status de processamento de membro por reconciliação: Processando.";

                verifica = true;
            }
        }
    }
}
