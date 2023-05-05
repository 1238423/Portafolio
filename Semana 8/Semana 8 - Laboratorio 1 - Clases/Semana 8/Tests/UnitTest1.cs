using Semana8_Lab1_Clases;
using FluentAssertions;
namespace Semana8_Lab1_CLases.Testing
{
    public class Tests
    {

        [Fact]
        public void ObjectCanBeCreated()
        {
            Helados helado = new Helados();
            helado.Should().NotBeNull();
            helado.Should().BeOfType<Helados>();
        }

        [Theory]
        [InlineData("Helado", true, "El nombre cumple las condiciones")]
        [InlineData("", false, "El nombre no puede ser vacio")]
        [InlineData("NombreMasLargoDe10Chars", false, "El nombre es muy largo")]
        public void ValidateName(string names, bool accepted, string reason)
        {
            Helados helado = new Helados();
            var result = helado.SetNombre(names);
            result.Should().Be(accepted, reason);
        }

        [Theory]
        [InlineData(1.2345, true, "El precio cumple las condiciones")]
        [InlineData(0, false, "El precio no puede ser 0")]
        [InlineData(-1, false, "El precio no pude ser negativo")]
        public void ValidatePrice(double prices, bool accepted, string reason)
        {
            Helados helado = new Helados();
            var result = helado.SetPrecio(prices);
            result.Should().Be(accepted, reason);
        }

        [Theory]
        [InlineData(3, true, "La cantidad de bolas cumple las condiciones")]
        [InlineData(0, false, "No puede elegir 0 bolas")]
        [InlineData(-1, false, "Las bolas de helado no pueden ser nagativas")]
        [InlineData(4, false, "El maximo son 3 bolas de helado")]
        public void ValidateIceCreamBalls(int number, bool accepted, string reason)
        {
            Helados helado = new Helados();
            var result = helado.AgregarBolas(number);
            result.Should().Be(accepted, reason);
        }

        [Theory]
        [InlineData(true, 1.0, true, "El topping esta bien agregado.")]
        [InlineData(true, 0.0, false, "No puede agregar un topping con precio 0")]
        [InlineData(true, -1, false, "No puede agregar un topping con precio negativo")]
        [InlineData(false, 0.0, true, "No se agrego topping entonces el precio no se valida")]
        [InlineData(false, 1.0, true, "No se agrego topping entonces el precio no se valida")]
        [InlineData(false, -1.0, true, "No se agrego topping entonces el precio no se valida")]
        public void ValidateAddTopping(bool add, double price, bool accepted, string reason)
        {
            Helados helado = new Helados();
            var result = helado.AgregarTopping(add, price);
            result.Should().Be(accepted, reason);
        }

        [Theory]
        [InlineData(1, 1, false, 0, true)]
        [InlineData(3, 4.111, true, 8.1, true)]
        [InlineData(1, 0.111, false, 10, true)]
        public void ValidateTotalPrice(int balls, double priceBall, bool topping, double priceTopping, bool accepted)
        {
            Helados helado = new Helados();
            helado.AgregarBolas(balls);
            helado.SetPrecio(priceTopping);
            helado.AgregarTopping(topping, priceTopping);
            var total = helado.PrecioTotal();
            if(topping)
            {
                total.Should().Be(balls * priceBall + priceTopping);
            }
            else
            {
                total.Should().Be(balls * priceBall);
            }
        }

    }
}