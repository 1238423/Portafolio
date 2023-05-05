namespace _1238423_semana11_cajero__25_de_marzo //El namespace que genere la clase copiarlo y pegarlo en el principal
{
    public class program
    {
        public static void Main(String[] args)
        {
            cajero cajero = new cajero();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("seleccione operacion; ");
                Console.WriteLine("1. realizar retiro ");
                Console.WriteLine("2. mostrar transsacciones");

                if (Console.ReadLine() == "1")
                {
                    cajero.retirarD();
                }
                if (Console.ReadLine() == "2")
                {
                    cajero.mostraT();
                }
                Console.ReadKey();
            }
        }
    }
}
