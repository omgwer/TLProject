using Computer.Components.Container;

namespace Computer.Components.Builders;

public class SystemUnitBuilder
{
    private SystemUnit SystemUnit;
    
    public SystemUnitBuilder()
    {
        SystemUnit = new SystemUnit();
    }
    public SystemUnitBuilder SetName(string name)
    {
        SystemUnit.Name = name;
        return this;
    }

    public SystemUnitBuilder SetColor(string color)
    {
        SystemUnit.Color = color;
        return this;
    }

    public SystemUnitBuilder SetSize(string size)
    {
        SystemUnit.Size = size;
        return this;
    }

    public SystemUnitBuilder SetWeight(int weight)
    {
        if (weight <= 0 | weight > 10000)
        {
            throw new ArgumentException(weight + " - argument is not valid");
        }

        SystemUnit.Weight = weight;
        return this;
    }

    public SystemUnit Build()
    {
        CheckReadyToBuild();
        return SystemUnit;
    }

    private void CheckReadyToBuild()
    {
        var softAssert = "";
        if (SystemUnit.Name == null)
        {
            softAssert += "SUName ";
        }

        if (SystemUnit.Color == null)
        {
            softAssert += "SUColor ";
        }

        if (SystemUnit.Size == null)
        {
            softAssert += "SUSize ";
        }

        if (SystemUnit.Weight == 0)
        {
            softAssert += "SUWeight ";
        }

        if (softAssert != "")
        {
            throw new ArgumentNullException(softAssert, "Error with build component");
        }
    }
}