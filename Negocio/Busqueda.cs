namespace Negocio;

using System;
using System.Collections.Generic;
using System.Linq;

public class Busqueda
{
    private List<Vehiculo> vehiculos = new();

    public void AgregarVehiculo(Vehiculo v)
    {
        vehiculos.Add(v);
    }
    public Vehiculo BuscarPorPatente(string patente)
    {
        var vehiculo = vehiculos.FirstOrDefault(v => v.Patente == patente);

        if (vehiculo == null) {

            throw new Exception("Vehículo no encontrado");
        }
        return vehiculo;
    }

    public List<T> BuscarPorTipo<T>() where T : Vehiculo
    {
        var lista = vehiculos.OfType<T>().ToList();

        if (lista.Count == 0)
            throw new Exception("No hay vehículos de ese tipo");

        return lista;
    }
}
