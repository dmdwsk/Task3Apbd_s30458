namespace TaskApbd;

public  class LiquidContainer : Container, IHazardNotifier
{
    public override string GetTypeCode()
    {
        return "L";
    }
    public bool IsHazardous { get; }

    public LiquidContainer(bool isHazardous)
    {
        IsHazardous = isHazardous;
    }

    public void NotifyHazard()
    {
        Console.WriteLine("Niebiezpeczna sytuacja z kontenerem numer: " + NumerSeryjny + ".");
    }

    public override void LoadCargo(double masaLadunku)
    {
        double allowedWeight = IsHazardous ? MaxLoadKg * 0.5 : MaxLoadKg * 0.9;
        if (allowedWeight > masaLadunku)
        {
            NotifyHazard();
            throw new OverfillException("MaxLoadKg is overlapping.");
        }
    }

}