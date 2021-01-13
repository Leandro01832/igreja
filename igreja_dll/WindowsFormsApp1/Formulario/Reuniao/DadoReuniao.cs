using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Reuniao
{
    public partial class DadoReuniao : FormCrudReuniao
    {
        public DadoReuniao(modelocrud modelo, bool deletar, bool atualizar, bool detalhes)
        : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        private void Reuniao_Load(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var reuniao = (business.classes.Reuniao)modelo;
                txt_local_reuniao.Text = reuniao.Local_reuniao;
                mask_horario_final.Text = reuniao.Horario_fim.ToString("HH:mm:ss");
                mask_horario_inicio.Text = reuniao.Horario_inicio.ToString("HH:mm:ss");
                mask_data_reuniao.Text = reuniao.Data_reuniao.ToString("dd/MM/yyyy");
            }
        }

        private void txt_local_reuniao_TextChanged(object sender, EventArgs e)
        {
            var reuniao = (business.classes.Reuniao)modelo;
            reuniao.Local_reuniao = txt_local_reuniao.Text;
        }

        private void mask_horario_final_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_horario_final.Text = "";            
        }

        private void mask_horario_inicio_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_horario_inicio.Text = "";
        }

        private void mask_data_reuniao_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_data_reuniao.Text = "";
        }

        private void mask_data_reuniao_TextChanged(object sender, EventArgs e)
        {
            var reuniao = (business.classes.Reuniao)modelo;
            try
            {
                reuniao.Data_reuniao = Convert.ToDateTime(mask_data_reuniao.Text);
            }
            catch { }
        }

        private void mask_horario_inicio_TextChanged(object sender, EventArgs e)
        {
            var reuniao = (business.classes.Reuniao)modelo;
            try
            {
                reuniao.Horario_inicio = Convert.ToDateTime(mask_horario_inicio.Text);
            }
            catch { }
        }

        private void mask_horario_final_TextChanged(object sender, EventArgs e)
        {
            var reuniao = (business.classes.Reuniao)modelo;
            try
            {
                reuniao.Horario_fim = Convert.ToDateTime(mask_horario_final.Text);
            }
            catch { }
        }
    }
}
