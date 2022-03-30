using Computer.Components.Builders;

namespace Computer
{
    public static class ProcessorTest
    {
        public static void Main(string[] args)
        {
            // var myDefaultPc = new Director().BuildDefaultPc();
            //new ComputerHelper().GetInformation(myDefaultPc);

            var t = new MotherboardBuilder();
            var res = t.SetMotherboardSocket("arm")
                .SetMotherboardName("kek")
                .SetMotherboardSize("test")
                .SetRamSlotsCount(5)
                .Build();
            Console.WriteLine('r');
        }
    }
}