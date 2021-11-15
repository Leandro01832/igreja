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

        private static FrmPrincipal instancia;

        public static FrmPrincipal InstanciaMDI()
        {
            {
                if (instancia == null)
                {
                    instancia = new FrmPrincipal();
                    return instancia;
                }
                return instancia;

            }
        }
    }
}
