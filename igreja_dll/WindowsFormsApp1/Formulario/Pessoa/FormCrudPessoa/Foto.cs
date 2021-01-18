using business.classes.Pessoas;
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

namespace WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa
{
    public partial class Foto : Formulario.FormCrudPessoa
    {
        public Foto()
        {
            InitializeComponent();
        }

        public Foto(modelocrud p,
            bool Deletar, bool Atualizar, bool Detalhes)
            : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        public Foto(bool Deletar, bool Atualizar, bool Detalhes, modelocrud modeloVelho, modelocrud modeloNovo)
           : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
        {
            InitializeComponent();
        }



        private void Foto_Load(object sender, EventArgs e)
        {
            this.Text = "Foto da pessoa";
            this.Proximo.Location = new Point(900, 150);

            if (modelo !=  null)
            {
                this.Atualizar.Location = new Point(900, 250);

                if (modelo is business.classes.Abstrato.Pessoa)
                {
                    var p = (business.classes.Abstrato.Pessoa)modelo;
                    ptrb_foto.ImageLocation = p.Img;
                }
            }
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Abstrato.Pessoa)modelo;
                try
                {

                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.InitialDirectory = $@"F:\repos\Igreja\igreja-master\igreja-master\igreja_dll\WindowsFormsApp1\bin\Debug\Fotos";
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

            if (ModeloNovo != null)
            {
                var p = (business.classes.Abstrato.Pessoa)ModeloNovo;
                try
                {

                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.InitialDirectory = @"F:\repos\Igreja\igreja-master\igreja-master\igreja_dll\WindowsFormsApp1\bin\Debug\Fotos";
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
        }
    }
}

