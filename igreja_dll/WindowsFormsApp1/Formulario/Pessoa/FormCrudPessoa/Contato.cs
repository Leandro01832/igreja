using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class Contato :  Formulario.FormCrudPessoa
    {
        public Contato(business.classes.Pessoas.PessoaDado p, bool Deletar, bool Atualizar,  bool Detalhes)
            : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        public Contato(bool Deletar, bool Atualizar, bool Detalhes, modelocrud modeloVelho, modelocrud modeloNovo)
           : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
        {
            InitializeComponent();
        }

        private void Contato_Load(object sender, EventArgs e)
        {
            this.Text = "Contatos.";

            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                mask_tel1.Text = p.Telefone.Fone;
                mask_tel2.Text = p.Telefone.Celular;
                mask_tel3.Text = p.Telefone.Whatsapp;
            }
            
        }

        private void mask_tel1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                p.Telefone.Fone = mask_tel1.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                p.Telefone.Fone = mask_tel1.Text;
            }

        }

        private void mask_tel2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                p.Telefone.Celular = mask_tel2.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                p.Telefone.Celular = mask_tel2.Text;
            }
        }

        private void mask_tel3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                p.Telefone.Whatsapp = mask_tel3.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                p.Telefone.Whatsapp = mask_tel3.Text;
            }
        }
    }
}
