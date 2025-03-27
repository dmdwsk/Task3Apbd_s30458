namespace TaskApbd;

public class СoldContainer : Container
{
    public string typeOfProduct { get;  set; }
    public double temperatureOfContainer { get;  set; }

    public СoldContainer(string productType, double containerTemperature)
    {
        if (!ProductTemperature.RequiredTemperatures.ContainsKey(productType))
        {
            throw new Exception("Nie wolno obsługiwać taki typ produktu " + productType);
        }

        if (containerTemperature < ProductTemperature.RequiredTemperatures[productType])
        {
            throw new Exception("Temperature kontenera za małą: "  + containerTemperature);
        }
        typeOfProduct = productType;
        temperatureOfContainer = containerTemperature;
    }
    public override string GetTypeCode()
    {
        return "C";
    }
}