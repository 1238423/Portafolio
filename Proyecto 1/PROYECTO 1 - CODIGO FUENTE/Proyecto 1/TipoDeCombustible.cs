using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class TipoDeCombustible
    {
        public int regular;
        public int super;
        public int diesel;
        private double PrecioRegular;
        private double PrecioSuper;
        private double PrecioDiesel;

        public double getPrecioR(int TipoDeCombustible) //Retorna los precios de los combustibles a publico
        {
            return PrecioRegular;
        }
        public double getPrecioS(int TipoDeCombustible) //Retorna los precios de los combustibles a publico
        {
            return PrecioSuper;
        }
        public double getPrecioD(int TipoDeCombustible) //Retorna los precios de los combustibles a publico
        {
            return PrecioDiesel;
        }

        public bool setPrecio(int tipoCombustible, double nuevoPrecio)
        {
            switch (tipoCombustible)
            {
                case 1:
                    if (PrecioRegular < nuevoPrecio)
                    {
                        PrecioRegular = nuevoPrecio;
                        return true;
                    }
                    break;


                case 2:
                    if (PrecioSuper < nuevoPrecio)
                    {
                        PrecioSuper = nuevoPrecio;
                        return true;
                    }
                    break;


                case 3:
                    if (PrecioDiesel < nuevoPrecio)
                    {
                        PrecioDiesel = nuevoPrecio;
                        return true;
                    }
                    break;
                default:

                    Console.WriteLine("Ingrese un numero de combustible valido...");
                    break;
            }

            return false;
        }
    }
}
        //public bool setPrecioSuper(decimal nuevoPrecio)
      //  {
        
          //  if (PrecioSuper < nuevoPrecio)
         //   {
         //       PrecioSuper = nuevoPrecio;
         //       return true;
          //  }
        //    return false;
     //   }
      //  public bool setPrecioDiesel(decimal nuevoPrecio)
      //  {
           
         //   if (PrecioDiesel < nuevoPrecio)
          //  {
             //   PrecioDiesel = nuevoPrecio;
           //     return true;
          //  }
        //    return false;
    //    }
  //  }
//}
//public class TipoDeCombustible
//{
    //public string regular;
   // public string super;
   // public string diesel;
   // private decimal precioRegular;
   // private decimal precioSuper;
   // private decimal precioDiesel;

   // public decimal getPrecio(string tipoCombustible)
  //  {
     //   switch (tipoCombustible)
      //  {
       //     case "regular":
         //       return precioRegular;
          //  case "super":
          //      return precioSuper;
          //  case "diesel":
          //      return precioDiesel;
          //  default:
           //     throw new ArgumentException("Tipo de combustible no válido.");
      //  }
  //  }
//}