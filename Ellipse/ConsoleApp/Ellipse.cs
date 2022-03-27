namespace ConsoleApp;
public class Ellipse
{
    private int
        horisontalRadius,
        verticalRadius;
     
    private const int RoundAccuracy = 2;
    
    public Ellipse(int verticalRadius, int horisontalRadius)
    {
        if (verticalRadius <= 0 | horisontalRadius <= 0)
        {
            throw new ArgumentException("Error with init object, arguments invalid");
        }

        this.verticalRadius = verticalRadius;
        this.horisontalRadius = horisontalRadius;
    }

    public double GetSquareEllipse()
    {
        return Math.Round(Math.PI * horisontalRadius * verticalRadius, RoundAccuracy);
    }

    public double GetСircumferenceEllipse()
    {
        return Math.Round(Math.PI * (horisontalRadius + verticalRadius), RoundAccuracy);
    }
}
