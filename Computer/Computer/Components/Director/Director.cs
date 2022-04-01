using Computer.Components.Builders;
using Computer.Components.Container;

namespace Computer.Components.Director;

public class Director
{
    public ComputerContainer BuildDefaultPc()
    {
        var Computer = new ComputerBuilder()
            .AddMotherboard(BuildDefaultMotherboard())
            .AddProcessor(BuildDefaultProcessor())
            .AddRam(BuildDefaultRam())
            .AddRom(BuildDefaultRom())
            .AddVideocard(BuildDefaultVideoCard())
            .AddSystemUnit(BuildDefaultSustemUnit())
            .Build();

        return Computer;
    }

    public Motherboard BuildDefaultMotherboard()
    {
        return new MotherboardBuilder()
            .SetMotherboardName("MSI")
            .SetMotherboardSize("ATX")
            .SetMotherboardSocket("1366")
            .SetRamSlotsCount(4)
            .Build();
    }

    public Processor BuildDefaultProcessor()
    {
        return new ProcessorBuilder()
            .SetProcessorName("Intel")
            .SetProcessorSocket("1366")
            .SetProcessorIntegratedVideo(false)
            .SetProcessorThreadCount(4)
            .SetProcessorThreadFrequency(1500)
            .Build();
    }

    public Ram BuildDefaultRam()
    {
        return new RamBuilder()
            .SetMemoryFrequency(3200)
            .SetMemoryType("DDR5")
            .SetRamMemory(8000)
            .SetRamName("newRam")
            .SetStickCount(4)
            .Build();
    }

    public Rom BuildDefaultRom()
    {
        return new RomBuilder()
            .SetRomMemory(500000)
            .SetRomName("newRom")
            .SetRomType("SSD")
            .SetRomSpeed(500)
            .Build();
    }

    public SystemUnit BuildDefaultSustemUnit()
    {
        return new SystemUnitBuilder()
            .SetColor("red")
            .SetSize("FullTower")
            .SetWeight(10)
            .SetName("newSustemUnit")
            .Build();
    }

    public VideoCard BuildDefaultVideoCard()
    {
        return new VideoCardBuilder()
            .SetTdp(100)
            .SetMemorySize(16000)
            .SetProcessorType("GeForce")
            .SetVideocardName("newVideoCard")
            .Build();
    }
}