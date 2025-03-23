namespace ConsoleApp1;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double Temperature { get; }

    private static readonly Dictionary<string, double> AllowedTemperatures = new()
    {
        { "Bananas", 13.3 },
        { "Milk", 4.0 },
        { "Helium", -269.0 }
    };

    public RefrigeratedContainer(int height, int containerMass, int depth, int maxLoad, string productType, double temperature)
        : base(height, containerMass, depth, maxLoad, "C")
    {
        if (!AllowedTemperatures.ContainsKey(productType))
            throw new ArgumentException("Invalid product type.");

        if (temperature > AllowedTemperatures[productType])
            throw new ArgumentException($"Temperature too high! Must be at most {AllowedTemperatures[productType]}°C.");

        ProductType = productType;
        Temperature = temperature;
    }

    public override void LoadCargo(double mass)
    {
        if (mass > MaxLoad)
            throw new OverfillException($"Cannot load {mass} kg. Max load is {MaxLoad} kg.");

        CargoMass = mass;
    }


    public override string ToString()
    {
        return base.ToString() + $", Product: {ProductType}, Temperature: {Temperature}°C";
    }
}