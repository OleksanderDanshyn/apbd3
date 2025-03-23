namespace ConsoleApp1;

public class ContainerShip
{
    public List<Container> Containers { get; } = new();
    public int MaxContainers { get; }
    public double MaxWeight { get; }
    public double MaxSpeed { get; }

    public ContainerShip(int maxContainers, double maxWeight, double maxSpeed)
    {
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        MaxSpeed = maxSpeed;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
            throw new InvalidOperationException("Cannot load more containers. Ship is full.");

        if ((GetTotalWeight() + (container.CargoMass + container.TareWeight) / 1000) > MaxWeight)
            throw new InvalidOperationException("Cannot load container. Exceeds ship weight limit.");

        Containers.Add(container);
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
            Containers.Remove(container);
        else
            Console.WriteLine("Container not found.");
    }

    public double GetTotalWeight()
    {
        return Containers.Sum(c => (c.CargoMass + c.TareWeight) / 1000);
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship Info: {Containers.Count}/{MaxContainers} containers, Weight: {GetTotalWeight()} tons, Max Speed: {MaxSpeed} knots");
        foreach (var container in Containers)
            Console.WriteLine(container);
    }

    public void TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            Console.WriteLine("Container not found.");
            return;
        }

        UnloadContainer(serialNumber);  

        try
        {
            targetShip.LoadContainer(container);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Transfer failed: {ex.Message}");
            
            if (GetTotalWeight() + (container.CargoMass + container.TareWeight) / 1000 <= MaxWeight)
                LoadContainer(container);
            else
                Console.WriteLine("Original ship cannot take the container back. It remains unloaded.");
        }
    }

    public void ReplaceContainer(string oldSerial, Container newContainer)
    {
        var oldContainer = Containers.FirstOrDefault(c => c.SerialNumber == oldSerial);
        if (oldContainer == null)
        {
            Console.WriteLine("Container not found.");
            return;
        }

        UnloadContainer(oldSerial);
        try
        {
            LoadContainer(newContainer);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Replacement failed: {ex.Message}");
            LoadContainer(oldContainer);
        }
    }
}