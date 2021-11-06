using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class MDISingleton
    {
        private MDISingleton()
        {

        }

        private static MDI instancia;

        public static MDI InstanciaMDI()
        {
            {
                if (instancia == null)
                {
                    instancia = new MDI();
                    return instancia;
                }
                return instancia;

            }
        }
    }
}
