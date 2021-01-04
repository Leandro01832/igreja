﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class CadastroMembroTransferencia : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
       

        public CadastroMembroTransferencia(business.classes.Abstrato.Pessoa p,
            bool Deletar, bool Atualizar, bool Detalhes)
            : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        public CadastroMembroTransferencia(modelocrud modelo, modelocrud modeloNovo)
            :base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        

        private void CadastroMembroTransferencia_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por transferência.";
            if(modelo != null)
            if(modelo.Id != 0)
            {
                var p = (business.classes.Pessoas.Membro_Transferencia)modelo;
                txt_nome_igreja.Text = p.Nome_igreja_transferencia;
                txt_nome_estado.Text = p.Estado_transferencia;
                txt_nome_cidade.Text = p.Nome_cidade_transferencia;
            }
            
        }

        private void txt_nome_igreja_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.Membro_Transferencia)modelo;
                p.Nome_igreja_transferencia = txt_nome_igreja.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.Membro_Transferencia)ModeloNovo;
                p.Nome_igreja_transferencia = txt_nome_igreja.Text;
            }

        }

        private void txt_nome_estado_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.Membro_Transferencia)modelo;
                p.Estado_transferencia = txt_nome_estado.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.Membro_Transferencia)ModeloNovo;
                p.Estado_transferencia = txt_nome_estado.Text;
            }
        }

        private void txt_nome_cidade_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.Membro_Transferencia)modelo;
                p.Nome_cidade_transferencia = txt_nome_cidade.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.Membro_Transferencia)ModeloNovo;
                p.Nome_cidade_transferencia = txt_nome_cidade.Text;
            }

        }
    }
}