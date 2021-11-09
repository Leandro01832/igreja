using business.classes.Esboco.Fontes;
using System;

namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    public partial class FrmLivro : WFCrud
    {
        public FrmLivro()
            :base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarLivro_Load(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var fonte = (Livro)modelo;
                txt_autor.Text = fonte.NomeAutor;
                txt_livro.Text = fonte.NomeLivro;
            }
        }

        private void txt_autor_TextChanged(object sender, EventArgs e)
        {
            var fonte = (Livro)modelo;
            fonte.NomeAutor = txt_autor.Text;

        }

        private void txt_livro_TextChanged(object sender, EventArgs e)
        {
            var fonte = (Livro)modelo;
            fonte.NomeLivro = txt_livro.Text;
        }
    }
}
