using Computer.Components.Container;

namespace Computer.Components.Builders;

public abstract class AbstractBuilder
{
    private ComponentContainer NewComponent;
    protected readonly string[] Sockets = {"Amd", "Intel"};
    protected readonly string[] FormFactor = {"MicroATX", "ATX"};
    protected const int MaxRAMSlotsCount = 8;
    protected const string ComponentType = "ComponentType";

    protected  AbstractBuilder()
    {
        NewComponent = new ComponentContainer();
    }

    protected void AddComponentValue(string key, string value)
    {
        NewComponent.Component.Add(key, value);
    }

    protected void RemoveComponentValue(string key)
    {
        NewComponent.Component.Remove(key);
    }

    protected void ClearComponentContainer()
    {
        NewComponent.Component.Clear();
    }

    protected bool IsHaveParameter(string key)
    {
        return NewComponent.Component.ContainsKey(key);
    }

    protected string GetComponentInfo(string key)
    {
        string? ComponentValue;
        NewComponent.Component.TryGetValue(key, out ComponentValue);
        return ComponentValue ?? "";
    }

    protected Dictionary<string, string> GetComponent()
    {
        return NewComponent.Component;
    }

    protected void ReplaceComponent(string componentType, string componentName)
    {
        ClearComponentContainer();
        AddComponentValue(componentType, componentName);
    }

    protected void ErrorMessage(string errorItem, string errorValue)
    {
        Console.WriteLine("Error to add " + errorItem + " Info! Input " + errorItem + " : " + errorValue +
                          " is not valid!");
    }
}