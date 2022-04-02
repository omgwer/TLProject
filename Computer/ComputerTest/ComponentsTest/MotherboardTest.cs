using System;
using Computer.Components.Builders;
using Computer.Components.Director;
using NUnit.Framework;

namespace ComputerTest.ComponentsTest;

public class MotherboardTest
{
    [Test]
    public void MotherboardPositiveTest()
    {
        Assert.DoesNotThrow(() => { new Director().BuildDefaultMotherboard(); });
    }

    [Test]
    public void MotherboardPositiveTest_overrideValue()
    {
        var newMotherboard = new MotherboardBuilder()
            .SetMotherboardName("testname")
            .SetMotherboardSize("full")
            .SetMotherboardSocket("AM4")
            .SetRamSlotsCount(4)
            .SetMotherboardName("newName")
            .Build();

        Assert.AreEqual(newMotherboard.Name, "newName");
    }

    [Test]
    public void MotherboardNegativeTest_emptyAllComponents()
    {
        Assert.Throws<ArgumentNullException>(() => new MotherboardBuilder().Build());
    }

    [Test]
    public void MotherboardNegativeTest_emptySomeoneValue()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var newMotherboard = new MotherboardBuilder()
                .SetMotherboardName("testName")
                .SetMotherboardSize("fullTower")
                .SetMotherboardSocket("am4")
                .Build();
        });
    }

    [Test]
    public void MotherboardNegativeTest_ValidateInputValueForComponents()
    {
        Assert.Throws<ArgumentException>(() => { new MotherboardBuilder().SetRamSlotsCount(-1); });
        Assert.Throws<ArgumentException>(() => { new MotherboardBuilder().SetRamSlotsCount(0); });
        Assert.Throws<ArgumentException>(() => { new MotherboardBuilder().SetRamSlotsCount(9); });
        Assert.DoesNotThrow(() => { new MotherboardBuilder().SetRamSlotsCount(1); });
        Assert.DoesNotThrow(() => { new MotherboardBuilder().SetRamSlotsCount(8); });
    }
}