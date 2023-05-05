using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class Gasolinera
    {
        private Deposito _depositoDiesel = new Deposito();
        private Deposito _depositoRegular = new Deposito();
        private Deposito _depositoSuper = new Deposito();

        private Bomba _bomba1 = new Bomba();
        private Bomba _bomba2 = new Bomba();
        private Bomba _bomba3 = new Bomba();
        private Bomba _bomba4 = new Bomba();

        public Gasolinera()
        {
            // Metodo Constructor
            // Aqui seteamos varias cosas, como la cantidad de combustible con la que inicia la gasolinera, por ejemplo
            // o tambien, los precios de cada combustible.
        }
        public void RecargarCombustible()
        {

        }
        public void VentaCombustible(int tipoCombustible, int numeroBomba, int tipoVenta, int cantidad, double dineroAGalones)
        {
          
        }
    }
}
