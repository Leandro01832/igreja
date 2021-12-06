using business.classes;
using business.classes.Abstrato;
using business.classes.financeiro;
using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioFonte;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public partial class WFCrud : Form, IFormCrud
    {
        public MdiForm crudForm;

        private Label infoForm;

        // botões para crud
        private Button proximo;
        private Button deletar;
        private Button atualizar;
        private Button finalizarCadastro;


        // botões para select: PESSOA
        private Button dadoPessoal;
        private Button dadoPessoalLgpd;
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
        

        public Button Proximo { get => proximo; set => proximo = value; }
        public Button Atualizar { get => atualizar; set => atualizar = value; }
        public modelocrud ModeloNovo { get => modeloNovo; set => modeloNovo = value; }
        public modelocrud ModeloVelho { get => modeloVelho; set => modeloVelho = value; }
        public Button FinalizaCadastro { get => finalizarCadastro; set => finalizarCadastro = value; }
        public Button Deletar { get => deletar; set => deletar = value; }
        public Button DadoPessoal { get => dadoPessoal; set => dadoPessoal = value; }
        public Button DadoPessoalLgpd { get => dadoPessoalLgpd; set => dadoPessoalLgpd = value; }
        public Button DadoFoto { get => dadoFoto; set => dadoFoto = value; }
        public Button DadoEnderecoPessoa { get => dadoEnderecoPessoa; set => dadoEnderecoPessoa = value; }
        public Button DadoContato { get => dadoContato; set => dadoContato = value; }
        public Button DadoClasse { get => dadoClasse; set => dadoClasse = value; }
        public Button DadoMinisteriosPessoa { get => dadoMinisteriosPessoa; set => dadoMinisteriosPessoa = value; }
        public Button DadoCelula { get => dadoCelula; set => dadoCelula = value; }
        public Button DadoEnderecoCelula { get => dadoEnderecoCelula; set => dadoEnderecoCelula = value; }
        public Button DadoCelulaMinisterio { get => dadoCelulaMinisterio; set => dadoCelulaMinisterio = value; }
        public Button DadoCelulaPessoas { get => dadoCelulaPessoas; set => dadoCelulaPessoas = value; }
        public Button DadoMinisterio { get => dadoMinisterio; set => dadoMinisterio = value; }
        public Button DadoMinisterioPessoas { get => dadoMinisterioPessoas; set => dadoMinisterioPessoas = value; }
        public Button DadoMinistro { get => dadoMinistro; set => dadoMinistro = value; }
        public Button DadoReuniao { get => dadoReuniao; set => dadoReuniao = value; }
        public Button DadoReuniaoPessoas { get => dadoReuniaoPessoas; set => dadoReuniaoPessoas = value; }
        public Label InfoForm { get => infoForm; set => infoForm = value; }
        
        private bool condicaoDeletar;
        private bool condicaoAtualizar;
        private bool condicaoDetalhes;


        public WFCrud()
        {
            crudForm = new MdiForm();
            crudForm.Mdi = this;
            this.FormClosing += WFCrud_FormClosing;

            InfoForm = new Label();
            InfoForm.Location = new Point(10, 10);
            InfoForm.Width = 1200;
            InfoForm.Font = new Font("Arial", 12);
            
            DadoReuniao = new Button();
            DadoReuniao.Location = new Point(50, 50);
            DadoReuniao.Size = new Size(100, 50);
            DadoReuniao.Text = "Dados da reunião";
            DadoReuniao.Click += ReuniaoFrmLocal_reuniaoSelecionar_Click;
            DadoReuniao.Visible = false;

            DadoReuniaoPessoas = new Button();
            DadoReuniaoPessoas.Location = new Point(200, 50);
            DadoReuniaoPessoas.Size = new Size(100, 50);
            DadoReuniaoPessoas.Text = "pessoas da reunião";
            DadoReuniaoPessoas.Click += ReuniaoFrmPessoasSelecionar_Click;
            DadoReuniaoPessoas.Visible = false;

            DadoPessoal = new Button();
            DadoPessoal.Location = new Point(50, 50);
            DadoPessoal.Size = new Size(100, 50);
            DadoPessoal.Text = "Dados Pessoais";
            DadoPessoal.Click += PessoaFrmCpfSelecionar_Click;
            DadoPessoal.Visible = false;

            DadoPessoalLgpd = new Button();
            DadoPessoalLgpd.Location = new Point(50, 50);
            DadoPessoalLgpd.Size = new Size(100, 50);
            DadoPessoalLgpd.Text = "Dados Pessoais LGPD";
            DadoPessoalLgpd.Click += PessoaFrmEmailSelecionar_Click;
            DadoPessoalLgpd.Visible = false;

            DadoEnderecoPessoa = new Button();
            DadoEnderecoPessoa.Location = new Point(200, 50);
            DadoEnderecoPessoa.Size = new Size(100, 50);
            DadoEnderecoPessoa.Text = "Endereço da pessoa";
            DadoEnderecoPessoa.Click += PessoaFrmEnderecoSelecionar_Click;
            DadoEnderecoPessoa.Visible = false;

            DadoContato = new Button();
            DadoContato.Location = new Point(200, 160);
            DadoContato.Size = new Size(100, 50);
            DadoContato.Text = "Contatos";
            DadoContato.Click += PessoaFrmTelefoneSelecionar_Click;
            DadoContato.Visible = false;

            DadoClasse = new Button();
            DadoClasse.Location = new Point(50, 160);
            DadoClasse.Size = new Size(100, 50);
            DadoClasse.Text = "Dados de classe";
            DadoClasse.Click += DadoClasse_Click;
            DadoClasse.Visible = false;

            DadoMinisteriosPessoa = new Button();
            DadoMinisteriosPessoa.Location = new Point(50, 270);
            DadoMinisteriosPessoa.Size = new Size(100, 50);
            DadoMinisteriosPessoa.Text = "Ministerios da pessoa";
            DadoMinisteriosPessoa.Click += PessoaFrmMinisterioSelecionar_Click;
            DadoMinisteriosPessoa.Visible = false;

            DadoFoto = new Button();
            DadoFoto.Location = new Point(200, 270);
            DadoFoto.Size = new Size(100, 50);
            DadoFoto.Text = "Foto da pessoa";
            DadoFoto.Click += PessoaFrmImgSelecionar_Click;
            DadoFoto.Visible = false;

            DadoCelula = new Button();
            DadoCelula.Location = new Point(50, 50);
            DadoCelula.Size = new Size(100, 50);
            DadoCelula.Text = "Dados de celula";
            DadoCelula.Click += DadoCelula_Click;
            DadoCelula.Visible = false;

            DadoEnderecoCelula = new Button();
            DadoEnderecoCelula.Location = new Point(200, 50);
            DadoEnderecoCelula.Size = new Size(100, 50);
            DadoEnderecoCelula.Text = "Endereço da celula";
            DadoEnderecoCelula.Click += CelulaFrmEnderecoCelulaSelecionar_Click;
            DadoEnderecoCelula.Visible = false;

            DadoCelulaMinisterio = new Button();
            DadoCelulaMinisterio.Location = new Point(200, 160);
            DadoCelulaMinisterio.Size = new Size(100, 50);
            DadoCelulaMinisterio.Text = "Ministérios da celula";
            DadoCelulaMinisterio.Click += CelulaFrmDia_semanaSelecionar_Click;
            DadoCelulaMinisterio.Visible = false;

            DadoCelulaPessoas = new Button();
            DadoCelulaPessoas.Location = new Point(50, 160);
            DadoCelulaPessoas.Size = new Size(100, 50);
            DadoCelulaPessoas.Text = "Pessoas da celula";
            DadoCelulaPessoas.Click += CelulaFrmMinisteriosSelecionar_Click;
            DadoCelulaPessoas.Visible = false;

            DadoMinisterio = new Button();
            DadoMinisterio.Location = new Point(50, 50);
            DadoMinisterio.Size = new Size(100, 50);
            DadoMinisterio.Text = "Dados do Ministério";
            DadoMinisterio.Click += DadoMinisterio_Click;
            DadoMinisterio.Visible = false;

            DadoMinisterioPessoas = new Button();
            DadoMinisterioPessoas.Location = new Point(200, 50);
            DadoMinisterioPessoas.Size = new Size(100, 50);
            DadoMinisterioPessoas.Text = "Pessoas do ministério";
            DadoMinisterioPessoas.Click += MinisterioFrmPessoaSelecionar_Click;
            DadoMinisterioPessoas.Visible = false;

            DadoMinistro = new Button();
            DadoMinistro.Location = new Point(200, 160);
            DadoMinistro.Size = new Size(100, 50);
            DadoMinistro.Text = "Ministro do ministério";
            DadoMinistro.Click += MinisterioFrmNomeSelecionar_Click;
            DadoMinistro.Visible = false;

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

            this.Controls.Add(DadoPessoal);
            this.Controls.Add(DadoEnderecoPessoa);
            this.Controls.Add(DadoClasse);
            this.Controls.Add(DadoContato);
            this.Controls.Add(DadoMinisteriosPessoa);
            this.Controls.Add(DadoFoto);

            this.Controls.Add(DadoCelula);
            this.Controls.Add(DadoEnderecoCelula);
            this.Controls.Add(DadoCelulaMinisterio);
            this.Controls.Add(DadoCelulaPessoas);

            this.Controls.Add(DadoMinisterio);
            this.Controls.Add(DadoMinisterioPessoas);
            this.Controls.Add(DadoMinistro);

            this.Controls.Add(DadoReuniao);
            this.Controls.Add(DadoReuniaoPessoas);

            InfoForm.Visible = false;
            this.Controls.Add(InfoForm);
            
        }

        private void WFCrud_Load(object sender, EventArgs e)
        {
        }        

        private void WFCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool deletar = false;

            if (CondicaoDeletar)
            {
                var p = (Pessoa)modelo;
                if (modelo.recuperar(modelo.Id)) deletar = true;
            }

            if (CondicaoAtualizar || CondicaoDetalhes || deletar)
            {
                modelocrud pes = null;
                var model = (modelocrud)Activator.CreateInstance(modelo.GetType());
                model.Id = modelo.Id;
                model.Select_padrao = $"select * from {model.GetType().Name} as C where C.Id='{modelo.Id}'";
                model.Delete_padrao = $" delete from {model.GetType().Name} where Id='{modelo.Id}' ";
                if (model.recuperar(modelo.Id)) pes = model;
                modelocrud.Modelos.Remove(modelocrud.Modelos.Where(m => m.GetType() == modelo.GetType())
                .ToList().First(i => i.Id == modelo.Id));
                modelocrud.Modelos.Add(pes);
            }

            this.Dispose();
        }

        private void    ReuniaoFrmLocal_reuniaoSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "ReuniaoFrmLocal_reuniaoSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    ReuniaoFrmPessoasSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "ReuniaoFrmPessoasSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    DadoCelula_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmDia_semanaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    CelulaFrmEnderecoCelulaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmEnderecoCelulaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void     CelulaFrmDia_semanaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this,  "CelulaFrmDia_semanaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    CelulaFrmMinisteriosSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "CelulaFrmMinisteriosSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    DadoMinisterio_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioFrmNomeSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    MinisterioFrmPessoaSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioFrmPessoaSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    MinisterioFrmNomeSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "MinisterioFrmNomeSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    PessoaFrmMinisterioSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmMinisterioSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    PessoaFrmTelefoneSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmTelefoneSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    PessoaFrmEnderecoSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmEnderecoSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    PessoaFrmCpfSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmCpfSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    PessoaFrmEmailSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmEmailSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }
        private void    PessoaFrmImgSelecionar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaFrmImgSelecionar_Click", modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar); }

        public void LoadCrudForm()
        {
            FormPadrao.LoadForm(this);

            if (!CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes && modelo.anular)
            {
                modelocrud.anularDados(modelo);
                modelo.anular = false;
            }

            if (CondicaoAtualizar || CondicaoDeletar || CondicaoDetalhes)
            {
                InfoForm.Visible = true;
                Proximo.Visible = false;
                FinalizaCadastro.Visible = false;

                if (modelo is PessoaDado)
                {
                    var pessoa = (PessoaDado)modelo;
                    DadoPessoal.Visible = true;
                    DadoPessoalLgpd.Visible = false;
                    InfoForm.Text = "Identificação: " + pessoa.Codigo.ToString() +
                    " - " + pessoa.Nome;
                }
                else
                if (modelo is PessoaLgpd)
                {
                    var pessoa = (PessoaLgpd)modelo;
                    DadoPessoal.Visible = false;
                    DadoPessoalLgpd.Visible = true;
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

            if (modelo is Pessoa && this is Formulario.Pessoas.FrmPessoa)
            {
                DadoPessoal.Visible = true;
                DadoClasse.Visible = true;
                DadoMinisteriosPessoa.Visible = true;
                DadoFoto.Visible = true;
                if (modelo is PessoaDado)
                {
                    DadoEnderecoPessoa.Visible = true;
                    DadoContato.Visible = true;
                }
            }

            if (modelo is Ministerio && this is Formulario.FormularioMinisterio.FrmMinisterio)
            {
                DadoMinisterio.Visible = true;
                DadoMinisterioPessoas.Visible = true;
                DadoMinistro.Visible = true;
            }

            if (modelo is Celula && this is FrmCelula)
            {
                DadoCelula.Visible = true;
                DadoEnderecoCelula.Visible = true;
                DadoCelulaMinisterio.Visible = true;
                DadoCelulaPessoas.Visible = true;
            }

            if (modelo is Reuniao && this is FrmReuniao)
            {
                DadoReuniao.Visible = true;
                DadoReuniaoPessoas.Visible = true;
            }

            if (!CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes)
                Proximo.Visible = true;

            if (!CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes &&
                this is FrmCelula ||
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes &&
                this is Formulario.FormularioMinisterio.FrmMinisterio ||
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes &&
                this is Formulario.Pessoas.FrmPessoa ||
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes &&
                this is FrmReuniao || modelo.GetType().IsSubclassOf(typeof(Movimentacao)) &&
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes ||
                this is FrmFonte &&
                !CondicaoAtualizar && !CondicaoDeletar && !CondicaoDetalhes)
            {
                Proximo.Visible = false;
                FinalizaCadastro.Visible = true;
            }

            if (CondicaoAtualizar)
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

                    if (item is Button && !(this is Formulario.FormularioMinisterio.FrmMinisterio) &&
                        !(this is Formulario.Pessoas.FrmPessoa) && !(this is FrmCelula) &&
                        !(this is FrmReuniao))
                    {
                        var t = (Button)item;
                        t.Enabled = false;
                    }
                }
            }
        }

        private void LoadForm()
        {
            LoadFormCrud( modelo, CondicaoDetalhes, CondicaoDeletar, CondicaoAtualizar, this);
        }

        private async void FinalizarCadastro_Click(object sender, EventArgs e)
        {
            FinalizaCadastro.Enabled = false;            

            if(modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                var ultimoRegistro = modelocrud.GetUltimoRegistro(typeof(Pessoa));
                p.Codigo = ultimoRegistro + 1;
            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                var ultimoRegistro = modelocrud.GetUltimoRegistro(typeof(Ministerio));
                p.CodigoMinisterio = ultimoRegistro + 1;
            }

            try { modelo.salvar(); }
            catch (Exception ex)
            {
                MessageBox.Show(modelo.exibirMensagemErro(ex, 1));
                FinalizaCadastro.Enabled = true;
                return;
            }
            modelocrud.Modelos.Add(modelo);   

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

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            crudForm.LoadFormCrud( modelo, detalhes, deletar, atualizar, this);
        }

        public void Clicar(Form form, string function, modelocrud Modelo = null,
            bool detalhes = false, bool deletar = false, bool atualizar = false)
        {
            crudForm.Clicar(form, function, Modelo, detalhes, deletar, atualizar);
        }
    }
}
