namespace ConsoleApp;
public class Ellipse
{
    private int
        horisontalRadius,
        verticalRadius;
     
    private const int ROUND_ACCURACY = 2;
    
    public Ellipse(int verticalRadius, int horisontalRadius)
    {
        if (verticalRadius <= 0 | horisontalRadius <= 0)
        {
            throw new ArgumentException("Error with init object, arguments invalid");
        }

        this.verticalRadius = verticalRadius;
        this.horisontalRadius = horisontalRadius;
    }

    public double getSquareEllipse()
    {
        return Math.Round(Math.PI * horisontalRadius * verticalRadius, ROUND_ACCURACY);
    }

    public double getСircumferenceEllipse()
    {
        return Math.Round(Math.PI * (horisontalRadius + verticalRadius), ROUND_ACCURACY);
    }
}
