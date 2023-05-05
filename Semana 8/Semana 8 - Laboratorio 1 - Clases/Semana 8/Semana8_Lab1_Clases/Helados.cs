namespace Semana8_Lab1_Clases
{
    public class Helados
    {
        public string Nombre; // Cambio el private por public
        public double PrecioPorBola;
        public int BolasDeHelado;
        public bool tieneTopping;
        public double precioTopping;

        public bool SetNombre(string nombre)
        {
            if (nombre == null) return false; // Validar siempre primero los casos que sean negativos
            if (nombre == "") return false;
            if (nombre.Length > 10) return false;
            //llamar a nombre y asignar lo que piden en el parametro.
            Nombre = nombre;
            return true;
        }

        public bool SetPrecio(double precio)
        {
            if (precio <=0) return false;
            PrecioPorBola = precio;
            return true;
        }
        public bool AgregarBolas(int cantidadBolas)
        {
            if (cantidadBolas <= 0) return false;
            if (cantidadBolas > 3) return false;
            BolasDeHelado = cantidadBolas;
            return true;
        }
        public bool AgregarTopping(bool agregar, double precio)
        {
            if (agregar == true)
            {
                if (precio <= 0) return false;
                tieneTopping = true;
                precioTopping = precio;
            }
            else
            {
                tieneTopping = false;
                precioTopping = 0;

            }
            return true;
        }
        //PRECIO -----------------------------------------------------------------------------------------
        public double PrecioTotal()
        {
            return PrecioHelado() + PrecioTopping(); //SUMA Y CALCULO DEL PRECIO TOTAL
        }

        public double PrecioHelado()
        {
            return BolasDeHelado * PrecioPorBola; //Calculo del precio total 2DO PASO
        }

        public double PrecioTopping()
        {
            return precioTopping; //Calculo del precio total 1ER PASO
        }

        public string Factura()
        {
            string factura = string.Empty; // String.enty se puede sustituir por "", pero el primero es mas eficiente
            factura += "Nombre: " + Nombre + "\n";
            factura += "Bolas de helado:  " + BolasDeHelado + "\n";
            factura += "Precio bolas:  " + PrecioPorBola + "\n";
            factura += "Desea topping:  " + tieneTopping + "\n";
            factura += "Precio Toppingo:  " + precioTopping + "\n";
            factura += "-----------------------------------------";
            factura += "Precio total: " + PrecioTotal ();
            return factura;
        
        }
    }
}
