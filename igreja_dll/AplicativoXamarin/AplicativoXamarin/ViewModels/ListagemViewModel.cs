using AplicativoXamarin.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {

        const string URL_GET_MINISTERIOS = "http://www.igrejadeusbom.somee.com/api/MinisterioApi";
        
        const string URL_GET_REUNIOES = "http://www.igrejadeusbom.somee.com/api/ReuniaoApi";

        string URL_GET_MINISTERIOPESSOA =
            "http://www.igrejadeusbom.somee.com/api/PessoaMinisterioApi?$filter=PessoaId" + " eq "
            + App.UserCurrent.IdPessoa.ToString();

        string URL_GET_REUNIAOPESSOA =
            "http://www.igrejadeusbom.somee.com/api/ReuniaoPessoaApi?$filter=PessoaId" + " eq "
            + App.UserCurrent.IdPessoa.ToString();

        public ObservableCollection<Ministerio> Ministerios { get; set; }
        public ObservableCollection<Reuniao> Reunioes { get; set; }
        

        Reuniao reuniaoSelecionado;
        public Reuniao ReuniaoSelecionado
        {
            get
            {
                return reuniaoSelecionado;
            }
            set
            {
                reuniaoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(reuniaoSelecionado, "ReuniaoSelecionado");
            }
        }

        Reuniao reuniaoSelecionadoUsuario;
        public Reuniao ReuniaoSelecionadoUsuario
        {
            get
            {
                return reuniaoSelecionadoUsuario;
            }
            set
            {
                reuniaoSelecionadoUsuario = value;
                if (value != null)
                    MessagingCenter.Send(reuniaoSelecionadoUsuario, "ReuniaoSelecionadoUsuario");
            }
        }

        Ministerio ministerioSelecionado;
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

        Ministerio ministerioSelecionadoUsuario;
        public Ministerio MinisterioSelecionadoUsuario
        {
            get
            {
                return ministerioSelecionadoUsuario;
            }
            set
            {
                ministerioSelecionadoUsuario = value;
                if (value != null)
                    MessagingCenter.Send(ministerioSelecionadoUsuario, "MinisterioSelecionadoUsuario");
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


        public ListagemViewModel()
        {
            this.Ministerios = new ObservableCollection<Ministerio>();
            this.Reunioes = new ObservableCollection<Reuniao>();
             
        }

        public async Task GetMinisterios(bool recuperarTodos)
        {
            Aguarde = true;
            try
            {
                HttpClient cliente = new HttpClient();

                var resultadoLista = await cliente.GetStringAsync(URL_GET_MINISTERIOPESSOA);
                var listaPessoaMinisterio = JsonConvert.DeserializeObject<PessoaMinisterio[]>(resultadoLista);
               
                if (!recuperarTodos)
                {
                    this.Ministerios.Clear();
                    foreach (var ministerioJson in listaPessoaMinisterio)
                    {
                        this.Ministerios.Add(new Ministerio
                        {                            
                            Nome = ministerioJson.Ministerio.Nome,
                            IdMinisterio = ministerioJson.Ministerio.IdMinisterio,
                            Celulas = ministerioJson.Ministerio.Celulas,
                            Maximo_pessoa = ministerioJson.Ministerio.Maximo_pessoa,
                            Ministro_ = ministerioJson.Ministerio.Ministro_,
                            Pessoas = ministerioJson.Ministerio.Pessoas,
                            Proposito = ministerioJson.Ministerio.Proposito
                        });
                    }
                }
                else
                {
                    
                    var resultado = await cliente.GetStringAsync(URL_GET_MINISTERIOS);

                   var lista = JsonConvert.DeserializeObject<Ministerio[]>(resultado);

                    this.Ministerios.Clear();
                    foreach (var ministerioJson in lista)
                    {
                        if(listaPessoaMinisterio != null)
                        {
                            if (listaPessoaMinisterio.FirstOrDefault(i => i.MinisterioId == ministerioJson.IdMinisterio) == null &&
                           listaPessoaMinisterio.FirstOrDefault(i => i.PessoaId == App.UserCurrent.IdPessoa) == null ||
                           listaPessoaMinisterio.FirstOrDefault(i => i.MinisterioId == ministerioJson.IdMinisterio) == null &&
                           listaPessoaMinisterio.FirstOrDefault(i => i.PessoaId == App.UserCurrent.IdPessoa) != null ||
                           listaPessoaMinisterio.FirstOrDefault(i => i.MinisterioId == ministerioJson.IdMinisterio) != null &&
                           listaPessoaMinisterio.FirstOrDefault(i => i.PessoaId == App.UserCurrent.IdPessoa) == null)
                                this.Ministerios.Add(new Ministerio
                                {
                                    Nome = ministerioJson.Nome,
                                    IdMinisterio = ministerioJson.IdMinisterio,
                                    Celulas = ministerioJson.Celulas,
                                    Maximo_pessoa = ministerioJson.Maximo_pessoa,
                                    Ministro_ = ministerioJson.Ministro_,
                                    Pessoas = ministerioJson.Pessoas,
                                    Proposito = ministerioJson.Proposito
                                });
                        }
                        else
                        {
                            this.Ministerios.Add(new Ministerio
                            {
                                Nome = ministerioJson.Nome,
                                IdMinisterio = ministerioJson.IdMinisterio,
                                Celulas = ministerioJson.Celulas,
                                Maximo_pessoa = ministerioJson.Maximo_pessoa,
                                Ministro_ = ministerioJson.Ministro_,
                                Pessoas = ministerioJson.Pessoas,
                                Proposito = ministerioJson.Proposito
                            });
                        }
                        
                    }
                }               
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaListagemMinisterio");
            }
            Aguarde = false;
        }        

        public async Task GetReunioes(bool recuperarTodos)
        {
            Aguarde = true;

            try
            {
                HttpClient cliente = new HttpClient();

                var resultadoLista = await cliente.GetStringAsync(URL_GET_REUNIAOPESSOA);
                var listaReuniaoPessoa = JsonConvert.DeserializeObject<ReuniaoPessoa[]>(resultadoLista);

                if (!recuperarTodos)
                {
                    this.Reunioes.Clear();
                    foreach (var reuniao in listaReuniaoPessoa)
                    {
                        this.Reunioes.Add(new Reuniao
                        {
                            Data_reuniao = reuniao.Reuniao.Data_reuniao,
                            Horario_fim = reuniao.Reuniao.Horario_fim,
                            Horario_inicio = reuniao.Reuniao.Horario_inicio,
                            Id = reuniao.Reuniao.Id,
                            Local_reuniao = reuniao.Reuniao.Local_reuniao,
                            Pessoas = reuniao.Reuniao.Pessoas
                        });
                    }
                }
                else
                {
                    var resultado = await cliente.GetStringAsync(URL_GET_REUNIOES);

                    var lista = JsonConvert.DeserializeObject<Reuniao[]>(resultado);

                    this.Reunioes.Clear();
                    foreach (var reuniao in lista)
                    {
                        //condicao que indica se usuario não pertence a esta reuniao
                        if(listaReuniaoPessoa != null)
                        {
                            if (listaReuniaoPessoa.FirstOrDefault(i => i.ReuniaoId == reuniao.Id) == null &&
                           listaReuniaoPessoa.FirstOrDefault(i => i.PessoaId == App.UserCurrent.IdPessoa) == null ||
                           listaReuniaoPessoa.FirstOrDefault(i => i.ReuniaoId == reuniao.Id) != null &&
                           listaReuniaoPessoa.FirstOrDefault(i => i.PessoaId == App.UserCurrent.IdPessoa) == null ||
                           listaReuniaoPessoa.FirstOrDefault(i => i.ReuniaoId == reuniao.Id) == null &&
                           listaReuniaoPessoa.FirstOrDefault(i => i.PessoaId == App.UserCurrent.IdPessoa) != null)
                                this.Reunioes.Add(new Reuniao
                                {
                                    Data_reuniao = reuniao.Data_reuniao,
                                    Horario_fim = reuniao.Horario_fim,
                                    Horario_inicio = reuniao.Horario_inicio,
                                    Id = reuniao.Id,
                                    Local_reuniao = reuniao.Local_reuniao,
                                    Pessoas = reuniao.Pessoas
                                });
                        }
                        else
                        {
                            this.Reunioes.Add(new Reuniao
                            {
                                Data_reuniao = reuniao.Data_reuniao,
                                Horario_fim = reuniao.Horario_fim,
                                Horario_inicio = reuniao.Horario_inicio,
                                Id = reuniao.Id,
                                Local_reuniao = reuniao.Local_reuniao,
                                Pessoas = reuniao.Pessoas
                            });
                        }                        
                    }
                }                
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaListagemReuniao");
            }
            Aguarde = false;
        }        
    }

    
}
