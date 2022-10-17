using System.Diagnostics;
using KI_Practice.Managers;

namespace KI_Practice.Labs;
public class AlgLab
{
    //Fields
    private static readonly Stopwatch Sw = new Stopwatch();
    private static readonly ExcelManager Manager = new ExcelManager();
        
    private delegate long[] PrimeDelegate(long n, ref long op);
    private delegate long FibDelegate(long n, ref long op);
    private delegate long SubArrSumDelegate(long[] n, ref long op);
    private delegate long GcdDelegate(long a, long b, ref long op);

    private static long[]
        //fib
        FR_time = new long[10],
        FR_op = new long[10],
        FF_time = new long[10],
        FF_op = new long[10],
        //GCD
        DivGCD_time = new long[10],
        DivGCD_op = new long[10],
        EnumerationGCD_time = new long[10],
        EnumerationGCD_op = new long[10],
        EuclRecGCD_time = new long[10],
        EuclRecGCD_op = new long[10],
        //SubArray
        SubH_time = new long[10],
        SubH_op = new long[10],
        SubM_time = new long[10],
        SubM_op = new long[10],
        SubE_time = new long[10],
        SubE_op = new long[10],
        //prime
        PS_time = new long[10],
        PS_op = new long[10],
        PF_time = new long[10],
        PF_op = new long[10];
    private static long[]
        //fib
        _ffNum = new long[10],
        //sort
        _gcdNum = new long[10],
        //SubArray
        _subNum = new long[10],
        //prime
        _peNum = new long[10];
    private static int _gcdNum2 = 0;
        
    //Methods
    public static void Run()
    {
        // Main program
        bool isActive = true;
        while (isActive)
        {
            int action = MenuAction();
                
            switch (action)
            {
                case 0:
                    isActive = false;
                    break;
                case 1:
                    FibonacciNumberCompare();
                    break;
                case 2:
                    SubArraySumCompare();
                    break;
                case 3:
                    PrimeNumbersCompare();
                    break;
                case 4:
                    GcdCompare();
                    break;
                case 5:
                    FibonacciNumberCompare();
                    PrimeNumbersCompare();
                    GcdCompare();
                    SubArraySumCompare();
                    break;
                case 6:
                    WriteTestToExcel();
                    break;
                default:
                    break;
            }
        }
    }
    private static int MenuAction()
    {
        Console.WriteLine("Enter an action:\n" +
                          "0. Leave\n" +
                          "1. Fibonacci number\n" +
                          "2. Sub array sum\n" +
                          "3. Find first n prime numbers\n" +
                          "4. Greater common division\n" +
                          "5. Do all tests\n" +
                          "6. Write tests results to excel");
        int a = Convert.ToInt32(Console.ReadLine());
        return a;
    }

    private static void GcdCompare()
    {
        long num2 = Fibonacci.CalculateUsingThreeField(40);
        _gcdNum2 = (int)num2;
        long[] arr =
        { Fibonacci.CalculateUsingThreeField(41), Fibonacci.CalculateUsingThreeField(42),
            Fibonacci.CalculateUsingThreeField(43), Fibonacci.CalculateUsingThreeField(44),
            Fibonacci.CalculateUsingThreeField(45), Fibonacci.CalculateUsingThreeField(46),
            Fibonacci.CalculateUsingThreeField(47), Fibonacci.CalculateUsingThreeField(48),
            Fibonacci.CalculateUsingThreeField(49), Fibonacci.CalculateUsingThreeField(50) };
        _gcdNum = arr;
            
        GcdDelegate gcdDelegate = GCD.Division;
        TestGcd(gcdDelegate, DivGCD_op, DivGCD_time, arr, num2, "Division");
        gcdDelegate = GCD.Enumeration;
        TestGcd(gcdDelegate, EnumerationGCD_op, EnumerationGCD_time, arr, num2, "Enumeration");
        gcdDelegate = GCD.EuclidAlgRec;
        TestGcd(gcdDelegate, EuclRecGCD_op, EuclRecGCD_time, arr, num2, "Euclidean (recursion)");

    }

    private static void SubArraySumCompare()
    {
        long[][] arr = new long[10][];
        Random rnd = new Random();
        for (long i = 0; i < arr.Length; i++)
        {
            arr[i] = new long[(i + 1) * 300];
            _subNum[i] = (i + 1) * 300;
            for (int j = 0; j < arr[i].Length; j++)
            {
                arr[i][j] = rnd.Next(-100, 100);
            }
        }

        SubArrSumDelegate subArrSumDelegate = SubArray.SubHard;
        TestArr(subArrSumDelegate, SubH_op, SubH_time, arr, "SubSumH");
        subArrSumDelegate = SubArray.SubMedium;
        TestArr(subArrSumDelegate, SubM_op, SubM_time, arr, "SubSumM");
        subArrSumDelegate = SubArray.SubEasy;
        TestArr(subArrSumDelegate, SubE_op, SubE_time, arr, "SubSumE");
    }

    private static void PrimeNumbersCompare()
    {
        long[] arr = { 100_000, 200_000, 300_000, 400_000, 500_000, 600_000, 700_000, 800_000, 900_000, 1_000_000 };
        //long[] arr = { 100_000_000 };
        _peNum = arr;
            
        PrimeDelegate primeDelegate = PrimeNumbers.CalculatePrimesSieve;
        TestPrime(primeDelegate, PS_op, PS_time, arr, "Sieve");
        primeDelegate = PrimeNumbers.CalculatePrimesField;
        TestPrime(primeDelegate, PF_op, PF_time, arr, "Field");
    }
        
