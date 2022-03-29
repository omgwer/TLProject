using Computer.Components.Builders;
using NUnit.Framework;

namespace ComputerTest;

public class MotherboardTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var testMotherBoard = new MotherboardBuilder("newMotherboard");
    }
}