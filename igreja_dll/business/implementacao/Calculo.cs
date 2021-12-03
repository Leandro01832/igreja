using business.classes;
using business.classes.Abstrato;
using business.classes.Intermediario;
using database;
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

                var totalRegistros = modelocrud.TotalRegistro(null);

                var modelos = modelocrud.Modelos.Count;

                var porcentagem = (int)((100 * modelos) / totalRegistros);
                modelocrud.textoPorcentagem = porcentagem.ToString() + "%";
            }
            catch (Exception ex) { var message = ex.Message; }
        }
    }
}
