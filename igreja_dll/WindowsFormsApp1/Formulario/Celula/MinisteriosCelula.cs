using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Celula
{
    public partial class MinisteriosCelula : FormularioCrudCelula
    {
        public MinisteriosCelula()
        {
            InitializeComponent();
        }

        public MinisteriosCelula(business.classes.Abstrato.Celula p,
            bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void MinisteriosCelula_Load(object sender, EventArgs e)
        {
            this.Text = " - Ministérios da celula";

            var c = (business.classes.Abstrato.Celula)modelo;
            if(c.IdCelula == 0)
            {
                txt_ministerio.Text = AddNaListaCelulaMinisterios;
            }

            if(c.IdCelula != 0)
            {
                var lista = c.buscarLista(new business.classes.Pessoas.Crianca(), c, "celula_", c.IdCelula);
                if (lista != null) lbl_pessoas.Text = "Pessoas: ";
                foreach (var numero in lista)
                {
                    lbl_pessoas.Text += numero.ToString() + ", ";
                }

                var minis = c.Ministerios;
                foreach(var item in minis)
                {
                    var m = listaMinisterios.First(i => i.IdMinisterio == item.MinisterioId);
                    txt_ministerio.Text += m.IdMinisterio.ToString() + ", ";
                }
            }
           
        }

        private void txt_ministerio_TextChanged(object sender, EventArgs e)
        {
            AddNaListaCelulaMinisterios = txt_ministerio.Text;         
        }

    }
}
