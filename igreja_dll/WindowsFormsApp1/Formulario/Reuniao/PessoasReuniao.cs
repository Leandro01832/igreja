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
using WindowsFormsApp1.Formulario.Pessoa;

namespace WindowsFormsApp1.Formulario.Reuniao
{
    public partial class PessoasReuniao : FormCrudReuniao
    {
        public PessoasReuniao(modelocrud modelo, bool deletar, bool atualizar, bool detalhes)
        : base(modelo, deletar, atualizar, detalhes)
        {
            
            InitializeComponent();
            txt_pessoas.Leave += Txt_pessoas_Leave;
        }

        private void Txt_pessoas_Leave(object sender, EventArgs e)
        {
            AddNaListaReuniaoPessoas = txt_pessoas.Text;
        }

        private void PessoasReuniao_Load(object sender, EventArgs e)
        {
            var p = (business.classes.Reuniao)modelo;

            if(p.IdReuniao == 0)
            {

                if (!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                {
                    var arr = AddNaListaReuniaoPessoas.Replace(" ", "").Split(',');
                    foreach (var item in arr)
                    {
                        if(item != "")
                        {
                            var modelo = business.classes.Abstrato.Pessoa.listaPessoas.First(m => m.Codigo == int.Parse(item));
                            txt_pessoas.Text += modelo.Codigo.ToString() + ", ";
                        }
                        
                    }
                }
                    
            }
            else 
            {
                var reuniao = (business.classes.Reuniao)modelo;
                var pessoas = reuniao.Pessoas;
                if (pessoas != null)
                foreach (var item in pessoas)
                {
                        var pes = business.classes.Abstrato.Pessoa.listaPessoas.First(i => i.IdPessoa == item.PessoaId);
                        txt_pessoas.Text += pes.Codigo + ", ";
                }
                
            }
        }

        private void txt_pessoas_TextChanged(object sender, EventArgs e)
        {
            AddNaListaReuniaoPessoas = "";
            var arr = txt_pessoas.Text.Replace(" ", "").Split(',');

            try { int teste = int.Parse(arr[0]); }
            catch
            {
                AddNaListaReuniaoPessoas = "";
                txt_pessoas.Text = "";
                txt_pessoas.Focus();
                MessageBox.Show("Informe numeros de identificação de pessoas.");
            }

            if (arr[arr.Length - 1] == "")
            foreach (var item in arr)
            {
                try
                {
                    if (item != "")
                    {
                            int teste = int.Parse(item);
                            
                        try
                        {
                                var modelo = business.classes.Abstrato.Pessoa.listaPessoas.First(m => m.Codigo == int.Parse(item));
                                AddNaListaReuniaoPessoas += modelo.IdPessoa.ToString() + ", ";
                        }
                        catch
                        {
                            AddNaListaReuniaoPessoas = "";
                                var numero = GeTotalRegistrosPessoas();
                                if (numero != business.classes.Abstrato.Pessoa.listaPessoas.Count)
                                    MessageBox.Show("Aguarde o processamento.");
                                else
                                    MessageBox.Show("Este registro não existe no banco de dados");
                        }
                    }

                }
                catch
                {
                        txt_pessoas.Text = "";
                        AddNaListaReuniaoPessoas = "";
                        MessageBox.Show("Informe numeros de identificação de pessoas.");
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
    }
}
