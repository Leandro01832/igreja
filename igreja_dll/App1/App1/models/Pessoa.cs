using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.models
{
   public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }
        public int Codigo { get; set; }
        public string Email { get; set; }
        public int Falta { get; set; }
        public int? celula_ { get; set; }
        public virtual Celula Celula { get; set; }
        public virtual Chamada Chamada { get; set; }
        public virtual List<PessoaMinisterio> Ministerios { get; set; }
        public virtual List<Historico> Historico { get; set; }
        public virtual List<ReuniaoPessoa> Reuniao { get; set; }
        public string Img { get; set; }
    }

    public class LoginResult
    {
        public Pessoa usuario { get; set; }
    }
}
