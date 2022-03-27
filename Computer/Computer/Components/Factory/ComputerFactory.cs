using Computer.Components.Builders;

namespace Computer.Components.Factory;

public class ComputerFactory
{
    public Dictionary<string, Dictionary<string, string>> BuildDefaultPc()
    {
        var buildingPc = new ComputerBuilder();

        var myNewProcessor = new ProcessorBuilder("DefaultProcessor");
        myNewProcessor.SetIntegratedVideo(true);
        myNewProcessor.SetProcessorSocket("Amd");
        myNewProcessor.SetProcessorCashStorage(15);
        myNewProcessor.SetProcessorThreadCount(2);
        myNewProcessor.SetProcessorThreadFrequency(2400);
        var processor = myNewProcessor.Build();

        var myNewMotherBoard = new MotherboardBuilder("Motherboard");
        myNewMotherBoard.SetMotherboardSize("ATX");
        myNewMotherBoard.SetMotherboardSocket("Amd");
        myNewMotherBoard.SetMotherBoardRamSlotCount(4);
        var motherboard = myNewMotherBoard.Build();

        var myNewRam = new RamBuilder("MegaRam");
        myNewRam.SetRamMemory(4000);
        myNewRam.SetRamStickCount(2);
        var ram = myNewRam.Build();

        var myNewRom = new RomBuilder("MegaRom");
        myNewRom.SetRomMemory(500000);
        myNewRom.SetRomType("ssd");
        var rom = myNewRom.Build();

        var myNewSustemUnit = new SystemUnitBuilder("Box");
        myNewSustemUnit.SetSystemUnitColor("red");
        myNewSustemUnit.SetSystemUnitSize("ATX");
        var sustemUnit = myNewSustemUnit.Build();

        var myNewVideoCard = new VideoCardBuilder("MiningCard");
        myNewVideoCard.SetVideoCardProcessor("GeForce");
        myNewVideoCard.SetVideoCardMemorySize(250);
        var videoCard = myNewVideoCard.Build();

        buildingPc.AddComponent(processor);
        buildingPc.AddComponent(motherboard);
        buildingPc.AddComponent(ram);
        buildingPc.AddComponent(rom);
        buildingPc.AddComponent(sustemUnit);
        buildingPc.AddComponent(videoCard);
        var newComputer = buildingPc.Build();
        return newComputer;
    }
}