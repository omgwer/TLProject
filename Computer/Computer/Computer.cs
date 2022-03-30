using Computer.Components.Director;
using Computer.Components.Helper;
using Computer.Components.Container;

namespace Computer
{
    public static class ProcessorTest
    {
        public static void Main(string[] args)
        {
            // var myDefaultPc = new Director().BuildDefaultPc();
            //new ComputerHelper().GetInformation(myDefaultPc);

            var t = new Processor();
            t.Name = "test";
            Console.WriteLine("rrr");
            
            
        }
    }
}