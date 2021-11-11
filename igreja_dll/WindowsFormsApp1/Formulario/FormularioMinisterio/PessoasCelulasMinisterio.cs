using business.classes.Abstrato;
using business.classes.Intermediario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class PessoasCelulasMinisterio : FormCrudMinisterio
    {
        public PessoasCelulasMinisterio() : base()
        {
            InitializeComponent();

        }

        // variavel para evitar bug
        bool condicao = false;

        private void PessoasCelulasMinisterio_Load(object sender, EventArgs e)
        {
            LoadCrudForm();
            this.Text = " - Celulas e pessoas do ministério.";

            var ministerio = (Ministerio)modelo;
            if (ministerio.Id != 0)
            {
                foreach (var item in ministerio.Pessoas)
                {
                    var indice = lstBoxPessoa.Items.IndexOf(item);
                    lstBoxPessoa.SetSelected(indice, true);
                }

                foreach (var item in ministerio.Celulas)
                {
                    var indice = lstBoxCelula.Items.IndexOf(item);
                    lstBoxCelula.SetSelected(indice, true);
                }
            }

            condicao = true;
        }
                
        private void lstBoxPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            var ministerio = (Ministerio)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxPessoa.SelectedItems;
                    var objetos = valor.Cast<Pessoa>().ToList();
                    ministerio.Pessoas = new List<PessoaMinisterio>();
                    foreach (var item in objetos)
                        ministerio.Pessoas.Add(new PessoaMinisterio { PessoaId = item.Id });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }

        private void lstBoxCelula_SelectedValueChanged(object sender, EventArgs e)
        {
            var ministerio = (Ministerio)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxPessoa.SelectedItems;
                    var objetos = valor.Cast<Celula>().ToList();
                    ministerio.Celulas = new List<MinisterioCelula>();
                    foreach (var item in objetos)
                        ministerio.Celulas.Add(new MinisterioCelula { CelulaId = item.Id });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }
    }
}
