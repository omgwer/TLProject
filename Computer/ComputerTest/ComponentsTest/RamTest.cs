using System;
using Computer.Components.Builders;
using Computer.Components.Director;
using NUnit.Framework;

namespace ComputerTest.ComponentsTest;

public class RamTest
{
    [Test]
    public void RamPositiveTest()
    {
        Assert.DoesNotThrow(() => { new Director().BuildDefaultRam(); });
    }

    [Test]
    public void RamPositiveTest_overrideValue()
    {
        var newRam = new RamBuilder()
            .SetMemoryFrequency(1500)
            .SetMemoryType("DDR3")
            .SetRamMemory(2000)
            .SetRamName("GigabyteMemory")
            .SetStickCount(4)
            .SetMemoryType("NewType")
            .Build();

        Assert.AreEqual(newRam.MemoryType, "NewType");
    }

    [Test]
    public void RamNegativeTest_emptyAllComponents()
    {
        Assert.Throws<ArgumentNullException>(() => new RamBuilder().Build());
    }

    [Test]
    public void RamNegativeTest_emptySomeoneValue()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var newProcessor = new ProcessorBuilder()
                .SetProcessorSocket("lga1155")
                .SetProcessorName("Intel")
                .SetProcessorIntegratedVideo(false)
                .SetProcessorThreadCount(5)
                .Build();
        });
    }

    [Test]
    public void RamNegativeTest_ValidateInputValueForComponents()
    {
        Assert.Throws<ArgumentException>(() => { new RamBuilder().SetStickCount(-1); });
        Assert.Throws<ArgumentException>(() => { new RamBuilder().SetStickCount(9); });
        Assert.Throws<ArgumentException>(() => { new RamBuilder().SetStickCount(0); });
        Assert.Throws<ArgumentException>(() => { new RamBuilder().SetMemoryFrequency(-1); });
        Assert.Throws<ArgumentException>(() => { new RamBuilder().SetMemoryFrequency(0); });
        Assert.Throws<ArgumentException>(() => { new RamBuilder().SetMemoryFrequency(8001); });
        Assert.DoesNotThrow(() => { new RamBuilder().SetStickCount(1); });
        Assert.DoesNotThrow(() => { new RamBuilder().SetStickCount(8); });
        Assert.DoesNotThrow(() => { new RamBuilder().SetMemoryFrequency(1); });
        Assert.DoesNotThrow(() => { new RamBuilder().SetMemoryFrequency(8000); });
    }
}