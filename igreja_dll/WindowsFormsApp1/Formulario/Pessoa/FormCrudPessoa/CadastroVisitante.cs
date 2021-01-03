using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class CadastroVisitante : WindowsFormsApp1.Formulario.FormCrudPessoa
    {

        public CadastroVisitante(business.classes.Abstrato.Pessoa p,
            bool Deletar, bool Atualizar,  bool Detalhes)
            :base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
            this.modelo = p;
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
            if (modelo.Id != 0)
            {
                var p = (business.classes.Pessoas.Visitante)modelo;
                mask_data_visita.Text = p.Data_visita.ToString("dd/MM/yyyy");
                txt_condicao_religiosa.Text = p.Condicao_religiosa; 
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
                var p = (business.classes.Pessoas.Visitante)modelo;
                p.Condicao_religiosa = txt_condicao_religiosa.Text;
            }
            if(ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.Visitante)ModeloNovo;
                p.Condicao_religiosa = txt_condicao_religiosa.Text;
            }
            
        }

        private void mask_data_visita_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.Visitante)modelo;
                try
                {
                    p.Data_visita = Convert.ToDateTime(mask_data_visita.Text);
                }
                catch (Exception)
                {
                }
            }

            if(ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.Visitante)ModeloNovo;
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
