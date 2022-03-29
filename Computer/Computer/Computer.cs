using Computer.Components.Director;
using Computer.Components.Helper;

namespace Computer
{
    public static class Computer
    {
        public static void Main(string[] args)
        {
            var myDefaultPc = new Director().BuildDefaultPc();
            new GetInformation(myDefaultPc);
        }
    }
}