﻿using System;

namespace WindowsFormsApp1.Formulario.Celulas
{
    public partial class FrmCelula : WFCrud
    {
        public FrmCelula(): base()
        {
            InitializeComponent();
        }

        private void FinalizarCadastro_Load(object sender, EventArgs e)
        {
            if (CondicaoDeletar)
            this.Text += " - Deletar celula.";

            if(CondicaoAtualizar)
                this.Text += " - Atualizar celula.";

            if (CondicaoDetalhes)
                this.Text += " - Detalhes de celula.";
        }
    }
}
