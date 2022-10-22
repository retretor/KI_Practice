namespace KI_Practice.Labs.Alg.AlgorithmsTest;

public class SubArray
{
    public static long SubHard(long[] array, ref long operations)
    {
        long max = 0;
        for (long i = 0; i < array.Length; i++)
        {
            for (long j = i; j < array.Length; j++)
            {
                long sum = 0;
                for (long k = i; k < j; k++)
                {
                    operations++;
                    sum += array[k];
                }
                max = Max(max, sum);
            }
        }
        return max;
    }
    public static long SubMedium(long[] array, ref long operations)
    {
        long max = 0;
        for (long i = 0; i < array.Length; i++)
        {
            long sum = 0;
            for (long j = i; j < array.Length; j++)
            {
                operations++;
                sum += array[j];
                max = Max(max, sum);
            }
        }
        return max;
    }
    public static long SubEasy(long[] array, ref long operations)
    {
        long max = 0;
        long maxEnding = 0;
        for (long i = 0; i < array.Length; i++)
        {
            operations++;
            maxEnding = Max(0, maxEnding + array[i]);
            max = Max(max, maxEnding);
        }
        return max;
    }
    private static long Max(long a, long b) => a > b ? a : b;

}