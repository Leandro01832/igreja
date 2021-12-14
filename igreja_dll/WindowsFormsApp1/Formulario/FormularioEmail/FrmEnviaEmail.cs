using business;
using business.classes.Abstrato;
using database;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class FrmEnviaEmail : Form
    {
        public FrmEnviaEmail()
        {
            InitializeComponent();
        }

        EmailIgreja email;

        private  void FrmEnviaEmail_Load(object sender, EventArgs e)
        {
            //  await modelocrud.Recuperar();

            FrmPrincipal.LoadForm(this);
            lstEmail.DataSource = modelocrud.Modelos
            .OfType<EmailIgreja>().Where(em => !em.Enviado).ToList();
             email = (EmailIgreja) lstEmail.SelectedItem;

            lstCategoria.DataSource = modelocrud.Modelos
            .OfType<Permissao>().Where(p => p.Id > 9).ToList();



        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            
            try
            {
                btnEnviar.Enabled = false;
                var pessoa = modelocrud.Modelos.OfType<Pessoa>().FirstOrDefault(p => p.Email == txtEmail.Text);

                email.Enviado = true;
                var categoria = (Categoria)lstCategoria.SelectedItem;
                email.Categoria.Permissao.Nome = categoria.Permissao.Nome;
                email.Categoria.Id = categoria.Id;

                email.alterar(email.Id);
                var valor = email.Body.Html;

                MailMessage mail = new MailMessage(FrmPrincipal.Email, txtEmail.Text);

                mail.Subject = txtAssunto.Text;
                mail.Body = valor;
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mail.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new NetworkCredential(FrmPrincipal.Email, FrmPrincipal.SenhaEmail);
                cliente.EnableSsl = true;

                await cliente.SendMailAsync(mail);

                MessageBox.Show("Email enviado com sucesso!!!");
                btnEnviar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void lstEmail_SelectedValueChanged(object sender, EventArgs e)
        {
            email = (EmailIgreja)lstEmail.SelectedItem;
            txtAssunto.Text = email.Assunto;
            txtEmail.Text = email.Pessoa.Email;
            wbHtml.DocumentText = email.Body.Html;
        }

        private void lstCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            email = (EmailIgreja)lstEmail.SelectedItem;
            var categoria = (Permissao)lstCategoria.SelectedItem;
            if(email != null)
            email.CategoriaId = categoria.Id;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            try
            {
                email.excluir(email.Id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private  void button1_Click(object sender, EventArgs e)
        {
          //  await BaseModel.Recuperar();
            lstEmail.DataSource = modelocrud.Modelos
            .OfType<EmailIgreja>().Where(em => !em.Enviado).ToList();
            email = (EmailIgreja)lstEmail.SelectedItem;
            lstCategoria.DataSource = modelocrud.Modelos
            .OfType<Permissao>().Where(p => p.Id > 9).ToList();
        }
    }
}
