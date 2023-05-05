using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class Bomba
    {

        private double CombustibleDespachado;
        private double DineroVentas;


        public double GetCombustibleDespachadoGalones()
        {
            return CombustibleDespachado;
        }
        public double GetDineroVentas()
        {
            return DineroVentas;
        }

        public void DespacharCombustibleGalones(TipoDeCombustible tipo, double galones, double dineroVentas)
        {
            CombustibleDespachado += galones;
            double combustibledespachado = CombustibleDespachado;
            dineroVentas = combustibledespachado * tipo.getPrecio();


        }
    }
}