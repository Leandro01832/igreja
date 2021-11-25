using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

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

        public static void recuperarTodasFontes()
        {
            List<Type> lista = listTypesSon(typeof(Fonte));
            foreach(var item in lista)
            {
                var model = (modelocrud) Activator.CreateInstance(item);
                Task.Run(() => model.recuperar());
            }
            
        }      

        public override string ToString()
        {
            return "Id: " + base.Id.ToString() + " Tipo da msg: " + this.Mensagem.Tipo;
        }
    }
}