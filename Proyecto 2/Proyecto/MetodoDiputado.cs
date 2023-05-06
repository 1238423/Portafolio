using Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class MetodoDiputado
    {

        public static string dpi;
        public static string nick;
        private List<string> votosRegistrados; //REGISTRA LOS VOTOS - Aquí concluye la parte 3

        public MetodoDiputado()
        {
            votosRegistrados = new List<string>();
        }
        public void M_CandidatosDiputados()
        {
            bool seleccionValida = false;

            while (!seleccionValida)
            {
                int seleccion;
                string[,] candidatosDiputados = BlockchainConnector.CandidatosDiputados();
                do
                {
                    Console.WriteLine("Seleccione el número del candidato a diputado: ");
                    seleccion = int.Parse(Console.ReadLine());
                    // Validar la selección del candidato
                    if (seleccion < 0 || seleccion > candidatosDiputados.GetLength(0))
                    {
                        Console.WriteLine("*****Número de candidato inválido. Por favor, seleccione un número válido.*****");

                        for (int i = 0; i < candidatosDiputados.GetLength(0); i++)
                        {
                            string id = candidatosDiputados[i, 0];
                            string nombreCandidato = candidatosDiputados[i, 1];
                            string nombrePartido = candidatosDiputados[i, 2];
                            string Departamento = candidatosDiputados[i, 3];

                            Console.WriteLine($"Candidato #{i}:");
                            Console.WriteLine($"ID: {id}");
                            Console.WriteLine($"Nombre del candidato: {nombreCandidato}");
                            Console.WriteLine($"Partido político: {nombrePartido}");
                            Console.WriteLine($"Departamento: {Departamento}");
                            Console.WriteLine();
                        }
                    }

                } while (seleccion < 0 || seleccion > candidatosDiputados.GetLength(0));


                string nombreCandidatoElegido = "";
                string nombrePartidoElegido = "";
                string nombreDepartamentoMismo = "";
                string[,] diputados = Driver.BlockchainConnector.CandidatosDiputados();
                if (seleccion > 0 || seleccion < candidatosDiputados.GetLength(0))
                {
                    // Obtener el ID del candidato seleccionado
                    string idCandidato = candidatosDiputados[seleccion, 0];


                    // Lógica para procesar el voto del candidato seleccionado

                    //Obtiene los datos del candidato que se seleccionó
                    nombreCandidatoElegido = diputados[seleccion, 1];
                    nombrePartidoElegido = diputados[seleccion, 2];
                    nombreDepartamentoMismo = diputados[seleccion, 3];
                }
                Console.WriteLine("\nCandidato elegido:");
                Console.WriteLine($"Nombre del candidato: {nombreCandidatoElegido}");
                Console.WriteLine($"Partido político: {nombrePartidoElegido}");
                Console.WriteLine($"Departamento: {nombreDepartamentoMismo}");

                // confirmar ingresando el nombre del candidato y del partido y del departamento
                Console.WriteLine("\nPor favor, confirme su elección ingresando el nombre del candidato");

                string confirmacionNombreCandidato = Console.ReadLine();
                Console.WriteLine(", el nombre del partido político:");
                string confirmacionNombrePartido = Console.ReadLine();
                Console.WriteLine(" y , el nombre del Departamento:");
                string confirmacionNombreDepar = Console.ReadLine();

                // Validar la confirmación del votante
                if (confirmacionNombreCandidato == nombreCandidatoElegido && confirmacionNombrePartido == nombrePartidoElegido && confirmacionNombreDepar == nombreDepartamentoMismo)
                {
                    Console.WriteLine("Elección confirmada. El voto para presidente ha sido registrado.");
                    // Lógica para registrar el voto del candidato seleccionado
                    Guid presidenteId = Guid.Parse(diputados[seleccion, 0]);
                    Guid diputadoId = Guid.NewGuid();

                    Driver.BlockchainConnector.RegistrarVoto(dpi, presidenteId, diputadoId, "nick");
                    seleccionValida = true; // Sale

                }
                else
                {
                    Console.WriteLine("Los datos ingresados no coinciden con la elección realizada. Por favor, intente nuevamente.");
                    for (int i = 0; i < candidatosDiputados.GetLength(0); i++)
                    {
                        string id = candidatosDiputados[i, 0];
                        string nombreCandidato = candidatosDiputados[i, 1];
                        string nombrePartido = candidatosDiputados[i, 2];
                        string Departamento = candidatosDiputados[i, 3];

                        Console.WriteLine($"Candidato #{i}:");
                        Console.WriteLine($"ID: {id}");
                        Console.WriteLine($"Nombre del candidato: {nombreCandidato}");
                        Console.WriteLine($"Partido político: {nombrePartido}");
                        Console.WriteLine($"Departamento: {Departamento}");
                        Console.WriteLine();
                    }

                }



            }
        }
    }
}
