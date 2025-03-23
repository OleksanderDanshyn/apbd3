namespace ConsoleApp1;

public abstract class Container
{
    private static int _counter = 1;
    public double CargoMass { get; protected set; }
    public int Height { get; }
    public int TareWeight { get; }
    public int Depth { get; }
    public string SerialNumber { get; }
    public int MaxLoad { get; }

    protected Container(int height, int tareWeight, int depth, int maxLoad, string type)
    {
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxLoad = maxLoad;
        SerialNumber = $"KON-{type}-{_counter++}";
    }

    public virtual void EmptyContainer()
    {
        CargoMass = 0;
    }

    public virtual void LoadCargo(double mass)
    {
        if (mass > MaxLoad)
            throw new OverfillException($"Cannot load {mass} kg. Max load is {MaxLoad} kg.");
        
        CargoMass = mass;
    }

    public override string ToString()
    {
        return $"Container {SerialNumber}: Cargo {CargoMass}/{MaxLoad} kg, Height {Height} cm, Depth {Depth} cm";
    }
}