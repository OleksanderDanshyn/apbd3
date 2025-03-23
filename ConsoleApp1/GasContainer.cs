namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure;
    
    public GasContainer(int height, int containerMass, int depth, int maxLoad, double pressure)
        : base(height, containerMass, depth, maxLoad, "G")
    {
        Pressure = pressure;
    }

    public override void EmptyContainer()
    {
        CargoMass *= 0.05;
    }

    public void SendNotification()
    {
        Console.WriteLine($"[HAZARD] Warning! Issue with container {SerialNumber}.");
    }
}