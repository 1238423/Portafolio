using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class lista_de_dpis_registrados
    {
        public void lista()
        {
            string[] ListaDeDpis = Driver.BlockchainConnector.ActualizarDpis();
            foreach (string s in ListaDeDpis) // lee los objetos y los parsea por i.   // MUESTRA LOS DPIs que se han ingresado.
            {
                Console.WriteLine(s);
            }
        }
    }
}
