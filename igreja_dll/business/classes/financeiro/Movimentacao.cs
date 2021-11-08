using database;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.Classe.financeiro
{
    [Table("Movimentacao")]
    public abstract class Movimentacao : modelocrud
    {
        public Movimentacao()
        {
            Data = DateTime.Now;
        }

        private double valor;

        [NotMapped]
        public static int UltimoRegistro { get; set; }

        public double Valor
        {
            get { return double.Parse(valor.ToString("F2")); }
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
