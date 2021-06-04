using business.classes.Pessoas;
using business.classes.PessoasLgpd;
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

namespace WindowsFormsApp1
{
    public partial class FormProcessamento : FormPadrao
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

        bool verifica = true;

        public FormProcessamento()
        {
            statusVisitanteLgpd = new Label();
            statusVisitanteLgpd.Text = "Status de processamento de Visitante Lgpd: ";
            statusVisitanteLgpd.Location = new Point(5, 50);
            statusVisitanteLgpd.Width = 350;
            statusVisitanteLgpd.Height = 50;

            statusCriancaLgpd = new Label();
            statusCriancaLgpd.Text = "Status de processamento de Criança Lgpd: ";
            statusCriancaLgpd.Location = new Point(5, 100);
            statusCriancaLgpd.Width = 350;
            statusCriancaLgpd.Height = 50;

            statusMembroBatismoLgpd = new Label();
            statusMembroBatismoLgpd.Text = "Status de processamento de Membro por Batismo Lgpd: ";
            statusMembroBatismoLgpd.Location = new Point(5, 150);
            statusMembroBatismoLgpd.Width = 350;
            statusMembroBatismoLgpd.Height = 50;

            statusMembroTransferenciaLgpd = new Label();
            statusMembroTransferenciaLgpd.Text = "Status de processamento de Membro por Transferência Lgpd: ";
            statusMembroTransferenciaLgpd.Location = new Point(5, 200);
            statusMembroTransferenciaLgpd.Width = 350;
            statusMembroTransferenciaLgpd.Height = 50;

            statusMembroAclamacaoLgpd = new Label();
            statusMembroAclamacaoLgpd.Text = "Status de processamento de Membro por aclamação Lgpd: ";
            statusMembroAclamacaoLgpd.Location = new Point(5, 250);
            statusMembroAclamacaoLgpd.Width = 350;
            statusMembroAclamacaoLgpd.Height = 50;

            statusMembroReconciliacaoLgpd = new Label();
            statusMembroReconciliacaoLgpd.Text = "Status de processamento de Membro por reconciliação Lgpd: ";
            statusMembroReconciliacaoLgpd.Location = new Point(5, 300);
            statusMembroReconciliacaoLgpd.Width = 350;
            statusMembroReconciliacaoLgpd.Height = 50;


            //////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////



            statusVisitante = new Label();
            statusVisitante.Text = "Status de processamento de Visitante: ";
            statusVisitante.Location = new Point(380, 50);
            statusVisitante.Width = 350;
            statusVisitante.Height = 50;

            statusCrianca = new Label();
            statusCrianca.Text = "Status de processamento de Criança: ";
            statusCrianca.Location = new Point(380, 100);
            statusCrianca.Width = 350;
            statusCrianca.Height = 50;

            statusMembroBatismo = new Label();
            statusMembroBatismo.Text = "Status de processamento de Membro por Batismo: ";
            statusMembroBatismo.Location = new Point(380, 150);
            statusMembroBatismo.Width = 350;
            statusMembroBatismo.Height = 50;

            statusMembroTransferencia = new Label();
            statusMembroTransferencia.Text = "Status de processamento de Membro por Transferência: ";
            statusMembroTransferencia.Location = new Point(380, 200);
            statusMembroTransferencia.Width = 350;
            statusMembroTransferencia.Height = 50;

            statusMembroAclamacao = new Label();
            statusMembroAclamacao.Text = "Status de processamento de Membro por aclamação: ";
            statusMembroAclamacao.Location = new Point(380, 250);
            statusMembroAclamacao.Width = 350;
            statusMembroAclamacao.Height = 50;

            statusMembroReconciliacao = new Label();
            statusMembroReconciliacao.Text = "Status de processamento de Membro por reconciliação: ";
            statusMembroReconciliacao.Location = new Point(380, 300);
            statusMembroReconciliacao.Width = 350;
            statusMembroReconciliacao.Height = 50;

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
        }

