using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
                        if(item != "")
                        {
                            var modelo = listaPessoas.First(m => m.Codigo == int.Parse(item));
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
                            var modelo = listaCelulas.First(m => m.IdCelula == int.Parse(item));
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
                        var celula = listaCelulas.First(i => i.IdCelula == item.CelulaId);
                        txt_celulas.Text += celula.IdCelula.ToString() + ", ";
                    }
                        

                var pessoas = mini.Pessoas;
                if (pessoas != null)
                    foreach (var item in pessoas)
                    {
                        var pes = listaPessoas.First(i => i.IdPessoa == item.PessoaId);
                        txt_pessoas.Text += pes.Codigo.ToString() + ", ";
                    }                        
            }

        }

        private void txt_pessoas_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_celulas_TextChanged(object sender, EventArgs e)
        {
            AddNaListaMinisterioCelulas = txt_celulas.Text;
        }

        private void txt_pessoas_Leave(object sender, EventArgs e)
        {
            AddNaListaMinisterioPessoas = "";
            var arr = txt_pessoas.Text.Replace(" ", "").Split(',');

            foreach (var item in arr)
            {
                try
                {
                    int numero = int.Parse(item);
                    
                    var modelo = listaPessoas.FirstOrDefault(i => i.Codigo == numero);
                    try
                    {
                        AddNaListaMinisterioPessoas += modelo.IdPessoa.ToString() + ", ";
                    }
                    catch
                    {
                        AddNaListaMinisterioPessoas = "";
                        txt_pessoas.Text = "";
                        MessageBox.Show("Este formulario não esta atualizado." +
                        " Para atualizar feche e abra novamente o formulario.");
                    }
                }
                catch
                {
                    if(item != "")
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
}