    private static void FibonacciNumberCompare()
    {
        long[] arr = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        _ffNum = arr;
            
        FibDelegate fibonacciDelegate = Fibonacci.CalculateUsingRecursion;
        TestFib(fibonacciDelegate, FR_op, FR_time, arr, "Recursive fibonacci");
        fibonacciDelegate = Fibonacci.CalculateUsingThreeField;
        TestFib(fibonacciDelegate, FF_op, FF_time, arr, "Three field fibonacci");
    }

    private static void TestPrime(PrimeDelegate dDelegate, long[] operations, long[] time, long[] data, string text)
    {
        for (int i = 0; i < data.Length; i++)
        {
            long counter = 0;
            Sw.Reset();
            Sw.Start();
            dDelegate(data[i], ref counter);
            Sw.Stop();
            PrimeNumbers.ClearPrimes();
            operations[i] = counter;
            time[i] = Sw.ElapsedMilliseconds;
            Console.WriteLine($"{text} {data[i]}\tTime - {time[i]}\tOperations - {counter}");
        }
    }
    private static void TestFib(FibDelegate dDelegate, long[] operations, long[] time, long[] data, string text)
    {
        for (int i = 0; i < data.Length; i++)
        {
            long counter = 0;
            Sw.Reset();
            Sw.Start();
            long a = dDelegate(data[i], ref counter);
            Sw.Stop();
            operations[i] = counter;
            time[i] = Sw.ElapsedMilliseconds;
            Console.WriteLine(data[i] < 35
                ? $"{text} {data[i]}\tNumber - {a}\t\tTime - {time[i]}\tOperations - {counter}"
                : $"{text} {data[i]}\tNumber - {a}\tTime - {time[i]}\tOperations - {counter}");
        }
    }
    private static void TestArr(SubArrSumDelegate dDelegate, long[] operations, long[] time, long[][] data, string text)
    {
        for (int i = 0; i < data.Length; i++)
        {
            long counter = 0;
            Sw.Reset();
            Sw.Start();
            long a = dDelegate(data[i], ref counter);
            Sw.Stop();
            operations[i] = counter;
            time[i] = Sw.ElapsedMilliseconds;
            Console.WriteLine($"{text} {data[i].Length}\tSum - {a}\tTime - {time[i]}\tOperations - {counter}");
        }
    }
    private static void TestGcd(GcdDelegate dDelegate, long[] operations, long[] time, long[] data, long data2, string text)
    {
        for (int i = 0; i < data.Length; i++)
        {
            long counter = 0;
            Sw.Reset();
            Sw.Start();
            long a = dDelegate(data[i], data2, ref counter);
            Sw.Stop();
            operations[i] = counter;
            time[i] = Sw.ElapsedMilliseconds;
            Console.WriteLine($"{text} {data[i]} and {data2}\tGCD - {a}\tTime - {time[i]}\tOperations - {counter}");
            data2 = data[i];
        }
    }
        
    private static void WriteTestToExcel()
    {
        try
        {
            string path = "D:\\Proggraming\\C# code\\KI_Practice\\Tests_xlsx\\Algorithms.xlsx";

            if (Manager.Open(path))
            {
                //----------------------------------------------------
                Manager.SetRange(el1: "C2", el2: "L2", _ffNum);
                Manager.SetRange(el1: "C3", el2: "L3", FR_time);
                Manager.SetRange(el1: "C4", el2: "L4", FR_op);
                Manager.SetRange(el1: "C5", el2: "L5", FF_time);
                Manager.SetRange(el1: "C6", el2: "L6", FF_op);
                //----------------------------------------------------
                Manager.SetRange(el1: "C18", el2: "L18", _peNum);
                Manager.SetRange(el1: "C19", el2: "L19", PF_time);
                Manager.SetRange(el1: "C20", el2: "L20", PF_op);
                Manager.SetRange(el1: "C21", el2: "L21", PS_time);
                Manager.SetRange(el1: "C22", el2: "L22", PS_op);
                //----------------------------------------------------
                Manager.SetRange(el1: "C25", el2: "L25", _gcdNum);
                Manager.SetRange(el1: "D26", el2: "M26", _gcdNum);
                Manager.Set("C", 26, _gcdNum2);
                Manager.Set("M", 26, "");
                Manager.SetRange(el1: "C27", el2: "L27", DivGCD_time);
                Manager.SetRange(el1: "C28", el2: "L28", DivGCD_op);
                Manager.SetRange(el1: "C29", el2: "L29", EnumerationGCD_time);
                Manager.SetRange(el1: "C30", el2: "L30", EnumerationGCD_op);
                Manager.SetRange(el1: "C31", el2: "L31", EuclRecGCD_time);
                Manager.SetRange(el1: "C32", el2: "L32", EuclRecGCD_op);
                //----------------------------------------------------
                Manager.SetRange(el1: "C9", el2: "L9", _subNum);
                Manager.SetRange(el1: "C10", el2: "L10", SubH_time);
                Manager.SetRange(el1: "C11", el2: "L11", SubH_op);
                Manager.SetRange(el1: "C12", el2: "L12", SubM_time);
                Manager.SetRange(el1: "C13", el2: "L13", SubM_op);
                Manager.SetRange(el1: "C14", el2: "L14", SubE_time);
                Manager.SetRange(el1: "C15", el2: "L15", SubE_op);
                //----------------------------------------------------
                
                Manager.Save();
                Manager.Dispose();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}