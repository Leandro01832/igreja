using business.classes.Abstrato;

namespace business
{
    public class EmailIgreja : Email
    {
        public bool Enviado { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa  { get; set; }
        public Body Body { get; set; }
    }
}
