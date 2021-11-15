﻿using business.classes.Abstrato;
using business.classes.Intermediario;
using database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class PessoasCelulasMinisterio  :  WFCrud
    {
        public PessoasCelulasMinisterio() : base()
        {
            InitializeComponent();

        }

        // variavel para evitar bug
        bool condicao = false;

        private void PessoasCelulasMinisterio_Load(object sender, EventArgs e)
        {
            LoadCrudForm();

            this.Text = " - Celulas e pessoas do ministério.";

            this.Proximo.Location = new Point(600, 150);
            this.Atualizar.Location = new Point(600, 250);
            this.Deletar.Location = new Point(600, 350);

            lstBoxCelula.DataSource = modelocrud.Modelos.OfType<Celula>().OrderBy(m => m.Id).ToList();
            if (modelocrud.Modelos.OfType<Celula>().ToList().Count > 0) lstBoxCelula.SetSelected(0, false);
            lstBoxPessoa.DataSource = modelocrud.Modelos.OfType<Pessoa>().OrderBy(m => m.Id).ToList();
            if (modelocrud.Modelos.OfType<Pessoa>().ToList().Count > 0) lstBoxPessoa.SetSelected(0, false);

            var ministerio = (Ministerio)modelo;

            try
            {
                foreach (var item in ministerio.Pessoas)
                {
                    var indice = lstBoxPessoa.Items.IndexOf(item.Pessoa);
                    lstBoxPessoa.SetSelected(indice, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
            }

            try
            {
                foreach (var item in ministerio.Celulas)
                {
                    var indice = lstBoxCelula.Items.IndexOf(item.Celula);
                    lstBoxCelula.SetSelected(indice, true);
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
            var ministerio = (Ministerio)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxPessoa.SelectedItems;
                    var objetos = valor.Cast<Pessoa>().ToList();
                    ministerio.Pessoas = new List<PessoaMinisterio>();
                    foreach (var item in objetos)
                        ministerio.Pessoas.Add(new PessoaMinisterio { PessoaId = item.Id, Pessoa = item });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }

        private void lstBoxCelula_SelectedValueChanged(object sender, EventArgs e)
        {
            var ministerio = (Ministerio)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxPessoa.SelectedItems;
                    var objetos = valor.Cast<Celula>().ToList();
                    ministerio.Celulas = new List<MinisterioCelula>();
                    foreach (var item in objetos)
                        ministerio.Celulas.Add(new MinisterioCelula { CelulaId = item.Id, Celula = item });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }
    }
}
