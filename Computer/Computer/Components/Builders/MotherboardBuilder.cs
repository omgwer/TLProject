using Computer.Components.Container;

namespace Computer.Components.Builders;

public class MotherboardBuilder
{
    private Motherboard Motherboard;
    private const int MaxRamSlotsCount = 8;

    public MotherboardBuilder()
    {
        Motherboard = new Motherboard();
    }

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
        if (ramSlotsCount <= 0 | ramSlotsCount > MaxRamSlotsCount)
        {
            throw new ArgumentException(ramSlotsCount + " - argument is not valid");
        }

        Motherboard.RamSlotCount = ramSlotsCount;
        return this;
    }

    public Motherboard Build()
    {
        CheckReadyToBuild();
        return Motherboard;
    }

    private void CheckReadyToBuild()
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