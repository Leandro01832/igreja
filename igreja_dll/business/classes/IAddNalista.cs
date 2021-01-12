using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes
{
    interface IAddNalista
    {
        void AdicionarNaLista(string NomeTabela, modelocrud modeloQRecebe, modelocrud modeloQPreenche, string numeros);
        void RemoverDaLista(string NomeTabela, modelocrud modeloQRecebe, modelocrud modeloQPreenche, string numeros);
    }
}
