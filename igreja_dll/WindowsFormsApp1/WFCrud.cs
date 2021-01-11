﻿using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celula;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoa;
using WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa;
using FinalizarCadastro = WindowsFormsApp1.Formulario.Celula.FinalizarCadastro;

namespace WindowsFormsApp1
{
    public partial class WFCrud : Form
    {
        public WFCrud()
        {
            InitializeComponent();
        }

        private Label InfoForm;

        // botões para crud
        private Button proximo;
        private Button Deletar;
        private Button atualizar;
        private Button finalizarCadastro;


        // botões para select: PESSOA
        private Button dadoPessoal;
        private Button dadoFoto;
        private Button dadoEnderecoPessoa;
        private Button dadoContato;
        private Button dadoClasse;
        private Button dadoMinisteriosPessoa;

        //botões para select: CELULA
        private Button dadoCelula;
        private Button dadoEnderecoCelula;
        private Button dadoCelulaMinisterio;
        private Button dadoCelulaPessoas;

        //botões para select: MINISTERIO
        private Button dadoMinisterio;
        private Button dadoMinisterioPessoas;
        private Button dadoMinistro;

        public modelocrud modelo { get; set; }
        private modelocrud modeloVelho;
        private modelocrud modeloNovo;
        public bool CondicaoDeletar { get => condicaoDeletar; set => condicaoDeletar = value; }
        public bool CondicaoAtualizar { get => condicaoAtualizar; set => condicaoAtualizar = value; }
        public bool CondicaoDetalhes { get => condicaoDetalhes; set => condicaoDetalhes = value; }
        public static string AddNaListaCelulaMinisterios
        { get => addNaListaCelulaMinisterios; set => addNaListaCelulaMinisterios = value; }
        public static string AddNaListaMinisterioPessoas
        { get => addNaListaMinisterioPessoas; set => addNaListaMinisterioPessoas = value; }
        public static string AddNaListaMinisterioCelulas
        { get => addNaListaMinisterioCelulas; set => addNaListaMinisterioCelulas = value; }
        public static string AddNaListaPessoaMinsterios
        { get => addNaListaPessoaMinsterios; set => addNaListaPessoaMinsterios = value; }
        public static string AddNaListaPessoaReunioes
        { get => addNaListaPessoaReunioes; set => addNaListaPessoaReunioes = value; }
        public static string AddNaListaReuniaoPessoas
        { get => addNaListaReuniaoPessoas; set => addNaListaReuniaoPessoas = value; }
        public Button Proximo { get => proximo; set => proximo = value; }
        public Button Atualizar { get => atualizar; set => atualizar = value; }
        public modelocrud ModeloNovo { get => modeloNovo; set => modeloNovo = value; }
        public modelocrud ModeloVelho { get => modeloVelho; set => modeloVelho = value; }
        public Button FinalizarCadastro { get => finalizarCadastro; set => finalizarCadastro = value; }

        private bool condicaoDeletar;
        private bool condicaoAtualizar;
        private bool condicaoDetalhes;
        private static string addNaListaCelulaMinisterios;
        private static string addNaListaMinisterioCelulas;
        private static string addNaListaMinisterioPessoas;
        private static string addNaListaPessoaMinsterios;
        private static string addNaListaPessoaReunioes;
        private static string addNaListaReuniaoPessoas;
        

