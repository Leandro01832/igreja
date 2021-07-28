using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class CadastroVisitante : WindowsFormsApp1.Formulario.FormCrudPessoa
    {

        public CadastroVisitante(modelocrud p, bool Deletar, bool Atualizar,  bool Detalhes)            
        :base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
            this.modelo = p;
        }

        public CadastroVisitante(bool Deletar, bool Atualizar, bool Detalhes, modelocrud modeloVelho, modelocrud modeloNovo)
            : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroVisitante(modelocrud modelo, modelocrud modeloNovo)
            :base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        private void CadastroVisitante_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de visitante.";

            if(modelo != null)
            {
                if(modelo is Visitante)
                {
                    var p = (Visitante)modelo;
                    mask_data_visita.Text = p.Data_visita.ToString("dd/MM/yyyy");
                    txt_condicao_religiosa.Text = p.Condicao_religiosa;
                }

                if (modelo is VisitanteLgpd)
                {
                    var p = (VisitanteLgpd)modelo;
                    mask_data_visita.Text = p.Data_visita.ToString("dd/MM/yyyy");
                    txt_condicao_religiosa.Text = p.Condicao_religiosa;
                }
            }
        }

        private void mask_data_visita_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_data_visita.Text = "";
        }

        private void txt_condicao_religiosa_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                if(modelo is Visitante)
                {
                    var p = (Visitante)modelo;
                    p.Condicao_religiosa = txt_condicao_religiosa.Text;
                }
                if (modelo is VisitanteLgpd)
                {
                    var p = (VisitanteLgpd)modelo;
                    p.Condicao_religiosa = txt_condicao_religiosa.Text;
                }

            }
            if(ModeloNovo != null)
            {
                if (ModeloNovo is Visitante)
                {
                    var p = (Visitante)ModeloNovo;
                    p.Condicao_religiosa = txt_condicao_religiosa.Text;
                }
                if (ModeloNovo is VisitanteLgpd)
                {
                    var p = (VisitanteLgpd)ModeloNovo;
                    p.Condicao_religiosa = txt_condicao_religiosa.Text;
                }
            }            
        }

        private void mask_data_visita_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                if(modelo is Visitante)
                {
                    var p = (Visitante)modelo;
                    try
                    {
                        p.Data_visita = Convert.ToDateTime(mask_data_visita.Text);
                    }
                    catch (Exception)
                    {
                    }
                }

                if (modelo is VisitanteLgpd)
                {
                    var p = (VisitanteLgpd)modelo;
                    try
                    {
                        p.Data_visita = Convert.ToDateTime(mask_data_visita.Text);
                    }
                    catch (Exception)
                    {
                    }
                }

            }

            if(ModeloNovo != null)
            {
                if (ModeloNovo is Visitante)
                {
                    var p = (Visitante)ModeloNovo;
                    try
                    {
                        p.Data_visita = Convert.ToDateTime(mask_data_visita.Text);
                    }
                    catch (Exception)
                    {
                    }
                }

                if (ModeloNovo is VisitanteLgpd)
                {
                    var p = (VisitanteLgpd)ModeloNovo;
                    try
                    {
                        p.Data_visita = Convert.ToDateTime(mask_data_visita.Text);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            
        }
    }
}
