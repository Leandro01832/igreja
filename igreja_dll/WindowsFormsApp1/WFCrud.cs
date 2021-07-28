using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using business.implementacao;
using database;
using database.banco;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas;
using WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public partial class WFCrud : FormPadrao
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

        //botoes para select: Reuniao
        private Button dadoReuniao;
        private Button dadoReuniaoPessoas;




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
        public Button FinalizaCadastro { get => finalizarCadastro; set => finalizarCadastro = value; }

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

            this.FormClosing += WFCrud_FormClosing;

            this.modelo = modelo;
            InfoForm = new Label();
            InfoForm.Location = new Point(10, 10);
            InfoForm.Width = 1200;
            InfoForm.Font = new Font("Arial", 12);

            dadoReuniao = new Button();
            dadoReuniao.Location = new Point(50, 50);
            dadoReuniao.Size = new Size(100, 50);
            dadoReuniao.Text = "Dados da reunião";
            dadoReuniao.Click += DadoReuniao_Click;
            dadoReuniao.Visible = false;

            dadoReuniaoPessoas = new Button();
            dadoReuniaoPessoas.Location = new Point(200, 50);
            dadoReuniaoPessoas.Size = new Size(100, 50);
            dadoReuniaoPessoas.Text = "pessoas da reunião";
            dadoReuniaoPessoas.Click += DadoReuniaoPessoas_Click;
            dadoReuniaoPessoas.Visible = false;

            dadoPessoal = new Button();
            dadoPessoal.Location = new Point(50, 50);
            dadoPessoal.Size = new Size(100, 50);
            dadoPessoal.Text = "Dados Pessoais";
            dadoPessoal.Click += DadoPessoal_Click;
            dadoPessoal.Visible = false;

            dadoEnderecoPessoa = new Button();
            dadoEnderecoPessoa.Location = new Point(200, 50);
            dadoEnderecoPessoa.Size = new Size(100, 50);
            dadoEnderecoPessoa.Text = "Endereço da pessoa";
            dadoEnderecoPessoa.Click += DadoEnderecoPessoa_Click;
            dadoEnderecoPessoa.Visible = false;

            dadoContato = new Button();
            dadoContato.Location = new Point(200, 160);
            dadoContato.Size = new Size(100, 50);
            dadoContato.Text = "Contatos";
            dadoContato.Click += DadoContato_Click;
            dadoContato.Visible = false;

            dadoClasse = new Button();
            dadoClasse.Location = new Point(50, 160);
            dadoClasse.Size = new Size(100, 50);
            dadoClasse.Text = "Dados de classe";
            dadoClasse.Click += DadoClasse_Click;
            dadoClasse.Visible = false;

            dadoMinisteriosPessoa = new Button();
            dadoMinisteriosPessoa.Location = new Point(50, 270);
            dadoMinisteriosPessoa.Size = new Size(100, 50);
            dadoMinisteriosPessoa.Text = "Ministerios da pessoa";
            dadoMinisteriosPessoa.Click += DadoMinisterioPessoas_Click1;
            dadoMinisteriosPessoa.Visible = false;

            dadoFoto = new Button();
            dadoFoto.Location = new Point(200, 270);
            dadoFoto.Size = new Size(100, 50);
            dadoFoto.Text = "Foto da pessoa";
            dadoFoto.Click += DadoFoto_Click;
            dadoFoto.Visible = false;

            dadoCelula = new Button();
            dadoCelula.Location = new Point(50, 50);
            dadoCelula.Size = new Size(100, 50);
            dadoCelula.Text = "Dados de celula";
            dadoCelula.Click += DadoCelula_Click;
            dadoCelula.Visible = false;

            dadoEnderecoCelula = new Button();
            dadoEnderecoCelula.Location = new Point(200, 50);
            dadoEnderecoCelula.Size = new Size(100, 50);
            dadoEnderecoCelula.Text = "Endereço da celula";
            dadoEnderecoCelula.Click += DadoEnderecoCelula_Click;
            dadoEnderecoCelula.Visible = false;

            dadoCelulaMinisterio = new Button();
            dadoCelulaMinisterio.Location = new Point(200, 160);
            dadoCelulaMinisterio.Size = new Size(100, 50);
            dadoCelulaMinisterio.Text = "Ministérios da celula";
            dadoCelulaMinisterio.Click += DadoCelulaMinisterio_Click;
            dadoCelulaMinisterio.Visible = false;

            dadoCelulaPessoas = new Button();
            dadoCelulaPessoas.Location = new Point(50, 160);
            dadoCelulaPessoas.Size = new Size(100, 50);
            dadoCelulaPessoas.Text = "Pessoas da celula";
            dadoCelulaPessoas.Click += DadoCelulaPessoas_Click;
            dadoCelulaPessoas.Visible = false;

            dadoMinisterio = new Button();
            dadoMinisterio.Location = new Point(50, 50);
            dadoMinisterio.Size = new Size(100, 50);
            dadoMinisterio.Text = "Dados do Ministério";
            dadoMinisterio.Click += DadoMinisterio_Click;
            dadoMinisterio.Visible = false;

            dadoMinisterioPessoas = new Button();
            dadoMinisterioPessoas.Location = new Point(200, 50);
            dadoMinisterioPessoas.Size = new Size(100, 50);
            dadoMinisterioPessoas.Text = "Pessoas do ministério";
            dadoMinisterioPessoas.Click += DadoMinisterioPessoas_Click;
            dadoMinisterioPessoas.Visible = false;

            dadoMinistro = new Button();
            dadoMinistro.Location = new Point(200, 160);
            dadoMinistro.Size = new Size(100, 50);
            dadoMinistro.Text = "Ministro do ministério";
            dadoMinistro.Click += DadoMinistro_Click;
            dadoMinistro.Visible = false;

            Proximo = new Button();
            Proximo.Click += Proximo_Click;
            Proximo.Text = "Proximo";
            Proximo.Location = new Point(650, 150);
            Proximo.Size = new Size(100, 50);

            Deletar = new Button();
            Deletar.Click += Deletar_Click;
            Deletar.Text = "Deletar";
            Deletar.Location = new Point(650, 250);
            Deletar.Size = new Size(100, 50);
            Deletar.Visible = false;

            Atualizar = new Button();
            Atualizar.Click += Atualizar_Click;
            Atualizar.Text = "Atualizar";
            Atualizar.Location = new Point(650, 350);
            Atualizar.Size = new Size(100, 50);
            Atualizar.Visible = false;

            FinalizaCadastro = new Button();
            FinalizaCadastro.Click += FinalizarCadastro_Click;
            FinalizaCadastro.Text = "Finalizar Cadastro";
            FinalizaCadastro.Location = new Point(650, 250);
            FinalizaCadastro.Size = new Size(100, 50);
            FinalizaCadastro.Visible = false;

            this.Controls.Add(Proximo);
            this.Controls.Add(Deletar);
            this.Controls.Add(Atualizar);
            this.Controls.Add(FinalizaCadastro);

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

            this.Controls.Add(dadoReuniao);
            this.Controls.Add(dadoReuniaoPessoas);

            InfoForm.Visible = false;
            this.Controls.Add(InfoForm);

            if (condicaoAtualizar || condicaoDeletar || condicaoDetalhes)
            {
                InfoForm.Visible = true;
                Proximo.Visible = false;
                FinalizaCadastro.Visible = false;

                if (modelo is PessoaDado)
                {
                    var pessoa = (PessoaDado)modelo;
                    InfoForm.Text = "Identificação: " + pessoa.Codigo.ToString() +
                    " - " + pessoa.NomePessoa;
                }
                else
                if (modelo is PessoaLgpd)
                {
                    var pessoa = (PessoaLgpd)modelo;
                    InfoForm.Text = "Identificação: " + pessoa.Codigo.ToString() +
                        " - " + pessoa.Email;
                }
                else
                if (modelo is Celula)
                {
                    var celula = (Celula)modelo;
                    InfoForm.Text = "Identificação: " + celula.Id.ToString() +
                    " - " + celula.Nome;
                }
                else if (modelo is Ministerio)
                {
                    var m = (Ministerio)modelo;
                    InfoForm.Text = "Identificação: " + m.Id.ToString() +
                    " - " + m.Nome;
                }
                else if (modelo is Reuniao)
                {
                    var p = (Reuniao)modelo;
                    InfoForm.Text = "Identificação: " + p.Id.ToString() + " - ";
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

            if (modelo is Reuniao && this is FinalizarCadastroReuniao)
            {
                dadoReuniao.Visible = true;
                dadoReuniaoPessoas.Visible = true;
            }

            if (!condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes)
                Proximo.Visible = true;

            if (!condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes &&
                this is FinalizarCadastro ||
                !condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes &&
                this is FinalizarCadastroMinisterio ||
                !condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes &&
                this is FinalizarCadastroPessoa ||
                !condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes &&
                this is FinalizarCadastroReuniao)
            {
                Proximo.Visible = false;
                FinalizaCadastro.Visible = true;
            }

            if (condicaoAtualizar)
                Atualizar.Visible = true;


            if (condicaoDeletar)
                Deletar.Visible = true;

            if (CondicaoDetalhes)
            {
                foreach (var item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        var t = (TextBox)item;
                        t.ReadOnly = true;
                    }
                    if (item is MaskedTextBox)
                    {
                        var t = (MaskedTextBox)item;
                        t.ReadOnly = true;
                    }

                    if (item is Button && !(this is FinalizarCadastroMinisterio) &&
                        !(this is FinalizarCadastroPessoa) && !(this is FinalizarCadastro) &&
                        !(this is FinalizarCadastroReuniao))
                    {
                        var t = (Button)item;
                        t.Enabled = false;
                    }
                }
            }
        }

        private void WFCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool deletar = false;

            if (CondicaoDeletar)
            {
                if (modelo is Pessoa)
                {
                    var p = (Pessoa)modelo;
                    if (modelo.recuperar(p.Id)) deletar = true;
                }
                if(modelo is Ministerio)
                {
                    var p = (Ministerio)modelo;
                    if (modelo.recuperar(p.Id)) deletar = true;
                }
                if (modelo is Celula)
                {
                    var p = (Celula)modelo;
                    if (modelo.recuperar(p.Id)) deletar = true;
                }
                if (modelo is Reuniao)
                {
                    var p = (Reuniao)modelo;
                    if (modelo.recuperar(p.Id)) deletar = true;
                }
            }

            if (condicaoAtualizar || condicaoDetalhes || deletar)
            {
                if (modelo is Pessoa)
                {
                    Pessoa pes = null;
                    var p = (Pessoa)modelo;
                    if (p is Visitante           )     { var model = new  Visitante           ();    if (model.recuperar(p.Id)) pes = model; }
                    if (p is Crianca             )     { var model = new Crianca             ();     if (model.recuperar(p.Id)) pes = model;  }
                    if (p is Membro_Aclamacao    )     { var model = new Membro_Aclamacao    ();     if (model.recuperar(p.Id)) pes = model;  }
                    if (p is Membro_Batismo      )     { var model = new Membro_Batismo      ();     if (model.recuperar(p.Id)) pes = model;  }
                    if (p is Membro_Reconciliacao)     { var model = new Membro_Reconciliacao();     if (model.recuperar(p.Id)) pes = model;  }
                    if (p is Membro_Transferencia)     { var model = new Membro_Transferencia();     if (model.recuperar(p.Id)) pes = model;  }
                    if (p is VisitanteLgpd       )     { var model = new VisitanteLgpd();            if (model.recuperar(p.Id)) pes = model;  }
                    if (p is CriancaLgpd         )     { var model = new CriancaLgpd();              if (model.recuperar(p.Id)) pes = model;  }
                    if (p is Membro_AclamacaoLgpd)     { var model = new Membro_AclamacaoLgpd();     if (model.recuperar(p.Id)) pes = model;  }
                    if (p is Membro_BatismoLgpd  )     { var model = new Membro_BatismoLgpd();       if (model.recuperar(p.Id)) pes = model;  }
                    if (p is Membro_ReconciliacaoLgpd) { var model = new Membro_ReconciliacaoLgpd(); if (model.recuperar(p.Id)) pes = model;  }
                    if (p is Membro_TransferenciaLgpd) { var model = new Membro_TransferenciaLgpd(); if (model.recuperar(p.Id)) pes = model;  }
                        
                    

                    modelocrud.Modelos.OfType<Pessoa>().ToList().Remove(modelocrud.Modelos.OfType<Pessoa>().ToList().First(i => i.Id == p.Id));
                    modelocrud.Modelos.OfType<Pessoa>().ToList().Add(pes);
                }

                if (modelo is Ministerio)
                {
                    Ministerio minis = null;
                    var m = (Ministerio)modelo;
                    if (m is Lider_Celula                     ) { var model = new Lider_Celula                     (); if (model.recuperar(m.Id)) minis = model; }
                    if (m is Lider_Celula_Treinamento         ) { var model = new Lider_Celula_Treinamento         (); if (model.recuperar(m.Id)) minis = model; }
                    if (m is Lider_Ministerio                 ) { var model = new Lider_Ministerio                 (); if (model.recuperar(m.Id)) minis = model; }
                    if (m is Lider_Ministerio_Treinamento     ) { var model = new Lider_Ministerio_Treinamento     (); if (model.recuperar(m.Id)) minis = model; }
                    if (m is Supervisor_Celula                ) { var model = new Supervisor_Celula                (); if (model.recuperar(m.Id)) minis = model; }
                    if (m is Supervisor_Celula_Treinamento    ) { var model = new Supervisor_Celula_Treinamento    (); if (model.recuperar(m.Id)) minis = model; }
                    if (m is Supervisor_Ministerio            ) { var model = new Supervisor_Ministerio            (); if (model.recuperar(m.Id)) minis = model; }
                    if (m is Supervisor_Ministerio_Treinamento) { var model = new Supervisor_Ministerio_Treinamento(); if (model.recuperar(m.Id)) minis = model; }
                                        
                    modelocrud.Modelos.OfType<Ministerio>().ToList().Remove(modelocrud.Modelos.OfType<Ministerio>().ToList().First(i => i.Id == m.Id));
                    modelocrud.Modelos.OfType<Ministerio>().ToList().Add(minis);
                }

                if (modelo is Celula)
                {
                    Celula cel = null;
                    var c = (Celula)modelo;

                    if (c is Celula_Adolescente) { var model = new Celula_Adolescente(); if (model.recuperar(c.Id)) cel = model; }
                    if (c is Celula_Jovem      ) { var model = new Celula_Jovem      (); if (model.recuperar(c.Id)) cel = model; }
                    if (c is Celula_Adulto     ) { var model = new Celula_Adulto     (); if (model.recuperar(c.Id)) cel = model; }
                    if (c is Celula_Casado     ) { var model = new Celula_Casado     (); if (model.recuperar(c.Id)) cel = model; }
                    if (c is Celula_Crianca    ) { var model = new Celula_Crianca();     if (model.recuperar(c.Id)) cel = model; }
                    
                    modelocrud.Modelos.OfType<Celula>().ToList().Remove(modelocrud.Modelos.OfType<Celula>().ToList().First(i => i.Id == c.Id));
                    modelocrud.Modelos.OfType<Celula>().ToList().Add(cel);
                }

                if (modelo is Reuniao)
                {
                    Reuniao reu = null;
                    var r = (Reuniao)modelo;
                    var model = new Reuniao(); if (model.recuperar(r.Id)) reu = model;
                    modelocrud.Modelos.OfType<Reuniao>().ToList().Remove(r);
                    modelocrud.Modelos.OfType<Reuniao>().ToList().Add(reu);
                }
            }

            this.Dispose();
        }

        private void DadoReuniao_Click(object sender, EventArgs e)
        {
            DadoReuniao frm = new DadoReuniao(modelo, CondicaoDeletar, CondicaoAtualizar, CondicaoDetalhes);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void DadoReuniaoPessoas_Click(object sender, EventArgs e)
        {
            PessoasReuniao frm = new PessoasReuniao(modelo, CondicaoDeletar, CondicaoAtualizar, CondicaoDetalhes);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        public WFCrud(modelocrud modelo, modelocrud modeloNovo)
        {
            this.ModeloVelho = modelo;
            this.ModeloNovo = modeloNovo;
        }

        public WFCrud(bool deletar, bool atualizar, bool detalhes,
        modelocrud modelo, modelocrud modeloNovo)
        {
            this.ModeloVelho = modelo;
            this.ModeloNovo = modeloNovo;
            condicaoDeletar = deletar;
            condicaoAtualizar = atualizar;
            condicaoDetalhes = detalhes;

            Proximo = new Button();
            Proximo.Click += Proximo_Click;
            Proximo.Text = "Proximo";
            Proximo.Location = new Point(650, 150);
            Proximo.Size = new Size(100, 50);

            this.Controls.Add(Proximo);
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
            FrmEnderecoCelula dc = new FrmEnderecoCelula((Celula)modelo, condicaoDeletar,
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
            PessoasCelulasMinisterio pcm = new PessoasCelulasMinisterio((Ministerio)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            pcm.MdiParent = this.MdiParent;
            pcm.Show();
        }

        private void DadoMinistro_Click(object sender, EventArgs e)
        {
            DadoMinisterio rmp = new DadoMinisterio((Ministerio)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            rmp.MdiParent = this.MdiParent;
            rmp.Show();
        }

        private void DadoMinisterioPessoas_Click1(object sender, EventArgs e)
        {
            ReunioesMinisteriosPessoa rmp = new ReunioesMinisteriosPessoa((Pessoa)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            rmp.MdiParent = this.MdiParent;
            rmp.Show();
        }

        private void DadoContato_Click(object sender, EventArgs e)
        {
            Contato dp = new Contato((PessoaDado)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }

        private void DadoEnderecoPessoa_Click(object sender, EventArgs e)
        {
            FrmEndereco dp = new FrmEndereco((PessoaDado)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }

        private void DadoPessoal_Click(object sender, EventArgs e)
        {
            if (modelo is PessoaDado)
            {
                DadoPessoal dp = new DadoPessoal((PessoaDado)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }
            if (modelo is PessoaLgpd)
            {
                DadoPessoalLgpd dp = new DadoPessoalLgpd((PessoaLgpd)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

        }

        private async void FinalizarCadastro_Click(object sender, EventArgs e)
        {
            FinalizaCadastro.Enabled = false;
            if (modelo is Celula)
            {
                var p = (Celula)modelo;
                if (!string.IsNullOrEmpty(AddNaListaCelulaMinisterios))
                {
                    var listaMinisterio = modelocrud.Modelos.OfType<Ministerio>().ToList().ToList();
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
                    p.AdicionarNaLista("MinisterioCelula", p, new Lider_Celula(), AddNaListaCelulaMinisterios);
                }
            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                    p.AdicionarNaLista("PessoaMinisterio", p, new Visitante(), AddNaListaMinisterioPessoas);

                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                    p.AdicionarNaLista("MinisterioCelula", p, new Visitante(), AddNaListaMinisterioCelulas);
            }

            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                if (!string.IsNullOrEmpty(AddNaListaPessoaMinsterios))
                    p.AdicionarNaLista("PessoaMinisterio", p, new Lider_Celula(), AddNaListaPessoaMinsterios);

                if (!string.IsNullOrEmpty(AddNaListaPessoaReunioes))
                    p.AdicionarNaLista("ReuniaoPessoa", p, new Reuniao(), AddNaListaPessoaReunioes);

                var ultimoRegistro = new BDcomum().GetUltimoRegistroPessoa();
                p.Codigo = ultimoRegistro + 1;
            }

            if (modelo is Reuniao)
            {
                var p = (Reuniao)modelo;
                if (!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                    p.AdicionarNaLista("ReuniaoPessoa", p, new Visitante(),
                    AddNaListaReuniaoPessoas);
            }

            modelo.salvar();

            if (modelo is Pessoa && modelocrud.Modelos.OfType<Pessoa>().ToList().Count > 0)
                modelocrud.Modelos.OfType<Pessoa>().ToList().Add((Pessoa)modelo);

            if (modelo is Reuniao && modelocrud.Modelos.OfType<Reuniao>().ToList().Count > 0)
                modelocrud.Modelos.OfType<Reuniao>().ToList().Add((Reuniao)modelo);

            if (modelo is Ministerio && modelocrud.Modelos.OfType<Ministerio>().ToList().Count > 0)
                modelocrud.Modelos.OfType<Ministerio>().ToList().Add((Ministerio)modelo);

            if (modelo is Celula && modelocrud.Modelos.OfType<Celula>().ToList().Count > 0)
                modelocrud.Modelos.OfType<Celula>().ToList().Add((Celula)modelo);

            if (modelo is MudancaEstado && modelocrud.Modelos.OfType<MudancaEstado>().ToList().Count > 0)
                modelocrud.Modelos.OfType<MudancaEstado>().ToList().Add((MudancaEstado)modelo);

            if (modelo is Pessoa && !BDcomum.BancoEnbarcado)
            {
                var p = (Pessoa)modelo;
                {
                    try
                    {
                        var photoRequest = new PhotoRequest
                        {
                            Id = p.Id,
                            Array = p.ImgArrayBytes
                        };
                        var resultado = await p.EnviarFoto(photoRequest);

                        if (!resultado) MessageBox.Show("Foto não enviada.");
                        else
                        {
                            p.Img = "/Content/Imagens/" + p.Id.ToString() + ".jpg";
                            p.alterar(p.Id);
                        }

                    }
                    catch { MessageBox.Show("Foto não enviada."); }
                }
            }

            MessageBox.Show("Cadastro realiado com sucesso.");
            this.Close();
        }
    }
}
