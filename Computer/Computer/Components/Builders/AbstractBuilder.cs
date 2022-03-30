namespace Computer.Components.Builders;

public abstract class AbstractBuilder
{
    protected readonly string[] Sockets = {"Amd", "Intel"};
    protected readonly string[] FormFactor = {"MicroATX", "ATX"};
    protected const int MaxRamSlotsCount = 8;
    protected const string ComponentType = "ComponentType";


    protected void ErrorMessage(string errorItem, string errorValue)
    {
        throw new Exception("Error to add " + errorItem + " Info! Input "
                            + errorItem + " : " + errorValue + " is not valid!");
    }
}