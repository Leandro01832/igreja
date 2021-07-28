using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class CadastroMembroTransferencia : FormCrudPessoa
    {
        public CadastroMembroTransferencia(modelocrud p, bool Deletar, bool Atualizar, bool Detalhes)            
        : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        public CadastroMembroTransferencia(bool Deletar, bool Atualizar, bool Detalhes, modelocrud modeloVelho,
            modelocrud modeloNovo)
            : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
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
            {
                if(modelo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)modelo;
                    txt_nome_igreja.Text = p.Nome_igreja_transferencia;
                    txt_nome_estado.Text = p.Estado_transferencia;
                    txt_nome_cidade.Text = p.Nome_cidade_transferencia;
                }
                if (modelo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)modelo;
                    txt_nome_igreja.Text = p.Nome_igreja_transferencia;
                    txt_nome_estado.Text = p.Estado_transferencia;
                    txt_nome_cidade.Text = p.Nome_cidade_transferencia;
                }

            }
            
        }

        private void txt_nome_igreja_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                if(modelo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)modelo;
                    p.Nome_igreja_transferencia = txt_nome_igreja.Text;
                }
                if (modelo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)modelo;
                    p.Nome_igreja_transferencia = txt_nome_igreja.Text;
                }

            }
            if (ModeloNovo != null)
            {
                if (ModeloNovo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)ModeloNovo;
                    p.Nome_igreja_transferencia = txt_nome_igreja.Text;
                }
                if (ModeloNovo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)ModeloNovo;
                    p.Nome_igreja_transferencia = txt_nome_igreja.Text;
                }
            }

        }

        private void txt_nome_estado_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)modelo;
                    p.Estado_transferencia = txt_nome_estado.Text;
                }
                if (modelo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)modelo;
                    p.Estado_transferencia = txt_nome_estado.Text;
                }

            }
            if (ModeloNovo != null)
            {
                if (ModeloNovo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)ModeloNovo;
                    p.Estado_transferencia = txt_nome_estado.Text;
                }
                if (ModeloNovo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)ModeloNovo;
                    p.Estado_transferencia = txt_nome_estado.Text;
                }
            }
        }

        private void txt_nome_cidade_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)modelo;
                    p.Nome_cidade_transferencia = txt_nome_cidade.Text;
                }
                if (modelo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)modelo;
                    p.Nome_cidade_transferencia = txt_nome_cidade.Text;
                }

            }
            if (ModeloNovo != null)
            {
                if (ModeloNovo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)ModeloNovo;
                    p.Nome_cidade_transferencia = txt_nome_cidade.Text;
                }
                if (ModeloNovo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)ModeloNovo;
                    p.Nome_cidade_transferencia = txt_nome_cidade.Text;
                }
            }

        }
    }
}
