namespace Negocio;

public class Bici : Vehiculo
{
    public int CantCambios {get;set;}

    public Bici(string patente, string marca, string modelo, int anioFabricacion, decimal precioBaseDiario, int cantCambios) : base(patente, marca, modelo, anioFabricacion, precioBaseDiario)
    {
        CantCambios = cantCambios;
    }

    public override decimal CalcularCosto(int dias)
    {
        return 200m * dias;
    }

}
