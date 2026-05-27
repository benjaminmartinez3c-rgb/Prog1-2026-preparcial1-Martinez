using NUnit.Framework;
using Negocio;
using System;

[TestFixture]
public class VehiculoTests
{
    [Test]
    public void Vehiculo_AñoMenor1900()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Auto("ABC123", "Ford", "Focus", 1800, 1000m);
        });
    }

    [Test]
    public void Vehiculo_AñoMayorActual()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Auto("ABC123", "Ford", "Focus", DateTime.Now.Year + 1, 1000m);
        });
    }

    [Test]
    public void Vehiculo_PatenteVacia()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Auto("", "Ford", "Focus", 2020, 1000m);
        });
    }
}