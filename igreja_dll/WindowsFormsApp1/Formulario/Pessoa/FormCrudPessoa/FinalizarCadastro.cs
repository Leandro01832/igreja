﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class FinalizarCadastro : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public FinalizarCadastro(business.classes.Abstrato.Pessoa p,
            bool Deletar, bool Atualizar,  bool Detalhes)
            :base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        public business.classes.Abstrato.Pessoa P { get; }

        

        private void FinalizarCadastro_Load(object sender, EventArgs e)
        {
            if(CondicaoAtualizar)
            this.Text = "Atualizar dados de pessoa.";

            if (CondicaoDeletar)
                this.Text = "Deletar dados de pessoa.";

            if (CondicaoDetalhes)
                this.Text = "Detalhes de pessoa.";
        }
    }
}