using Computer.Components.Container;

namespace Computer.Components.Builders;

public class VideoCardBuilder : AbstractBuilder
{
    private const string
        Name = "VideoCardName",
        Processor = "VideoCardProcessor",
        MemorySize = "VideoCardMemorySize",
        ComponentTypeName = "Videocard";
    
    public VideoCardBuilder(string name)
    {
        AddComponentValue(ComponentType, ComponentTypeName);
        AddComponentValue(Name, name);
    }

    public void SetVideoCardProcessor(string processorType)
    {
        AddComponentValue(Processor, processorType);
    }
    
    public void SetVideoCardMemorySize(int memorySizeMb)
    {
        if (memorySizeMb <= 0 | memorySizeMb > 32000)
        {
            ErrorMessage(MemorySize, memorySizeMb.ToString());
            return;
        }
        AddComponentValue(MemorySize, memorySizeMb.ToString());
    }
    
    public Dictionary<string, string> Build()
    {
        return GetComponent();
    }
}