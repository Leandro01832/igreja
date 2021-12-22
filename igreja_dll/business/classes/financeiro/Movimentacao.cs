using database;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace business.classes.financeiro
{
    [Table("Movimentacao")]
    public abstract class Movimentacao : modelocrud
    {
        public Movimentacao()
        {
            Data = DateTime.Now;
        }

        private decimal valor;

        public static int UltimoRegistro;

        [OpcoesBase(Obrigatorio =true)]
        public decimal Valor
        {            
            get {

                if (valor == 0)
                    throw new Exception("Valor");

                string texto = valor.ToString("N", CultureInfo.CreateSpecificCulture("en-US"));
                return decimal.Parse(texto, CultureInfo.CreateSpecificCulture("en-US"));
            }
            set
            {
                valor = value;
                if (valor == 0)
                    throw new Exception("Valor");
            }
        }
        public DateTime Data { get; set; }

        public bool Pago { get; set; }
        
        public override string ToString()
        {
            return "Identificação: " + this.Id.ToString() + " - " + this.Data.ToString("dd/MM/yyyy");
        }
    }
}
