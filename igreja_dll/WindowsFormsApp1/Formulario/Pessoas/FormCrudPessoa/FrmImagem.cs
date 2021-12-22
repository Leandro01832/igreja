﻿using business.classes.Abstrato;
using database.banco;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas
{
    public partial class FrmImagem : WFCrud
    {
        public FrmImagem()
        {
            InitializeComponent();
        }

        private void Foto_Load(object sender, EventArgs e)
        {
            this.Text = "Foto da pessoa";
            this.Proximo.Location = new Point(900, 150);

            Pessoa p = null;
            if (modelo != null)
                p = (Pessoa)modelo;
            else
                p = (Pessoa)ModeloNovo;
            this.Atualizar.Location = new Point(900, 250);
            this.Deletar.Location = new Point(900, 350);

            if (modelo is Pessoa && !BDcomum.BancoEnbarcado)
                ptrb_foto.ImageLocation = "http://www.igrejadeusbom.somee.com" + p.Imagem;
            else
                ptrb_foto.ImageLocation = p.Imagem;

        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            if (modelo != null)
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
                        p.Imagem = ptrb_foto.ImageLocation;


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
                        p.Imagem = ptrb_foto.ImageLocation;
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

