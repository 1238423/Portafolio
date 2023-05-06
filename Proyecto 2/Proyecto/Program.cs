
using Driver;
using System.Security.Cryptography.X509Certificates;

namespace Proyecto
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Ejemplo de como utilizar el driver en su sistema/proyecto

            //string[] ListaDeDpis = Driver.BlockchainConnector.ActualizarDpis();
            string[,] presidentes = Driver.BlockchainConnector.CandidatosPresidentes();
            string[,] diputados = Driver.BlockchainConnector.CandidatosDiputados();

            // Registrar un voto recibe los 4 parametros del enunciado
            // en el caso de los parametros 2 y 3, los Guid.NewGuid(), estos seran reemplzados
            // por los ids del presidente y diputado electo por el votante, respectivamente
            // Aqui solo se han utilizado como ejemplos.

        
            // Utiliza la lista de DPIs registrados 
            // Obtener la lista de DPIs que ya han registrado su voto
            Console.WriteLine("DPIs ya registrados");

            lista_de_dpis_registrados dpisRegistrados = new lista_de_dpis_registrados();
            dpisRegistrados.lista();




            Console.WriteLine("Presione enter para continuar");
            Console.ReadKey();

            string[] listaDpis = BlockchainConnector.ActualizarDpis();

            //2------------------------------------------------------------------------------------------------------------------------------
            // Segunda parte del enunciado. Parte 1. Vista del usuario
            Console.WriteLine("Bienvenido al sistema de votación.");
            Console.Write("Por favor ingrese su número de DPI: ");
            string dpi = Console.ReadLine();

            //cambio de string de ejemplo a la variable dpi - AGREGA EL DATO DEL USUARIO A LA LISTA DE DPIs
            string[] ListaDeDpis = Driver.BlockchainConnector.ActualizarDpis();
            ListaDeDpis = Driver.BlockchainConnector.RegistrarVoto(dpi, Guid.NewGuid(), Guid.NewGuid(), "nick");

            

           
           
            // Validar si el DPI ya fue utilizado.
            

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


            // TERCERA PARTE DEL ENUNCIADO ------- VIST PARA VOTACIÓN DEL PRESIDENTE
            switch (opcion)
            {
                case "1":
                    //Muestra los candidatos a presidente
                    string[,] candidatosPresidentes = BlockchainConnector.CandidatosPresidentes();

                    for (int i = 0; i < candidatosPresidentes.GetLength(0); i++)
                    {
                        string id = candidatosPresidentes[i, 0];
                        string nombreCandidato = candidatosPresidentes[i, 1];
                        string nombrePartido = candidatosPresidentes[i, 2];
                        string vicepresidente = candidatosPresidentes[i, 3];

                        // Aquí puedes mostrar los datos del candidato en la interfaz de usuario
                        Console.WriteLine("Candidato {0}:", i + 1);
                        Console.WriteLine("ID: {0}", id);
                        Console.WriteLine("Nombre: {0}", nombreCandidato);
                        Console.WriteLine("Partido: {0}", nombrePartido);
                        Console.WriteLine("Vicepresidente: {0}", vicepresidente);
                        Console.WriteLine();
                    }

                    // lógica para elegir presidente
                    break;
                case "2":
                    //Muestra los canditados a diputado
                    string[,] candidatosDiputados = BlockchainConnector.CandidatosDiputados();
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