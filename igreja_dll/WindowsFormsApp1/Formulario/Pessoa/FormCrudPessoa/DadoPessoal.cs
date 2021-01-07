using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using business.classes.Abstrato;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class DadoPessoal : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public DadoPessoal(business.classes.Pessoas.PessoaDado P,
            bool Deletar, bool Atualizar,  bool Detalhes)
            : base(P, Deletar, Atualizar,  Detalhes)
        { 
            InitializeComponent();
        }

        private void DadoPessoal_Load(object sender, EventArgs e)
        {
            this.Text = "Daddos pessoais.";

            if (modelo.Id != 0)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                text_nome.Text = p.Nome;
                text_rg.Text = p.Rg;
                text_cpf.Text = p.Cpf;
                listestado_civil.Text = p.Estado_civil;
                listBox_status.Text = p.Status;
                mask_data_nascimento.Text = p.Data_nascimento.ToString("dd/MM/yyyy");
                textemail.Text = p.Email;
                radioButton_masculino.Checked = p.Sexo_masculino;
                radioButton_feminino.Checked = p.Sexo_feminino; 
            }

        }

        private void text_nome_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado) modelo;
            p.Nome = text_nome.Text;
        }

        private void text_rg_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)modelo;
            p.Rg = text_rg.Text;
        }

        private void text_cpf_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)modelo;
            p.Cpf = text_cpf.Text;
        }

        private void listestado_civil_SelectedIndexChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)modelo;
            p.Estado_civil = listestado_civil.Text;
        }

        private void listBox_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)modelo;
            p.Status = listBox_status.Text;
        }

        private void mask_data_nascimento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_data_nascimento.Text = "";
        }

        private void textemail_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)modelo;
            p.Email = textemail.Text;
        }

        private void radioButton_masculino_CheckedChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)modelo;
            p.Sexo_masculino = radioButton_masculino.Checked;
        }

        private void radioButton_feminino_CheckedChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)modelo;
            p.Sexo_feminino = radioButton_feminino.Checked;
        }

        private void mask_data_nascimento_MaskChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)modelo;
            p.Data_nascimento = Convert.ToDateTime(mask_data_nascimento.Text);
        }

        private void mask_data_nascimento_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)modelo;
            try
            {
                p.Data_nascimento = Convert.ToDateTime(mask_data_nascimento.Text.ToString());
            }
            catch (Exception)
            {
                
            }
        }
    }
}
