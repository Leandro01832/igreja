using business.classes.Abstrato;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Celulas
{
    public partial class FrmDia_semana : WFCrud
    {
        public FrmDia_semana() : base()
        {
            InitializeComponent();
        }

        private void DadoCelula_Load(object sender, EventArgs e)
        {
            this.Text = " - Dados de celula.";


            var p = (Celula)modelo;
            try { txt_nome_celula.Text = p.Nome; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txt_dia_semana.Text = p.Dia_semana; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { mask_horario.Text = p.Horario.ToString(); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }


        }

        private void txt_nome_celula_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            c.Nome = txt_nome_celula.Text;
        }

        private void txt_dia_semana_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            c.Dia_semana = txt_dia_semana.Text;
        }

        private void mask_horario_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_horario.Text = "";
        }

        private void mask_horario_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            try
            {
                c.Horario = TimeSpan.Parse(mask_horario.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}
