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

        private static MDIFinanceiro instancia;

        public static MDIFinanceiro InstanciaMDI()
        {
            {
                if (instancia == null)
                {
                    instancia = new MDIFinanceiro();
                    return instancia;
                }
                return instancia;

            }
        }
    }
}
