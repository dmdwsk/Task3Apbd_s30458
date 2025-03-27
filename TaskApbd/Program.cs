using System;
using System.Collections.Generic;

namespace TaskApbd;

public class Program
{
    public static void Main()
    {
        var shipA = new Ship(25, 3, 50);
        var shipB = new Ship(20, 2, 30);

        var container1 = new СoldContainer("Bananas", 14)
        {
            masaLadunku = 8000,
            wagaWlasna = 2000
        };

        var container2 = new GazContainer(120)
        {
            masaLadunku = 5000,
            wagaWlasna = 1000
        };

        var container3 = new СoldContainer("Meat", -10)
        {
            masaLadunku = 6000,
            wagaWlasna = 3000
        };

        var container4 = new GazContainer(90)
        {
            masaLadunku = 4000,
            wagaWlasna = 900
        };

        shipA.LoadContainer(container1);
        shipA.LoadContainer(container2);
        shipA.LoadContainers(new List<Container> { container3 });

        container1.UnloadCargo();

        shipA.RemoveContainer(container2.NumerSeryjny);
        shipA.ReplaceContainer(container3.NumerSeryjny, container4);
        Ship.TransferContainer(shipA, shipB, container4.NumerSeryjny);

        Console.WriteLine("\n== Statek A ==");
        shipA.PrintShipInfo();

        Console.WriteLine("\n== Statek B ==");
        shipB.PrintShipInfo();

        Console.WriteLine("\n== Informacja o kontenerze ==");
        Console.WriteLine(container1);
    }
}