﻿
using Driver;

namespace Proyecto
{
    public class Program 
    {
        public static void Main(string[] args) 
        {

            // Ejemplo de como utilizar el driver en su sistema/proyecto

            string[] ListaDeDpis = Driver.BlockchainConnector.ActualizarDpis();
            string[,] presidentes = Driver.BlockchainConnector.CandidatosPresidentes();
            string[,] diputados = Driver.BlockchainConnector.CandidatosDiputados();

            // Registrar un voto recibe los 4 parametros del enunciado
            // en el caso de los parametros 2 y 3, los Guid.NewGuid(), estos seran reemplzados
            // por los ids del presidente y diputado electo por el votante, respectivamente
            // Aqui solo se han utilizado como ejemplos.
            ListaDeDpis = Driver.BlockchainConnector.RegistrarVoto("Rempplazar por un DPI", Guid.NewGuid(), Guid.NewGuid(), "nick");

            Console.WriteLine("DPIs ya registrados");
            foreach (string s in ListaDeDpis) // lee los objetos y los parsea por i. 
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();

            // Obtener la lista de DPIs que ya han registrado su voto
            string[] dpisRegistrados = Driver.BlockchainConnector.ActualizarDpis();

            // Utiliza la lista de DPIs registrados 

            Console.ReadKey();
            //2------------------------------------------------------------------------------------------------------------------------------
            // Segunda parte del enunciado. Parte 1. Vista del usuario
            Console.WriteLine("Bienvenido al sistema de votación.");
            Console.Write("Por favor ingrese su número de DPI: ");
            string dpi = Console.ReadLine();

            // Validar si el DPI ya fue utilizado.
            string[] listaDpis = BlockchainConnector.ActualizarDpis();

            if (listaDpis.Contains(dpi))
            {
                Console.WriteLine("Este DPI ya ha sido utilizado anteriormente.");
                // Aquí puedes mostrar un mensaje de error en la interfaz de usuario
            }
            else
            {
                Console.WriteLine("Bienvenido, puede continuar con el proceso de votación.");
                // Aquí puedes mostrar la siguiente vista para continuar con el proceso de votación
            }

            // SEGUNDA PARTE DEL ENUNCIADO. (MENU)
            Console.WriteLine("Bienvenido, por favor seleccione una opción:");
            Console.WriteLine("1. Elegir presidente");
            Console.WriteLine("2. Elegir diputado");
            Console.WriteLine("3. Finalizar votación");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // lógica para elegir presidente
                    break;
                case "2":
                    // lógica para elegir diputado
                    break;
                case "3":
                    Console.WriteLine("Gracias por votar.");
                    Console.ReadKey();
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                    return;
            }



        }

    }
    
}