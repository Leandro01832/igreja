using Mobile.models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
   public class ListagemMinisterioViewModel : BaseViewModel
    {
        const string URL_GET_MINISTERIOS = "http://www.igrejadedeus.somee.com/api/MinisterioApi";

        public ObservableCollection<Ministerio> Ministerios { get; set; }

        Ministerio ministerioSelecionado;

        public ListagemMinisterioViewModel()
        {
            this.Ministerios = new ObservableCollection<Ministerio>();
        }

        public Ministerio MinisterioSelecionado
        {
            get
            {
                return ministerioSelecionado;
            }
            set
            {
                ministerioSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(ministerioSelecionado, "MinisterioSelecionado");
            }
        }

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        public async Task GetMinisterios()
        {
            Aguarde = true;
            HttpClient cliente = new HttpClient();

            try
            {
                var resultado = await cliente.GetStringAsync(URL_GET_MINISTERIOS);

                var MinisterioJson = JsonConvert.DeserializeObject<Ministerio[]>(resultado);

                this.Ministerios.Clear();
                foreach (var m in MinisterioJson)
                {
                    this.Ministerios.Add(new Ministerio
                    {
                        Nome = m.Nome,
                        Ministro_ = m.Ministro_,
                        Celulas = m.Celulas,
                        Maximo_pessoa = m.Maximo_pessoa,
                        Pessoas = m.Pessoas,
                        Proposito = m.Proposito,
                        IdMinisterio = m.IdMinisterio
                    });
                }
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaListagem");
            }
            Aguarde = false;
        }
    }
}
