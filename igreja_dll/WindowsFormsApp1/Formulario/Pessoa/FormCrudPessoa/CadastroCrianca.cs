using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class CadastroCrianca : WindowsFormsApp1.Formulario.FormCrudPessoa
    {

        public CadastroCrianca(PessoaDado p, bool Atualizar, bool Deletar, bool Detalhes)            
            : base(p, Atualizar, Deletar, Detalhes)
        {
            InitializeComponent();
        }

        public CadastroCrianca(PessoaLgpd p, bool Atualizar, bool Deletar, bool Detalhes)            
            : base(p, Atualizar, Deletar, Detalhes)
        {
            InitializeComponent();
        }

        public CadastroCrianca(modelocrud modelo, modelocrud modeloNovo)
            : base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        public business.classes.Pessoas.PessoaDado P { get; }        

        private void Proximo_Click(object sender, EventArgs e)
        {

        }

        private void CadastroCrianca_Load_1(object sender, EventArgs e)
        {
            this.Text = "Cadastro de Criança.";
            if (modelo != null)
            {
                if(modelo is Crianca)
                {
                    var p = (Crianca)modelo;
                    textBox1.Text = p.Nome_pai;
                    textBox2.Text = p.Nome_mae;
                }

                if (modelo is CriancaLgpd)
                {
                    var p = (CriancaLgpd)modelo;
                    textBox1.Text = p.Nome_pai;
                    textBox2.Text = p.Nome_mae;
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                if (modelo is Crianca)
                {
                    var p = (Crianca)modelo;
                    p.Nome_mae = textBox2.Text;
                }
                if (modelo is CriancaLgpd)
                {
                    var p = (CriancaLgpd)modelo;
                    p.Nome_mae = textBox2.Text;
                }
            }

            if (ModeloNovo != null)
            {
                if (ModeloNovo is Crianca)
                {
                    var p = (Crianca)ModeloNovo;
                    p.Nome_mae = textBox2.Text;
                }
                if (ModeloNovo is CriancaLgpd)
                {
                    var p = (CriancaLgpd)ModeloNovo;
                    p.Nome_mae = textBox2.Text;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(modelo is Crianca)
            {
                var p = (Crianca)modelo;
                p.Nome_pai = textBox1.Text;
            }

            if (modelo is CriancaLgpd)
            {
                var p = (CriancaLgpd)modelo;
                p.Nome_pai = textBox1.Text;
            }

        }
    }
}
