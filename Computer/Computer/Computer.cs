using Computer.Components.Factory;
using Computer.Components.Helper;

namespace Computer
{
    public static class Computer
    {
        public static void Main(string[] args)
        {
            var myDefaultPc = new ComputerFactory().BuildDefaultPc();
            new GetInformation(myDefaultPc);
        }
    }
}