        private void FormProcessamento_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (verifica)
            {
                verifica = false;

                if (!carregandoCriancaLgpd)
                    statusCriancaLgpd.Text = "Status de processamento de criança Lgpd: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new CriancaLgpd().GetType().Name).ToList().Count > 0)
                    statusCriancaLgpd.Text = "Status de processamento de criança Lgpd: processado.";
                else statusCriancaLgpd.Text = "Status de processamento de criança Lgpd: Processando.";

                if (!carregandoVisitanteLgpd)
                    statusVisitanteLgpd.Text = "Status de processamento de visitante Lgpd: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new VisitanteLgpd().GetType().Name).ToList().Count > 0)
                    statusVisitanteLgpd.Text = "Status de processamento de visitante Lgpd: processado.";
                else statusVisitanteLgpd.Text = "Status de processamento de visitante Lgpd: Processando.";

                if (!carregandoMembroBatismoLgpd)
                    statusMembroBatismoLgpd.Text = "Status de processamento de Membro por Batismo Lgpd: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Membro_BatismoLgpd().GetType().Name).ToList().Count > 0)
                    statusMembroBatismoLgpd.Text = "Status de processamento de Membro por Batismo Lgpd: processado.";
                else statusMembroBatismoLgpd.Text = "Status de processamento de Membro por Batismo Lgpd: Processando.";

                if (!carregandoMembroTransferenciaLgpd)
                    statusMembroTransferenciaLgpd.Text = "Status de processamento de Membro por Transferência Lgpd: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Membro_TransferenciaLgpd().GetType().Name).ToList().Count > 0)
                    statusMembroTransferenciaLgpd.Text = "Status de processamento de Membro por Transferência Lgpd: processado.";
                else statusMembroTransferenciaLgpd.Text = "Status de processamento de Membro por Transferência Lgpd: Processando.";

                if (!carregandoMembroAclamacaoLgpd)
                    statusMembroAclamacaoLgpd.Text = "Status de processamento de Membro por aclamação Lgpd: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Membro_AclamacaoLgpd().GetType().Name).ToList().Count > 0)
                    statusMembroAclamacaoLgpd.Text = "Status de processamento de Membro por aclamação Lgpd: processado.";
                else statusMembroAclamacaoLgpd.Text = "Status de processamento de Membro por aclamação Lgpd: Processando.";

                if (!carregandoMembroReconciliacaoLgpd)
                    statusMembroReconciliacaoLgpd.Text = "Status de processamento de Membro por reconciliação Lgpd: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Membro_ReconciliacaoLgpd().GetType().Name).ToList().Count > 0)
                    statusMembroReconciliacaoLgpd.Text = "Status de processamento de Membro por reconciliação Lgpd: processado.";
                else statusMembroReconciliacaoLgpd.Text = "Status de processamento de Membro por reconciliação Lgpd: Processando.";



                if (!carregandoCrianca)
                    statusCrianca.Text = "Status de processamento de criança: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Crianca().GetType().Name).ToList().Count > 0)
                    statusCrianca.Text = "Status de processamento de criança: processado.";
                else statusCrianca.Text = "Status de processamento de criança: Processando.";

                if (!carregandoVisitante)
                    statusVisitante.Text = "Status de processamento de visitante: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Visitante().GetType().Name).ToList().Count > 0)
                    statusVisitante.Text = "Status de processamento de visitante: processado.";
                else statusVisitante.Text = "Status de processamento de visitante: Processando.";

                if (!carregandoMembroBatismo)
                    statusMembroBatismo.Text = "Status de processamento de membro por batismo: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Membro_Batismo().GetType().Name).ToList().Count > 0)
                    statusMembroBatismo.Text = "Status de processamento de membro por batismo: processado.";
                else statusMembroBatismo.Text = "Status de processamento de membro por batismo: Processando.";

                if (!carregandoMembroTransferencia)
                    statusMembroTransferencia.Text = "Status de processamento de membro por transferência: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Membro_Transferencia().GetType().Name).ToList().Count > 0)
                    statusMembroTransferencia.Text = "Status de processamento de membro por transferência: processado.";
                else statusMembroTransferencia.Text = "Status de processamento de membro por transferência: Processando.";

                if (!carregandoMembroAclamacao)
                    statusMembroAclamacao.Text = "Status de processamento de membro por aclamação: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Membro_Aclamacao().GetType().Name).ToList().Count > 0)
                    statusMembroAclamacao.Text = "Status de processamento de membro por aclamação: processado.";
                else statusMembroAclamacao.Text = "Status de processamento de membro por aclamação: Processando.";

                if (!carregandoMembroReconciliacao)
                    statusMembroReconciliacao.Text = "Status de processamento de membro por reconciliação: Não processado.";
                else if (listaPessoas.Where(p => p.GetType().Name == new Membro_Reconciliacao().GetType().Name).ToList().Count > 0)
                    statusMembroReconciliacao.Text = "Status de processamento de membro por reconciliação: processado.";
                else statusMembroReconciliacao.Text = "Status de processamento de membro por reconciliação: Processando.";

                verifica = true;
            }
        }
    }
}
