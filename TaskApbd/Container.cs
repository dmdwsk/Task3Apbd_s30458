namespace TaskApbd;

public abstract class Container
{
    private static int counter = 1;
    
    public double masaLadunku { get; set; }
    public double wysokosc { get; set; }
    public double wagaWlasna { get; set; }
    public double glebokosc { get; set; }
    public double MaxLoadKg { get;  set; }
    public string NumerSeryjny { get; }
    public Container()
    {
        NumerSeryjny = GenerateSerialNumber(GetTypeCode());
    }

    
    public abstract string GetTypeCode();

    private string GenerateSerialNumber(string typeCode)
    {
        return $"KON-{typeCode}-{counter++}";
    }
    public virtual void UnloadCargo()
    {
        Console.WriteLine("Rozładowano " + masaLadunku +  " kg z kontenera ." + NumerSeryjny);
        masaLadunku = 0;
    }

    public virtual void LoadCargo(double masaLadunku)
    {
        if (masaLadunku > MaxLoadKg)
        {
            throw new OverfillException("MaxLoadKg is overlapping.");
        }
        this.masaLadunku = masaLadunku;
        Console.WriteLine($"Załadowano {masaLadunku} kg do kontenera {NumerSeryjny}.");
    }

    public class OverfillException : Exception
    {
        public OverfillException(string message)
            : base(message)
        {
        }
    }
    public override string ToString()
    {
        return $"[{GetType().Name}] Numer: {NumerSeryjny}, Masa: {masaLadunku}kg, Waga własna: {wagaWlasna}kg";
    }


}