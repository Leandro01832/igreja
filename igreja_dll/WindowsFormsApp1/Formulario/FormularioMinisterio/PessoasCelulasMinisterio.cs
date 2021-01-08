using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class PessoasCelulasMinisterio : FormCrudMinisterio
    {
        public PessoasCelulasMinisterio()
        {
            InitializeComponent();
        }
        List<modelocrud> lista;
        List<business.classes.Pessoas.PessoaDado> lista2;


        public PessoasCelulasMinisterio(business.classes.Abstrato.Ministerio p,
            bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }
        
               
        private void PessoasCelulasMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Celulas e pessoas do ministério.";
            lista = new List<modelocrud>();
            lista2 = new List<business.classes.Pessoas.PessoaDado>();
            lista = business.classes.Pessoas.PessoaDado.recuperarTodos();
            foreach (var item in lista)
            lista2.Add((business.classes.Pessoas.PessoaDado)item);
        }

        private void txt_pessoas_TextChanged(object sender, EventArgs e)
        {
            var arr = txt_pessoas.Text.Replace(" ", "").Split(',');

            foreach (var item in arr)
            {
                try
                {
                    int numero = int.Parse(item);
                    var modelo = lista2.FirstOrDefault(i => i.Codigo == numero);
                    AddNaListaMinisterioPessoas += modelo.Id.ToString() + ", ";
                }
                catch { }
            }

            
        }

        private void txt_celulas_TextChanged(object sender, EventArgs e)
        {
            AddNaListaMinisterioCelulas = txt_celulas.Text;
        }
    }
}
