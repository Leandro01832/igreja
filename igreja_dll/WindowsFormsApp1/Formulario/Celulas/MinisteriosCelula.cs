using business.classes.Abstrato;
using business.classes.Intermediario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace WindowsFormsApp1.Formulario.Celulas
{
    public partial class MinisteriosCelula : FormularioCrudCelula
    {
        public MinisteriosCelula() : base()
        {
            InitializeComponent();
        }
        
        private void MinisteriosCelula_Load(object sender, EventArgs e)
        {
            this.Text = " - Ministérios da celula";

            var c = (Celula)modelo;
            if (c.Id != 0)
            {
                foreach (var item in c.Ministerios)
                {
                    var indice = lstBoxMinisterio.Items.IndexOf(item);
                    lstBoxMinisterio.SetSelected(indice, true);
                }
            }
            condicao = true;
        }

        // variavel para evitar bug
        bool condicao = false;

        private void lstBoxMinisterio_SelectedValueChanged(object sender, EventArgs e)
        {
            var celula = (Celula)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxMinisterio.SelectedItems;
                    var objetos = valor.Cast<Ministerio>().ToList();
                    celula.Ministerios = new List<MinisterioCelula>();
                    foreach (var item in objetos)
                    celula.Ministerios.Add(new MinisterioCelula { MinisterioId = item.Id });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }
    }
}
