namespace Computer.Components;

public class ComputerBuilder
{
    private Dictionary<string, Dictionary<string, string>> ComputerContainer = new();
    private const string ComponentType = "ComponentType";
    private string[] requiredComponents = {"Ram", "Rom", "Processor", "Sustemunit", "Videocard", "Motherboard"};

    public void AddComponent(Dictionary<string, string> component)
    {
        string componentKey = component[ComponentType];
        if (ComputerContainer.ContainsKey(componentKey))
        {
            ErrorMessage(componentKey);
            return;
        }

        ComputerContainer.Add(componentKey, component);
    }

    public void RemoveComponent(string componentKey)
    {
        ComputerContainer.Remove(componentKey);
    }

    public Dictionary<string, Dictionary<string, string>> Build()
    {
        foreach (var requiredComponent in requiredComponents)
        {
            if (!ComputerContainer.ContainsKey(requiredComponent))
            {
                throw new ArgumentNullException("Error to build computer ! Require " + requiredComponent);
            }
        }

        return ComputerContainer;
    }

    private void ErrorMessage(string componentKey)
    {
        Console.WriteLine("Error to add " + componentKey + "this component was installed before");
    }
}