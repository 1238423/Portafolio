using Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class MetodoPresidente
    {
        public static string dpi;
        public static string nick;
        private List<string> votosRegistrados; //REGISTRA LOS VOTOS - Aquí concluye la parte 3

        public MetodoPresidente()
        {
            votosRegistrados = new List<string>();
        }
        public void M_CandidatosPresidentes()
        {
            bool seleccionValida = false;

            while (!seleccionValida)
            {
                int seleccion;
                string[,] candidatosPresidentes = BlockchainConnector.CandidatosPresidentes();
                do
                {
                    Console.WriteLine("Seleccione el número del candidato a presidente: ");
                    seleccion = int.Parse(Console.ReadLine());
                    // Validar la selección del candidato
                    if (seleccion < 0 || seleccion > candidatosPresidentes.GetLength(0))
                    {
                        Console.WriteLine("*****Número de candidato inválido. Por favor, seleccione un número válido.*****");

                        for (int i = 0; i < candidatosPresidentes.GetLength(0); i++)
                        {
                            string id = candidatosPresidentes[i, 0];
                            string nombreCandidato = candidatosPresidentes[i, 1];
                            string nombrePartido = candidatosPresidentes[i, 2];
                            string vicepresidente = candidatosPresidentes[i, 3];

                            Console.WriteLine($"Candidato #{i}:");
                            Console.WriteLine($"ID: {id}");
                            Console.WriteLine($"Nombre del candidato: {nombreCandidato}");
                            Console.WriteLine($"Partido político: {nombrePartido}");
                            Console.WriteLine($"Vicepresidente: {vicepresidente}");
                            Console.WriteLine();
                        }
                    }

                } while (seleccion < 0 || seleccion > candidatosPresidentes.GetLength(0));


                string nombreCandidatoElegido = "";
                string nombrePartidoElegido = "";
                string[,] presidentes = Driver.BlockchainConnector.CandidatosPresidentes();
                if (seleccion > 0 || seleccion < candidatosPresidentes.GetLength(0))
                {
                    // Obtener el ID del candidato seleccionado
                    string idCandidato = candidatosPresidentes[seleccion, 0];


                    // Lógica para procesar el voto del candidato seleccionado

                    //Obtiene los datos del candidato que se seleccionó
                    nombreCandidatoElegido = presidentes[seleccion, 1];
                    nombrePartidoElegido = presidentes[seleccion, 2];
                }
                Console.WriteLine("\nCandidato elegido:");
                Console.WriteLine($"Nombre del candidato: {nombreCandidatoElegido}");
                Console.WriteLine($"Partido político: {nombrePartidoElegido}");

                // confirmar ingresando el nombre del candidato y del partido
                Console.WriteLine("\nPor favor, confirme su elección ingresando el nombre del candidato");

                string confirmacionNombreCandidato = Console.ReadLine();
                Console.WriteLine("y el nombre del partido político:");
                string confirmacionNombrePartido = Console.ReadLine();

                // Validar la confirmación del votante
                if (confirmacionNombreCandidato == nombreCandidatoElegido && confirmacionNombrePartido == nombrePartidoElegido)
                {
                    Console.WriteLine("Elección confirmada. El voto para presidente ha sido registrado.");
                    // Lógica para registrar el voto del candidato seleccionado
                    Guid presidenteId = Guid.Parse(presidentes[seleccion, 0]);
                    Guid diputadoId = Guid.NewGuid();

                    string[] listaDeDpis = Driver.BlockchainConnector.RegistrarVoto(dpi, presidenteId, diputadoId, nick);

                    seleccionValida = true; // Sale

                }
                else
                {
                    Console.WriteLine("Los datos ingresados no coinciden con la elección realizada. Por favor, intente nuevamente.");
                    for (int i = 0; i < candidatosPresidentes.GetLength(0); i++)
                    {
                        string id = candidatosPresidentes[i, 0];
                        string nombreCandidato = candidatosPresidentes[i, 1];
                        string nombrePartido = candidatosPresidentes[i, 2];
                        string vicepresidente = candidatosPresidentes[i, 3];

                        Console.WriteLine($"Candidato #{i}:");
                        Console.WriteLine($"ID: {id}");
                        Console.WriteLine($"Nombre del candidato: {nombreCandidato}");
                        Console.WriteLine($"Partido político: {nombrePartido}");
                        Console.WriteLine($"Vicepresidente: {vicepresidente}");
                        Console.WriteLine();
                    }

                }



            }
        }
    }
}
