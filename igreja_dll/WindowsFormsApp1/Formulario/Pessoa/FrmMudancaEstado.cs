using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class FrmMudancaEstado : Form
    {
        public FrmMudancaEstado()
        {

        }

        public FrmMudancaEstado(modelocrud modelo, bool Lgpd)
        {
            Modelo = modelo;
            this.Lgpd = Lgpd;
            AlterarPTodoDado = new CheckBox();
            AlterarPTodoDado.Text = "Alterar para modelo com todos os dados";
            AlterarPTodoDado.Location = new Point(20, 20);
            AlterarPTodoDado.Font = new Font("Arial", 12);

            if (!Lgpd)
                AlterarPTodoDado.Visible = true;
            else
                AlterarPTodoDado.Visible = false;

            Controls.Add(AlterarPTodoDado);

            InitializeComponent();            
        }

        private CheckBox AlterarPTodoDado;
        public modelocrud Modelo { get; }
        public bool Lgpd { get; }
        public modelocrud ModeloNovo { get; set; }

        private void FrmMudancaEstado_Load(object sender, EventArgs e)
        {
            ModeloNovo = new Membro_Batismo();
        }

        private void btn_proximo_Click(object sender, EventArgs e)
        {
            if (!AlterarPTodoDado.Checked)
            {
                if (ModeloNovo is Crianca || ModeloNovo is CriancaLgpd)
                {
                    CadastroCrianca frm = new CadastroCrianca(Modelo, ModeloNovo);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                if (ModeloNovo is Visitante || ModeloNovo is VisitanteLgpd)
                {
                    CadastroVisitante frm = new CadastroVisitante(Modelo, ModeloNovo);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                if (ModeloNovo is Membro_Aclamacao || ModeloNovo is Membro_AclamacaoLgpd)
                {
                    CadastroMembroAclamacao frm = new CadastroMembroAclamacao(Modelo, ModeloNovo);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                if (ModeloNovo is Membro_Batismo || ModeloNovo is Membro_BatismoLgpd)
                {
                    CadastroMembroBatismo frm = new CadastroMembroBatismo(Modelo, ModeloNovo);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                if (ModeloNovo is Membro_Reconciliacao || ModeloNovo is Membro_ReconciliacaoLgpd)
                {
                    CadastroMembroReconciliacao frm = new CadastroMembroReconciliacao(Modelo, ModeloNovo);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                if (ModeloNovo is Membro_Transferencia || ModeloNovo is Membro_TransferenciaLgpd)
                {
                    CadastroMembroTransferencia frm = new CadastroMembroTransferencia(Modelo, ModeloNovo);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                } 
            }

            else
            {
                DadoPessoal frm = new DadoPessoal(false, false, false, Modelo, ModeloNovo);
            }


        }

        private void radio_crianca_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_crianca.Checked && Lgpd)
                ModeloNovo = new CriancaLgpd();            
            if (radio_crianca.Checked && !Lgpd )
                ModeloNovo = new CriancaLgpd();
            if (radio_crianca.Checked && !Lgpd && AlterarPTodoDado.Checked)
                ModeloNovo = new Crianca();
        }

        private void radio_visitante_CheckedChanged(object sender, EventArgs e)
        {
            if(radio_visitante.Checked && Lgpd)
                ModeloNovo = new VisitanteLgpd();            
            if (radio_visitante.Checked && !Lgpd)
                ModeloNovo = new VisitanteLgpd();
            if (radio_visitante.Checked && !Lgpd && AlterarPTodoDado.Checked)
                ModeloNovo = new Visitante();
        }

        private void radio_membrotransferencia_CheckedChanged(object sender, EventArgs e)
        {
            if(radio_membrotransferencia.Checked && Lgpd)
                ModeloNovo = new Membro_TransferenciaLgpd();
            if (radio_membrotransferencia.Checked && !Lgpd)
                ModeloNovo = new Membro_TransferenciaLgpd();
            if (radio_membrotransferencia.Checked && !Lgpd && AlterarPTodoDado.Checked)
                ModeloNovo = new Membro_Transferencia();
        }

        private void radio_membroaclamacao_CheckedChanged(object sender, EventArgs e)
        {
            if(radio_membroaclamacao.Checked && Lgpd)
                ModeloNovo = new Membro_AclamacaoLgpd();
            if (radio_membroaclamacao.Checked && !Lgpd)
                ModeloNovo = new Membro_AclamacaoLgpd();
            if (radio_membroaclamacao.Checked && !Lgpd && AlterarPTodoDado.Checked)
                ModeloNovo = new Membro_Aclamacao();
        }

        private void radio_membroreconciliacao_CheckedChanged(object sender, EventArgs e)
        {
            if(radio_membroreconciliacao.Checked && Lgpd)
                ModeloNovo = new Membro_ReconciliacaoLgpd();
            if (radio_membroreconciliacao.Checked && !Lgpd)
                ModeloNovo = new Membro_ReconciliacaoLgpd();
            if (radio_membroreconciliacao.Checked && !Lgpd && AlterarPTodoDado.Checked)
                ModeloNovo = new Membro_Reconciliacao();
        }

        private void radio_membrobatismo_CheckedChanged(object sender, EventArgs e)
        {
            if(radio_membrobatismo.Checked && Lgpd)
                ModeloNovo = new Membro_BatismoLgpd();
            if (radio_membrobatismo.Checked && !Lgpd)
                ModeloNovo = new Membro_BatismoLgpd();
            if (radio_membrobatismo.Checked && !Lgpd && AlterarPTodoDado.Checked)
                ModeloNovo = new Membro_Batismo();
        }
    }
}
