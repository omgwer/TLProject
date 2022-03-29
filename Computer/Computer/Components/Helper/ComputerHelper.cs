namespace Computer.Components.Helper;

public class ComputerHelper
{
    public void GetInformation(Dictionary<string, string> container)
    {
        GetElementInformation(container);
    }

    public void GetInformation(Dictionary<string, Dictionary<string, string>> container)
    {
        foreach (var computerContainer in container)
        {
            Console.WriteLine(computerContainer.Key + ":");
            GetElementInformation(computerContainer.Value);
        }
    }

    private void GetElementInformation(Dictionary<string, string> elementContainer)
    {
        foreach (var element in elementContainer)
        {
            Console.WriteLine("\t" + element.Key + ": " + element.Value);
        }
    }
}