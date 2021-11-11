using business;
using business.classes.Pessoas;
using database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1.Formulario.FormularioEmail
{
    public partial class FrmOpenEmail : Form
    {
        public FrmOpenEmail()
        {
            InitializeComponent();
        }
        
        EmailPessoa email;

        private void FrmOpenEmail_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this);

            lstBoxEmail.DataSource = modelocrud.Modelos.OfType<EmailPessoa>().OrderByDescending(em => em.Data).ToList();

            lstCategoria.DataSource = modelocrud.Modelos
            .OfType<Permissao>().Where(p => p.Id > 9).ToList();

            lstBoxAtendente.DataSource = modelocrud.Modelos.OfType<Atendente>().ToList();


        }

        

        private void lstBoxEmail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBoxEmail_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                email = (EmailPessoa) lstBoxEmail.SelectedItem;

                txtDe.Text = email.Remetente;

                web.DocumentText = email.Body;

                txtData.Text = email.Data.ToString("dd/MM/yyyy");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu" + ex.Message);
            }
        }

        private void lstCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            email = (EmailPessoa)lstBoxEmail.SelectedItem;
            var categoria = (Permissao)lstCategoria.SelectedItem;
            if (email != null)
                email.CategoriaId = categoria.Id;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                email.alterar(email.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            try
            {
                email.excluir(email.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            lstBoxEmail.DataSource = modelocrud.Modelos.OfType<EmailPessoa>().OrderByDescending(em => em.Data).ToList();
            lstCategoria.DataSource = modelocrud.Modelos
            .OfType<Permissao>().Where(p => p.Id > 9).ToList();
        }

        private void lstBoxAtendente_SelectedValueChanged(object sender, EventArgs e)
        {
            var atende = (Atendente)lstBoxAtendente.SelectedItem;
            if (atende != null && email != null)
                email.AtendenteId = atende.Id;
        }
    }
}
