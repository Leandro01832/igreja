﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Celula
{
    public partial class MinisteriosCelula : FormularioCrudCelula
    {
        public MinisteriosCelula()
        {
            InitializeComponent();
        }

        public MinisteriosCelula(business.classes.Abstrato.Celula p,
            bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
            txt_ministerio.Leave += Txt_ministerio_Leave;
        }

        private void Txt_ministerio_Leave(object sender, EventArgs e)
        {
            AddNaListaCelulaMinisterios = txt_ministerio.Text;
        }

        private void MinisteriosCelula_Load(object sender, EventArgs e)
        {
            this.Text = " - Ministérios da celula";

            var c = (business.classes.Abstrato.Celula)modelo;
            if (c.IdCelula == 0)
            {
                txt_ministerio.Text = AddNaListaCelulaMinisterios;
            }
            else
            {
                var lista = c.buscarLista(new business.classes.Pessoas.Crianca(), c, "celula_", c.IdCelula);
                if (lista != null) lbl_pessoas.Text = "Pessoas: ";
                foreach (var numero in lista)
                {
                    lbl_pessoas.Text += numero.ToString() + ", ";
                }

                var minis = c.Ministerios;
                foreach (var item in minis)
                {
                    var m = listaMinisterios.First(i => i.IdMinisterio == item.MinisterioId);
                    txt_ministerio.Text += m.IdMinisterio.ToString() + ", ";
                }
            }

        }

        private void txt_ministerio_TextChanged(object sender, EventArgs e)
        {
            AddNaListaCelulaMinisterios = "";
            var arr = txt_ministerio.Text.Replace(" ", "").Split(',');

            try { int teste = int.Parse(arr[0]); }
            catch
            {
                AddNaListaCelulaMinisterios = "";
                txt_ministerio.Text = "";
                txt_ministerio.Focus();
                MessageBox.Show("Informe numeros de identificação de ministérios.");
            }

            if (arr[arr.Length - 1] == "")
                foreach (var item in arr)
                {
                    try
                    {
                        if (item != "")
                        {
                            int numero = int.Parse(item);
                            try
                            {
                                var modelo = listaMinisterios.FirstOrDefault(i => i.IdMinisterio == numero);
                                AddNaListaCelulaMinisterios += modelo.IdMinisterio.ToString() + ", ";
                            }
                            catch
                            {
                                AddNaListaCelulaMinisterios = "";
                                var num = GeTotalRegistrosMinisterios();
                                if (num != listaMinisterios.Count)
                                    MessageBox.Show("Aguarde o processamento.");
                                else
                                    MessageBox.Show("Este registro não existe no banco de dados");
                            }
                        }
                    }
                    catch
                    {
                        if (item != "")
                        {
                            AddNaListaCelulaMinisterios = "";
                            txt_ministerio.Text = "";
                            txt_ministerio.Focus();
                            MessageBox.Show("Informe numeros de identificação de ministérios.");
                        }
                    }
                }
        }

    }
}
