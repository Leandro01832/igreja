using AplicativoXamarin.models;
using AplicativoXamarin.models.Pessoas;
using AplicativoXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Edicao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseClass : ContentPage
    {
        public ViewModelEdicao viewmodel { get; set; }

        public ChooseClass()
        {
            InitializeComponent();
            viewmodel = new ViewModelEdicao();

            BindingContext = viewmodel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<modelocrud>(this, "Next", (msg) => {

                if (msg is Visitante) Navigation.PushAsync(new EditVisitante());
                if (msg is Crianca) Navigation.PushAsync(new EditCrianca());
                if (msg is Membro_Aclamacao) Navigation.PushAsync(new EditMembroAclamcacao());
                if (msg is Membro_Batismo) Navigation.PushAsync(new EditMembroBatismo());
                if (msg is Membro_Reconciliacao) Navigation.PushAsync(new EditMembroReconciliacao());
                if (msg is Membro_Transferencia) Navigation.PushAsync(new EditMembroTransferencia());

            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<modelocrud>(this, "Next");
        }
    }
}