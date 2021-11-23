using business;
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
using static System.Windows.Forms.ListBox;

namespace WindowsFormsApp1.Formulario.FormularioEmail.FormularioEmail
{
    public partial class FrmAtendente : WFCrud
    {
        public FrmAtendente() : base()
        {
            InitializeComponent();
        }
        

        // variavel para evitar bug
        bool condicao = false;

        private void FrmAtendente_Load(object sender, EventArgs e)
        {
            var Atendente = (Atendente)modelo;
            lstPermissoes.DataSource = modelocrud.Modelos.OfType<Permissao>().ToList();
            lstPermissoes.SetSelected(0, false);

            if (Atendente.Id != 0)
            {
                txtEmail.Text = Atendente.Email;
                txtNome.Text = Atendente.NomePessoa;
                txtSenha.Text = Atendente.password;
                foreach (var item in Atendente.Permissao)
                {
                    var indice = lstPermissoes.Items.IndexOf(item.Permissao);
                    lstPermissoes.SetSelected(indice, true);
                }
            }
            else
                Atendente.Permissao = new List<PermissaoPessoa>();

            condicao = true;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            var Atendente = (Atendente)modelo;
            Atendente.NomePessoa = txtNome.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            var Atendente = (Atendente)modelo;
            Atendente.Email = txtEmail.Text;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            var Atendente = (Atendente)modelo;
            Atendente.Senha = txtSenha.Text;
        }

        private void lstPermissoes_SelectedValueChanged(object sender, EventArgs e)
        {
            var Atendente = (Atendente)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstPermissoes.SelectedItems;
                    var objetos = valor.OfType<Permissao>().ToList();
                    Atendente.Permissao = new List<PermissaoPessoa>();
                    foreach (var item in objetos)
                        Atendente.Permissao.Add(new PermissaoPessoa { PermissaoId = item.Id }); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu. " + ex.Message);
            }
        }

       
    }
}
