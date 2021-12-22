using business.classes.Abstrato;
using business.classes.Intermediario;
using database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class FrmPessoa  :  WFCrud
    {
        public FrmPessoa() : base()
        {
            InitializeComponent();

        }

        // variavel para evitar bug
        bool condicao = false;

        private void PessoasCelulasMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Celulas e pessoas do ministério.";

            this.Proximo.Location = new Point(600, 150);
            this.Atualizar.Location = new Point(600, 250);
            this.Deletar.Location = new Point(600, 350);

            lstBoxCelula.DataSource = modelocrud.Modelos.OfType<Celula>().OrderBy(m => m.Id).ToList();
            if (modelocrud.Modelos.OfType<Celula>().ToList().Count > 0) lstBoxCelula.SetSelected(0, false);
            lstBoxPessoa.DataSource = modelocrud.Modelos.OfType<Pessoa>().OrderBy(m => m.Id).ToList();
            if (modelocrud.Modelos.OfType<Pessoa>().ToList().Count > 0) lstBoxPessoa.SetSelected(0, false);

            Ministerio p = null;
            if (modelo != null)
                p = (Ministerio)modelo;
            else
                p = (Ministerio)ModeloNovo;

            try
            {
                foreach (var item in p.Pessoa)
                {
                    var indice = lstBoxPessoa.Items.IndexOf(item.Pessoa);
                    lstBoxPessoa.SetSelected(indice, true);
                }
            }
            catch (Exception ex)
            {
                var msg = modeloErro.exibirMensagemErro(ex, 2);
                if (msg != "")
                    MessageBox.Show(msg);
            }

            try
            {
                foreach (var item in p.Celulas)
                {
                    var indice = lstBoxCelula.Items.IndexOf(item.Celula);
                    lstBoxCelula.SetSelected(indice, true);
                }
            }
            catch (Exception ex)
            {
                var msg = modeloErro.exibirMensagemErro(ex, 2);
                if (msg != "")
                    MessageBox.Show(msg);
            }

            condicao = true;
        }
                
        private void lstBoxPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            Ministerio p = null;
            if (modelo != null)
                p = (Ministerio)modelo;
            else
                p = (Ministerio)ModeloNovo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxPessoa.SelectedItems;
                    var objetos = valor.Cast<Pessoa>().ToList();
                    p.Pessoa = new List<PessoaMinisterio>();
                    foreach (var item in objetos)
                        p.Pessoa.Add(new PessoaMinisterio { PessoaId = item.Id, Pessoa = item,
                            MinisterioId = p.Id, Ministerio = p });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }

        private void lstBoxCelula_SelectedValueChanged(object sender, EventArgs e)
        {
            Ministerio p = null;
            if (modelo != null)
                p = (Ministerio)modelo;
            else
                p = (Ministerio)ModeloNovo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxPessoa.SelectedItems;
                    var objetos = valor.Cast<Celula>().ToList();
                    p.Celulas = new List<MinisterioCelula>();
                    foreach (var item in objetos)
                        p.Celulas.Add(new MinisterioCelula { CelulaId = item.Id, Celula = item,
                            MinisterioId = p.Id, Ministerio = p });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }
    }
}
