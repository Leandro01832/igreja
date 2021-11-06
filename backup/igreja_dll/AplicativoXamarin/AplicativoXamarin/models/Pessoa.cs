using AplicativoXamarin.models.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoXamarin.models
{
   public class Pessoa : modelocrud,  IMudancaEstado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }
        public int Codigo { get; set; }
        public string Email { get; set; }
        public int Falta { get; set; }
        public int? celula_ { get; set; }
        [Ignore]
        public virtual Celula Celula { get; set; }
        [Ignore]
        public virtual Chamada Chamada { get; set; }
        [Ignore]
        public virtual List<PessoaMinisterio> Ministerios { get; set; }
        [Ignore]
        public virtual List<Historico> Historico { get; set; }
        [Ignore]
        public virtual List<ReuniaoPessoa> Reuniao { get; set; }

        public Pessoa()
        {
            MudancaEstado = new MudancaEstado();
            Chamada = new Chamada
            {
                Data_inicio = DateTime.Now,
                Numero_chamada = 0
            };
        }

        public string Img { get; set; }

        public string Foto { get { return "http://www.igrejadeusbom.somee.com" + Img; } }

        public string password { get;  set; }
        public bool Lembrar_me { get; set; }
        [Ignore]
        public MudancaEstado MudancaEstado { get; set; }
        

        public void MudarEstado(int id, Pessoa m)
        {
            MudancaEstado.MudarEstado(id, m);
        }
    }

    public class LoginResult
    {
        public Pessoa usuario { get; set; }
    }
}
