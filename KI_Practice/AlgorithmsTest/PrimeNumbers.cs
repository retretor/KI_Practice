namespace KI_Practice;

public class PrimeNumbers
{
    private static long[]? _primes = null;

    public static long[] CalculatePrimesSieve(long count, ref long operations)
    {
        long num = CalculateSize(count);
        bool[] sieve = new bool[num + 1];
        List<long> primes = new List<long>();
        long sqrtNum = (long)Math.Sqrt(num) + 1;
        
        for (long i = 2; i <= num; i++)
        {
            operations++;
            if (!sieve[i])
            {
                primes.Add(i);
                if (i <= sqrtNum)
                {
                    for (long j = i * i; j <= num; j += i)
                    {
                        operations++;
                        sieve[j] = true;
                    }
                }
            }

            if (primes.Count == count) break;
        }
        _primes = primes.ToArray();
        return _primes;
    }
    private static long CalculateSize(long count)
    {
        // (long)(Math.Log(count) + 1.5 * Math.Log(Math.Log(count))) * count;
        return count switch
        {
            <= 100 => count * 6,
            <= 1_000 => count * 8,
            <= 100_000 => count * 13,
            <= 1_000_000 => count * 16,
            <= 10_000_000 => count * 18,
            <= 100_000_000 => count * 21,
            _ => throw new ArgumentOutOfRangeException(nameof(count))
        };
    }

    private static bool IsPrime(long x, ref long operations)
    {
        for (int j = 2; j <= Math.Sqrt(x); j++)
        {
            operations++;
            if (x % j == 0) return false;
        }
        return true;
    }

    public static long[] CalculatePrimesField(long count, ref long operations)
    {
        long num = CalculateSize(count);
        List<long> primes = new List<long>();

        for (int i = 2; i <= num; i++) // num * sqrt(num)
        {
            operations++;
            if (IsPrime(i, ref operations)) primes.Add(i);

            if (primes.Count == count) break;
        }
        
        _primes = primes.ToArray();
        return _primes;
    }
    public static void ClearPrimes() => _primes = null;
}