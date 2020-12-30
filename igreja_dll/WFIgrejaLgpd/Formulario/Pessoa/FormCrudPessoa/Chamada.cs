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
    public partial class Chamada : WFIgrejaLgpd.Formulario.FormCrudPessoa
    {
        public Chamada(business.classes.Abstrato.PessoaLgpd p, bool Deletar, bool Atualizar,  bool Detalhes)
           : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void Chamada_Load(object sender, EventArgs e)
        {

        }
    }
}
