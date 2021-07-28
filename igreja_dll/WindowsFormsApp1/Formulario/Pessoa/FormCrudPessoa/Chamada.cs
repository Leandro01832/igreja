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
    public partial class Chamada : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public Chamada(business.classes.Pessoas.PessoaDado p,
            bool Deletar, bool Atualizar,  bool Detalhes)
           : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void Chamada_Load(object sender, EventArgs e)
        {

        }
    }
}
