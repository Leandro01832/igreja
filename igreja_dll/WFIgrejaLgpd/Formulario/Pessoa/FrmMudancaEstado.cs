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

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class FrmMudancaEstado : Form
    {
        public FrmMudancaEstado()
        {
            InitializeComponent();
        }

        public FrmMudancaEstado(modelocrud modelo)
        {
            InitializeComponent();
            Modelo = modelo;
        }

        public modelocrud Modelo { get; }
        public modelocrud ModeloNovo { get; set; }

        private void FrmMudancaEstado_Load(object sender, EventArgs e)
        {
            ModeloNovo = new business.classes.Pessoas.Membro_Batismo();
        }

        private void btn_proximo_Click(object sender, EventArgs e)
        {
            if (ModeloNovo is business.classes.Pessoas.Crianca)
            {
                CadastroCrianca frm = new CadastroCrianca(Modelo, ModeloNovo);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            if (ModeloNovo is business.classes.Pessoas.Visitante)
            {
                CadastroVisitante frm = new CadastroVisitante(Modelo, ModeloNovo);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            if (ModeloNovo is business.classes.Pessoas.Membro_Aclamacao)
            {
                CadastroMembroAclamacao frm = new CadastroMembroAclamacao(Modelo, ModeloNovo);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            if (ModeloNovo is business.classes.Pessoas.Membro_Batismo)
            {
                CadastroMembroBatismo frm = new CadastroMembroBatismo(Modelo, ModeloNovo);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            if (ModeloNovo is business.classes.Pessoas.Membro_Reconciliacao)
            {
                CadastroMembroReconciliacao frm = new CadastroMembroReconciliacao(Modelo, ModeloNovo);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            if (ModeloNovo is business.classes.Pessoas.Membro_Transferencia)
            {
                CadastroMembroTransferencia frm = new CadastroMembroTransferencia(Modelo, ModeloNovo);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void radio_crianca_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_crianca.Checked)
                ModeloNovo = new business.classes.Pessoas.Crianca();
        }

        private void radio_visitante_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_visitante.Checked)
                ModeloNovo = new business.classes.Pessoas.Visitante();
        }

        private void radio_membrotransferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_membrotransferencia.Checked)
                ModeloNovo = new business.classes.Pessoas.Membro_Transferencia();
        }

        private void radio_membroaclamacao_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_membroaclamacao.Checked)
                ModeloNovo = new business.classes.Pessoas.Membro_Aclamacao();
        }

        private void radio_membroreconciliacao_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_membroreconciliacao.Checked)
                ModeloNovo = new business.classes.Pessoas.Membro_Reconciliacao();
        }

        private void radio_membrobatismo_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_membrobatismo.Checked)
                ModeloNovo = new business.classes.Pessoas.Membro_Batismo();
        }
    }
}
