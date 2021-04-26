using AplicativoXamarin.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
   public class JoinViewModel : BaseViewModel
    {
        public Ministerio Ministerio { get; set; }
        public Reuniao Reuniao { get; set; }
        public ICommand ParticipandoMinisterio { get; set; }
        public ICommand ParticipandoReuniao { get; set; }

        public ObservableCollection<Pessoa> PessoasDoMinisterio { get; set; }
        public ObservableCollection<Pessoa> PessoasDaReuniao { get; set; }

        string Url_Get_PessoaMinisterio =
            "http://www.igrejadeusbom.somee.com/api/PessoaMinisterioApi?filter=MinisterioId" + " eq ";
            

        string Url_Get_ReuniaoPessoa =
            "http://www.igrejadeusbom.somee.com/api/ReuniaoPessoaApi?filter=ReuniaoId" + " eq ";

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


        public JoinViewModel()
        {
            PessoasDaReuniao = new ObservableCollection<Pessoa>();
            PessoasDoMinisterio = new ObservableCollection<Pessoa>();

            ParticipandoMinisterio = new Command(() =>
            {
                MessagingCenter.Send<Ministerio>(this.Ministerio
                    , "ConfirmaMinisterio");
            });

            ParticipandoReuniao = new Command(() =>
            {
                MessagingCenter.Send<Reuniao>(this.Reuniao
                    , "ConfirmaReuniao");
            });
        }


        public async Task GetPessoas(bool ministerio)
        {
            Aguarde = true;
            try
            {
                HttpClient cliente = new HttpClient();               

                if (ministerio)
                {
                    var resultadoLista = await cliente.GetStringAsync(Url_Get_PessoaMinisterio + Ministerio.IdMinisterio.ToString());
                    var listaPessoaMinisterio = JsonConvert.DeserializeObject<PessoaMinisterio[]>(resultadoLista);
                    this.PessoasDoMinisterio.Clear();
                    foreach (var pessoaMinisterio in listaPessoaMinisterio)
                    {
                        this.PessoasDoMinisterio.Add(new Pessoa
                        {
                            Celula = pessoaMinisterio.Pessoa.Celula,
                            celula_ = pessoaMinisterio.Pessoa.celula_,
                            Chamada = pessoaMinisterio.Pessoa.Chamada,
                            Codigo = pessoaMinisterio.Pessoa.Codigo,
                            Email = pessoaMinisterio.Pessoa.Email,
                            Falta = pessoaMinisterio.Pessoa.Falta,
                            Historico = pessoaMinisterio.Pessoa.Historico,
                            IdPessoa = pessoaMinisterio.Pessoa.IdPessoa,
                            Img = pessoaMinisterio.Pessoa.Img,
                            Ministerios = pessoaMinisterio.Pessoa.Ministerios,
                            NomePessoa = pessoaMinisterio.Pessoa.NomePessoa,
                            Reuniao = pessoaMinisterio.Pessoa.Reuniao                                     
                        });
                    }
                }
                else
                {
                    var resultado = await cliente.GetStringAsync(Url_Get_ReuniaoPessoa + Reuniao.IdReuniao.ToString());
                    var lista = JsonConvert.DeserializeObject<ReuniaoPessoa[]>(resultado);

                    this.PessoasDaReuniao.Clear();
                    foreach (var reuniaoPessoa in lista)
                    {
                        
                            this.PessoasDaReuniao.Add(new Pessoa
                            {
                                Celula = reuniaoPessoa.Pessoa.Celula,
                                celula_ = reuniaoPessoa.Pessoa.celula_,
                                Chamada = reuniaoPessoa.Pessoa.Chamada,
                                Codigo = reuniaoPessoa.Pessoa.Codigo,
                                Email = reuniaoPessoa.Pessoa.Email,
                                Falta = reuniaoPessoa.Pessoa.Falta,
                                Historico = reuniaoPessoa.Pessoa.Historico,
                                IdPessoa = reuniaoPessoa.Pessoa.IdPessoa,
                                Img = reuniaoPessoa.Pessoa.Img,
                                Ministerios = reuniaoPessoa.Pessoa.Ministerios,
                                NomePessoa = reuniaoPessoa.Pessoa.NomePessoa,
                                Reuniao = reuniaoPessoa.Pessoa.Reuniao
                            });
                        

                    }
                }
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaListagemMinisterio");
            }
            Aguarde = false;
        }

    }
}
