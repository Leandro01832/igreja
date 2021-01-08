using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Drawing;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class CadastroMembroAclamacao : WindowsFormsApp1.Formulario.FormCrudPessoa
    {

        public CadastroMembroAclamacao(modelocrud modelo, modelocrud modeloNovo)
            :base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroMembroAclamacao(modelocrud p, bool Deletar, bool Atualizar,  bool Detalhes)            
            : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }
        

        private void CadastroMembroAclamacao_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por aclamação.";
             this.Size = new Size(new Point(850, 750));
            if(modelo != null)
            {
                if(modelo is Membro_Aclamacao)
                {
                    var p = (Membro_Aclamacao)modelo;
                    txt_denominacao.Text = p.Denominacao;
                }
                if (modelo is Membro_AclamacaoLgpd)
                {
                    var p = (Membro_AclamacaoLgpd)modelo;
                    txt_denominacao.Text = p.Denominacao;
                }

            }
        }

        private void txt_denominacao_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                if(modelo is Membro_Aclamacao)
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
