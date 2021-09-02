using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HforceNegocio.Texto
{
    public class CiudadesTxt
    {
        public List<string>[] ListaCiudades()
        {
            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();

            System.IO.StreamReader ciudades = new System.IO.StreamReader(@"Resources\Ciudades.txt");

            while (ciudades.Peek() != -1)
            {
                string ciudad = ciudades.ReadLine();
                if (String.IsNullOrEmpty(ciudad))
                {
                    continue;
                }
                list[0].Add(ciudad);
            }
            ciudades.Close();

            return list;
        }
    }
}
