namespace ConsoleApp1;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(int height, int containerMass, int depth, int maxLoad, bool isHazardous)
        : base(height, containerMass, depth, maxLoad, "L")
    {
        IsHazardous = isHazardous;
    }
    
    public override void LoadCargo(double mass)
    {
        double allowedMass = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;

        if (mass > allowedMass)
        {
            SendNotification();
            throw new OverfillException($"Cannot load {mass} kg. Allowed max is {allowedMass} kg.");
        }

        CargoMass = mass;
    }

    public void SendNotification()
    {
        Console.WriteLine($"[HAZARD] Warning! Overfill attempt in container {SerialNumber}.");
    }
}