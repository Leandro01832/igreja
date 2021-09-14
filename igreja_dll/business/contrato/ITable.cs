using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.contrato
{
   public interface ITable
    {
        void CreateTable(Type tipo);
        void DeleteTable(Type tipo);
    }
}
