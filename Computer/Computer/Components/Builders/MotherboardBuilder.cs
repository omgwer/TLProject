namespace Computer.Components.Builders;

public class MotherboardBuilder : AbstractBuilder
{
    private const string
        Name = "MotherboardName",
        Socket = "MotherboardSocket",
        Size = "MotherboardSize",
        RamSlotCount = "MotherboardRAMSlotsCount",
        ComponentTypeName = "Motherboard";

    public MotherboardBuilder(string name)
    {
        AddComponentValue(ComponentType, ComponentTypeName);
        AddComponentValue(Name, name);
    }

    public void SetMotherboardSocket(string socketType)
    {
        foreach (var socket in Sockets)
        {
            if (socket.Equals(socketType))
            {
                AddComponentValue(Socket, socketType);
                return;
            }
        }

        ErrorMessage(Socket, socketType);
    }

    public void SetMotherboardSize(string size)
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

    public void SetMotherBoardRamSlotCount(int ramSlotCount)
    {
        if (ramSlotCount <= 0 | ramSlotCount > MaxRAMSlotsCount)
        {
            ErrorMessage(RamSlotCount, ramSlotCount.ToString());
            return;
        }

        AddComponentValue(RamSlotCount, ramSlotCount.ToString());
    }

    public Dictionary<string, string> Build()
    {
        return GetComponent();
    }
}