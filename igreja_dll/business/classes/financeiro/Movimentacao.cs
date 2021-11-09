using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        private double valor;

        [NotMapped]
        public static int UltimoRegistro;

        public double Valor
        {

            get { return double.Parse(valor.ToString().Replace(",", ".")); }
            set { valor = value; }
        }
        public DateTime Data { get; set; }

        public bool Pago { get; set; }

        public async static void recuperarTodos()
        {
            List<Type> list = listTypes(typeof(Movimentacao));
            foreach (var item in list)
            {
                var modelo = (modelocrud)Activator.CreateInstance(item);
                await Task.Run(() => modelo.recuperar());
            }
        }

        public override string ToString()
        {
            return "Identificação: " + this.Id.ToString() + " - " + this.Data.ToString("dd/MM/yyyy");
        }
    }
}
