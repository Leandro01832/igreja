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
    public partial class DadoCelula : FormularioCrudCelula
    {
        public DadoCelula()
        {

        }

        public DadoCelula(business.classes.Abstrato.Celula p,
            bool Deletar, bool Atualizar, bool Detalhes)
           : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void DadoCelula_Load(object sender, EventArgs e)
        {
                this.Text = " - Dados de celula.";

            if (modelo != null)
            {
                var p = (business.classes.Abstrato.Celula)modelo;
                txt_nome_celula.Text = p.Nome;
                txt_dia_semana.Text = p.Dia_semana;
                mask_horario.Text = p.Horario.ToString();

            }
        }

        private void txt_nome_celula_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.Nome = txt_nome_celula.Text;
        }

        private void txt_dia_semana_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.Dia_semana = txt_dia_semana.Text;
        }

        private void mask_horario_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_horario.Text = "";
        }

        private void mask_horario_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
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
