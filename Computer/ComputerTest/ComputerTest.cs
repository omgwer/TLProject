using System;
using Computer.Components.Builders;
using Computer.Components.Director;
using NUnit.Framework;

namespace ComputerTest;

public class ComputerTest
{
    [Test]
    public void ComputerPositiveTest()
    {
        Assert.DoesNotThrow(() => { new Director().BuildDefaultPc(); });
    }

    [Test]
    public void ComputerPositiveTest_overrideComponent()
    {
        var motherboard = new Director().BuildDefaultMotherboard();
        var processor = new Director().BuildDefaultProcessor();
        var ram = new Director().BuildDefaultRam();
        var rom = new Director().BuildDefaultRom();
        var videocard = new Director().BuildDefaultVideoCard();
        var defaultSustemUnit = new Director().BuildDefaultSustemUnit();
        var newMotherboard = new MotherboardBuilder()
            .SetMotherboardName("new")
            .SetMotherboardSocket("new")
            .SetMotherboardSize("new")
            .SetRamSlotsCount(1)
            .Build();
        
        var newComputer = new ComputerBuilder()
            .AddMotherboard(motherboard)
            .AddProcessor(processor)
            .AddRam(ram)
            .AddRom(rom)
            .AddVideocard(videocard)
            .AddSystemUnit(defaultSustemUnit)
            .AddMotherboard(newMotherboard) 
            .Build();

        Assert.AreEqual(newComputer.Motherboard.Name, "new");
    }

    [Test]
    public void ComputerNegativeTest_emptyAllComponents()
    {
        Assert.Throws<ArgumentNullException>(() => { new ComputerBuilder().Build(); });
    }

    [Test]
    public void ComputerNegativeTest_emptySomeoneComponent()
    {
        var motherboard = new Director().BuildDefaultMotherboard();
        var processor = new Director().BuildDefaultProcessor();
        var ram = new Director().BuildDefaultRam();
        var rom = new Director().BuildDefaultRom();
        var videocard = new Director().BuildDefaultVideoCard();

        Assert.Throws<ArgumentNullException>(() =>
        {
            new ComputerBuilder()
                .AddMotherboard(motherboard)
                .AddProcessor(processor)
                .AddRam(ram)
                .AddRom(rom)
                .AddVideocard(videocard)
                .Build();
        });
    }
}