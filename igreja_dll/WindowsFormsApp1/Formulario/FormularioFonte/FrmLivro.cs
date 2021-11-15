using business.classes.Esboco.Fontes;
using System;
using System.Windows.Forms;

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
            LoadCrudForm();
            FormPadrao.LoadForm(this);
            
                var fonte = (Livro)modelo;
              try{  txt_autor.Text = fonte.NomeAutor; } catch(Exception ex){MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
            try { txt_livro.Text = fonte.NomeLivro; } catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); } 
            
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
