using _1238423_semana11_cajero__25_de_marzo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1238423_semana11_cajero__25_de_marzo
{
    internal class cajero //Guardar las transacciones en el cajero
    {
        transaccion[] transacciones = new transaccion[1000];

        public void retirarD()
        {
            Console.WriteLine("ingrese el numero de tarjeta; ");
            string numeroT = Console.ReadLine();

            Console.WriteLine("ingrese el monto a retirar: ");
            decimal cantidadR = decimal.Parse(Console.ReadLine()); 

            cantidadR = validarRetiro(numeroT, cantidadR); //no olvidar validar antes de ejecutar. EN este caso es solo si es de credito o de debito 
            bool resultadoTra = generalT(numeroT, cantidadR);

            if (resultadoTra)
            {
                Console.WriteLine("su retiro fue exitoso. Presione cualquier numero para continuar.");
            }
            else
            {
                Console.WriteLine("no se pudo completar la transaccion ");
            }
        }
        public decimal validarRetiro(string numeroT, decimal cantidadR)
        {
            String tipoT = numeroT[0].ToString();  

            if (tipoT == "0") //EL indice empieza en cero por lo que toma el primer caracter/ el primer digito
            {
                Console.WriteLine("su tarjerta es de debito ");
                Console.WriteLine("se retirara; " + cantidadR);
            }
            if (tipoT == "1")
            {
                cantidadR = cantidadR * 1.05m;
                Console.WriteLine("su tarjerta es de credito ");
                Console.WriteLine("se retirara; " + cantidadR);
            }
            return cantidadR;
        }
        public bool generalT(string numeroT, decimal cantidadR)
        {
            for (int i = 0; i < transacciones.Length; i++)
            {
                if (transacciones[i] != null) //Buscar en todo el arreglo si ya tegno la tarjeta resgistrada en una transaccion anterior

                {
                    //encontrar una transaccion con la misma tarjeta
                    if (numeroT.Contains(transacciones[i].NoTarjeta))
                    {
                        transacciones[i].credito += cantidadR;
                        return true;
                    }
                }
            }
            transaccion nuevaTra = new transaccion();
            nuevaTra.NoTarjeta = numeroT;
            nuevaTra.credito = cantidadR;

            for (int i = 0; i < transacciones.Length; i++)
            {
                if (transacciones[i] == null)
                {
                    transacciones[i] = nuevaTra;
                    return true;
                }
            }
            return false;
        }
        public void mostraT()
        {
            for (int i = 0; i < transacciones.Length; i++)
            {
                Console.WriteLine("Trancacion " + 1);
                Console.WriteLine("tarjeta  " + transacciones[i].NoTarjeta);
                Console.WriteLine("credito: " + transacciones[i].credito);
            }
        }
    }
}