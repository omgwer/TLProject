
using Computer.Components;

namespace Computer
{
    public static class Computer
    {
        static Dictionary<string, Dictionary<string, string>> ComputerContainer = new();
        public static void Main(string[] args)
        {
            var processorBuilder = new ProcessorBuilder("Amd");
            processorBuilder.SetProcessorCashStorage(15);
            processorBuilder.SetProcessorThreadCount(22);
            processorBuilder.SetProcessorThreadFrequency(5000);
            processorBuilder.SetProcessorTdp(25);
            var myProcessor = processorBuilder.Build();
            
        }
    }
};

