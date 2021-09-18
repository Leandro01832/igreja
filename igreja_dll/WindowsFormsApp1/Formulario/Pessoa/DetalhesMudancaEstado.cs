using business.classes;
using business.implementacao;
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
    public partial class DetalhesMudancaEstado : WFCrud
    {
        public DetalhesMudancaEstado(modelocrud modelo, bool deletar, bool atualizar, bool detalhes)
            : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        private void DetalhesMudancaEstado_Load(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var mudanca = (MudancaEstado)modelo;
                lbl_data_mudanca.Text += mudanca.DataMudanca.ToString();
                lbl_modelo_antigo.Text += mudanca.velhoEstado.ToString();
                lbl_modelo_novo.Text += mudanca.novoEstado.ToString();
                lbl_id_pessoa.Text += mudanca.Codigo.ToString();
            }
        }
    }
}
