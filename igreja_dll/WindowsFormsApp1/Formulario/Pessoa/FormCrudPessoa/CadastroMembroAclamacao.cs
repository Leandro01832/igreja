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
    public partial class CadastroMembroAclamacao : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public CadastroMembroAclamacao(business.classes.Abstrato.Pessoa p, bool Deletar, bool Atualizar,  bool Detalhes)
            : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void CadastroMembroAclamacao_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por aclamação.";

            if (modelo.Id != 0)
            {
                this.Size = new Size(new Point(850, 750));
                var p = (business.classes.Pessoas.Membro_Aclamacao)modelo;
                txt_denominacao.Text = p.Denominacao; 
            }
        }

        private void txt_denominacao_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.Membro_Aclamacao)modelo;
            p.Denominacao = txt_denominacao.Text;
        }
    }
}
