﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFIgrejaLgpd.Formulario.Pessoa.FormCrudPessoa
{
    public partial class ReunioesMinisteriosPessoa : WFIgrejaLgpd.Formulario.FormCrudPessoa
    {
        public ReunioesMinisteriosPessoa()
        {
            InitializeComponent();
        }

        public ReunioesMinisteriosPessoa(business.classes.Pessoas.PessoaLgpd p, bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void ReunioesMinisteriosPessoa_Load(object sender, EventArgs e)
        {
            this.Text = "Reuniões e ministérios da pessoa.";
        }

        private void txt_reunioes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var arr = txt_reunioes.Text.Replace(" ", "").Split(',');
                foreach (var valor in arr)
                {
                    int v = int.Parse(valor);
                }
                AddNaListaPessoaReunioes = txt_reunioes.Text;
            }
            catch (Exception)
            {
                txt_reunioes.Text = "";
                MessageBox.Show("Informe numeros de identificação de reuniões.");
            }
        }

        private void txt_ministerios_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var arr = txt_ministerios.Text.Replace(" ", "").Split(',');
                foreach (var valor in arr)
                {
                    int v = int.Parse(valor);
                }
                AddNaListaPessoaMinsterios = txt_ministerios.Text;
            }
            catch (Exception)
            {
                txt_ministerios.Text = "";
                MessageBox.Show("Informe numeros de identificação de ministerios.");
            }
        }

        private void txt_celula_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var p = (business.classes.Pessoas.PessoaLgpd)modelo;
                p.celula_ = int.Parse(txt_celula.Text);
            }
            catch (Exception)
            {
                txt_celula.Text = "";
                MessageBox.Show("Informe um numero de identificação de celula.");
            }
        }
    }
}
