using business.classes.Abstrato;
using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celula;
using WindowsFormsApp1.Formulario.Pessoa;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class PessoasCelulasMinisterio : FormCrudMinisterio
    {
        public PessoasCelulasMinisterio()
        {
            InitializeComponent();
        }

        public PessoasCelulasMinisterio(Ministerio p, bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
            txt_pessoas.Leave += Txt_pessoas_Leave;
            txt_celulas.Leave += Txt_celulas_Leave;
        }

        private void Txt_celulas_Leave(object sender, EventArgs e)
        {
            AddNaListaMinisterioCelulas = txt_celulas.Text;
        }

        private void Txt_pessoas_Leave(object sender, EventArgs e)
        {
            AddNaListaMinisterioPessoas = txt_pessoas.Text;
        }

        private void PessoasCelulasMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Celulas e pessoas do ministério.";

            var ministerio = (Ministerio)modelo;
            if (ministerio.IdMinisterio == 0)
            {
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                {
                    var arr = AddNaListaMinisterioPessoas.Replace(" ", "").Split(',');
                    foreach (var item in arr)
                    {
                        if (item != "")
                        {
                            var modelo = business.classes.Abstrato.Pessoa.listaPessoas.First(m => m.Codigo == int.Parse(item));
                            txt_pessoas.Text += modelo.Codigo.ToString() + ", ";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                {
                    var arr = AddNaListaMinisterioCelulas.Replace(" ", "").Split(',');
                    foreach (var item in arr)
                    {
                        if (item != "")
                        {
                            var modelo = business.classes.Abstrato.Celula.listaCelulas.First(m => m.IdCelula == int.Parse(item));
                            txt_celulas.Text += modelo.IdCelula.ToString() + ", ";
                        }
                    }
                }
            }

            else
            {
                var mini = (Ministerio)modelo;
                var celulas = mini.Celulas;
                if (celulas != null)
                    foreach (var item in celulas)
                    {
                        var celula = business.classes.Abstrato.Celula.listaCelulas.First(i => i.IdCelula == item.CelulaId);
                        txt_celulas.Text += celula.IdCelula.ToString() + ", ";
                    }


                var pessoas = mini.Pessoas;
                if (pessoas != null)
                    foreach (var item in pessoas)
                    {
                        var pes = business.classes.Abstrato.Pessoa.listaPessoas.First(i => i.IdPessoa == item.PessoaId);
                        txt_pessoas.Text += pes.Codigo.ToString() + ", ";
                    }
            }

        }

        private void txt_pessoas_TextChanged(object sender, EventArgs e)
        {
            AddNaListaMinisterioPessoas = "";
            var arr = txt_pessoas.Text.Replace(" ", "").Split(',');

            try { int teste = int.Parse(arr[0]); }
            catch
            {
                AddNaListaMinisterioPessoas = "";
                txt_pessoas.Text = "";
                txt_celulas.Focus();
                MessageBox.Show("Informe numeros de identificação de pessoas.");
            }

            if (arr[arr.Length - 1] == "")
                foreach (var item in arr)
                {
                    if (item != "")
                    {                        
                        try
                        {
                            int numero = int.Parse(item);
                            try
                            {
                                var modelo = business.classes.Abstrato.Pessoa.listaPessoas.FirstOrDefault(i => i.Codigo == numero);
                                AddNaListaMinisterioPessoas += modelo.IdPessoa.ToString() + ", ";
                            }
                            catch
                            {
                                AddNaListaReuniaoPessoas = "";
                                var num = modelocrud.GeTotalRegistrosPessoas();
                                if (num != business.classes.Abstrato.Pessoa.listaPessoas.Count)
                                    MessageBox.Show("Aguarde o processamento.");
                                else
                                    MessageBox.Show("Este registro não existe no banco de dados");
                            }
                        }
                        catch
                        {
                            if (item != "")
                            {
                                AddNaListaMinisterioPessoas = "";
                                txt_pessoas.Text = "";
                                txt_pessoas.Focus();
                                MessageBox.Show("Informe numeros de identificação de pessoas.");
                            }
                        } 
                    }
                }
        }

        private void txt_celulas_TextChanged(object sender, EventArgs e)
        {
            AddNaListaMinisterioCelulas = "";
            var arr = txt_celulas.Text.Replace(" ", "").Split(',');

            try { int teste = int.Parse(arr[0]); }
            catch
            {
                AddNaListaMinisterioCelulas = "";
                txt_celulas.Text = "";
                txt_celulas.Focus();
                MessageBox.Show("Informe numeros de identificação de celulas.");
            }

            if (arr[arr.Length - 1] == "")
                foreach (var item in arr)
                {
                    try
                    {
                        if (item != "")
                        {
                            int numero = int.Parse(item);
                            try
                            {
                                var modelo = business.classes.Abstrato.Celula.listaCelulas.FirstOrDefault(i => i.IdCelula == numero);
                                AddNaListaMinisterioCelulas += modelo.IdCelula.ToString() + ", ";
                            }
                            catch
                            {
                                AddNaListaMinisterioCelulas = "";
                                txt_celulas.Text = "";
                                var num = modelocrud.GeTotalRegistrosCelulas();
                                if (num != business.classes.Abstrato.Celula.listaCelulas.Count)
                                    MessageBox.Show("Aguarde o processamento.");
                                else
                                    MessageBox.Show("Este registro não existe no banco de dados");
                            } 
                        }
                    }
                    catch
                    {
                        if (item != "")
                        {
                            AddNaListaMinisterioCelulas = "";
                            txt_celulas.Text = "";
                            txt_celulas.Focus();
                            MessageBox.Show("Informe numeros de identificação de celulas.");
                        }
                    }
                }
        }

        private void listapessoas_Click(object sender, EventArgs e)
        {
            FrmPessoa form = new FrmPessoa(typeof(business.classes.Abstrato.Pessoa));
            form.MdiParent = this.MdiParent;
            form.Text = "Lista de Pessoas";
            form.Show();
        }

        private void listacelulas_Click(object sender, EventArgs e)
        {
            FrmCelula form = new FrmCelula();
            form.MdiParent = this.MdiParent;
            form.Text = "Lista de Celulas";
            form.Show();
        }
    }
}
