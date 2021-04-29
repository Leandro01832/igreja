using AplicativoXamarin.models;
using AplicativoXamarin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
   public class ViewModelCell : BaseViewModel
    {
        const string URL_GET_CELULAS = "http://www.igrejadeusbom.somee.com/api/CelulaApi";
        public Celula Celula { get; set; }

        public ObservableCollection<Celula> Celulas { get; set; }

       private Celula celulaSelecionado;
        public Celula CelulaSelecionado
        {
            get
            {
                return celulaSelecionado;
            }
            set
            {
                celulaSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(celulaSelecionado, "CelulaSelecionado");
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

        public ViewModelCell()
        {
            Celulas = new ObservableCollection<Celula>();
            
        }

        public async System.Threading.Tasks.Task GetCelulas()
        {
            Aguarde = true;

            try
            {
                HttpClient cliente = new HttpClient();

                var resultadoLista = await cliente.GetStringAsync(URL_GET_CELULAS);
                var listaCelulas = JsonConvert.DeserializeObject<Celula[]>(resultadoLista);
                
                    this.Celulas.Clear();
                    foreach (var celula in listaCelulas)
                    {
                    this.Celulas.Add(new Celula
                    {
                        Dia_semana = celula.Dia_semana,
                        EnderecoCelula = celula.EnderecoCelula,
                        Horario = celula.Horario,
                        IdCelula = celula.IdCelula,
                        Maximo_pessoa = celula.Maximo_pessoa,
                        Ministerios = celula.Ministerios,
                        Nome = celula.Nome,
                        Pessoas = celula.Pessoas
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
