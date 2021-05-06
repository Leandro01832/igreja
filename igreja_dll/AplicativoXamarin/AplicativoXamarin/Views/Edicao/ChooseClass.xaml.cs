using AplicativoXamarin.models;
using AplicativoXamarin.models.Pessoas;
using AplicativoXamarin.models.PessoasLgpd;
using AplicativoXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Edicao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseClass : ContentPage
    {

        public ChooseClass()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ViewModelEdicao>(this, "Next", async (msg) => {

                modelocrud m = null;
                
                Pessoa p = await msg.GetPessoa();
                

                if (p is PessoaLgpd)
                {
                    if (msg.Visitante)           m = msg.visitante;
                    if (msg.Crianca)             m = msg.crianca;
                    if (msg.MembroAclamacao)     m = msg.membro_Aclamacao;
                    if (msg.MembroBatismo)       m = msg.membro_Batismo;
                    if (msg.MembroReconciliacao) m = msg.membro_Reconciliacao;
                    if (msg.MembroTransferencia) m = msg.membro_Transferencia;
                }
                else if (p is PessoaDado)
                {
                    if (msg.Visitante)           m = msg.visitanteLgpd;
                    if (msg.Crianca)             m = msg.criancaLgpd;
                    if (msg.MembroAclamacao)     m = msg.membro_AclamacaoLgpd;
                    if (msg.MembroBatismo)       m = msg.membro_BatismoLgpd;
                    if (msg.MembroReconciliacao) m = msg.membro_ReconciliacaoLgpd;
                    if (msg.MembroTransferencia) m = msg.membro_TransferenciaLgpd;
                }

                if (m is Visitante)                await Navigation.PushAsync(new EditVisitante());
                if (m is Crianca)                  await Navigation.PushAsync(new EditCrianca());
                if (m is Membro_Aclamacao)         await Navigation.PushAsync(new EditMembroAclamcacao());
                if (m is Membro_Batismo)           await Navigation.PushAsync(new EditMembroBatismo());
                if (m is Membro_Reconciliacao)     await Navigation.PushAsync(new EditMembroReconciliacao());
                if (m is Membro_Transferencia)     await Navigation.PushAsync(new EditMembroTransferencia());
                if (m is VisitanteLgpd)            await Navigation.PushAsync(new EditVisitanteLgpd());
                if (m is CriancaLgpd)              await Navigation.PushAsync(new EditCriancaLgpd());
                if (m is Membro_AclamacaoLgpd)     await Navigation.PushAsync(new EditMembroAclamcacaoLgpd());
                if (m is Membro_BatismoLgpd)       await Navigation.PushAsync(new EditMembroBatismoLgpd());
                if (m is Membro_ReconciliacaoLgpd) await Navigation.PushAsync(new EditMembroReconciliacaoLgpd());
                if (m is Membro_TransferenciaLgpd) await Navigation.PushAsync(new EditMembroTransferenciaLgpd());

            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<modelocrud>(this, "Next");
        }
    }
}