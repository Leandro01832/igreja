using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class Endereco : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public Endereco(business.classes.Abstrato.Pessoa p, bool Deletar, bool Atualizar, bool Detalhes)
           : base(p, Deletar, Atualizar, Detalhes)
        {
            
            InitializeComponent();
        }

        private void Endereco_Load(object sender, EventArgs e)
        {
            this.Text = "Endereço da pessoa.";


            if (modelo.Id != 0)
            {
                var p = (business.classes.Abstrato.Pessoa)modelo;
                textpais.Text = p.Endereco.Pais;
                text_cep.Text = p.Endereco.Cep.ToString();
                text_estado.Text = p.Endereco.Estado;
                text_cidade.Text = p.Endereco.Cidade;
                text_bairro.Text = p.Endereco.Bairro;
                text_rua.Text = p.Endereco.Rua;
                text_complemento.Text = p.Endereco.Complemento;
                text_numero.Text = p.Endereco.Numero_casa.ToString(); 
            }
        }

        private void textpais_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            p.Endereco.Pais = textpais.Text;
        }

        private void text_cep_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var p = (business.classes.Abstrato.Pessoa)modelo;
                p.Endereco.Cep = long.Parse(text_cep.Text);
            }
            catch (Exception)
            {
                text_cep.Text = "";
                MessageBox.Show("informe apenas numeros");
            }
        }

        private void text_estado_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            p.Endereco.Estado = text_estado.Text;
        }

        private void text_cidade_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            p.Endereco.Cidade = text_cidade.Text;
        }

        private void text_bairro_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            p.Endereco.Bairro = text_bairro.Text;
        }

        private void text_rua_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            p.Endereco.Rua = text_rua.Text;
        }

        private void text_complemento_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            p.Endereco.Complemento = text_complemento.Text;
        }

        private void text_numero_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            try
            {
                p.Endereco.Numero_casa = int.Parse(text_numero.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Informe a rua corretamente.");
            }
        }
    }
}
