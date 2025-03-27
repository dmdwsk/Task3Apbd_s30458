namespace TaskApbd;

public static class ProductTemperature
{
    public static readonly Dictionary<string, double> RequiredTemperatures = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 1 },
        { "Meat", -11 },
        { "Ice cream", -18 },
        { "Frozen pizza", -32 },
        { "Cheese", 7.9 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };
}