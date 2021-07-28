using business.classes.Abstrato;
using database;
using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.Pessoas;

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
            if (ministerio.Id == 0)
            {
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                {
                    var arr = AddNaListaMinisterioPessoas.Replace(" ", "").Split(',');
                    foreach (var item in arr)
                    {
                        if (item != "")
                        {
                            var modelo = modelocrud.Modelos.OfType<Pessoa>().ToList().First(m => m.Codigo == int.Parse(item));
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
                            var modelo = modelocrud.Modelos.OfType<Celula>().ToList().First(m => m.Id == int.Parse(item));
                            txt_celulas.Text += modelo.Id.ToString() + ", ";
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
                        var celula = modelocrud.Modelos.OfType<Celula>().ToList().First(i => i.Id == item.CelulaId);
                        txt_celulas.Text += celula.Id.ToString() + ", ";
                    }


                var pessoas = mini.Pessoas;
                if (pessoas != null)
                    foreach (var item in pessoas)
                    {
                        var pes = modelocrud.Modelos.OfType<Pessoa>().ToList().First(i => i.Id == item.PessoaId);
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
                                var modelo = modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(i => i.Codigo == numero);
                                AddNaListaMinisterioPessoas += modelo.Id.ToString() + ", ";
                            }
                            catch
                            {
                                AddNaListaReuniaoPessoas = "";
                                var num = Pessoa.GeTotalRegistrosPessoas();
                                if (num != modelocrud.Modelos.OfType<Pessoa>().ToList().Count)
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
                                var modelo = modelocrud.Modelos.OfType<Celula>().ToList().FirstOrDefault(i => i.Id == numero);
                                AddNaListaMinisterioCelulas += modelo.Id.ToString() + ", ";
                            }
                            catch
                            {
                                AddNaListaMinisterioCelulas = "";
                                txt_celulas.Text = "";
                                var num = Celula.GeTotalRegistrosCelulas();
                                if (num != modelocrud.Modelos.OfType<Celula>().ToList().Count)
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
            FrmPessoa form = new FrmPessoa(typeof(Pessoa));
            form.MdiParent = this.MdiParent;
            form.Text = "Lista de Pessoas";
            form.Show();
        }

        private void listacelulas_Click(object sender, EventArgs e)
        {
            FrmCelula form = new FrmCelula(typeof(Celula));
            form.MdiParent = this.MdiParent;
            form.Text = "Lista de Celulas";
            form.Show();
        }
    }
}
