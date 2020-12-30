using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFIgrejaLgpd.Formulario.Celula
{
    public partial class EnderecoCelula : FormularioCrudCelula
    {
        public EnderecoCelula(business.classes.Abstrato.Celula p, bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void EnderecoCelula_Load(object sender, EventArgs e)
        {
            this.Text = " - Endereço da celula";
        }

        private void textpais_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.EnderecoCelula.Pais = textpais.Text;
        }

        private void text_cep_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.EnderecoCelula.Cep = long.Parse(text_cep.Text);
        }

        private void text_estado_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.EnderecoCelula.Estado = text_estado.Text;
        }

        private void text_cidade_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.EnderecoCelula.Cidade = text_cidade.Text;
        }

        private void text_bairro_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.EnderecoCelula.Bairro = text_bairro.Text;
        }

        private void text_rua_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.EnderecoCelula.Rua = text_rua.Text;
        }

        private void text_complemento_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.EnderecoCelula.Complemento = text_complemento.Text;
        }

        private void text_numero_TextChanged(object sender, EventArgs e)
        {
            var c = (business.classes.Abstrato.Celula)modelo;
            c.EnderecoCelula.Numero_casa = int.Parse(text_numero.Text);
        }
    }
}
