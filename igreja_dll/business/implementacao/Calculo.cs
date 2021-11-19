using business.classes;
using business.classes.Abstrato;
using business.classes.Intermediario;
using database;
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

                var modelos = 0;

                var lista = modelocrud.listTypes(typeof(modelocrud));

                foreach(var item in lista)
                    modelos += modelocrud.Modelos.Where(m => m.GetType() == item).ToList().Count;

                var porcentagem = (int)((100 * modelos) / totalRegistros);
                modelocrud.textoPorcentagem = porcentagem.ToString() + "%";
            }
            catch { }
        }
    }
}
