namespace Negocio;

public class Vehiculos
{
    public string Patente {get;}
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int AnioFabricacion { get; set; }
    public decimal PrecioBaseDiario { get; set; }

    public Vehiculo( string patente, string marca, string modelo, int anioFabricacion, decimal precioBaseDiario)
    {

        if (anioFabricacion < 1900 || anioFabricacion > DateTime.Now.Year)
        {
            throw new Exception("Año de fabricación inválido");
        }

         if (string.IsNullOrWhiteSpace(patente))
         {
            throw new ArgumentException("La patente no puede estar vacía");
         }


        Patente = patente;
        Marca = marca;
        Modelo = modelo;
        AnioFabricacion = anioFabricacion;
        PrecioBaseDiario = precioBaseDiario;
    }
}
