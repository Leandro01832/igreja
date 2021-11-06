using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class Endereco : Formulario.FormCrudPessoa
    {
        public Endereco(business.classes.Pessoas.PessoaDado p,
            bool Deletar, bool Atualizar, bool Detalhes)
           : base(p, Deletar, Atualizar, Detalhes)
        {
            
            InitializeComponent();
        }

        public Endereco(bool Deletar, bool Atualizar, bool Detalhes, modelocrud modeloVelho, modelocrud modeloNovo)
           : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
        {
            InitializeComponent();
        }

        private void Endereco_Load(object sender, EventArgs e)
        {
            this.Text = "Endereço da pessoa.";


            if (modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
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
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                p.Endereco.Pais = textpais.Text;
            }
            if(ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                p.Endereco.Pais = textpais.Text;
            }
            
        }

        private void text_cep_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                try
                {
                    var p = (business.classes.Pessoas.PessoaDado)modelo;
                    p.Endereco.Cep = long.Parse(text_cep.Text);
                }
                catch (Exception)
                {
                    text_cep.Text = "";
                    MessageBox.Show("informe apenas numeros");
                }
            }
            if (ModeloNovo != null)
            {
                try
                {
                    var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                    p.Endereco.Cep = long.Parse(text_cep.Text);
                }
                catch (Exception)
                {
                    text_cep.Text = "";
                    MessageBox.Show("informe apenas numeros");
                }
            }
        }

        private void text_estado_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                p.Endereco.Estado = text_estado.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                p.Endereco.Estado = text_estado.Text;
            }
        }

        private void text_cidade_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                p.Endereco.Cidade = text_cidade.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                p.Endereco.Cidade = text_cidade.Text;
            }
        }

        private void text_bairro_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                p.Endereco.Bairro = text_bairro.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                p.Endereco.Bairro = text_bairro.Text;
            }
        }

        private void text_rua_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                p.Endereco.Rua = text_rua.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                p.Endereco.Rua = text_rua.Text;
            }
        }

        private void text_complemento_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                p.Endereco.Complemento = text_complemento.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                p.Endereco.Complemento = text_complemento.Text;
            }
        }

        private void text_numero_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                try
                {
                    p.Endereco.Numero_casa = int.Parse(text_numero.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe a rua corretamente.");
                }
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
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
}
