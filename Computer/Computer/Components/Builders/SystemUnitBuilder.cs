using Computer.Components.Container;

namespace Computer.Components.Builders;

public class SystemUnitBuilder : AbstractBuilder
{
    private const string
        Name = "SystemUnitName",
        Color = "SystemUnitColor",
        Size = "SystemUnitSize",
        ComponentTypeName = "Sustemunit";

    public SystemUnitBuilder(string name)
    {
        AddComponentValue(ComponentType, ComponentTypeName);
        AddComponentValue(Name, name);
    }
    
    public void SetSystemUnitColor(string color)
    {
        AddComponentValue(Color, color);
    }
    
    public void SetSystemUnitSize(string size)
    {
        foreach (var form in FormFactor)
        {
            if (form.Equals(size))
            {
                AddComponentValue(Size, size);
                return;
            }
        }
        ErrorMessage(Size, size);
    }
    
    public Dictionary<string, string> Build()
    {
        return GetComponent();
    }
}