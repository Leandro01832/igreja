﻿using System;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class FrmMinisterio : WFCrud
    {
        public FrmMinisterio(): base()
        {
            InitializeComponent();
        }

        private void FinalizarCadastro_Load(object sender, EventArgs e)
        {
            LoadCrudForm();
            if (CondicaoAtualizar)
            this.Text = "Atualizar ministério.";

            if (CondicaoDeletar)
                this.Text = "Deletar ministério.";

            if (CondicaoDetalhes)
                this.Text = "Detalhes do ministério.";
        }
    }
}
