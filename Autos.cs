namespace Negocio;

public class Autos : Vehiculos
{
public bool Seguro { get; set; }

public Auto(string patente, string marca, string modelo, int anioFabricacion, decimal precioBaseDiario) : base(patente, marca, modelo, anioFabricacion, precioBaseDiario)
    {
    }

    public override decimal CalcularCosto(int dias)
    {
        decimal total = PrecioBaseDiario * dias;

        if (dias > 7){
            total = total * 0.85m; 
        }

        if (Seguro){
            total *= 1.10m;
        }

        return total;
    }
}
