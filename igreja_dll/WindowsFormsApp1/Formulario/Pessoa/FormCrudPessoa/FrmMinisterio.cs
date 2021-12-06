using business.classes.Abstrato;
using business.classes.Intermediario;
using database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas
{
    public partial class FrmMinisterio : WFCrud
    {
        
        public FrmMinisterio() : base()
        {
            InitializeComponent();
        }

        // variavel para evitar bug
        bool condicao = false;

        private void ReunioesMinisteriosPessoa_Load(object sender, EventArgs e)
        {
            this.Proximo.Location = new Point(900, 150);
            this.Atualizar.Location = new Point(900, 250);
            this.Deletar.Location = new Point(900, 350);

            lstBoxCelula.DataSource = modelocrud.Modelos.OfType<Celula>().OrderBy(m => m.Id).ToList();
            if (modelocrud.Modelos.OfType<Celula>().ToList().Count > 0) lstBoxCelula.SetSelected(0, false);
            lstBoxMinisterio.DataSource = modelocrud.Modelos.OfType<Ministerio>().OrderBy(m => m.Id).ToList();
            if (modelocrud.Modelos.OfType<Ministerio>().ToList().Count > 0) lstBoxMinisterio.SetSelected(0, false);
            lstBoxReuniao.DataSource = modelocrud.Modelos.OfType<business.classes.Reuniao>().OrderBy(m => m.Id).ToList();
            if (modelocrud.Modelos.OfType<business.classes.Reuniao>().ToList().Count > 0) lstBoxReuniao.SetSelected(0, false);

            this.Text = "Reuniões, celula e ministérios da pessoa.";
            var pessoa = (Pessoa)modelo;

            if (pessoa.celula_ != null)
            {
                var indice = lstBoxCelula.Items.IndexOf(pessoa.Celula);
                lstBoxCelula.SetSelected(indice, true);
            }
            else ckBoxNulo.Checked = true;

            try
            {
                foreach (var item in pessoa.Ministerio)
                {
                    var indice = lstBoxMinisterio.Items.IndexOf(item);
                    lstBoxMinisterio.SetSelected(indice, true);
                }
            }
            catch (Exception ex)
            {
                var msg = modelo.exibirMensagemErro(ex, 2);
                if(msg != "")
                MessageBox.Show(msg);
            }

            try
            {
                foreach (var item in pessoa.Reuniao)
                {
                    var indice = lstBoxReuniao.Items.IndexOf(item);
                    lstBoxReuniao.SetSelected(indice, true);
                }
            }
            catch (Exception ex)
            {
                var msg = modelo.exibirMensagemErro(ex, 2);
                if (msg != "")
                    MessageBox.Show(msg);
            }



            condicao = true;
        }

        private void lstBoxMinisterio_SelectedValueChanged(object sender, EventArgs e)
        {
            var pessoa = (Pessoa)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxMinisterio.SelectedItems;
                    var objetos = valor.Cast<Ministerio>().ToList();
                    pessoa.Ministerio = new List<PessoaMinisterio>();
                    foreach (var item in objetos)
                    pessoa.Ministerio.Add(new PessoaMinisterio { MinisterioId = item.Id });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }

        private void lstBoxCelula_SelectedValueChanged(object sender, EventArgs e)
        {
            var pessoa = (Pessoa)modelo;
            Celula cel = (Celula)lstBoxCelula.SelectedItem;
            if(cel != null)
            {
                pessoa.celula_ = cel.Id;
                pessoa.Celula = cel;
                if (ckBoxNulo.Checked)
                    ckBoxNulo.Checked = false;
            }
        }

        private void lstBoxReuniao_SelectedValueChanged(object sender, EventArgs e)
        {
            var pessoa = (Pessoa)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxReuniao.SelectedItems;
                    var objetos = valor.Cast<business.classes.Reuniao>().ToList();
                    pessoa.Reuniao = new List<ReuniaoPessoa>();
                    foreach (var item in objetos)
                        pessoa.Reuniao.Add(new ReuniaoPessoa { ReuniaoId = item.Id });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }

        private void ckBoxNulo_CheckedChanged(object sender, EventArgs e)
        {
            var pessoa = (Pessoa)modelo;
            if (ckBoxNulo.Checked)
            {
                var indice = lstBoxCelula.SelectedIndex;
                if (indice >= 0)
                lstBoxCelula.SetSelected(indice, false);
                pessoa.celula_ = null;
            }
        }
    }
}
