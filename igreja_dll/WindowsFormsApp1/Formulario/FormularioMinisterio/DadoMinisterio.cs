﻿using business.classes.Abstrato;
using database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class DadoMinisterio : WFCrud
    {
        public DadoMinisterio()
          : base()
        {
            InitializeComponent();
        }


        private void DadoMinisterio_Load(object sender, EventArgs e)
        {
            LoadCrudForm();

            this.Text = " - Dados de Ministério";


            var p = (Ministerio)modelo;
            try { txt_nome_ministerio.Text = p.Nome; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txt_proposito.Text = p.Proposito; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txt_ministro.Text = p.Ministro_.ToString(); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }

        }

        private void txt_nome_ministerio_TextChanged(object sender, EventArgs e)
        {
            var m = (Ministerio)modelo;
            m.Nome = txt_nome_ministerio.Text;

        }

        private void txt_proposito_TextChanged(object sender, EventArgs e)
        {
            var m = (Ministerio)modelo;
            m.Proposito = txt_proposito.Text;
        }

        private void txt_ministro_TextChanged(object sender, EventArgs e)
        {
            var m = (Ministerio)modelo;
            try
            {
                var modelo = modelocrud.Modelos.OfType<Pessoa>().ToList().FirstOrDefault(i => i.Codigo == int.Parse(txt_ministro.Text));
                if (modelo != null)
                    m.Ministro_ = modelo.Id;
            }
            catch (Exception)
            {
                m.Ministro_ = null;
                txt_ministro.Text = "";
                MessageBox.Show("Informe um numero de indentificação. Apenas numeros.");
            }
        }
    }
}
