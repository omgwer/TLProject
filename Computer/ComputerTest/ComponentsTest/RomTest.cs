using System;
using Computer.Components.Builders;
using Computer.Components.Director;
using NUnit.Framework;

namespace ComputerTest.ComponentsTest;

public class RomTest
{
    [Test]
    public void RomPositiveTest()
    {
        Assert.DoesNotThrow(() => { new Director().BuildDefaultRam(); });
    }

    [Test]
    public void RomPositiveTest_overrideValue()
    {
        var newRom = new RomBuilder()
            .SetRomMemory(4000)
            .SetRomName("myNewDisk")
            .SetRomSpeed(400)
            .SetRomType("SSD")
            .SetRomName("NewName")
            .Build();

        Assert.AreEqual(newRom.Name, "NewName");
    }

    [Test]
    public void RomNegativeTest_emptyAllComponents()
    {
        Assert.Throws<ArgumentNullException>(() => new RomBuilder().Build());
    }

    [Test]
    public void RomNegativeTest_emptySomeoneValue()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var newRom = new RomBuilder()
                .SetRomMemory(4000)
                .SetRomName("myNewDisk")
                .SetRomSpeed(400)
                .Build();
        });
    }

    [Test]
    public void RomNegativeTest_ValidateInputValueForComponents()
    {
        Assert.Throws<ArgumentException>(() => { new RomBuilder().SetRomMemory(-1); });
        Assert.Throws<ArgumentException>(() => { new RomBuilder().SetRomMemory(1000001); });
        Assert.Throws<ArgumentException>(() => { new RomBuilder().SetRomMemory(0); });
        Assert.Throws<ArgumentException>(() => { new RomBuilder().SetRomSpeed(-1); });
        Assert.Throws<ArgumentException>(() => { new RomBuilder().SetRomSpeed(0); });
        Assert.Throws<ArgumentException>(() => { new RomBuilder().SetRomSpeed(10001); });
        
        Assert.DoesNotThrow(() => { new RomBuilder().SetRomMemory(1); });
        Assert.DoesNotThrow(() => { new RomBuilder().SetRomMemory(1000000); });
        Assert.DoesNotThrow(() => { new RomBuilder().SetRomSpeed(1); });
        Assert.DoesNotThrow(() => { new RomBuilder().SetRomSpeed(10000); });
    }
}