        public WFCrud(modelocrud modelo, bool deletar, bool atualizar, bool detalhes)
        {
            condicaoDeletar = deletar;
            condicaoAtualizar = atualizar;
            condicaoDetalhes = detalhes;

            this.modelo = modelo;
            InfoForm = new Label();
            InfoForm.Location = new System.Drawing.Point(10, 10);
            InfoForm.Width = 1200;
            InfoForm.Font = new Font("Arial", 12);

            dadoPessoal = new Button();
            dadoPessoal.Location = new System.Drawing.Point(50, 50);
            dadoPessoal.Size = new System.Drawing.Size(100, 50);
            dadoPessoal.Text = "Dados Pessoais";
            dadoPessoal.Click += DadoPessoal_Click;
            dadoPessoal.Visible = false;

            dadoEnderecoPessoa = new Button();
            dadoEnderecoPessoa.Location = new System.Drawing.Point(200, 50);
            dadoEnderecoPessoa.Size = new System.Drawing.Size(100, 50);
            dadoEnderecoPessoa.Text = "Endereço da pessoa";
            dadoEnderecoPessoa.Click += DadoEnderecoPessoa_Click;
            dadoEnderecoPessoa.Visible = false;

            dadoContato = new Button();
            dadoContato.Location = new System.Drawing.Point(200, 160);
            dadoContato.Size = new System.Drawing.Size(100, 50);
            dadoContato.Text = "Contatos";
            dadoContato.Click += DadoContato_Click;
            dadoContato.Visible = false;

            dadoClasse = new Button();
            dadoClasse.Location = new System.Drawing.Point(50, 160);
            dadoClasse.Size = new System.Drawing.Size(100, 50);
            dadoClasse.Text = "Dados de classe";
            dadoClasse.Click += DadoClasse_Click;
            dadoClasse.Visible = false;

            dadoMinisteriosPessoa = new Button();
            dadoMinisteriosPessoa.Location = new System.Drawing.Point(50, 270);
            dadoMinisteriosPessoa.Size = new System.Drawing.Size(100, 50);
            dadoMinisteriosPessoa.Text = "Ministerios da pessoa";
            dadoMinisteriosPessoa.Click += DadoMinisterioPessoas_Click1;
            dadoMinisteriosPessoa.Visible = false;

            dadoFoto = new Button();
            dadoFoto.Location = new System.Drawing.Point(200, 270);
            dadoFoto.Size = new System.Drawing.Size(100, 50);
            dadoFoto.Text = "Foto da pessoa";
            dadoFoto.Click += DadoFoto_Click;
            dadoFoto.Visible = false;

            dadoCelula = new Button();
            dadoCelula.Location = new System.Drawing.Point(50, 50);
            dadoCelula.Size = new System.Drawing.Size(100, 50);
            dadoCelula.Text = "Dados de celula";
            dadoCelula.Click += DadoCelula_Click;
            dadoCelula.Visible = false;

            dadoEnderecoCelula = new Button();
            dadoEnderecoCelula.Location = new System.Drawing.Point(200, 50);
            dadoEnderecoCelula.Size = new System.Drawing.Size(100, 50);
            dadoEnderecoCelula.Text = "Endereço da celula";
            dadoEnderecoCelula.Click += DadoEnderecoCelula_Click;
            dadoEnderecoCelula.Visible = false;

            dadoCelulaMinisterio = new Button();
            dadoCelulaMinisterio.Location = new System.Drawing.Point(200, 160);
            dadoCelulaMinisterio.Size = new System.Drawing.Size(100, 50);
            dadoCelulaMinisterio.Text = "Ministérios da celula";
            dadoCelulaMinisterio.Click += DadoCelulaMinisterio_Click;
            dadoCelulaMinisterio.Visible = false;

            dadoCelulaPessoas = new Button();
            dadoCelulaPessoas.Location = new System.Drawing.Point(50, 160);
            dadoCelulaPessoas.Size = new System.Drawing.Size(100, 50);
            dadoCelulaPessoas.Text = "Pessoas da celula";
            dadoCelulaPessoas.Click += DadoCelulaPessoas_Click;
            dadoCelulaPessoas.Visible = false;

            dadoMinisterio = new Button();
            dadoMinisterio.Location = new System.Drawing.Point(50, 50);
            dadoMinisterio.Size = new System.Drawing.Size(100, 50);
            dadoMinisterio.Text = "Dados do Ministério";
            dadoMinisterio.Click += DadoMinisterio_Click;
            dadoMinisterio.Visible = false;

            dadoMinisterioPessoas = new Button();
            dadoMinisterioPessoas.Location = new System.Drawing.Point(200, 50);
            dadoMinisterioPessoas.Size = new System.Drawing.Size(100, 50);
            dadoMinisterioPessoas.Text = "Pessoas do ministério";
            dadoMinisterioPessoas.Click += DadoMinisterioPessoas_Click;
            dadoMinisterioPessoas.Visible = false;

            dadoMinistro = new Button();
            dadoMinistro.Location = new System.Drawing.Point(200, 160);
            dadoMinistro.Size = new System.Drawing.Size(100, 50);
            dadoMinistro.Text = "Ministro do ministério";
            dadoMinistro.Click += DadoMinistro_Click;
            dadoMinistro.Visible = false;

            Proximo = new Button();
            Proximo.Click += Proximo_Click;
            Proximo.Text = "Proximo";
            Proximo.Location = new Point(650, 150);
            Proximo.Size = new System.Drawing.Size(100, 50);

            Deletar = new Button();
            Deletar.Click += Deletar_Click;
            Deletar.Text = "Deletar";
            Deletar.Location = new Point(650, 250);
            Deletar.Size = new System.Drawing.Size(100, 50);
            Deletar.Visible = false;

            Atualizar = new Button();
            Atualizar.Click += Atualizar_Click;
            Atualizar.Text = "Atualizar";
            Atualizar.Location = new Point(650, 350);
            Atualizar.Size = new System.Drawing.Size(100, 50);
            Atualizar.Visible = false;

            FinalizarCadastro = new Button();
            FinalizarCadastro.Click += FinalizarCadastro_Click;
            FinalizarCadastro.Text = "Finalizar Cadastro";
            FinalizarCadastro.Location = new Point(650, 250);
            FinalizarCadastro.Size = new System.Drawing.Size(100, 50);
            FinalizarCadastro.Visible = false;

            this.Controls.Add(Proximo);
            this.Controls.Add(Deletar);
            this.Controls.Add(Atualizar);
            this.Controls.Add(FinalizarCadastro);

            this.Controls.Add(dadoPessoal);
            this.Controls.Add(dadoEnderecoPessoa);
            this.Controls.Add(dadoClasse);
            this.Controls.Add(dadoContato);
            this.Controls.Add(dadoMinisteriosPessoa);
            this.Controls.Add(dadoFoto);


            this.Controls.Add(dadoCelula);
            this.Controls.Add(dadoEnderecoCelula);
            this.Controls.Add(dadoCelulaMinisterio);
            this.Controls.Add(dadoCelulaPessoas);

            this.Controls.Add(dadoMinisterio);
            this.Controls.Add(dadoMinisterioPessoas);
            this.Controls.Add(dadoMinistro);

            InfoForm.Visible = false;
            this.Controls.Add(InfoForm);

            if (condicaoAtualizar || condicaoDeletar || condicaoDetalhes)
            {
                InfoForm.Visible = true;
                Proximo.Visible = false;
                FinalizarCadastro.Visible = false;

                if (modelo is PessoaDado)
                {
                    var pessoa = (PessoaDado)modelo;
                    InfoForm.Text = "Identificação: " + pessoa.Codigo.ToString() + " - " + pessoa.Nome;
                }
                else
                if (modelo is PessoaLgpd)
                {
                    var pessoa = (PessoaLgpd)modelo;
                    InfoForm.Text = "Identificação: " + pessoa.Codigo.ToString() + " - " + pessoa.Email;
                }
                else
                if (modelo is Celula)
                {
                    var celula = (Celula)modelo;
                    InfoForm.Text = "Identificação: " + celula.Id.ToString() + " - " + celula.Nome;
                }
                else if (modelo is Ministerio)
                {
                    var m = (Ministerio)modelo;
                    InfoForm.Text = "Identificação: " + m.Id.ToString() + " - " + m.Nome;
                }
                else
                {
                    InfoForm.Text = "Identificação: " + modelo.Id.ToString() + " - ";
                }

            }            

            if (modelo is Pessoa && this is FinalizarCadastroPessoa)
            {
                dadoPessoal.Visible = true;                
                dadoClasse.Visible = true;
                dadoMinisteriosPessoa.Visible = true;
                dadoFoto.Visible = true;
                if (modelo is PessoaDado)
                {
                    dadoEnderecoPessoa.Visible = true;
                    dadoContato.Visible = true;
                }
            }

            if (modelo is Ministerio && this is FinalizarCadastroMinisterio)
            {
                dadoMinisterio.Visible = true;
                dadoMinisterioPessoas.Visible = true;
                dadoMinistro.Visible = true;
            }

            if (modelo is Celula && this is FinalizarCadastro)
            {
                dadoCelula.Visible = true;
                dadoEnderecoCelula.Visible = true;
                dadoCelulaMinisterio.Visible = true;
                dadoCelulaPessoas.Visible = true;
            }
            
            if(!condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes)
                Proximo.Visible = true;

            if (!condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes && this is FinalizarCadastro ||
                !condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes && this is FinalizarCadastroMinisterio ||
                !condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes && this is FinalizarCadastroPessoa)
            {
                Proximo.Visible = false;
                FinalizarCadastro.Visible = true;
            }                

            if (this is FinalizarCadastro && condicaoAtualizar ||
                this is FinalizarCadastroMinisterio && condicaoAtualizar ||
                this is FinalizarCadastroPessoa && condicaoAtualizar)
                Atualizar.Visible = true;


            if (this is FinalizarCadastro && condicaoDeletar ||
                this is FinalizarCadastroMinisterio && condicaoDeletar ||
                this is FinalizarCadastroPessoa && condicaoDeletar)
                Deletar.Visible = true;
        }

