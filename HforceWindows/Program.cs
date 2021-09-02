using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HforceWindows
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Splash.Splash());
            //Application.Run(new Menus.Remision.RemisionNuevo());
            Application.Run(new Menus.Clientes.ClienteNuevo());
            //Application.Run(new pruebas());
        }
    }
}
