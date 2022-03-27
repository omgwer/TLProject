namespace ConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int verticalRadius = 5;
            int horisontalRadius = 3;

            try
            {
                Ellipse newEllipse = new Ellipse(verticalRadius, horisontalRadius);
                Console.WriteLine("Ellipse Square is : " + newEllipse.GetSquareEllipse());
                Console.WriteLine("Ellipse Circumference is : " + newEllipse.GetСircumferenceEllipse());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}