using business.classes.Esboco.Fontes;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    public partial class FrmCanalTv : WFCrud
    {
        public FrmCanalTv()
            : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarCanalTv_Load(object sender, EventArgs e)
        {
            
                var fonte = (CanalTv)modelo;

             try { txt_nome_canal.Text = fonte.NomeCanal;         } catch(Exception ex){MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
              try{  txt_nome_programa.Text = fonte.NomePrograma;  } catch(Exception ex){MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
             try { mask_horario.Text = fonte.Horario.ToString();  } catch(Exception ex){ MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            
        }

        private void txt_nome_canal_TextChanged(object sender, EventArgs e)
        {
            var fonte = (CanalTv)modelo;
            fonte.NomeCanal = txt_nome_canal.Text;
        }

        private void txt_nome_programa_TextChanged(object sender, EventArgs e)
        {
            var fonte = (CanalTv)modelo;
            fonte.NomePrograma = txt_nome_programa.Text;
        }

        private void mask_horario_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_horario.Text = "";
        }

        private void mask_horario_TextChanged(object sender, EventArgs e)
        {
            var fonte = (CanalTv)modelo;
            try
            {
                fonte.Horario = TimeSpan.Parse(mask_horario.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}
