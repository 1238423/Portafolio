using System;
using System.Runtime.CompilerServices;

namespace Proyecto_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salirDelMenu = false;
            do
            {
                Console.WriteLine("Precio inicial del combustible...");
                Console.WriteLine("Ingrese su tipo de venta: ");
                Console.WriteLine("1. Cantidad de galones a dinero.");
                Console.WriteLine("2. Cantidad de dinero a galones.");
               

                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        {
                            Console.WriteLine("Tipo de combustible (Seleccione el numero): ");
                            Console.WriteLine("1. Regular");
                            Console.WriteLine("2. Super");
                            Console.WriteLine("3. Diesel");
                            int tipoCombustible = int.Parse(Console.ReadLine());

                            if (tipoCombustible == 1)
                            {
                                Console.WriteLine("Ingrese la cantidad de galones que desea despachar...");
                                double cantidad = double.Parse(Console.ReadLine());

                                if (cantidad <= 50) //_depositoDiesel.Reversa
                                {
                                    Console.WriteLine("No se puede hacer la venta...");
                                    return;
                                }
                                else if (cantidad > 50)  //_depositoDiesel.Reversa
                                {
                                    Console.WriteLine("Va a despachar " + cantidad + " galones " + "Costo = precio del combustible luego de ser modificado y dependiendo del tipo");
                                    return;
                                }
                            }

                        }
                        break;

                        case 2:
                        {
                            Console.WriteLine("Tipo de combustible (Seleccione el numero): ");
                            Console.WriteLine("1. Regular");
                            Console.WriteLine("2. Super");
                            Console.WriteLine("3. Diesel");
                            int tipoCombustible = int.Parse(Console.ReadLine());

                            if (tipoCombustible == 1)
                            {
                                Console.WriteLine("Ingrese la cantidad de Dinero que desea despachar...");
                                double cantidad = double.Parse(Console.ReadLine());

                                if (cantidad <= 50) //_depositoDiesel.Reversa
                                {
                                    Console.WriteLine("No se puede hacer la venta...");
                                    return;
                                }
                                else if (cantidad > 50)  //_depositoDiesel.Reversa
                                {
                                    Console.WriteLine("Va a despachar " + cantidad + " Dinero " + "Costo = precio del combustible luego de ser modificado y dependiendo del tipo");
                                    return;
                                }
                            }

                        }
                        break;

                    default:
                        Console.WriteLine("Esta opción no es valida");
                        salirDelMenu = true;
                        break;
                }

            } while (!salirDelMenu);

        }
    }
}
