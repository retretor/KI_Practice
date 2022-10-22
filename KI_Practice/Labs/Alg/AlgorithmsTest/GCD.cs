namespace KI_Practice.Labs.Alg.AlgorithmsTest;

public class GCD
{
    public static long Division(long a, long b, ref long operations)
    {
        while (b != 0)
        {
            var c = a % b;
            a = b;
            b = c;
            operations++;
        }
        return a;
    }
    public static long Enumeration(long a, long b, ref long operations)
    {
        long gcd = 1L;

        for (long i = Min(a, b); i > 0; i--) {
            operations++;
            if (a % i == 0 && b % i == 0) {
                gcd = i;
                break;
            }
        }
        
        return gcd;
    }
    public static long EuclidAlgRec(long a, long b, ref long operations)
    {
        if (a == 0)
        {
            operations++;
            return b;
        }

        operations++;
        return EuclidAlgRec(b % a, a, ref operations);
    }
    private static long Min(long a, long b) => a < b ? a : b;
}