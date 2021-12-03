using business.classes.Abstrato;
using business.classes.Pessoas;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(MDISingleton.InstanciaMDI());
          //  Application.Run(new Pesquisar(typeof(Membro_Transferencia)));
        }
    }
}
