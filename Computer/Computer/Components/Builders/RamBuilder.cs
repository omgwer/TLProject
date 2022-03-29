using Computer.Components.Container;

namespace Computer.Components.Builders;

public class RamBuilder : AbstractBuilder
{
    private const string
        Name = "RamName",
        ComponentTypeName = "Ram",
        RamStickCount = "RamStickCount",
        RamMemory = "RamMemory";

    public RamBuilder(string name)
    {
        AddComponentValue(ComponentType, ComponentTypeName);
        AddComponentValue(Name, name);
    }

    public void SetRamStickCount(int stickCount)
    {
        if (0 < stickCount | stickCount >= MaxRAMSlotsCount)
        {
            AddComponentValue(RamStickCount, stickCount.ToString());
            return;
        }

        ErrorMessage(RamStickCount, stickCount.ToString());
    }
    
    public void SetRamMemory(int memorySizeMb)
    {
        if (0 < memorySizeMb | memorySizeMb >= 32000)
        {
            AddComponentValue(RamMemory, memorySizeMb.ToString());
            return;
        }

        ErrorMessage(RamMemory, memorySizeMb.ToString());
    }

    public Dictionary<string, string> Build()
    {
        return GetComponent();
    }
}