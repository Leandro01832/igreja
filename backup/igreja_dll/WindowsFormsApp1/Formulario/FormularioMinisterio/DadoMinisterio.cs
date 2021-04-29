using business.classes.Abstrato;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class DadoMinisterio : FormCrudMinisterio
    {
        public DadoMinisterio(business.classes.Abstrato.Ministerio p,
            bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }
        List<business.classes.Abstrato.Pessoa> lista;

        private void DadoMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Dados de Ministério";
            lista = new List<business.classes.Abstrato.Pessoa>();
            lista = business.classes.Abstrato.Pessoa.recuperarTodos()
            .OfType<business.classes.Abstrato.Pessoa>().ToList();

            if (modelo != null)
            {
                var p = (Ministerio)modelo;
                txt_nome_ministerio.Text = p.Nome;
                txt_proposito.Text = p.Proposito;
                txt_ministro.Text = p.Ministro_.ToString();
            }
        }

        private void txt_nome_ministerio_TextChanged(object sender, EventArgs e)
        {
            var m = (business.classes.Abstrato.Ministerio)modelo;
            m.Nome = txt_nome_ministerio.Text;
            
        }

        private void txt_proposito_TextChanged(object sender, EventArgs e)
        {
            var m = (business.classes.Abstrato.Ministerio)modelo;
            m.Proposito = txt_proposito.Text;
        }

        private void txt_ministro_TextChanged(object sender, EventArgs e)
        {
            var m = (business.classes.Abstrato.Ministerio)modelo;
            try
            {
                var modelo = lista.First(i => i.Codigo == int.Parse(txt_ministro.Text));
                m.Ministro_ = modelo.IdPessoa;
            }
            catch (Exception)
            {
                m.Ministro_ = null;
                txt_ministro.Text = "";
                MessageBox.Show("Informe um numero de indentificação. Apenas digitos.");
            }
        }
    }
}
