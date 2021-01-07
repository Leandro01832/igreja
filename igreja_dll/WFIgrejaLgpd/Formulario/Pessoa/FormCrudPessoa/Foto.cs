using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFIgrejaLgpd.Formulario.Pessoa.FormCrudPessoa
{
    public partial class Foto : WFIgrejaLgpd.Formulario.FormCrudPessoa
    {
        public Foto()
        {
            InitializeComponent();
        }

        public Foto(business.classes.Pessoas.PessoaLgpd p, bool Deletar, bool Atualizar, bool Detalhes)
            : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void Foto_Load(object sender, EventArgs e)
        {
            this.Text = "Foto da pessoa";

            this.Proximo.Location = new Point(900, 150);
            this.Atualizar.Location = new Point(900, 250);

            if(modelo.Id != 0)
            {
                var p = (business.classes.Pessoas.PessoaLgpd)modelo;
                ptrb_foto.ImageLocation = p.Img;
            }
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaLgpd)modelo;
            try
            {

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = @"F:\repos\Igreja\igreja-master\igreja-master\igreja_dll\WFIgrejaLgpd\bin\Debug\Fotos";
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                dlg.Title = "selecione uma imagem";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string imagem;
                    imagem = dlg.FileName;
                    ptrb_foto.ImageLocation = imagem;
                    p.Img = ptrb_foto.ImageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ptrb_foto_Click(object sender, EventArgs e)
        {

        }
    }
}

