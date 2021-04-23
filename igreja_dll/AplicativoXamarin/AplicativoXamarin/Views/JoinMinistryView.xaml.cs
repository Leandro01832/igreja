using AplicativoXamarin.models;
using AplicativoXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JoinMinistryView : ContentPage
	{
        public ListagemViewModel Listagem { get; set; }

        public JoinMinistryView ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Ministerio>(this, "MinisterioSelecionado",
               async (msg) =>
                {
                    if (await DisplayAlert("Confirmação", "Deseja realmente participar deste Ministério?", "SIM", "Cancelar"))
                    {
                        using (var cliente = new HttpClient())
                        {
                            cliente.BaseAddress = new Uri("http://igrejadeusbom.somee.com");
                            var camposFormulario = new FormUrlEncodedContent(new[]
                             {
                        new KeyValuePair<string, string>("MinisterioId", msg.IdMinisterio.ToString()),
                        new KeyValuePair<string, string>("PessoaId", App.UserCurrent.IdPessoa.ToString())
                        });
                            var resultado = await cliente.PostAsync("/Api/PessoaMinisterioApi", camposFormulario);

                            if (resultado.IsSuccessStatusCode)
                            {
                                await DisplayAlert("Parabens!!!", "Parabens!!! você esta participando desta Ministério.", "Ok");
                                await this.Listagem.GetReunioes(true);
                            }
                            else
                            {
                                await DisplayAlert("Erro", "Ocorreu um erro ao enviar o cadastro.Tente novamente mais tarde.", "Ok");
                            }
                        }
                    }                    
                });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagemMinisterio",
                (msg) =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de ministérios. Por favor tente novamente mais tarde.", "Ok");
                });

            await this.Listagem.GetMinisterios(true);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Ministerio>(this, "MinisterioSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagemMinisterio");
        }
    }
}