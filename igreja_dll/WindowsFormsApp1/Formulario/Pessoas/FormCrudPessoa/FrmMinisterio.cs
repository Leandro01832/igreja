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
            Pessoa p = null;
            if (modelo != null)
                p = (Pessoa)modelo;
            else
                p = (Pessoa)ModeloNovo;

            if (p.celula_ != null)
            {
                var indice = lstBoxCelula.Items.IndexOf(p.Celula);
                lstBoxCelula.SetSelected(indice, true);
            }
            else ckBoxNulo.Checked = true;

            try
            {
                foreach (var item in p.Ministerio)
                {
                    var indice = lstBoxMinisterio.Items.IndexOf(item);
                    lstBoxMinisterio.SetSelected(indice, true);
                }
            }
            catch (Exception ex)
            {
                var msg = modeloErro.exibirMensagemErro(ex, 2);
                if(msg != "")
                MessageBox.Show(msg);
            }

            try
            {
                foreach (var item in p.Reuniao)
                {
                    var indice = lstBoxReuniao.Items.IndexOf(item);
                    lstBoxReuniao.SetSelected(indice, true);
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

        private void lstBoxMinisterio_SelectedValueChanged(object sender, EventArgs e)
        {
            Pessoa p = null;
            if (modelo != null)
                p = (Pessoa)modelo;
            else
                p = (Pessoa)ModeloNovo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxMinisterio.SelectedItems;
                    var objetos = valor.Cast<Ministerio>().ToList();
                    p.Ministerio = new List<PessoaMinisterio>();
                    foreach (var item in objetos)
                    p.Ministerio.Add(new PessoaMinisterio { MinisterioId = item.Id, Ministerio = item,
                        PessoaId = p.Id, Pessoa = p });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }

        private void lstBoxCelula_SelectedValueChanged(object sender, EventArgs e)
        {
            Pessoa p = null;
            if (modelo != null)
                p = (Pessoa)modelo;
            else
                p = (Pessoa)ModeloNovo;
            Celula cel = (Celula)lstBoxCelula.SelectedItem;
            if(cel != null)
            {
                p.celula_ = cel.Id;
                p.Celula = cel;
                if (ckBoxNulo.Checked)
                    ckBoxNulo.Checked = false;
            }
        }

        private void lstBoxReuniao_SelectedValueChanged(object sender, EventArgs e)
        {
            Pessoa p = null;
            if (modelo != null)
                p = (Pessoa)modelo;
            else
                p = (Pessoa)ModeloNovo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxReuniao.SelectedItems;
                    var objetos = valor.Cast<business.classes.Reuniao>().ToList();
                    p.Reuniao = new List<ReuniaoPessoa>();
                    foreach (var item in objetos)
                    p.Reuniao.Add(new ReuniaoPessoa { ReuniaoId = item.Id, Reuniao = item,
                        PessoaId = p.Id, Pessoa = p });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }

        private void ckBoxNulo_CheckedChanged(object sender, EventArgs e)
        {
            Pessoa p = null;
            if (modelo != null)
                p = (Pessoa)modelo;
            else
                p = (Pessoa)ModeloNovo;
            if (ckBoxNulo.Checked)
            {
                var indice = lstBoxCelula.SelectedIndex;
                if (indice >= 0)
                lstBoxCelula.SetSelected(indice, false);
                p.celula_ = null;
            }
        }
    }
}
