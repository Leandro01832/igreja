using business;
using business.classes.Abstrato;
using database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioEmail
{
    public partial class FrmPermissao : WFCrud
    {
        Button AtendentesCategoria;
        Button EmailCategoria;
        public FrmPermissao() : base()
        {
            AtendentesCategoria = new Button();
            AtendentesCategoria.Click += AtendentesCategoria_Click;
            AtendentesCategoria.Text = "Atendentes desta categoria";
            AtendentesCategoria.Location = new Point(350, 350);
            AtendentesCategoria.Size = new Size(250, 50);
            AtendentesCategoria.Visible = false;

            EmailCategoria = new Button();
            EmailCategoria.Click += EmailCategoria_Click;     
            EmailCategoria.Text = "E-mails desta categoria";
            EmailCategoria.Location = new Point(650, 350);
            EmailCategoria.Size = new Size(250, 50);
            EmailCategoria.Visible = false;

            InitializeComponent();
        }

        private void EmailCategoria_Click(object sender, EventArgs e)
        {
            var lista = new List<Pessoa>();
            var Permissao = (Permissao)modelo;
            FormularioListView form = new FormularioListView(Permissao.Categoria.Email.Cast<modelocrud>().ToList());
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void AtendentesCategoria_Click(object sender, EventArgs e)
        {
            var lista = new List<Pessoa>();
            var Permissao = (Permissao)modelo;
            foreach (var item in Permissao.PermissaoPessoa)
                lista.Add(item.Pessoa);
            FormularioListView form = new FormularioListView(lista.Cast<modelocrud>().ToList());
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            var Permissao = (Permissao)modelo;
            Permissao.Nome = txtNome.Text;
        }

        private void FrmPermissao_Load(object sender, EventArgs e)
        {
            var Permissao = (Permissao)modelo;
            if (Permissao.Id != 0)
            {
                txtNome.Text = Permissao.Nome;

                if(Permissao.Categoria != null)
                {
                    AtendentesCategoria.Visible = true;
                    AtendentesCategoria.Enabled = true;
                    EmailCategoria.Visible = true;
                    EmailCategoria.Enabled = true;
                }
                else
                {
                    AtendentesCategoria.Visible = false;
                    AtendentesCategoria.Enabled = false;
                    EmailCategoria.Visible = false;
                    EmailCategoria.Enabled = false;
                }
            }
            else
                Permissao.Categoria = new Categoria();

        }
    }
}
