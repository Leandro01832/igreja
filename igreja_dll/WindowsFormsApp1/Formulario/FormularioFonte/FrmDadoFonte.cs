﻿using business.classes.Esboco;
using business.classes.Esboco.Abstrato;
using database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    public partial class FrmDadoFonte : WFCrud
    {
        public FrmDadoFonte() : base()
        {
            InitializeComponent();
        }

        private void FrmDadoFonte_Load(object sender, EventArgs e)
        {
            lstBoxMensagem.DataSource = modelocrud.Modelos.OfType<Mensagem>()
                .OrderBy(m => m.Id).ToList();

            if (modelocrud.Modelos.OfType<Mensagem>().ToList().Count > 0)
                lstBoxMensagem.SetSelected(0, false);


            var fonte = (Fonte)modelo;
            try { var indice = lstBoxMensagem.Items.IndexOf(fonte.Mensagem);
            lstBoxMensagem.SetSelected(indice, true);
            } catch (Exception ex){ MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }

        }

        private void lstBoxMensagem_SelectedValueChanged(object sender, EventArgs e)
        {
            var fonte = (Fonte)modelo;
            var mensagem = (Mensagem)lstBoxMensagem.SelectedItem;
            if (mensagem != null)
            {
                fonte.MensagemId = mensagem.Id;
                fonte.Mensagem = mensagem;
            }
        }
    }
}
