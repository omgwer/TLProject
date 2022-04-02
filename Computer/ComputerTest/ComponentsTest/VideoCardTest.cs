using System;
using Computer.Components.Builders;
using Computer.Components.Director;
using NUnit.Framework;

namespace ComputerTest.ComponentsTest;

public class VideoCardTest
{
    [Test]
    public void VideoCardPositiveTest()
    {
        Assert.DoesNotThrow(() => { new Director().BuildDefaultVideoCard(); });
    }

    [Test]
    public void SustemUnitPositiveTest_overrideValue()
    {
        var newVideoCard = new VideoCardBuilder()
            .SetMemorySize(10000)
            .SetTdp(159)
            .SetProcessorType("GeForce")
            .SetVideocardName("newVideCard")
            .SetProcessorType("NewProcessorType")
            .Build();

        Assert.AreEqual(newVideoCard.Processor, "NewProcessorType");
    }

    [Test]
    public void SustemUnitNegativeTest_emptyAllComponents()
    {
        Assert.Throws<ArgumentNullException>(() => new VideoCardBuilder().Build());
    }

    [Test]
    public void SustemUnitNegativeTest_emptySomeoneValue()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var newVideoCard = new VideoCardBuilder()
                .SetMemorySize(10000)
                .SetTdp(159)
                .SetProcessorType("GeForce")
                .Build();
        });
    }

    [Test]
    public void SustemUnitNegativeTest_ValidateInputValueForComponents()
    {
        Assert.Throws<ArgumentException>(() => { new VideoCardBuilder().SetMemorySize(-1); });
        Assert.Throws<ArgumentException>(() => { new VideoCardBuilder().SetMemorySize(16001); });
        Assert.Throws<ArgumentException>(() => { new VideoCardBuilder().SetMemorySize(0); });
        Assert.Throws<ArgumentException>(() => { new VideoCardBuilder().SetTdp(-1); });
        Assert.Throws<ArgumentException>(() => { new VideoCardBuilder().SetTdp(301); });
        Assert.Throws<ArgumentException>(() => { new VideoCardBuilder().SetTdp(0); });
        Assert.DoesNotThrow(() => { new VideoCardBuilder().SetMemorySize(1); });
        Assert.DoesNotThrow(() => { new VideoCardBuilder().SetMemorySize(16000); });
        Assert.DoesNotThrow(() => { new VideoCardBuilder().SetTdp(1); });
        Assert.DoesNotThrow(() => { new VideoCardBuilder().SetTdp(300); });
    }
}