        public WFCrud(modelocrud modelo, modelocrud modeloNovo)
        {
            this.ModeloVelho = modelo;
            this.ModeloNovo = modeloNovo;
        }

        public WFCrud(bool deletar, bool atualizar, bool detalhes,  modelocrud modelo, modelocrud modeloNovo)
        {
            this.ModeloVelho = modelo;
            this.ModeloNovo = modeloNovo;
            condicaoDeletar = deletar;
            condicaoAtualizar = atualizar;
            condicaoDetalhes = detalhes;


        }

        private void WFCrud_Load(object sender, EventArgs e)
        {

        }

        

        private void DadoCelula_Click(object sender, EventArgs e)
        {
            DadoCelula dc = new DadoCelula((Celula)modelo, condicaoDeletar,
            condicaoAtualizar, condicaoDetalhes);
            dc.MdiParent = this.MdiParent;
            dc.Show();
        }

        private void DadoEnderecoCelula_Click(object sender, EventArgs e)
        {
            EnderecoCelula dc = new EnderecoCelula((Celula)modelo, condicaoDeletar,
            condicaoAtualizar, condicaoDetalhes);
            dc.MdiParent = this.MdiParent;
            dc.Show();
        }

        private void DadoCelulaMinisterio_Click(object sender, EventArgs e)
        {
            MinisteriosCelula mt = new MinisteriosCelula((Celula)modelo,
            condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            mt.MdiParent = this.MdiParent;
            mt.Show();
        }

        private void DadoCelulaPessoas_Click(object sender, EventArgs e)
        {
            MinisteriosCelula mt = new MinisteriosCelula((Celula)modelo,
            condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            mt.MdiParent = this.MdiParent;
            mt.Show();
        }

        private void DadoMinisterio_Click(object sender, EventArgs e)
        {
            DadoMinisterio pcm = new DadoMinisterio((Ministerio)modelo
            , condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            pcm.MdiParent = this.MdiParent;
            pcm.Show();
        }

        private void DadoMinisterioPessoas_Click(object sender, EventArgs e)
        {
            PessoasCelulasMinisterio pcm = new PessoasCelulasMinisterio((Ministerio)modelo
            , condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            pcm.MdiParent = this.MdiParent;
            pcm.Show();
        }

        private void DadoMinistro_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DadoMinisterioPessoas_Click1(object sender, EventArgs e)
        {
            ReunioesMinisteriosPessoa rmp = new ReunioesMinisteriosPessoa((Pessoa)modelo
            , condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            rmp.MdiParent = this.MdiParent;
            rmp.Show();


        }

        private void DadoContato_Click(object sender, EventArgs e)
        {
            Contato dp = new Contato((PessoaDado)modelo,
            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }

        private void DadoEnderecoPessoa_Click(object sender, EventArgs e)
        {
            Endereco dp = new Endereco((PessoaDado)modelo,
            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }

        private void DadoPessoal_Click(object sender, EventArgs e)
        {
            if (modelo is PessoaDado)
            {
                DadoPessoal dp = new DadoPessoal((PessoaDado)modelo,
                condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }
            if (modelo is PessoaLgpd)
            {
                DadoPessoalLgpd dp = new DadoPessoalLgpd((PessoaLgpd)modelo,
               condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

        }

        private void FinalizarCadastro_Click(object sender, EventArgs e)
        {
            FinalizarCadastro.Enabled = false;
            if (modelo is Celula)
            {
                var p = (Celula)modelo;
                if (!string.IsNullOrEmpty(AddNaListaCelulaMinisterios))
                {
                    var listaMinisterio = Ministerio.recuperarTodosMinisterios();
                    var arr = AddNaListaCelulaMinisterios.Replace(" ", "").Split(',');
                    foreach (var item in arr)
                    {
                        try
                        {
                            if (listaMinisterio.FirstOrDefault(i => i.Id == int.Parse(item)) == null)
                                AddNaListaCelulaMinisterios.Replace(item, "");
                        }
                        catch { }
                    }
                    p.AdicionarNaLista("MinisterioCelula", "Celula", "Ministerio", AddNaListaCelulaMinisterios);
                }
            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                    p.AdicionarNaLista("PessoaMinisterio", "Ministerio", "Pessoa", AddNaListaMinisterioPessoas);

                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                    p.AdicionarNaLista("MinisterioCelula", "Ministerio", "Celula", AddNaListaMinisterioCelulas);
            }

            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                if (!string.IsNullOrEmpty(AddNaListaPessoaMinsterios))
                    p.AdicionarNaLista("PessoaMinisterio", "Pessoa", "Ministerio", AddNaListaPessoaMinsterios);

                if (!string.IsNullOrEmpty(AddNaListaPessoaReunioes))
                    p.AdicionarNaLista("ReuniaoPessoa", "Pessoa", "Reuniao", AddNaListaPessoaReunioes);

            }

            if (modelo is business.classes.Reuniao)
            {
                var p = (business.classes.Reuniao)modelo;
                if (!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                    p.AdicionarNaLista("ReuniaoPessoa", "Reuniao", "Pessoa", AddNaListaReuniaoPessoas);

            }

            modelo.salvar();

            MessageBox.Show("Cadastro realiado com sucesso.");
            this.Close();
        }
    }
}
