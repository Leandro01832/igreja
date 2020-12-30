using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFIgrejaLgpd.ListViews;

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class Pessoa : Form
    {
        ListView Pessoas;
        public Button botaoDetalhes;
        public Button botaoExcluir;
        public Button botaoAtualizar;

        public modelocrud Modelo { get; set; }

        public Pessoa() 
        {     
            Pessoas = new ListView();
            Pessoas.View = View.List;
            Pessoas.ItemSelectionChanged += Pessoas_ItemSelectionChanged;
            Pessoas.Size = new System.Drawing.Size(500, 300);
            Pessoas.Location = new System.Drawing.Point(50, 50);
            Pessoas.Font = new System.Drawing.Font("Arial", 15);
            

            botaoExcluir = new Button();
            botaoExcluir.Location = new System.Drawing.Point(570, 120);
            botaoExcluir.Size = new System.Drawing.Size(100, 50);
            botaoExcluir.Text = "Excluir";
            botaoExcluir.Click += botaoExcluir_Click;
            botaoExcluir.Dock = DockStyle.Right;

            botaoAtualizar = new Button();
            botaoAtualizar.Location = new System.Drawing.Point(570, 200);
            botaoAtualizar.Size = new System.Drawing.Size(100, 50);
            botaoAtualizar.Text = "Atualizar";
            botaoAtualizar.Click += botaoAtualizar_Click;
            botaoAtualizar.Dock = DockStyle.Right;

            botaoDetalhes = new Button();
            botaoDetalhes.Location = new System.Drawing.Point(570, 280);
            botaoDetalhes.Size = new System.Drawing.Size(100, 50);
            botaoDetalhes.Text = "Detalhes";
            botaoDetalhes.Click += BotaoDetalhes_Click;
            botaoDetalhes.Dock = DockStyle.Right;

            Controls.Add(Pessoas);
            Controls.Add(botaoExcluir);
            Controls.Add(botaoAtualizar);
            Controls.Add(botaoDetalhes);

            InitializeComponent();
        }

        private void Pessoas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                Pessoas.Text = Pessoas.SelectedItems[0].Text;
            }
            catch (Exception)
            {
            }
        }

        private async void BotaoDetalhes_Click(object sender, EventArgs e)
        {
            var numero = Regex.Match(Pessoas.Text, @"\d+").Value;

            Modelo = await Task.Run(() => business.classes.Abstrato.PessoaLgpd.recuperarPessoa(int.Parse(numero)));
            VerificarModelo();

            FinalizarCadastro fc = new FinalizarCadastro((business.classes.Abstrato.PessoaLgpd)Modelo
            , false, false, true);
            fc.MdiParent = this.MdiParent;
            fc.Show();
        }

        private void VerificarModelo()
        {
            if (Modelo is business.classes.PessoasLgpd.VisitanteLgpd)
                Modelo =
                new business.classes.PessoasLgpd.VisitanteLgpd(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.PessoasLgpd.CriancaLgpd)
                Modelo =
                new business.classes.PessoasLgpd.CriancaLgpd(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.PessoasLgpd.Membro_AclamacaoLgpd)
                Modelo =
                new business.classes.PessoasLgpd.Membro_AclamacaoLgpd(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.PessoasLgpd.Membro_BatismoLgpd)
                Modelo =
                new business.classes.PessoasLgpd.Membro_BatismoLgpd(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.PessoasLgpd.Membro_ReconciliacaoLgpd)
                Modelo =
                new business.classes.PessoasLgpd.Membro_ReconciliacaoLgpd(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.PessoasLgpd.Membro_TransferenciaLgpd)
                Modelo =
                new business.classes.PessoasLgpd.Membro_TransferenciaLgpd(Modelo.Id, true).recuperar(Modelo.Id)[0];
        }

        private async void botaoAtualizar_Click(object sender, EventArgs e)
        {
            var numero = Regex.Match(Pessoas.Text, @"\d+").Value;
            
            Modelo = await Task.Run(() => business.classes.Abstrato.Pessoa.recuperarPessoa(int.Parse(numero)));
            VerificarModelo();

            FinalizarCadastro fc = new FinalizarCadastro((business.classes.Abstrato.PessoaLgpd)Modelo
            , false, true, false);
            fc.MdiParent = this.MdiParent;
            fc.Show();   
        }
        
        private async void botaoExcluir_Click(object sender, EventArgs e)
        {
            var numero = Regex.Match(Pessoas.Text, @"\d+").Value;
            
            Modelo = await Task.Run(() => business.classes.Abstrato.PessoaLgpd.recuperarPessoa(int.Parse(numero)));
            VerificarModelo();

            FinalizarCadastro fc = new FinalizarCadastro((business.classes.Abstrato.PessoaLgpd)Modelo
            , true, false, false);
            fc.MdiParent = this.MdiParent;
            fc.Show();
            
        }
        
        private async void Pessoa_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de pessoas";
            Pessoas.Dock = DockStyle.Left;

            List<modelocrud> lista = await Task.Run(() => business.classes.Abstrato.PessoaLgpd.recuperarTodos());

            foreach (var item in lista)
            {
                business.classes.Abstrato.PessoaLgpd p = (business.classes.Abstrato.PessoaLgpd)item;
                Pessoas.Items.Add(p.Id.ToString() + " - " + p.Email);
            }
        }
    }
}
