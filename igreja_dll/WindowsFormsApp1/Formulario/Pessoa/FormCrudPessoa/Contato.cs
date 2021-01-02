using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class Contato : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public Contato(business.classes.Abstrato.Pessoa p,
            bool Deletar, bool Atualizar,  bool Detalhes)
            : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void Contato_Load(object sender, EventArgs e)
        {
            this.Text = "Contatos.";

            var p = (business.classes.Abstrato.Pessoa)modelo;
            mask_tel1.Text = p.Telefone.Fone;
            mask_tel2.Text = p.Telefone.Celular;
            mask_tel3.Text = p.Telefone.Whatsapp;
        }

        private void mask_tel1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            p.Telefone.Fone = mask_tel1.Text;
        }

        private void mask_tel2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            p.Telefone.Celular = mask_tel2.Text;
        }

        private void mask_tel3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)modelo;
            p.Telefone.Whatsapp = mask_tel3.Text;
        }
    }
}
