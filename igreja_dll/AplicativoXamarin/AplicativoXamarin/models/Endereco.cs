using AplicativoXamarin.models.Pessoas;
using Newtonsoft.Json;

namespace AplicativoXamarin.models
{

    public class Endereco 
    {
        public int Id { get; set; }
        public virtual PessoaDado Pessoa { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero_casa { get; set; }
        public long Cep { get; set; }
        public string Complemento { get; set; }

        public Endereco()
        {
        }

        public string RetornaJson(Endereco end)
        {
            var j = JsonConvert.SerializeObject(new Endereco
            {
                Id = end.Id,
                Pais = end.Pais,
                Estado = end.Estado,
                Cidade = end.Cidade,
                Bairro = end.Bairro,
                Rua = end.Rua,
                Numero_casa = end.Numero_casa,
                Cep = end.Cep,
                Complemento = end.Complemento
            });

            return j;
        }

    }

}
