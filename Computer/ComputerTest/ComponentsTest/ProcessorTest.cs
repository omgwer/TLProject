using System;
using Computer.Components.Builders;
using Computer.Components.Director;
using NUnit.Framework;

namespace ComputerTest.ComponentsTest;

public class ProcessorTest
{
    [Test]
    public void ProcessorPositiveTest()
    {
        Assert.DoesNotThrow(() => { new Director().BuildDefaultMotherboard(); });
    }

    [Test]
    public void ProcessorPositiveTest_overrideValue()
    {
        var newProcessor = new ProcessorBuilder()
            .SetProcessorSocket("lga1155")
            .SetProcessorName("Intel")
            .SetProcessorIntegratedVideo(false)
            .SetProcessorThreadCount(5)
            .SetProcessorThreadFrequency(1700)
            .SetProcessorName("newName")
            .Build();

        Assert.AreEqual(newProcessor.Name, "newName");
    }

    [Test]
    public void ProcessorNegativeTest_emptyAllComponents()
    {
        Assert.Throws<ArgumentNullException>(() => new ProcessorBuilder().Build());
    }

    [Test]
    public void ProcessorNegativeTest_emptySomeoneValue()
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
    public void ProcessorNegativeTest_ValidateInputValueForComponents()
    {
        Assert.Throws<ArgumentException>(() => { new ProcessorBuilder().SetProcessorThreadCount(-1); });
        Assert.Throws<ArgumentException>(() => { new ProcessorBuilder().SetProcessorThreadCount(65); });
        Assert.Throws<ArgumentException>(() => { new ProcessorBuilder().SetProcessorThreadCount(0); });
        Assert.Throws<ArgumentException>(() => { new ProcessorBuilder().SetProcessorThreadFrequency(-1); });
        Assert.Throws<ArgumentException>(() => { new ProcessorBuilder().SetProcessorThreadFrequency(0); });
        Assert.Throws<ArgumentException>(() => { new ProcessorBuilder().SetProcessorThreadFrequency(5001); });
        Assert.DoesNotThrow(() => { new ProcessorBuilder().SetProcessorThreadCount(1); });
        Assert.DoesNotThrow(() => { new ProcessorBuilder().SetProcessorThreadCount(64); });
        Assert.DoesNotThrow(() => { new ProcessorBuilder().SetProcessorThreadFrequency(1); });
        Assert.DoesNotThrow(() => { new ProcessorBuilder().SetProcessorThreadFrequency(4999); });
    }
}
