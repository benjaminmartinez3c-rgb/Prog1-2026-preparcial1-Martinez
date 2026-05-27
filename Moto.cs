namespace Negocio;

public enum CategoriaMoto
{
    Urbana,
    Deportiva,
    Todoterreno
}

public class Moto : Vehiculo
{

public CategoriaMoto Categoria { get; set; }  

public Moto(string patente, string marca, string modelo, int anioFabricacion, decimal precioBaseDiario,CategoriaMoto categoria) : base(patente, marca, modelo, anioFabricacion, precioBaseDiario)
    {
        Categoria = categoria;
    }


public override decimal CalcularCosto(int dias)
{
    decimal factor;

    if (Categoria == CategoriaMoto.Deportiva)
    {
        factor = 0.8m;
    }
    else
    {
        factor = 0.6m;
    }

    return PrecioBaseDiario * dias * factor;
}  
}
