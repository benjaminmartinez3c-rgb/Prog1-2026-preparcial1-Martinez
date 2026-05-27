namespace Negocio;

public enum CategoriaMoto
{
    Urbana,
    Deportiva,
    Todoterreno
}

public class Motos : Vehiculos
{

public Moto(string patente, string marca, string modelo, int anioFabricacion, decimal precioBaseDiario,CategoriaMoto categoria) : base(patente, marca, modelo, anioFabricacion, precioBaseDiario)
    {
        Categoria = categoria;
    }

public CategoriaMoto Categoria { get; set; }    
}
