using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using System;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class ListPessoa : FormularioListView
    {

        public ListPessoa(Type Tipo) : base(Tipo)
        {     
            InitializeComponent();
            this.Tipo = Tipo;
        }

        public Type Tipo { get; }

        private void Pessoa_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de";

            if (Tipo == typeof(Pessoa                          )) this.Text += " todas as pessoas";
            if (Tipo == typeof(PessoaDado                      )) this.Text += " pessoas - com todos os dados";
            if (Tipo == typeof(Membro                          )) this.Text += " membros - com todos os dados";
            if (Tipo == typeof(Visitante                       )) this.Text += " visitantes - com todos os dados";
            if (Tipo == typeof(Crianca                         )) this.Text += " crianças - com todos os dados";
            if (Tipo == typeof(Membro_Aclamacao                )) this.Text += " membros por aclamação - com todos os dados";
            if (Tipo == typeof(Membro_Batismo                  )) this.Text += " membros por batismo - com todos os dados";
            if (Tipo == typeof(Membro_Reconciliacao            )) this.Text += " membros por reconciliação - com todos os dados";
            if (Tipo == typeof(Membro_Transferencia            )) this.Text += " membros por transferência - com todos os dados";

            if (Tipo == typeof(PessoaLgpd                          )) this.Text += " pessoas - somente e-mail";
            if (Tipo == typeof(MembroLgpd                          )) this.Text += " membros - somente e-mail";
            if (Tipo == typeof(VisitanteLgpd                       )) this.Text += " visitantes - somente e-mail";
            if (Tipo == typeof(CriancaLgpd                         )) this.Text += " crianças - somente e-mail";
            if (Tipo == typeof(Membro_AclamacaoLgpd                )) this.Text += " membros por aclamação - somente e-mail";
            if (Tipo == typeof(Membro_BatismoLgpd                  )) this.Text += " membros por batismo - somente e-mail";
            if (Tipo == typeof(Membro_ReconciliacaoLgpd            )) this.Text += " membros por reconciliação - somente e-mail";
            if (Tipo == typeof(Membro_TransferenciaLgpd            )) this.Text += " membros por transferência - somente e-mail";


            if (Tipo == typeof(Pessoa                          )) this.BackColor = System.Drawing.Color.LightGray;
            if (Tipo == typeof(PessoaDado                      )) this.BackColor = System.Drawing.Color.Coral;
            if (Tipo == typeof(Membro                          )) this.BackColor = System.Drawing.Color.Coral;
            if (Tipo == typeof(Visitante                       )) this.BackColor = System.Drawing.Color.Coral;
            if(Tipo == typeof(Crianca                          )) this.BackColor = System.Drawing.Color.Coral;
            if(Tipo == typeof(Membro_Aclamacao                 )) this.BackColor = System.Drawing.Color.Coral;
            if(Tipo == typeof(Membro_Batismo                   )) this.BackColor = System.Drawing.Color.Coral;
            if(Tipo == typeof(Membro_Reconciliacao             )) this.BackColor = System.Drawing.Color.Coral;
            if(Tipo == typeof(Membro_Transferencia             )) this.BackColor = System.Drawing.Color.Coral;
                                                               
            if(Tipo == typeof(VisitanteLgpd                    )) this.BackColor = System.Drawing.Color.LightBlue;
            if(Tipo == typeof(CriancaLgpd                      )) this.BackColor = System.Drawing.Color.LightBlue;
            if(Tipo == typeof(Membro_AclamacaoLgpd             )) this.BackColor = System.Drawing.Color.LightBlue;
            if(Tipo == typeof(Membro_BatismoLgpd               )) this.BackColor = System.Drawing.Color.LightBlue;
            if(Tipo == typeof(Membro_ReconciliacaoLgpd         )) this.BackColor = System.Drawing.Color.LightBlue;
            if(Tipo == typeof(Membro_TransferenciaLgpd         )) this.BackColor = System.Drawing.Color.LightBlue;
        }
    }
}
