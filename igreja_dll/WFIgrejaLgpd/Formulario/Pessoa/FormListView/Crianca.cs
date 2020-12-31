using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFIgrejaLgpd.ListViews;

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class Crianca : FormularioListView
    {
        

        public Crianca() : base(
            new ListViewCrianca
            (new business.classes.PessoasLgpd.CriancaLgpd(), ""))
        {
            
            InitializeComponent();
        }

        private void Crianca_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de Crianças";
        }
    }
}
