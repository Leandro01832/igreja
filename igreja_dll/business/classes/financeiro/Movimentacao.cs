using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Threading.Tasks;

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

        public decimal Valor
        {            
            get {
                string texto = valor.ToString("N", CultureInfo.CreateSpecificCulture("en-US"));
                return decimal.Parse(texto, CultureInfo.CreateSpecificCulture("en-US"));
            }
            set { valor = value; }
        }
        public DateTime Data { get; set; }

        public bool Pago { get; set; }
        
        public override string ToString()
        {
            return "Identificação: " + this.Id.ToString() + " - " + this.Data.ToString("dd/MM/yyyy");
        }
    }
}
