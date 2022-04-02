using Computer.Components.Container;

namespace Computer.Components.Builders;

public class ComputerBuilder
{
    private ComputerContainer ComputerContainer;

    public ComputerBuilder()
    {
        ComputerContainer = new ComputerContainer();
    }

    public ComputerBuilder AddVideocard(VideoCard videoCard)
    {
        ComputerContainer.VideoCard = videoCard;
        return this;
    }

    public ComputerBuilder AddSystemUnit(SystemUnit systemUnit)
    {
        ComputerContainer.SystemUnit = systemUnit;
        return this;
    }

    public ComputerBuilder AddRom(Rom rom)
    {
        ComputerContainer.Rom = rom;
        return this;
    }

    public ComputerBuilder AddRam(Ram ram)
    {
        ComputerContainer.Ram = ram;
        return this;
    }

    public ComputerBuilder AddProcessor(Processor processor)
    {
        ComputerContainer.Processor = processor;
        return this;
    }

    public ComputerBuilder AddMotherboard(Motherboard motherboard)
    {
        ComputerContainer.Motherboard = motherboard;
        return this;
    }

    public ComputerContainer Build()
    {
        CheckReadyToBuild();
        return ComputerContainer;
    }

    private void CheckReadyToBuild()
    {
        var softAssert = "";
        if (ComputerContainer.Motherboard == null)
        {
            softAssert += "Motherboard ";
        }

        if (ComputerContainer.Processor == null)
        {
            softAssert += "Processor ";
        }

        if (ComputerContainer.Ram == null)
        {
            softAssert += "Ram ";
        }

        if (ComputerContainer.Rom == null)
        {
            softAssert += "Rom ";
        }

        if (ComputerContainer.SystemUnit == null)
        {
            softAssert += "SystemUnit ";
        }

        if (ComputerContainer.VideoCard == null)
        {
            softAssert += "VideoCard ";
        }

        if (softAssert != "")
        {
            throw new ArgumentNullException(softAssert, "Error with build component");
        }
    }
}