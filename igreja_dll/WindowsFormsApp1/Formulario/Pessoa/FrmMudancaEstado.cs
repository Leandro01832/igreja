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

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class FrmMudancaEstado : FormPadrao
    {
        public FrmMudancaEstado()
        {

        }

        public FrmMudancaEstado(modelocrud modelo)
        {
            Modelo = modelo;
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
        public modelocrud Modelo { get; }
        public modelocrud ModeloNovo { get; set; }

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
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }
    }
}
