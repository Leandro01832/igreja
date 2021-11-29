using database;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Esboco.Abstrato
{
    [Table("Fonte")]
    public abstract class Fonte : modelocrud
    {
        public Fonte() : base()
        {

        }

        private int mensagemId = 0; 
        [OpcoesBase(ChaveEstrangeira = true, Obrigatorio =true)]
        public int MensagemId
        {
            get
            {
                if (mensagemId == 0)
                    throw new Exception("MensagemId");
                return mensagemId;
            }
            set { mensagemId = value; }
        }

        [ForeignKey("MensagemId")]
        public virtual Mensagem Mensagem { get; set; }    

        public override string ToString()
        {
            return "Id: " + base.Id.ToString() + " Tipo da msg: " + this.Mensagem.Tipo;
        }
    }
}