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
        
    }
}