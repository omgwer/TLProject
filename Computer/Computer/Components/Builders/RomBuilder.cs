using Computer.Components.Container;

namespace Computer.Components.Builders;

public class RomBuilder
{
    private Rom Rom = new();

    public RomBuilder SetRomName(string name)
    {
        Rom.Name = name;
        return this;
    }

    public RomBuilder SetRomType(string memoryType)
    {
        Rom.RomType = memoryType;
        return this;
    }

    public RomBuilder SetRomMemory(int capacity)
    {
        if (capacity < 0 | capacity > 1000000)
        {
            throw new ArgumentException(capacity + " - argument is not valid");
        }

        Rom.Capacity = capacity;
        return this;
    }

    public RomBuilder SetRomSpeed(int speed)
    {
        if (speed < 0 | speed > 10000)
        {
            throw new ArgumentException(speed + " - argument is not valid");
        }

        Rom.Speed = speed;
        return this;
    }

    public Rom Build()
    {
        CheckReadyToBuild();
        return Rom;
    }

    private void CheckReadyToBuild()
    {
        var softAssert = "";
        if (Rom.Name == null)
        {
            softAssert += "RomName ";
        }

        if (Rom.RomType == null)
        {
            softAssert += "RomType ";
        }

        if (Rom.Capacity == 0)
        {
            softAssert += "RomCapacity ";
        }

        if (Rom.Speed == 0)
        {
            softAssert += "RomSpeed ";
        }

        if (softAssert != "")
        {
            throw new ArgumentNullException(softAssert, "Error with build component");
        }
    }
}