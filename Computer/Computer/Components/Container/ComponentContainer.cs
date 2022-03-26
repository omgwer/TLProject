namespace Computer.Components.Container;

public abstract class ComponentContainer
{
    private Dictionary<string, string> Component;

    protected ComponentContainer()
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

    protected bool IsHaveParameter(String key)
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
}