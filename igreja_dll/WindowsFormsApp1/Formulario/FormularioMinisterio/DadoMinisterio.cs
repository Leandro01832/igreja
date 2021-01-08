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
        List<modelocrud> lista;
        List<business.classes.Pessoas.PessoaDado> lista2;

        private void DadoMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Dados de Ministério";
            lista = new List<modelocrud>();
            lista2 = new List<business.classes.Pessoas.PessoaDado>();
            lista = business.classes.Pessoas.PessoaDado.recuperarTodos();
            foreach (var item in lista)
            lista2.Add((business.classes.Pessoas.PessoaDado)item);
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
                var modelo = lista2.First(i => i.Codigo == int.Parse(txt_ministro.Text));
                m.Ministro_ = modelo.Id;
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
