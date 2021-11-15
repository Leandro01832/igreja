using business.classes.Abstrato;
using business.classes.Intermediario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace WindowsFormsApp1.Formulario.Reuniao
{
    public partial class PessoasReuniao : WFCrud
    {
        public PessoasReuniao() : base()
        {
            InitializeComponent();
        }

        // variavel para evitar bug
        bool condicao = false;

        private void PessoasReuniao_Load(object sender, EventArgs e)
        {
            LoadCrudForm();
            var p = (business.classes.Reuniao)modelo;


            try
            {
                foreach (var item in p.Pessoas)
                {
                    var indice = lstBoxPessoa.Items.IndexOf(item);
                    lstBoxPessoa.SetSelected(indice, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
            }


            condicao = true;
        }



        private void lstBoxPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            var reuniao = (business.classes.Reuniao)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxPessoa.SelectedItems;
                    var objetos = valor.Cast<Pessoa>().ToList();
                    reuniao.Pessoas = new List<ReuniaoPessoa>();
                    foreach (var item in objetos)
                        reuniao.Pessoas.Add(new ReuniaoPessoa { PessoaId = item.Id });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }
    }
}
