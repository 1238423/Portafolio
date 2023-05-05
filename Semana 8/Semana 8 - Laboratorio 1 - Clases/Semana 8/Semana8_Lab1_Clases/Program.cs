namespace Semana8_Lab1_Clases
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Solicitamos datos
            Console.WriteLine("Ingrese los siguientes datos: ");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Cantidad de bolas de helado: ");
            int bolasDeHelado = int.Parse(Console.ReadLine());
            Console.Write("Precio Bolas: ");
            double precioBolas =  double.Parse(Console.ReadLine());
            Console.Write("Desea agregar topping? (s/n): ");
            string respuestaTopping = Console.ReadLine();
            bool TieneTopping = false;
            double valorTopping = 0;

        if (respuestaTopping == "s")
        {
            TieneTopping = true;
            Console.Write("Ingrese el valor del topping: ");
            valorTopping = Convert.ToDouble(Console.ReadLine());
        }
        else if (respuestaTopping == "n")
        {
            Console.WriteLine("No se agregará topping.");
        }
        else
        {
            Console.WriteLine("El valor ingresado no es válido.");
        }

        // Instancia de la clase = Objeto
        Helados Helados1 = new Helados();

        Helados1.Nombre = nombre;
        Helados1.PrecioPorBola = precioBolas;
        Helados1.BolasDeHelado = bolasDeHelado;
        Helados1.tieneTopping = TieneTopping;
        Helados1.precioTopping = valorTopping;


            // Mostramos los datos del Heladoss
            Console.WriteLine();
            Console.WriteLine("El Helado ha sido generado con los siguientes datos: ");
            Console.WriteLine(Helados1.Factura());
            Console.ReadKey();

        }
    }
}