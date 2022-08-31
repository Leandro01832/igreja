﻿using business.classes.Abstrato;
using business.classes.Intermediario;
using database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace WindowsFormsApp1.Formulario.Celulas
{
    public partial class FrmMinisterios : WFCrud
    {
        public FrmMinisterios() : base()
        {
            InitializeComponent();
        }

        private void MinisteriosCelula_Load(object sender, EventArgs e)
        {
            this.Text = " - Ministérios da celula";

            lstBoxMinisterio.DataSource = modelocrud.Modelos.OfType<Ministerio>().OrderBy(m => m.Id).ToList();
            if (modelocrud.Modelos.OfType<Ministerio>().ToList().Count > 0) lstBoxMinisterio.SetSelected(0, false);
            lstBoxPessoa.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().OrderBy(m => m.Id).ToList();
            if (modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().Count > 0) lstBoxPessoa.SetSelected(0, false);

            this.Proximo.Location = new Point(600, 150);
            this.Atualizar.Location = new Point(600, 250);
            this.Deletar.Location = new Point(600, 350);

            var c = (Celula)modelo;

            try
            {
                foreach (var item in c.Ministerios)
                {
                    var indice = lstBoxMinisterio.Items.IndexOf(item.Ministerio);
                    lstBoxMinisterio.SetSelected(indice, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
            }

            try
            {
                foreach (var item in c.Pessoas)
                {
                    var indice = lstBoxPessoa.Items.IndexOf(item);
                    lstBoxPessoa.SetSelected(indice, true);
                }
            }
            catch (Exception ex)
            {
                var msg = modelo.exibirMensagemErro(ex, 2);
                if (msg != "")
                    MessageBox.Show(msg);
            }

            condicao = true;
        }

        // variavel para evitar bug
        bool condicao = false;

        private void lstBoxMinisterio_SelectedValueChanged(object sender, EventArgs e)
        {
            var celula = (Celula)modelo;
            try
            {
                if (condicao)
                {
                    var lista = new List<MinisterioCelula>();
                    SelectedObjectCollection valor = lstBoxMinisterio.SelectedItems;
                    var objetos = valor.Cast<Ministerio>().ToList();
                    celula.Ministerios = new List<MinisterioCelula>();
                    foreach (var item in objetos)
                    lista.Add(new MinisterioCelula { MinisterioId = item.Id, Ministerio = item, CelulaId = celula.Id, Celula = celula });
                    
                    PropertyInfo prop = modelo.GetType().GetProperty("Ministerios");
                    prop.SetValue(modelo, lista);
                }

            }
            catch (Exception ex)
            {
                if(ex.HResult == 1)
                MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                
            }
        }

        private void lstBoxPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            var celula = (Celula)modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstBoxPessoa.SelectedItems;
                    var objetos = valor.Cast<business.classes.Abstrato.Pessoa>().ToList();
                    celula.Pessoas = new List<business.classes.Abstrato.Pessoa>();
                    foreach (var item in objetos)
                        celula.Pessoas.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu " + ex.Message);
            }
        }
    }
}