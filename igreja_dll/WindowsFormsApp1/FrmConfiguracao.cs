using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmConfiguracao : Form
    {
        public FrmConfiguracao()
        {
            InitializeComponent();
        }

       static int numeroEmailB = 0;
       static int numeroEmailG = 0;
       static int numeroEmailR = 0;
       static int numeroFinanceiroB = 0;
       static int numeroFinanceiroG = 0;
       static int numeroFinanceiroR = 0;
       static int numeroPessoaB = 0;
       static int numeroPessoaG = 0;
       static int numeroPessoaR = 0;
       static int numeroPrincipalB = 0;
       static int numeroPrincipalG = 0;
       static int numeroPrincipalR = 0;
       static int numeroEsbocoB = 0;
       static int numeroEsbocoG = 0;
       static int numeroEsbocoR = 0;

        private void FrmConfiguracao_Load(object sender, EventArgs e)
        {
            numericPrincipalB.Value = numeroPrincipalB;
            numericPrincipalG.Value = numeroPrincipalG;
            numericPrincipalR.Value = numeroPrincipalR;
            numericEsbocoB.Value = numeroEsbocoB;
            numericEsbocoG.Value = numeroEsbocoG;
            numericEsbocoR.Value = numeroEsbocoR;
            numericEmailB.Value = numeroEmailB;
            numericEmailG.Value = numeroEmailG;
            numericEmailR.Value = numeroEmailR;
            numericFinanceiroB.Value = numeroFinanceiroB;
            numericFinanceiroG.Value = numeroFinanceiroG;
            numericFinanceiroR.Value = numeroFinanceiroR;
            numericPessoaB.Value = numeroPessoaB;
            numericPessoaG.Value = numeroPessoaG;
            numericPessoaR.Value = numeroPessoaR;
        }
        

        private void numericEsbocoB_ValueChanged(object sender, EventArgs e)
        {
            numeroEsbocoB = int.Parse(numericEsbocoB.Value.ToString());
            FrmPrincipal.mus.BackgroundColorEsboco = Color.FromArgb(numeroEsbocoR, numeroEsbocoG, numeroEsbocoB);
            btnEsboco.BackColor = FrmPrincipal.mus.BackgroundColorEsboco;
        }

        private void numericEsbocoG_ValueChanged(object sender, EventArgs e)
        {
            numeroEsbocoG = int.Parse(numericEsbocoG.Value.ToString());
            FrmPrincipal.mus.BackgroundColorEsboco = Color.FromArgb(numeroEsbocoR, numeroEsbocoG, numeroEsbocoB);
            btnEsboco.BackColor = FrmPrincipal.mus.BackgroundColorEsboco;
        }

        private void numericEsbocoR_ValueChanged(object sender, EventArgs e)
        {
            numeroEsbocoR = int.Parse(numericEsbocoR.Value.ToString());
            FrmPrincipal.mus.BackgroundColorEsboco = Color.FromArgb(numeroEsbocoR, numeroEsbocoG, numeroEsbocoB);
            btnEsboco.BackColor = FrmPrincipal.mus.BackgroundColorEsboco;
        }

        private void numericEmailB_ValueChanged(object sender, EventArgs e)
        {
            numeroEmailB = int.Parse(numericEmailB.Value.ToString());
            FrmPrincipal.mus.BackgroundColorEmail = Color.FromArgb(numeroEmailR, numeroEmailG, numeroEmailB);
            btnEmail.BackColor = FrmPrincipal.mus.BackgroundColorEmail;
        }

        private void numericEmailG_ValueChanged(object sender, EventArgs e)
        {
            numeroEmailG = int.Parse(numericEmailG.Value.ToString());
            FrmPrincipal.mus.BackgroundColorEmail = Color.FromArgb(numeroEmailR, numeroEmailG, numeroEmailB);
            btnEmail.BackColor = FrmPrincipal.mus.BackgroundColorEmail;
        }

        private void numericEmailR_ValueChanged(object sender, EventArgs e)
        {
            numeroEmailR = int.Parse(numericEmailR.Value.ToString());
            FrmPrincipal.mus.BackgroundColorEmail = Color.FromArgb(numeroEmailR, numeroEmailG, numeroEmailB);
            btnEmail.BackColor = FrmPrincipal.mus.BackgroundColorEmail;
        }

        private void numericFinanceiroB_ValueChanged(object sender, EventArgs e)
        {
            numeroFinanceiroB = int.Parse(numericFinanceiroB.Value.ToString());
            FrmPrincipal.mus.BackgroundColorFinanceiro = Color.FromArgb(numeroFinanceiroR, numeroFinanceiroG, numeroFinanceiroB);
            btnFinanceiro.BackColor = FrmPrincipal.mus.BackgroundColorFinanceiro;
        }

        private void numericFinanceiroG_ValueChanged(object sender, EventArgs e)
        {
            numeroFinanceiroG = int.Parse(numericFinanceiroG.Value.ToString());
            FrmPrincipal.mus.BackgroundColorFinanceiro = Color.FromArgb(numeroFinanceiroR, numeroFinanceiroG, numeroFinanceiroB);
            btnFinanceiro.BackColor = FrmPrincipal.mus.BackgroundColorFinanceiro;
        }

        private void numericFinanceiroR_ValueChanged(object sender, EventArgs e)
        {
            numeroFinanceiroR = int.Parse(numericFinanceiroR.Value.ToString());
            FrmPrincipal.mus.BackgroundColorFinanceiro = Color.FromArgb(numeroFinanceiroR, numeroFinanceiroG, numeroFinanceiroB);
            btnFinanceiro.BackColor = FrmPrincipal.mus.BackgroundColorFinanceiro;
        }

        private void numericPessoaB_ValueChanged(object sender, EventArgs e)
        {
            numeroPessoaB = int.Parse(numericPessoaB.Value.ToString());
            FrmPrincipal.mus.BackgroundColorGereciamentoPessoa = Color.FromArgb(numeroPessoaR, numeroPessoaG, numeroPessoaB);
            btnPessoa.BackColor = FrmPrincipal.mus.BackgroundColorGereciamentoPessoa;
        }

        private void numericPessoaG_ValueChanged(object sender, EventArgs e)
        {
            numeroPessoaG = int.Parse(numericPessoaG.Value.ToString());
            FrmPrincipal.mus.BackgroundColorGereciamentoPessoa = Color.FromArgb(numeroPessoaR, numeroPessoaG, numeroPessoaB);
            btnPessoa.BackColor = FrmPrincipal.mus.BackgroundColorGereciamentoPessoa;
        }

        private void numericPessoaR_ValueChanged(object sender, EventArgs e)
        {
            numeroPessoaR = int.Parse(numericPessoaR.Value.ToString());
            FrmPrincipal.mus.BackgroundColorGereciamentoPessoa = Color.FromArgb(numeroPessoaR, numeroPessoaG, numeroPessoaB);
            btnPessoa.BackColor = FrmPrincipal.mus.BackgroundColorGereciamentoPessoa;
        }

        private void numericPrincipalB_ValueChanged(object sender, EventArgs e)
        {
            numeroPrincipalB = int.Parse(numericPrincipalB.Value.ToString());
            FrmPrincipal.mus.BackgroundColorPrincipal = Color.FromArgb(numeroPrincipalR, numeroPrincipalG, numeroPrincipalB);
            btnPrincipal.BackColor = FrmPrincipal.mus.BackgroundColorPrincipal;
        }

        private void numericPrincipalG_ValueChanged(object sender, EventArgs e)
        {
            numeroPrincipalG = int.Parse(numericPrincipalG.Value.ToString());
            FrmPrincipal.mus.BackgroundColorPrincipal = Color.FromArgb(numeroPrincipalR, numeroPrincipalG, numeroPrincipalB);
            btnPrincipal.BackColor = FrmPrincipal.mus.BackgroundColorPrincipal;
        }

        private void numericPrincipalR_ValueChanged(object sender, EventArgs e)
        {
            numeroPrincipalR = int.Parse(numericPrincipalR.Value.ToString());
            FrmPrincipal.mus.BackgroundColorPrincipal = Color.FromArgb(numeroPrincipalR, numeroPrincipalG, numeroPrincipalB);
            btnPrincipal.BackColor = FrmPrincipal.mus.BackgroundColorPrincipal;
        }

        
    }
}
