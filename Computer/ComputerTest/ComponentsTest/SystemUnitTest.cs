using System;
using Computer.Components.Builders;
using Computer.Components.Director;
using NUnit.Framework;

namespace ComputerTest.ComponentsTest;

public class SystemUnitTest
{
    [Test]
    public void SustemUnitPositiveTest()
    {
        Assert.DoesNotThrow(() => { new Director().BuildDefaultSustemUnit(); });
    }

    [Test]
    public void SustemUnitPositiveTest_overrideValue()
    {
        var newSystemUnit = new SystemUnitBuilder()
            .SetColor("red")
            .SetName("myFavoriteBlock")
            .SetSize("fullTower")
            .SetWeight(100)
            .SetName("NewName")
            .Build();

        Assert.AreEqual(newSystemUnit.Name, "NewName");
    }

    [Test]
    public void SustemUnitNegativeTest_emptyAllComponents()
    {
        Assert.Throws<ArgumentNullException>(() => new SystemUnitBuilder().Build());
    }

    [Test]
    public void SustemUnitNegativeTest_emptySomeoneValue()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var sustemUnit = new SystemUnitBuilder()
                .SetColor("red")
                .SetName("myFavoriteBlock")
                .SetSize("fullTower")
                .Build();
        });
    }

    [Test]
    public void SustemUnitNegativeTest_ValidateInputValueForComponents()
    {
        Assert.Throws<ArgumentException>(() => { new SystemUnitBuilder().SetWeight(-1); });
        Assert.Throws<ArgumentException>(() => { new SystemUnitBuilder().SetWeight(10001); });
        Assert.Throws<ArgumentException>(() => { new SystemUnitBuilder().SetWeight(0); });
        Assert.DoesNotThrow(() => { new SystemUnitBuilder().SetWeight(1); });
        Assert.DoesNotThrow(() => { new SystemUnitBuilder().SetWeight(10000); });
    }
}