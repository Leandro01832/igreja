using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class Contato :  WFCrud
    {
        public Contato() : base()
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
            LoadCrudForm();
            this.Text = "Contatos.";

            
                var p = (business.classes.Pessoas.PessoaDado)modelo;
             try{   mask_tel1.Text = p.Telefone.Fone;      } catch(Exception ex) {MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
             try{   mask_tel2.Text = p.Telefone.Celular;   } catch(Exception ex) {MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
            try { mask_tel3.Text = p.Telefone.Whatsapp; } catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            
            
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
