
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

        }
    }
}