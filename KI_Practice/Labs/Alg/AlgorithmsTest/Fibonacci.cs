namespace KI_Practice.Labs.Alg.AlgorithmsTest;

public class Fibonacci
{
    public static long CalculateUsingRecursion(long x, ref long operations)
    {
        operations++;
        if (x == 0 || x == 1)
        {
            return x;
        }
        return CalculateUsingRecursion(x - 1, ref operations) + CalculateUsingRecursion(x - 2, ref operations);
    }

    public static long CalculateUsingThreeField(long x, ref long operations)
    {
        operations++;
        if (x == 0 || x == 1) return x;
        long a = 0, b = 1, c = 0;
        for (long i = 0; i < x - 1; i++)
        {
            operations++;
            c = a + b;
            (a, b) = (b, c);
        }

        return c;
    }
    public static long CalculateUsingThreeField(long x)
    {
        if (x == 0 || x == 1) return x;
        long a = 0, b = 1, c = 0;
        for (long i = 0; i < x - 1; i++)
        {
            c = a + b;
            (a, b) = (b, c);
        }

        return c;
    }
}