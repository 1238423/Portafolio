
using Driver;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;


namespace Proyecto
{
    public class Program
    {
        public static string dpi;
        public static string nick;

        public static void Main(string[] args)
        {

            // Ejemplo de como utilizar el driver en su sistema/proyecto

            //listo
            string[,] presidentes = Driver.BlockchainConnector.CandidatosPresidentes();
            string[,] diputados = Driver.BlockchainConnector.CandidatosDiputados();
            Driver.BlockchainConnector.RegistrarVoto("TEST_DUPLICADO_0089", Guid.Parse(presidentes[0, 0]), Guid.Parse(diputados[0, 0]), "1238423");
            // Registrar un voto recibe los 4 parametros del enunciado
            // en el caso de los parametros 2 y 3, los Guid.NewGuid(), estos seran reemplzados
            // por los ids del presidente y diputado electo por el votante, respectivamente




            Console.WriteLine("DPIs ya registrados: " + "\n");

            lista_de_dpis_registrados dpisRegistrados = new lista_de_dpis_registrados();
            dpisRegistrados.lista();




            Console.WriteLine("\n" + "Presione enter para continuar" + "\n");
            Console.ReadKey();

            string[] listaDpis = BlockchainConnector.ActualizarDpis();

            //2------------------------------------------------------------------------------------------------------------------------------
            // Segunda parte del enunciado. Parte 1. Vista del usuario
            Console.WriteLine("Bienvenido al sistema de votación. \n");


            //cambio de string de ejemplo a la variable dpi - AGREGA EL DATO DEL USUARIO A LA LISTA DE DPIs



            // Validar si el DPI ya fue utilizado.


            bool dpiValido = false;

            while (!dpiValido)
            {
                Console.Write("Por favor ingrese su número de DPI: \n");
                string dpi = Console.ReadLine();

                // Validar si el DPI ya fue utilizado.
                if (listaDpis.Contains(dpi))
                {
                    Console.WriteLine("Este DPI ya ha sido utilizado anteriormente. \n" + "ingrese otro DPI");
                    // Aquí puedes mostrar un mensaje de error en la interfaz de usuario
                }
                else
                {
                    dpiValido = true;
                    Console.WriteLine("***** Bienvenido, puede continuar con el proceso de votación. *****");

                    string[] ListaDeDpis = Driver.BlockchainConnector.ActualizarDpis();
                    // EJ
                   Driver.BlockchainConnector.RegistrarVoto("TEST_DUPLICADO_003", Guid.Parse(presidentes[0,0]), Guid.Parse(diputados[0, 0]), "1238423");

                }
            }

            // SEGUNDA PARTE DEL ENUNCIADO. (MENU)
            Console.WriteLine("Bienvenido, por favor seleccione una opción:");
            Console.WriteLine("1. Elegir presidente");
            Console.WriteLine("2. Elegir diputado");
            Console.WriteLine("3. Finalizar votación");

            string opcion = Console.ReadLine();


            // TERCERA PARTE DEL ENUNCIADO ------- VISTA PARA VOTACIÓN DEL PRESIDENTE


            switch (opcion)
            {
                case "1":
                    //Muestra los candidatos a presidente

                    Console.WriteLine("Lista de candidatos a presidente:\n");

                    string[,] candidatosPresidentes = BlockchainConnector.CandidatosPresidentes();

                    for (int i = 0; i < candidatosPresidentes.GetLength(0); i++)
                    {
                        string id = candidatosPresidentes[i, 0];
                        string nombreCandidato = candidatosPresidentes[i, 1];
                        string nombrePartido = candidatosPresidentes[i, 2];
                        string vicepresidente = candidatosPresidentes[i, 3];

                        Console.WriteLine($"Candidato #{i}:"); // i + 1 para que inicie desde 1
                        Console.WriteLine($"ID: {id}");
                        Console.WriteLine($"Nombre del candidato: {nombreCandidato}");
                        Console.WriteLine($"Partido político: {nombrePartido}");
                        Console.WriteLine($"Vicepresidente: {vicepresidente}");
                        Console.WriteLine();
                    }

                    // guardar los datos impresos localmente.
                    CandidatosLocal presidenteData = new CandidatosLocal();

                    for (int i = 0; i < candidatosPresidentes.GetLength(0); i++)
                    {
                        // Crear un objeto Presidente y asignar los valores correspondientes

                        Presidente presidente = new Presidente
                        {
                            Id = Guid.Parse(candidatosPresidentes[i, 0]),
                            Name = candidatosPresidentes[i, 1],
                            Partido = candidatosPresidentes[i, 2],
                            VicePresident = candidatosPresidentes[i, 3]
                        };


                        // Agregar el objeto Presidente a la clase PresidenteData
                        presidenteData.AgregarPresidente(presidente);
                    }
                    //AQUI TERMINA LA PARTE B

                    //---------------------------------------------------------------------------------------------------------------------------------------------------------------

                    // Lógica para elegir un candidato a presidente ----------------Parte D -------------
                    MetodoPresidente elegirPresi = new MetodoPresidente(); //---
                    elegirPresi.M_CandidatosPresidentes();


              


                    //    break;
                    //case "2":
                    //Muestra los canditados a diputado
                    //  string[,] candidatosDiputados = BlockchainConnector.CandidatosDiputados();
                    // lógica para elegir diputado
                    Console.WriteLine("Lista de candidatos a diputado:\n");

                    string[,] candidatosDiputados = BlockchainConnector.CandidatosDiputados();

                    for (int i = 0; i < candidatosDiputados.GetLength(0); i++)
                    {
                        string id = candidatosDiputados[i, 0];
                        string nombreCandidato = candidatosDiputados[i, 1];
                        string nombrePartido = candidatosDiputados[i, 2];
                        string departamento = candidatosDiputados[i, 3];

                        Console.WriteLine($"Candidato #{i}:"); // i + 1 para que inicie desde 1
                        Console.WriteLine($"ID: {id}");
                        Console.WriteLine($"Nombre del candidato: {nombreCandidato}");
                        Console.WriteLine($"Partido político: {nombrePartido}");
                        Console.WriteLine($"Departamento: {departamento}");
                        Console.WriteLine();
                    }

                    // guardar los datos impresos localmente.
                    _CandidatosLocalD diputadoData = new _CandidatosLocalD();

                    for (int i = 0; i < candidatosDiputados.GetLength(0); i++)
                    {
                        // Crear un objeto Diputado y asignar los valores correspondientes

                        Diputado diputado = new Diputado
                        {
                            Id = Guid.Parse(candidatosDiputados[i, 0]),
                            Nombre = candidatosDiputados[i, 1],
                            Partido = candidatosDiputados[i, 2],
                            Departamento = candidatosDiputados[i, 3]
                        };


                        // Agregar el objeto Presidente a la clase PresidenteData
                        diputadoData.AgregarDiputado(diputado);
                    }

                    MetodoDiputado elegirDiputado = new MetodoDiputado();
                    elegirDiputado.M_CandidatosDiputados();

               

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
