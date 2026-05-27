namespace Negocio;

public abstract class Vehiculo
{
    public string Patente { get; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int AnioFabricacion { get; set; }
    public decimal PrecioBaseDiario { get; set; }

    protected Vehiculo(string patente, string marca, string modelo, int anioFabricacion, decimal precioBaseDiario)
    {
        if (string.IsNullOrWhiteSpace(patente))
            throw new ArgumentException("Patente invalida");

        if (anioFabricacion < 1900 || anioFabricacion > DateTime.Now.Year)
            throw new ArgumentException("Año invalido");

        Patente = patente;
        Marca = marca;
        Modelo = modelo;
        AnioFabricacion = anioFabricacion;
        PrecioBaseDiario = precioBaseDiario;
    }

    public abstract decimal CalcularCosto(int dias);
}