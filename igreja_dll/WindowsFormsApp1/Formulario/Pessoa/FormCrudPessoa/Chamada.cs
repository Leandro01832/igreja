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
    public partial class Chamada : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public Chamada(business.classes.Abstrato.Pessoa p, bool Deletar, bool Atualizar,  bool Detalhes)
           : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void Chamada_Load(object sender, EventArgs e)
        {

        }
    }
}
