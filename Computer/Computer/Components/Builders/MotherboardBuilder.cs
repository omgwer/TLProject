using System.Text;
using Computer.Components.Container;

namespace Computer.Components.Builders;

public class MotherboardBuilder : AbstractBuilder
{
    private Motherboard Motherboard = new();

    public MotherboardBuilder SetMotherboardName(string name)
    {
        Motherboard.Name = name;
        return this;
    }

    public MotherboardBuilder SetMotherboardSocket(string socket)
    {
        Motherboard.Socket = socket;
        return this;
    }

    public MotherboardBuilder SetMotherboardSize(string size)
    {
        Motherboard.Size = size;
        return this;
    }

    public MotherboardBuilder SetRamSlotsCount(int ramSlotsCount)
    {
        if (0 < ramSlotsCount | ramSlotsCount > MaxRamSlotsCount)
        {
        }

        Motherboard.RamSlotCount = ramSlotsCount;
        return this;
    }

    public Motherboard Build()
    {
        checkReadyToBuild();
        return Motherboard;
    }

    public void checkReadyToBuild()
    {
        var softAssert = "";
        if (Motherboard.Name == null)
        {
            softAssert += "MotherboardName ";
        }

        if (Motherboard.Size == null)
        {
            softAssert += "MotherboardSize ";
        }

        if (Motherboard.Socket == null)
        {
            softAssert += "MotherboardSocket ";
        }

        if (Motherboard.RamSlotCount == 0)
        {
            softAssert += "MotherboardRamSlotCount ";
        }

        if (softAssert != "")
        {
            throw new ArgumentNullException(softAssert, "Error with build component");
        }
    }
}