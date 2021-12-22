using database;
using System.Reflection;

namespace business.contrato
{
    public interface IValidate
    {
        void Validar(string valor, string name);
    }
}
