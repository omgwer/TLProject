namespace Computer.Components.Container;

public abstract class AbstractComponentContainer
{
    private Dictionary<string, string> Component;
    protected readonly string[] Sockets = {"Amd", "Intel"};
    protected readonly string[] FormFactor = {"MicroATX", "ATX"};
    protected const int MaxRAMSlotsCount = 8;
    protected const string ComponentType = "ComponentType";
    protected AbstractComponentContainer()
    {
        Component = new Dictionary<string, string>();
    }

    protected void AddComponentValue(string key, string value)
    {
        Component.Add(key, value);
    }

    protected void RemoveComponentValue(string key)
    {
        Component.Remove(key);
    }

    protected void ClearComponentContainer()
    {
        Component.Clear();
    }

    protected bool IsHaveParameter(string key)
    {
        return Component.ContainsKey(key);
    }

    protected string GetComponentInfo(string key)
    {
        string? ComponentValue;
        Component.TryGetValue(key, out ComponentValue);
        return ComponentValue ?? "";
    }

    protected Dictionary<string, string> GetComponent()
    {
        return Component;
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