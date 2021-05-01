using AplicativoXamarin.models;
using AplicativoXamarin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
   public class ViewModelCell : BaseViewModel
    {
        const string URL_GET_CELULAS = "http://www.igrejadeusbom.somee.com/api/CelulaApi";
        const string URL_GET_PESSOAS = "http://www.igrejadeusbom.somee.com/api/PessoaApi";
        const string URL_GET_MINISTERIOS = "http://www.igrejadeusbom.somee.com/api/MinisterioApi";
        const string URL_GET_MINISTERIOS_REST = "http://www.igrejadeusbom.somee.com/api/MinisterioCelulaApi/?$filter=" +
        "CelulaId eq ";
        public Celula Celula { get; set; }

        public ObservableCollection<Celula> Celulas { get; set; }
        public ObservableCollection<Ministerio> Ministerios { get; set; }
        public ObservableCollection<Pessoa> Pessoas { get; set; }

        public ICommand ConfirmJoinCell { get; set; }
        public ICommand ViewMinistries { get; set; }
        public ICommand ViewPeoples { get; set; }

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
            Ministerios = new ObservableCollection<Ministerio>();
            Pessoas = new ObservableCollection<Pessoa>();

            ConfirmJoinCell = new Command(() =>
            {
                MessagingCenter.Send<Celula>(CelulaSelecionado, "ParticiparCelula");

            });

            ViewMinistries = new Command(() =>
            {
              //  App.Current.MainPage.Navigation.PushAsync(new m);

            });

            ViewPeoples = new Command(() =>
            {
                //  App.Current.MainPage.Navigation.PushAsync(new m);

            });

        }

        public async Task GetCelulas()
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

        public async Task GetPessoas()
        {
            Aguarde = true;

            try
            {
                HttpClient cliente = new HttpClient();

                var resultadoLista = await cliente.GetStringAsync(URL_GET_PESSOAS);
                var lista = JsonConvert.DeserializeObject<List<Pessoa>>(resultadoLista);

                this.Pessoas.Clear();
                foreach (var pes in lista.Where(i => i.celula_ == Celula.IdCelula))
                {
                    this.Pessoas.Add(new Pessoa
                    {
                        Celula = pes.Celula,
                        celula_ = pes.celula_,
                        Chamada = pes.Chamada,
                        Codigo = pes.Codigo,
                        Email = pes.Email,
                        Falta = pes.Falta,
                        Historico = pes.Historico,
                        IdPessoa = pes.IdPessoa,
                        Img = pes.Img,
                        Ministerios = pes.Ministerios,
                        NomePessoa = pes.NomePessoa,
                        Reuniao = pes.Reuniao
                    });
                }

            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaListagem");
            }
            Aguarde = false;
        }

        public async Task GetMinisterios()
        {
            Aguarde = true;

            try
            {
                HttpClient cliente = new HttpClient();

                var resultadoTodosLista = await cliente.GetStringAsync(URL_GET_MINISTERIOS);
                var listatodos = JsonConvert.DeserializeObject<List<Ministerio>>(resultadoTodosLista);

                var resultadoListaRestrita = await cliente.GetStringAsync(URL_GET_MINISTERIOS_REST);
                var listaRestrita = JsonConvert.DeserializeObject<List<MinisterioCelula>>(resultadoListaRestrita);

                this.Ministerios.Clear();
                foreach (var ministerio in listatodos.Where(i => i.IdMinisterio == listaRestrita
                .First(r => r.MinisterioId == i.IdMinisterio).MinisterioId))
                {
                    this.Ministerios.Add(new Ministerio
                    {
                        IdMinisterio = ministerio.IdMinisterio,
                        Celulas = ministerio.Celulas,
                        Maximo_pessoa = ministerio.Maximo_pessoa,
                        Ministro_ = ministerio.Ministro_,
                        Nome = ministerio.Nome,
                        Pessoas = ministerio.Pessoas,
                        Proposito = ministerio.Proposito
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
