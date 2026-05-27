using NUnit.Framework;
using Negocio;
using System;

[TestFixture]

public class MotoTests
{
    [Test]
    public void Moto_Deportiva_Factor()
    {
        var moto = new Moto("m1", "Yamaha", "R1", 2022, 100m, CategoriaMoto.Deportiva);

        var total = moto.CalcularCosto(2);

        Assert.AreEqual(1600m, total);
    }
}