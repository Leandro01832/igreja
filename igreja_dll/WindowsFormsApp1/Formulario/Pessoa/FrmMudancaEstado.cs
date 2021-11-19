using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class FrmMudancaEstado : WFCrud
    {
        public FrmMudancaEstado()
        {

        }

        public FrmMudancaEstado(modelocrud modelo)
        {
            ModeloVelho = modelo;
            AlterarPTodoDado = new CheckBox();
            AlterarPTodoDado.Width = 500;
            AlterarPTodoDado.Text = "Alterar para modelo com todos os dados";
            AlterarPTodoDado.Location = new Point(20, 20);
            AlterarPTodoDado.Font = new Font("Arial", 12);
            AlterarPTodoDado.Visible = true;

            Controls.Add(AlterarPTodoDado);

            InitializeComponent();            
        }

        private CheckBox AlterarPTodoDado;

        private void FrmMudancaEstado_Load(object sender, EventArgs e)
        {
            ModeloNovo = new Membro_Batismo();
        }

        private void btn_proximo_Click(object sender, EventArgs e)
        {
            if (radio_membrobatismo.Checked)
                ModeloNovo = new Membro_BatismoLgpd();
            if (radio_membrobatismo.Checked && AlterarPTodoDado.Checked)
                ModeloNovo = new Membro_Batismo();

            if (radio_membroreconciliacao.Checked)
                ModeloNovo = new Membro_ReconciliacaoLgpd();
            if (radio_membroreconciliacao.Checked && AlterarPTodoDado.Checked)
                ModeloNovo = new Membro_Reconciliacao();

            if (radio_membroaclamacao.Checked)
                ModeloNovo = new Membro_AclamacaoLgpd();
            if (radio_membroaclamacao.Checked && AlterarPTodoDado.Checked)
                ModeloNovo = new Membro_Aclamacao();

            if (radio_membrotransferencia.Checked)
                ModeloNovo = new Membro_TransferenciaLgpd();
            if (radio_membrotransferencia.Checked && AlterarPTodoDado.Checked)
                ModeloNovo = new Membro_Transferencia();

            if (radio_visitante.Checked)
                ModeloNovo = new VisitanteLgpd();
            if (radio_visitante.Checked && AlterarPTodoDado.Checked)
                ModeloNovo = new Visitante();

            if (radio_crianca.Checked)
                ModeloNovo = new CriancaLgpd();
            if (radio_crianca.Checked && AlterarPTodoDado.Checked)
                ModeloNovo = new Crianca();

            if (!AlterarPTodoDado.Checked)
            {
                if (ModeloNovo is Crianca || ModeloNovo is CriancaLgpd)
                {
                    CadastroCrianca frm = new CadastroCrianca();
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                if (ModeloNovo is Visitante || ModeloNovo is VisitanteLgpd)
                {
                    Frm = new CadastroVisitante();
                    Frm.MdiParent = this.MdiParent;
                    Frm.Show();
                }
                if (ModeloNovo is Membro_Aclamacao || ModeloNovo is Membro_AclamacaoLgpd)
                {
                    Frm = new CadastroMembroAclamacao();
                    Frm.MdiParent = this.MdiParent;
                    Frm.Show();
                }
                if (ModeloNovo is Membro_Batismo || ModeloNovo is Membro_BatismoLgpd)
                {
                    Frm = new CadastroMembroBatismo();
                    Frm.MdiParent = this.MdiParent;
                    Frm.Show();
                }
                if (ModeloNovo is Membro_Reconciliacao || ModeloNovo is Membro_ReconciliacaoLgpd)
                {
                    Frm = new CadastroMembroReconciliacao();
                    Frm.MdiParent = this.MdiParent;
                    Frm.Show();
                }
                if (ModeloNovo is Membro_Transferencia || ModeloNovo is Membro_TransferenciaLgpd)
                {
                    Frm = new CadastroMembroTransferencia();
                    Frm.MdiParent = this.MdiParent;
                    Frm.Show();
                } 
            }
            else
            {
                Frm = new DadoPessoal();
                Frm.MdiParent = this.MdiParent;
                Frm.Show();
            }
        }
    }
}
