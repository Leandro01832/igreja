﻿using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Reuniao
{
    public partial class PessoasReuniao : FormCrudReuniao
    {
        public PessoasReuniao(modelocrud modelo, bool deletar, bool atualizar, bool detalhes)
        : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        List<business.classes.Abstrato.Pessoa> lista;

        private void PessoasReuniao_Load(object sender, EventArgs e)
        {
            lista = new List<business.classes.Abstrato.Pessoa>();
            lista = business.classes.Abstrato.Pessoa.recuperarTodos()
            .OfType<business.classes.Abstrato.Pessoa>().ToList();

            if(modelo.Id == 0)
            {
                var arr = AddNaListaReuniaoPessoas.Replace(" ", "").Split(',');
                if(!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                    foreach(var item in arr)
                    {
                        var modelo = lista.First(m => m.Id == int.Parse(item));
                        txt_pessoas.Text += modelo.Codigo.ToString() + ", ";
                    }
            }
            else if (modelo != null)
            {
                var reuniao = (business.classes.Reuniao)modelo;
                var pessoas = reuniao.Pessoas;
                if (pessoas != null)
                foreach (var item in pessoas)
                txt_pessoas.Text += item.Codigo + ", ";
            }
        }

        private void txt_pessoas_TextChanged(object sender, EventArgs e)
        {            
        }

        private void txt_pessoas_Leave(object sender, EventArgs e)
        {
            AddNaListaReuniaoPessoas = "";
            var arr = txt_pessoas.Text.Replace(" ", "").Split(',');

            foreach (var item in arr)
            {
                try
                {
                    if (item != "")
                    {
                        var modelo = lista.FirstOrDefault(m => m.Codigo == int.Parse(item));
                        try
                        {
                            AddNaListaReuniaoPessoas += modelo.Id.ToString() + ", ";
                        }
                        catch
                        {
                            AddNaListaReuniaoPessoas = "";
                            txt_pessoas.Text = "";
                            MessageBox.Show("Este formulario não esta atualizado." +
                            " Para atualizar feche e abra novamente o formulario.");
                        }
                    }

                }
                catch {
                    AddNaListaReuniaoPessoas = "";
                    txt_pessoas.Text = "";
                    MessageBox.Show("Informe numeros de identificação de pessoas."); }
            }
        }
    }
}