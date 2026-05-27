namespace Negocio;

public class Reserva
{
    private static int contador = 1;

    public int Numero { get; }
    public string Cliente { get; set; }
    public Vehiculo Vehiculo { get; set; }
    public int Dias { get; set; }

    public decimal Total => Vehiculo.CalcularCosto(Dias); 

    public Reserva(string cliente, Vehiculo vehiculo, int dias)
    {
        if (dias <= 0){
            throw new ArgumentException("Los das deben ser mayores a 0");
        }
        Numero = contador++;
        Cliente = cliente;
        Vehiculo = vehiculo;
        Dias = dias;
    }
}
