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
        public Fonte(bool v) : base(v)
        {

        }        
        
        public int MensagemId { get; set; }
        [ForeignKey("MensagemId")]
        public virtual Mensagem Mensagem { get; set; }        

        public static void recuperarTodasFontes()
        {
            List<Type> lista = listTypes(typeof(Fonte));
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