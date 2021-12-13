using business.classes;
using business.classes.Abstrato;
using business.classes.Intermediario;
using database;
using database.banco;
using System;
using System.Linq;

namespace business.implementacao
{
    public class Calculo 
    {
        public void CalcularPorcentagem()
        {
            try
            {

                var totalRegistros = modelocrud.TotalRegistro(null, BDcomum.conecta1);

                var modelos = modelocrud.Modelos.Count;

                var porcentagem = ((100 * modelos) / totalRegistros);
                modelocrud.textoPorcentagem = porcentagem.ToString() + "%";
            }
            catch (Exception ex) { var message = ex.Message; }
        }
    }
}
