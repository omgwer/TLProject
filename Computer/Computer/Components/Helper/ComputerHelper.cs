using Computer.Components.Container;

namespace Computer.Components.Helper;

public class ComputerHelper
{
    public static void GetInformation(ComputerContainer computerContainer)
    {
        GetInformation(computerContainer.Processor);
        GetInformation(computerContainer.Motherboard);
        GetInformation(computerContainer.Ram);
        GetInformation(computerContainer.Ram);
        GetInformation(computerContainer.SystemUnit);
        GetInformation(computerContainer.VideoCard);
    }

    public static void GetInformation(Processor processor)
    {
        Console.WriteLine(processor.Name);
        Console.WriteLine(processor.Socket);
        Console.WriteLine(processor.CoreFrequency);
        Console.WriteLine(processor.IntegratedVideo);
        Console.WriteLine(processor.ThreadCount);
        Console.WriteLine();
    }

    public static void GetInformation(Motherboard motherboard)
    {
        Console.WriteLine(motherboard.Name);
        Console.WriteLine(motherboard.Socket);
        Console.WriteLine(motherboard.Size);
        Console.WriteLine(motherboard.RamSlotCount);
        Console.WriteLine();
    }

    public static void GetInformation(Ram ram)
    {
        Console.WriteLine(ram.Name);
        Console.WriteLine(ram.Memory);
        Console.WriteLine(ram.MemoryFrequency);
        Console.WriteLine(ram.MemoryType);
        Console.WriteLine(ram.StickCount);
        Console.WriteLine();
    }

    public static void GetInformation(Rom rom)
    {
        Console.WriteLine(rom.Name);
        Console.WriteLine(rom.Capacity);
        Console.WriteLine(rom.Speed);
        Console.WriteLine(rom.RomType);
        Console.WriteLine();
    }

    public static void GetInformation(SystemUnit systemUnit)
    {
        Console.WriteLine(systemUnit.Name);
        Console.WriteLine(systemUnit.Color);
        Console.WriteLine(systemUnit.Size);
        Console.WriteLine(systemUnit.Weight);
        Console.WriteLine();
    }

    public static void GetInformation(VideoCard videoCard)
    {
        Console.WriteLine(videoCard.Name);
        Console.WriteLine(videoCard.Processor);
        Console.WriteLine(videoCard.MemorySize);
        Console.WriteLine(videoCard.TDP);
        Console.WriteLine();
    }
}