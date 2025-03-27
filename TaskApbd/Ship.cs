namespace TaskApbd;

public class Ship
{
    public List<Container> containers { get; } = new();
    public double maxSpeed { get; }
    public int maxContainerAmount { get; }
    public double maxTotalWeight { get; }

    public Ship(double maxSpeed, int maxContainerAmount, double maxTotalWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainerAmount = maxContainerAmount;
        this.maxTotalWeight = maxTotalWeight;
    }

    public void LoadContainer(Container container)
    {
        if (containers.Count >= maxContainerAmount)
        {
            Console.WriteLine(" Za dużo kontenerów .");
            return;
        }

        double totalWeightKg = 0;

        foreach (var c in containers)
        {
            totalWeightKg += c.masaLadunku + c.wagaWlasna;
        }
        double newTotalWeightTons = (totalWeightKg + container.masaLadunku + container.wagaWlasna) / 1000.0;

        if (newTotalWeightTons > maxTotalWeight)
        {
            Console.WriteLine("  Przekroczono limit wagowy .");
            return;
        }

        containers.Add(container);
        Console.WriteLine($" Załadowano kontener {container.NumerSeryjny} na statek.");
    }

    public void LoadContainers(List<Container> list)
    {
        foreach (var c in list)
        {
            LoadContainer(c);
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        Container found = null;

        foreach (var c in containers)
        {
            if (c.NumerSeryjny == serialNumber)
            {
                found = c;
                break;
            }
        }

        if (found != null)
        {
            containers.Remove(found);
            Console.WriteLine($" Usunięto kontener {serialNumber}.");
        }
        else
        {
            Console.WriteLine($" Kontener {serialNumber} nie znaleziony.");
        }
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = -1;

        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].NumerSeryjny == serialNumber)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            containers[index] = newContainer;
            Console.WriteLine($" Zamieniono kontener {serialNumber}.");
        }
        else
        {
            Console.WriteLine($" Kontener {serialNumber} nie znaleziony do zamiany.");
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"\n Statek: max prędkość: {maxSpeed} węzłów, max kontenery: {maxContainerAmount}, max waga: {maxTotalWeight} ton");
        Console.WriteLine($" Kontenery ({containers.Count}):");
        foreach (var c in containers)
        {
            Console.WriteLine($" - {c}");
        }
    }

    public static void TransferContainer(Ship from, Ship to, string serialNumber)
    {
        Container container = null;

        foreach (var c in from.containers)
        {
            if (c.NumerSeryjny == serialNumber)
            {
                container = c;
                break;
            }
        }

        if (container != null)
        {
            from.containers.Remove(container);
            to.LoadContainer(container);
            Console.WriteLine($" Przeniesiono kontener {serialNumber}.");
        }
        else
        {
            Console.WriteLine($" Nie znaleziono kontenera {serialNumber} do przeniesienia.");
        }
    }
}
