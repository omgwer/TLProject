using Computer.Components.Container;

namespace Computer.Components.Builders;

public class RomBuilder : AbstractComponentContainer
{
    private const string
        Name = "RomName",
        ComponentTypeName = "Rom",
        RomType = "RomType",
        RomMemory = "RomMemory";

    public RomBuilder(string name)
    {
        AddComponentValue(ComponentType, ComponentTypeName);
        AddComponentValue(Name, name);
    }
    
    public void SetRomType(string romTypeName)
    {
        AddComponentValue(RomType, romTypeName);
    }
    
    public void SetRomMemory(int memorySizeMb)
    {
        if (0 < memorySizeMb | memorySizeMb < 10000000)
        {
            AddComponentValue(RomMemory, memorySizeMb.ToString());
            return;
        }

        ErrorMessage(RomMemory, memorySizeMb.ToString());
    }

    public Dictionary<string, string> Build()
    {
        return GetComponent();
    }
}