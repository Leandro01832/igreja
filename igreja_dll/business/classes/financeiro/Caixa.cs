using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Classe.financeiro
{
    public class Caixa : modelocrud
    {
        [NotMapped]
        public static int DiaMesFechamento { get; set; }
        [NotMapped]
        public static string Status { get; set; }
        [NotMapped]
        public static double Saldo {get;set;}


        public void calcularSaldoCaixa(bool liquido)
        {
            double valorPagar = 0;
            double valorReceber = 0;
            var contasPagar = Modelos.OfType<MovimentacaoSaida>();
            var contasReceber = Modelos.OfType<MovimentacaoEntrada>();

            if(contasPagar != null)
            foreach (var item in contasPagar.Where(c => !c.Pago && c.Data.Day < DiaMesFechamento))
                valorPagar += item.Valor;


            if (liquido)
            {
                if(contasReceber != null)
                foreach (var item in contasReceber.Where(c => !c.Pago 
                && c.Data.Day < DiaMesFechamento || c.Pago && c.Data.Day < DiaMesFechamento))
                    valorReceber += item.Valor;

                Saldo = valorReceber - valorPagar;

                if (Saldo > 0) Status = "Saldo Positivo liquido: " + Saldo.ToString();
                else Status = "Saldo Negativo liquido: " + Saldo.ToString(); 
            }

            else
            {
                Saldo = valorReceber - valorPagar;
                if (contasReceber != null)
                    foreach (var item in contasReceber.Where(c => c.Pago
                    && c.Data.Day < DiaMesFechamento))
                        valorReceber += item.Valor;

                Saldo = valorReceber - valorPagar;

                if (Saldo > 0) Status = "Saldo Positivo bruto: " + Saldo.ToString();
                else Status = "Saldo Negativo bruto: " + Saldo.ToString(); 
            }

        }
    }


}
