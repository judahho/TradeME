namespace TradeME;

public class Mathf
{
    // random intager from 0 to 'maxExclusive'
    public static int Range(int maxExclusive)
    {
        Random rand = new Random();
        return rand.Next(maxExclusive);
    }
    // random float from 0 to 'maxExclusive'
    public static float Range(float maxExclusive)
    {
        Random rand = new Random();
        float value = rand.Next((int)maxExclusive) - rand.NextSingle();
        return (value >= maxExclusive) ? maxExclusive - .1f : value;
    }
    // random intager from 'mixInclusive' to 'maxExclusive'
    public static int Range(int minInclusive, int maxExclusive)
    {
        if (minInclusive <= maxExclusive) { throw new Exception("'minInclusive' is less than or equal to 'maxExclusive'"); }
        Random rand = new Random();
        return rand.Next(maxExclusive - minInclusive) + minInclusive;
    }
    // random float from 'mixInclusive' to 'maxExclusive'
    public static float Range(float minInclusive, float maxExclusive)
    {
        if (minInclusive <= maxExclusive) { throw new Exception("'minInclusive' is less than or equal to 'maxExclusive'"); }
        Random rand = new Random();
        float value = (rand.Next((int)maxExclusive - (int)minInclusive) - rand.NextSingle()) + minInclusive;
        return (value >= maxExclusive) ? maxExclusive - .1f : (value < minInclusive) ? minInclusive:value;
    }
}
