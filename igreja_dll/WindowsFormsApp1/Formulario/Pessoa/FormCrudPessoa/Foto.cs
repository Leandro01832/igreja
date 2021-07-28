using business.classes.Abstrato;
using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas
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
            var p = (Pessoa)modelo;
            if (p !=  null)
            {
                this.Atualizar.Location = new Point(900, 250);

                if (modelo is Pessoa && !BDcomum.BancoEnbarcado)
                ptrb_foto.ImageLocation = "http://www.igrejadeusbom.somee.com" + p.Img;
                else
                ptrb_foto.ImageLocation = p.Img;
            }
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (Pessoa)modelo;
                try
                {

                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.InitialDirectory = $@"F:\repos\Igreja\igreja-master\igreja-master\igreja_dll\WindowsFormsApp1\bin\Debug\Fotos";
                    dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                    dlg.Title = "selecione uma imagem";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string imagem;
                        ptrb_foto.SizeMode = PictureBoxSizeMode.Zoom;
                        ptrb_foto.Image = Image.FromFile(dlg.FileName);
                        imagem = dlg.FileName;
                        ptrb_foto.ImageLocation = imagem;
                        p.Img = ptrb_foto.ImageLocation;


                        // Converter em array
                        Image minhaImagem = Image.FromFile(dlg.FileName);
                        byte[] meuArrayBytes = ConverteImagemParaByteArray(minhaImagem);
                        p.ImgArrayBytes = meuArrayBytes;                        

                      //  SalvaArrayBytesEmArquivo(meuArrayBytes);
                      //  ExibirArquivos();
                      //  picImagem.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (ModeloNovo != null)
            {
                var p = (Pessoa)ModeloNovo;
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

        private byte[] ConverteImagemParaByteArray(Image img)
        {
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    img.Save(mStream, img.RawFormat);
                    return mStream.ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

