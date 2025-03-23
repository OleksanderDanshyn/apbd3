namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Creating container ships...");
        var ship1 = new ContainerShip(5, 10000, 25);
        var ship2 = new ContainerShip(3, 8000, 30);

        Console.WriteLine("\nCreating containers...");
        var gasContainer = new GasContainer(250, 3000, 500, 20000, 10);
        var liquidContainer = new LiquidContainer(300, 2500, 600, 15000, true);
        var fridgeContainer = new RefrigeratedContainer(350, 4000, 700, 12000, "Bananas", 10.0);

        Console.WriteLine("\nLoading cargo into containers...");
        try
        {
            gasContainer.LoadCargo(19000);
            liquidContainer.LoadCargo(8000);
            fridgeContainer.LoadCargo(10000);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nLoading containers onto Ship 1...");
        ship1.LoadContainer(gasContainer);
        ship1.LoadContainer(liquidContainer);
        ship1.LoadContainer(fridgeContainer);

        ship1.PrintShipInfo();

        Console.WriteLine("\n Trying to overfill a container...");
        try
        {
            liquidContainer.LoadCargo(16000);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hazard Alert: {ex.Message}");
        }

        Console.WriteLine("\nEmptying a gas container...");
        gasContainer.EmptyContainer();
        Console.WriteLine(gasContainer);

        Console.WriteLine("\nReplacing a container...");
        var newLiquidContainer = new LiquidContainer(280, 2600, 580, 14000, false);
        ship1.ReplaceContainer(liquidContainer.SerialNumber, newLiquidContainer);
        ship1.PrintShipInfo();

        Console.WriteLine("\nTransferring a container to Ship 2...");
        ship1.TransferContainer(ship2, fridgeContainer.SerialNumber);
        Console.WriteLine("\nShip 1 Info After Transfer:");
        ship1.PrintShipInfo();
        Console.WriteLine("\nShip 2 Info After Transfer:");
        ship2.PrintShipInfo();

        Console.WriteLine("\nUnloading a container...");
        ship1.UnloadContainer(gasContainer.SerialNumber);
        ship1.PrintShipInfo();

        Console.WriteLine("\nAll operations executed successfully!");
    }
}
