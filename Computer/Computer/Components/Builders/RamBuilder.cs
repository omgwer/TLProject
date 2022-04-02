using Computer.Components.Container;

namespace Computer.Components.Builders;

public class RamBuilder
{
    private Ram Ram;
    private const int MaxRamSlotsCount = 8;
    
    public RamBuilder()
    {
        Ram = new Ram();
    }

    public RamBuilder SetRamName(string name)
    {
        Ram.Name = name;
        return this;
    }

    public RamBuilder SetMemoryType(string memoryType)
    {
        Ram.MemoryType = memoryType;
        return this;
    }

    public RamBuilder SetRamMemory(int ramMemory)
    {
        if (ramMemory < 0 | ramMemory > 64000)
        {
            throw new ArgumentException(ramMemory + " - argument is not valid");
        }

        Ram.Memory = ramMemory;
        return this;
    }

    public RamBuilder SetStickCount(int stickCount)
    {
        if (stickCount <= 0 | stickCount > MaxRamSlotsCount)
        {
            throw new ArgumentException(stickCount + " - argument is not valid");
        }

        Ram.StickCount = stickCount;
        return this;
    }

    public RamBuilder SetMemoryFrequency(int memoryFrequency)
    {
        if (memoryFrequency <= 0 | memoryFrequency > 8000)
        {
            throw new ArgumentException(memoryFrequency + " - argument is not valid");
        }

        Ram.MemoryFrequency = memoryFrequency;
        return this;
    }

    public Ram Build()
    {
        CheckReadyToBuild();
        return Ram;
    }

    private void CheckReadyToBuild()
    {
        var softAssert = "";
        if (Ram.Name == null)
        {
            softAssert += "RamName ";
        }

        if (Ram.Memory == 0)
        {
            softAssert += "RamMemory ";
        }

        if (Ram.StickCount == 0)
        {
            softAssert += "RamStickCount ";
        }

        if (Ram.MemoryFrequency == 0)
        {
            softAssert += "RamMemoryFrequency ";
        }

        if (softAssert != "")
        {
            throw new ArgumentNullException(softAssert, "Error with build component");
        }
    }
}