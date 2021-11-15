using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class CadastroMembroAclamacao : WFCrud
    {

        public CadastroMembroAclamacao(modelocrud modelo, modelocrud modeloNovo)
            : base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroMembroAclamacao(bool Deletar, bool Atualizar, bool Detalhes, modelocrud modeloVelho,
            modelocrud modeloNovo)
            : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroMembroAclamacao() : base()
        {
            InitializeComponent();
        }


        private void CadastroMembroAclamacao_Load(object sender, EventArgs e)
        {
            LoadCrudForm();
            this.Text = "Cadastro de membro por aclamação.";
            this.Size = new Size(new Point(850, 750));

            if (modelo is Membro_Aclamacao)
            {
                var p = (Membro_Aclamacao)modelo;
                try { txt_denominacao.Text = p.Denominacao; } catch(Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }
            if (modelo is Membro_AclamacaoLgpd)
            {
                var p = (Membro_AclamacaoLgpd)modelo;
                try { txt_denominacao.Text = p.Denominacao; } catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }


        }

        private void txt_denominacao_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Membro_Aclamacao)
                {
                    var p = (Membro_Aclamacao)modelo;
                    p.Denominacao = txt_denominacao.Text;
                }
                if (modelo is Membro_AclamacaoLgpd)
                {
                    var p = (Membro_AclamacaoLgpd)modelo;
                    p.Denominacao = txt_denominacao.Text;
                }

            }

            if (ModeloNovo != null)
            {
                if (ModeloNovo is Membro_Aclamacao)
                {
                    var p = (Membro_Aclamacao)ModeloNovo;
                    p.Denominacao = txt_denominacao.Text;
                }
                if (ModeloNovo is Membro_AclamacaoLgpd)
                {
                    var p = (Membro_AclamacaoLgpd)ModeloNovo;
                    p.Denominacao = txt_denominacao.Text;
                }
            }

        }
    }
}
