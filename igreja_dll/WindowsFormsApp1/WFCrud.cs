using database;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.Celula;
using WindowsFormsApp1.Formulario.Ministerio;
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
        private Button FinalizarCadastro;

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
            FinalizarCadastro.Click +=  FinalizarCadastro_Click;
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

                var pessoa = (business.classes.Abstrato.Pessoa)modelo;
                InfoForm.Text = "Identificação: " + modelo.Id.ToString() + " - " + pessoa.Nome;

                if (modelo is business.classes.Abstrato.Pessoa && this.GetType().Name == "FinalizarCadastro")
                {
                    dadoPessoal.Visible = true;
                    dadoEnderecoPessoa.Visible = true;
                    dadoContato.Visible = true;
                    dadoClasse.Visible = true;
                    dadoMinisteriosPessoa.Visible = true;
                    dadoFoto.Visible = true;                    
                }

                if (modelo is business.classes.Abstrato.Ministerio && this.GetType().Name == "FinalizarCadastro")
                {
                    dadoMinisterio.Visible = true;
                    dadoMinisterioPessoas.Visible = true;
                    dadoMinistro.Visible = true;
                    var p = (business.classes.Abstrato.Ministerio)modelo;
                    InfoForm.Text += p.Nome;
                }

                if (modelo is business.classes.Abstrato.Celula && this.GetType().Name == "FinalizarCadastro")
                {
                    dadoCelula.Visible = true;
                    dadoEnderecoCelula.Visible = true;
                    dadoCelulaMinisterio.Visible = true;
                    dadoCelulaPessoas.Visible = true;
                    var p = (business.classes.Abstrato.Celula)modelo;
                    InfoForm.Text += p.Nome;
                }

            }

            if(!condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes)
                Proximo.Visible = true;

            if (!condicaoAtualizar && !condicaoDeletar && !condicaoDetalhes && this.GetType().Name == "FinalizarCadastro")
            {
                Proximo.Visible = false;
                FinalizarCadastro.Visible = true;
            }                

            if (this.GetType().Name != "FinalizarCadastro" && condicaoAtualizar)
                Atualizar.Visible = true;


            if (this.GetType().Name != "FinalizarCadastro" && condicaoDeletar)
                Deletar.Visible = true;
        }

        public WFCrud(modelocrud modelo, modelocrud modeloNovo)
        {
            this.ModeloVelho = modelo;
            this.ModeloNovo = modeloNovo;
        }

        private void DadoFoto_Click(object sender, EventArgs e)
        {
            Foto c = new Foto((business.classes.Abstrato.Pessoa)modelo, condicaoAtualizar,
                condicaoDeletar, condicaoDetalhes);
            c.MdiParent = this.MdiParent;
            c.Show();
        }

        private void DadoClasse_Click(object sender, EventArgs e)
        {
            if(modelo is business.classes.Pessoas.Crianca)
            {
                CadastroCrianca c = new CadastroCrianca((business.classes.Abstrato.Pessoa)modelo, condicaoAtualizar,
                condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is business.classes.Pessoas.Visitante)
            {
                CadastroVisitante c = 
                new CadastroVisitante((business.classes.Abstrato.Pessoa)modelo, condicaoAtualizar,
                condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is business.classes.Pessoas.Membro_Aclamacao)
            {
                CadastroMembroAclamacao c = 
                new CadastroMembroAclamacao((business.classes.Abstrato.Pessoa)modelo, condicaoAtualizar,
                condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is business.classes.Pessoas.Membro_Batismo)
            {
                CadastroMembroBatismo c = 
                new CadastroMembroBatismo((business.classes.Abstrato.Pessoa)modelo, condicaoAtualizar,
                condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is business.classes.Pessoas.Membro_Reconciliacao)
            {
                CadastroMembroReconciliacao c = 
                new CadastroMembroReconciliacao((business.classes.Abstrato.Pessoa)modelo, condicaoAtualizar,
                condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is business.classes.Pessoas.Membro_Transferencia)
            {
                CadastroMembroTransferencia c = 
                new CadastroMembroTransferencia((business.classes.Abstrato.Pessoa)modelo, condicaoAtualizar,
                condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

        }

        private void DadoCelula_Click(object sender, EventArgs e)
        {
            DadoCelula dc = new DadoCelula((business.classes.Abstrato.Celula)modelo, condicaoDeletar,
            condicaoAtualizar, condicaoDetalhes);
            dc.MdiParent = this.MdiParent;
            dc.Show();
        }

        private void DadoEnderecoCelula_Click(object sender, EventArgs e)
        {
            EnderecoCelula dc = new EnderecoCelula((business.classes.Abstrato.Celula)modelo, condicaoDeletar,
            condicaoAtualizar, condicaoDetalhes);
            dc.MdiParent = this.MdiParent;
            dc.Show();
        }

        private void DadoCelulaMinisterio_Click(object sender, EventArgs e)
        {
            MinisteriosCelula mt = new MinisteriosCelula((business.classes.Abstrato.Celula)modelo,
            condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            mt.MdiParent = this.MdiParent;
            mt.Show();
        }

        private void DadoCelulaPessoas_Click(object sender, EventArgs e)
        {
            MinisteriosCelula mt = new MinisteriosCelula((business.classes.Abstrato.Celula)modelo,
            condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            mt.MdiParent = this.MdiParent;
            mt.Show();
        }

        private void DadoMinisterio_Click(object sender, EventArgs e)
        {
            DadoMinisterio pcm = new DadoMinisterio((business.classes.Abstrato.Ministerio)modelo
            , condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            pcm.MdiParent = this.MdiParent;
            pcm.Show();
        }

        private void DadoMinisterioPessoas_Click(object sender, EventArgs e)
        {
            PessoasCelulasMinisterio pcm = new PessoasCelulasMinisterio((business.classes.Abstrato.Ministerio)modelo
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
            ReunioesMinisteriosPessoa rmp = new ReunioesMinisteriosPessoa((business.classes.Abstrato.Pessoa)modelo
            , condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            rmp.MdiParent = this.MdiParent;
            rmp.Show();
        }

        private void DadoContato_Click(object sender, EventArgs e)
        {
            Contato dp = new Contato((business.classes.Abstrato.Pessoa)modelo,
            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }       

        private void DadoEnderecoPessoa_Click(object sender, EventArgs e)
        {
            Endereco dp = new Endereco((business.classes.Abstrato.Pessoa)modelo,
            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }

        private void DadoPessoal_Click(object sender, EventArgs e)
        {
            DadoPessoal dp = new DadoPessoal((business.classes.Abstrato.Pessoa)modelo,
                condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }

        private  void FinalizarCadastro_Click(object sender, EventArgs e)
        {
            FinalizarCadastro.Enabled = false;
            if(modelo is business.classes.Abstrato.Celula)
            {
                var p = (business.classes.Abstrato.Celula)modelo;
                if (!string.IsNullOrEmpty(AddNaListaCelulaMinisterios))
                {
                    var arr = AddNaListaCelulaMinisterios.Replace(" ", "").Split(',');
                    foreach (var item in arr)
                    {
                        try
                        {
                            if (business.classes.Abstrato.Ministerio.recuperarMinisterio(int.Parse(item)) == null)
                                AddNaListaCelulaMinisterios.Replace(item, "");
                        }
                        catch { }
                    }
                    p.AdicionarNaLista("MinisterioCelula", "Celula", "Ministerio", AddNaListaCelulaMinisterios);
                }                
            }

            if (modelo is business.classes.Abstrato.Ministerio)
            {
                var p = (business.classes.Abstrato.Ministerio)modelo;
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                p.AdicionarNaLista("PessoaMinisterio", "Ministerio", "Pessoa", AddNaListaMinisterioPessoas);               
                               
                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                p.AdicionarNaLista("MinisterioCelula", "Ministerio", "Celula", AddNaListaMinisterioCelulas);                               
            }

            if (modelo is business.classes.Abstrato.Pessoa)
            {
                var p = (business.classes.Abstrato.Pessoa)modelo;
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

        private void Atualizar_Click(object sender, EventArgs e)
        {
            if (modelo is business.classes.Abstrato.Celula)
            {
                var p = (business.classes.Abstrato.Celula)modelo;
                if (!string.IsNullOrEmpty(AddNaListaCelulaMinisterios))
                {
                    var arr = AddNaListaCelulaMinisterios.Replace(" ", "").Split(',');
                    foreach (var item in arr)
                    {
                        try
                        {
                            if (business.classes.Abstrato.Ministerio.recuperarMinisterio(int.Parse(item)) == null)
                                AddNaListaCelulaMinisterios.Replace(item, "");
                        }
                        catch { }
                    }
                    p.RemoverDaLista("MinisterioCelula", "Celula", "Ministerio", AddNaListaCelulaMinisterios, modelo.Id);
                }
            }

            if (modelo is business.classes.Abstrato.Ministerio)
            {
                var p = (business.classes.Abstrato.Ministerio)modelo;
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                    p.RemoverDaLista("PessoaMinisterio", "Ministerio", "Pessoa", AddNaListaMinisterioPessoas, modelo.Id);

                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                    p.RemoverDaLista("MinisterioCelula", "Ministerio", "Celula", AddNaListaMinisterioCelulas, modelo.Id);
            }

            if (modelo is business.classes.Abstrato.Pessoa)
            {
                var p = (business.classes.Abstrato.Pessoa)modelo;
                if (!string.IsNullOrEmpty(AddNaListaPessoaMinsterios))
                    p.RemoverDaLista("PessoaMinisterio", "Pessoa", "Ministerio", AddNaListaPessoaMinsterios, modelo.Id);

                if (!string.IsNullOrEmpty(AddNaListaPessoaReunioes))
                    p.RemoverDaLista("ReuniaoPessoa", "Pessoa", "Reuniao", AddNaListaPessoaReunioes, modelo.Id);

            }

            if (modelo is business.classes.Reuniao)
            {
                var p = (business.classes.Reuniao)modelo;
                if (!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                    p.RemoverDaLista("ReuniaoPessoa", "Reuniao", "Pessoa", AddNaListaReuniaoPessoas, modelo.Id);

            }

            modelo.alterar(modelo.Id);
            MessageBox.Show("Informação atualizada com sucesso.");
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            modelo.excluir(modelo.Id);
        }

        private void Proximo_Click(object sender, EventArgs e)
        {
            if (this is FormCrudPessoa)
            {
                if (this.GetType().Name == "DadoPessoal")
                {
                    
                    Endereco end = new Endereco((business.classes.Abstrato.Pessoa)modelo,
                    condicaoAtualizar, condicaoDeletar, CondicaoDetalhes);
                    end.MdiParent = this.MdiParent;
                    this.Close();
                    end.Show();
                }

                if (this.GetType().Name == "Endereco")
                {
                   
                    Contato con = new Contato((business.classes.Abstrato.Pessoa)modelo,
                        condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    con.MdiParent = this.MdiParent;
                    this.Close();
                    con.Show();
                }

                if (this.GetType().Name == "Contato")
                {                    
                    Foto con = new Foto((business.classes.Abstrato.Pessoa)modelo,
                    condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    con.MdiParent = this.MdiParent;
                    this.Close();
                    con.Show();
                }

                if (this.GetType().Name == "Foto")
                {
                    ReunioesMinisteriosPessoa con = new ReunioesMinisteriosPessoa((business.classes.Abstrato.Pessoa)modelo,
                    condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    con.MdiParent = this.MdiParent;
                    this.Close();
                    con.Show();
                }

                if (this.GetType().Name == "ReunioesMinisteriosPessoa")
                {
                    if (modelo.GetType().Name == "Crianca")
                    {                        
                        CadastroCrianca cc = new CadastroCrianca((business.classes.Abstrato.Pessoa)
                        modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        cc.MdiParent = this.MdiParent;
                        this.Close();
                        cc.Show();
                    }


                    if (modelo.GetType().Name == "Visitante")
                    {                        
                        CadastroVisitante cv = new CadastroVisitante((business.classes.Abstrato.Pessoa)
                        modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        cv.MdiParent = this.MdiParent;
                        this.Close();
                        cv.Show();
                    }


                    if (modelo.GetType().Name == "Membro_Aclamacao")
                    {                        
                        CadastroMembroAclamacao cma = new CadastroMembroAclamacao((business.classes.Abstrato.Pessoa)
                       modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        cma.MdiParent = this.MdiParent;
                        this.Close();
                        cma.Show();
                    }


                    if (modelo.GetType().Name == "Membro_Reconciliacao")
                    {
                        CadastroMembroReconciliacao cmr = new CadastroMembroReconciliacao((business.classes.Abstrato.Pessoa)
                        modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        cmr.MdiParent = this.MdiParent;
                        this.Close();
                        cmr.Show();
                    }


                    if (modelo.GetType().Name == "Membro_Batismo")
                    {
                        CadastroMembroBatismo cmb = new CadastroMembroBatismo((business.classes.Abstrato.Pessoa)
                        modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        cmb.MdiParent = this.MdiParent;
                        this.Close();
                        cmb.Show();
                    }


                    if (modelo.GetType().Name == "Membro_Transferencia")
                    {
                        CadastroMembroTransferencia cmt = new CadastroMembroTransferencia((business.classes.Abstrato.Pessoa)
                        modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        cmt.MdiParent = this.MdiParent;
                        this.Close();
                        cmt.Show();
                    }

                }

                if (this.GetType().Name == "CadastroCrianca" || this.GetType().Name == "CadastroVisitante" ||
                    this.GetType().Name == "CadastroMembroAclamacao" || this.GetType().Name == "CadastroMembroReconciliacao" ||
                    this.GetType().Name == "CadastroMembroBatismo" || this.GetType().Name == "CadastroMembroTransferencia")
                {
                    WindowsFormsApp1.Formulario.Pessoa.FinalizarCadastro fn = new
                    WindowsFormsApp1.Formulario.Pessoa.FinalizarCadastro((business.classes.Abstrato.Pessoa)modelo,
                   CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    fn.MdiParent = this.MdiParent;
                    this.Close();
                    fn.Show();

                }
            }

            if (this is FormularioCrudCelula)
            {
                if (this.GetType().Name == "DadoCelula")
                {
                    EnderecoCelula end = new EnderecoCelula((business.classes.Abstrato.Celula)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    end.MdiParent = this.MdiParent;
                    this.Close();
                    end.Show();
                }

                if (this.GetType().Name == "EnderecoCelula")
                {
                    MinisteriosCelula con = new MinisteriosCelula((business.classes.Abstrato.Celula)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    con.MdiParent = this.MdiParent;
                    this.Close();
                    con.Show();
                }
                if (this.GetType().Name == "MinisteriosCelula")
                {                    
                    FinalizarCadastro con = new FinalizarCadastro((business.classes.Abstrato.Celula)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    con.MdiParent = this.MdiParent;
                    this.Close();
                    con.Show();
                }
            }

            if (this is FormCrudMinisterio)
            {
                if (this.GetType().Name == "DadoMinisterio")
                {
                    PessoasCelulasMinisterio fn = new
                    WindowsFormsApp1.Formulario.Ministerio.PessoasCelulasMinisterio((business.classes.Abstrato.Ministerio)modelo,
                   CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    fn.MdiParent = this.MdiParent;
                    this.Close();
                    fn.Show();
                }

                if (this.GetType().Name == "PessoasCelulasMinisterio")
                {
                    WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro fn = new
                    WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)modelo,
                   CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    fn.MdiParent = this.MdiParent;
                    this.Close();
                    fn.Show();
                }
            }
            
        }

        private void WFCrud_Load(object sender, EventArgs e)
        {

        }
    }
}
