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
        public Movimentacao(bool v) : base(v)
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
