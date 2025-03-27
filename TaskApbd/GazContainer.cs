namespace TaskApbd;

public class GazContainer : Container,IHazardNotifier
{
    public double PressureAtm { get; set; }
    public GazContainer(double pressureAtm)
    {
        PressureAtm = pressureAtm;
    }
    public override string GetTypeCode()
    {
        return "G";
    }

    public override void UnloadCargo()
    {
        double pozostalo = masaLadunku * 0.05;
        Console.WriteLine("Rozładowano gaz z kontenera " + NumerSeryjny +  " pozostało " + pozostalo +  " kg");
        masaLadunku = pozostalo;
    }
    public void NotifyHazard()
    {
        Console.WriteLine("Niebiezpeczna sytuacja z kontenerem numer: " + NumerSeryjny + ".");
    }
    public override void LoadCargo(double masaLadunku)
    {
        if (masaLadunku > MaxLoadKg)
        {
            NotifyHazard();
            throw new OverfillException("MaxLoadKg is overlapping.");
        }
        masaLadunku = masaLadunku;
        Console.WriteLine($"Załadowano {masaLadunku} kg do kontenera {NumerSeryjny}.");
    }
} 