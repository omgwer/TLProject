using Computer.Components.Director;
using Computer.Components.Helper;

namespace Computer
{
    public static class ProcessorTest
    {
        /**
         * Build default computer and write information on console
         */
        public static void Main(string[] args)
        {
            var newComputer = new Director().BuildDefaultPc();
            Console.WriteLine("My new computer : \n");
            ComputerHelper.GetInformation(newComputer);
        }
    }
}