using business.classes.Abstrato;
using database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class DadoMinisterio : FormCrudMinisterio
    {
        public DadoMinisterio(Ministerio p, bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }
        

        private void DadoMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Dados de Ministério";

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
            var m = (Ministerio)modelo;
            m.Nome = txt_nome_ministerio.Text;
            
        }

        private void txt_proposito_TextChanged(object sender, EventArgs e)
        {
            var m = (Ministerio)modelo;
            m.Proposito = txt_proposito.Text;
        }

        private void txt_ministro_TextChanged(object sender, EventArgs e)
        {
            var m = (Ministerio)modelo;
            try
            {
                var modelo = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().FirstOrDefault(i => i.Codigo == int.Parse(txt_ministro.Text));
                if(modelo != null)
                m.Ministro_ = modelo.Id;
            }
            catch (Exception)
            {
                m.Ministro_ = null;
                txt_ministro.Text = "";
                MessageBox.Show("Informe um numero de indentificação. Apenas numeros.");
            }
        }
    }
}
