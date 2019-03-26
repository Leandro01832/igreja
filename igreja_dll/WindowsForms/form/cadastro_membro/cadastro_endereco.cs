using business.classes;
using igreja2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.form.cadastro_membro
{
    public partial class cadastro_endereco : Form
    {
        Pessoa p = new Pessoa();
        Membro m = new Membro();
        Visitante v = new Visitante();
        bool salvar = false;
        string classe_ = string.Empty;

        public cadastro_endereco(Pessoa pessoa, string classe, bool salve = false)
        {
            InitializeComponent();
            p = pessoa;
            salvar = salve;
            classe_ = classe;
        }        

        private void cadastro_endereco_Load(object sender, EventArgs e)
        {
            if (!salvar)
            {
                button1.Text = "cadastrar telefone.";
            }
            else
            {
                button1.Text = "salvar.";
                textpais.Text = p.Endereco.Pais;
                text_cep.Text = p.Endereco.Cep.ToString();
                text_estado.Text = p.Endereco.Estado;
                text_cidade.Text = p.Endereco.Cidade;
                text_bairro.Text = p.Endereco.Bairro;
                text_rua.Text = p.Endereco.Rua;
                text_complemento.Text = p.Endereco.Complemento;
                text_numero.Text = p.Endereco.Numero_casa.ToString();            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();

            pessoa = p;
            pessoa.Endereco = new Endereco();
            pessoa.Endereco.Pais = textpais.Text;
            pessoa.Endereco.Cidade = text_cidade.Text;
            pessoa.Endereco.Bairro = text_bairro.Text;
            pessoa.Endereco.Rua = text_rua.Text;
            pessoa.Endereco.Estado = text_estado.Text;
            pessoa.Endereco.Numero_casa = int.Parse(text_numero.Text);
            pessoa.Endereco.Cep = long.Parse(text_cep.Text);
            pessoa.Endereco.Complemento = text_complemento.Text;

            if (!salvar)
            {
                cadastro_telefone cad_tel = new cadastro_telefone(pessoa, classe_);
                cad_tel.MdiParent = MDIsingleton.InstanciaMDI();
                cad_tel.Show();
                cad_tel.WindowState = FormWindowState.Maximized;
            }
            else
            {
                finalizar_cadastro fin_cad = new finalizar_cadastro(pessoa, classe_);
                fin_cad.MdiParent = MDIsingleton.InstanciaMDI();
                fin_cad.Show();
                fin_cad.WindowState = FormWindowState.Maximized;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string urlconsulta = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml";
            DataSet retornaendereco = new DataSet();
            retornaendereco.ReadXml(urlconsulta.Replace("@cep", text_cep.Text));

            string retorno = retornaendereco.Tables[0].Rows[0]["resultado"].ToString();

            if (retorno == "0")
            {
                MessageBox.Show("CEP invalido");
            }
            else
            {
                text_cidade.Text = retornaendereco.Tables[0].Rows[0]["cidade"].ToString();
                text_estado.Text = retornaendereco.Tables[0].Rows[0]["uf"].ToString();
                text_rua.Text = retornaendereco.Tables[0].Rows[0]["logradouro"].ToString();
                text_bairro.Text = retornaendereco.Tables[0].Rows[0]["bairro"].ToString();
            }
        }
    }
}
