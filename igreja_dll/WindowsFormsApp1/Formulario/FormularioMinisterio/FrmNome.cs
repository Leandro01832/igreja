using business.classes.Abstrato;
using database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class FrmNome : WFCrud
    {
        public FrmNome() : base()
        {
            InitializeComponent();
        }

        bool condicao = false;

        private void DadoMinisterio_Load(object sender, EventArgs e)
        {

            this.Text = " - Dados de Ministério";

            lstBoxPessoa.DataSource = modelocrud.Modelos.OfType<Pessoa>().OrderBy(m => m.Id).ToList();
            if(modelocrud.Modelos.OfType<Pessoa>().ToList().Count > 0)            
                lstBoxPessoa.SetSelected(0, false);

            Ministerio p = null;
            if (modelo != null)
                p = (Ministerio)modelo;
            else
                p = (Ministerio)ModeloNovo;            
            try { txt_nome_ministerio.Text = p.Nome; }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            try { txt_proposito.Text = p.Proposito; }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            try
            {
                if (p.Ministro_ != null)
                {
                    var indice = lstBoxPessoa.Items.IndexOf(modelocrud.Modelos.OfType<Pessoa>().First(m => m.Id == p.Ministro_));
                    lstBoxPessoa.SetSelected(indice, true);
                }
                else
                    ckBoxNulo.Checked = true;
            }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }

            condicao = true;
        }

        private void txt_nome_ministerio_TextChanged(object sender, EventArgs e)
        {
            var m = (Ministerio)modelo;
            try
            {
                m.Nome = txt_nome_ministerio.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2));
            }

        }

        private void txt_proposito_TextChanged(object sender, EventArgs e)
        {
            var m = (Ministerio)modelo;
            try
            {
                m.Proposito = txt_proposito.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2));
            }
        }

        private void ckBoxNulo_CheckedChanged(object sender, EventArgs e)
        {
            var m = (Ministerio)modelo;
           if(ckBoxNulo.Checked)
            {
                var indice = lstBoxPessoa.SelectedIndex;
                if(indice >= 0)
                lstBoxPessoa.SetSelected(indice, false);
                m.Ministro_ = null;
            }
        }

        private void lstBoxPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (condicao)
            {
                var m = (Ministerio)modelo;
                var pessoa = (Pessoa)lstBoxPessoa.SelectedItem;
                if(pessoa != null)
                {
                    m.Ministro_ = pessoa.Id;
                    if (ckBoxNulo.Checked)
                        ckBoxNulo.Checked = false;
                }
                
            }
            
        }
    }
}
