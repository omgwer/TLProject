using Computer.Components.Builders;

namespace Computer
{
    public static class ProcessorTest
    {
        public static void Main(string[] args)
        {
            var res = new MotherboardBuilder()
                .SetMotherboardSocket("arm")
                .SetMotherboardName("kek")
                .SetMotherboardSize("test")
                .SetRamSlotsCount(5)
                .Build();
            var proc = new ProcessorBuilder()
                .SetProcessorName("kek")
                .SetProcessorSocket("am4")
                .SetProcessorIntegratedVideo(true)
                .SetProcessorThreadCount(4)
                .SetProcessorThreadFrequency(5000)
                .Build();
            Console.WriteLine('r');
            var ram = new RamBuilder()
                .Build();
        }
    }
}