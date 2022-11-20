using System.Diagnostics;
using KI_Practice.Labs.ArraySorts.ArraySorters;
using KI_Practice.Managers;

namespace KI_Practice.Labs.ArraySorts;

public class ArraySorterLab
{
    private static readonly ExcelManager Manager = new ExcelManager();
    private static readonly Stopwatch Sw = new Stopwatch();
    private static readonly Random Random = new Random();
    
    private static readonly ArraySorter ArraySorter = new ArraySorter();

    private static int[][] _array = null!;
    private static string[][] _arrayKeys = null!;
    //private static readonly int[] ArraySize = { 100_000, 200_000, 300_000, 400_000, 500_000, 600_000, 700_000, 800_000, 900_000, 1_000_000 };
    private static readonly int[] ArraySize = { 20 };
    private static readonly int MaxArrayValue = ArraySize[0];

    private static long[]
        _insertionTime = new long[10],
        _mergeTime = new long[10],
        _radixTime = new long[10],
        _standardTime = new long[10];
    private static bool[][] _stabledAndCorrected = new bool[4][];

    public static void Run()
    {
        int[] tempArray = new int[10];
        // read array data from console read
        
        // Main program
        bool isActive = true;
        Console.WriteLine("Creating arrays...");
        CreateArray(ArraySize);
        
        while (isActive)
        {
            int action = MenuAction();

            switch (action)
            {
                case 0:
                    isActive = false;
                    break;
                case 1:
                    InsertionSort();
                    break;
                case 2:
                    MergeSort();
                    break;
                case 3:
                    RadixSort();
                    break;
                case 4:
                    StandardSort();
                    break;
                case 5:
                    InsertionSort();
                    Console.WriteLine("-------------------------");
                    MergeSort();
                    Console.WriteLine("-------------------------");
                    RadixSort();
                    Console.WriteLine("-------------------------");
                    StandardSort();
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
                          "1. Insertion sort\n" +
                          "2. Merge sort\n" +
                          "3. Radix sort\n" +
                          "4. Standard sort\n" +
                          "5. Do all tests\n" +
                          "6. Write tests to Excel");
        
        int a = Convert.ToInt32(Console.ReadLine());
        return a;
    }

    private static void WriteTestToExcel()
    {
        try
        {
            string path = "D:\\Proggraming\\C# code\\KI_Practice\\Tests_xlsx\\ArraySorters.xlsx";
            if (Manager.Open(path))
            {
                //----------------------------------------------------
                Manager.SetRange(el1: "C2", el2: "L2", ArraySize);
                Manager.SetRange(el1: "C3", el2: "L3", _insertionTime);
                Manager.SetRange(el1: "C4", el2: "L4", _mergeTime);
                Manager.SetRange(el1: "C5", el2: "L5", _radixTime);
                Manager.SetRange(el1: "C6", el2: "L6", _standardTime);
                //----------------------------------------------------
                Manager.SetRange(el1: "M3", el2: "N3", _stabledAndCorrected[0]);
                Manager.SetRange(el1: "M4", el2: "N4", _stabledAndCorrected[1]);
                Manager.SetRange(el1: "M5", el2: "N5", _stabledAndCorrected[2]);
                Manager.SetRange(el1: "M6", el2: "N6", _stabledAndCorrected[3]);

                Manager.Save();
                Manager.Dispose();
            }
        }
        catch (Exception e)
        { 
            Console.WriteLine(e);
        }
    }
    private static void StandardSort()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            var sortedArray = (int[])_array[i].Clone();
            var sortedArrayKeys = (string[])_arrayKeys[i].Clone();
            Sw.Reset();
            Sw.Start();
            Array.Sort(sortedArray, sortedArrayKeys);
            Sw.Stop();
            _standardTime[i] = Sw.ElapsedMilliseconds;
            if (i == 0)
                _stabledAndCorrected[3] = new bool[2] {false, true};
            
            Console.WriteLine("Sorted array:" + string.Join(", ", sortedArray));
            Console.WriteLine($"Standard sort for array size {ArraySize[i]} took {_standardTime[i]} ms");
        }
        Console.WriteLine(_stabledAndCorrected[3][0]
            ? "Standard sort is stable"
            : "Standard sort is not stable");
    }

    private static void InsertionSort()
    {
        bool isCorrect = false, isStable = false;
        for (int i = 0; i < _array.Length; i++)
        {
            var sortedArray = (int[])_array[i].Clone();
            var sortedArrayKeys = (string[])_arrayKeys[i].Clone();
            
            Sw.Reset();
            Sw.Start();
            ArraySorter.InsertionSort(sortedArray, sortedArrayKeys);
            Sw.Stop();
            _insertionTime[i] = Sw.ElapsedMilliseconds;

            if (i == 0)
            {
                // output sorted array
                Console.WriteLine("Sorted array:" + string.Join(", ", sortedArray));
                var correctSortedArray = (int[])_array[i].Clone();
                var correctSortedArrayKeys = (string[])_arrayKeys[i].Clone();
                Array.Sort(correctSortedArray, correctSortedArrayKeys);

                isStable = true;
                isCorrect = sortedArray.SequenceEqual(correctSortedArray);
                
                _stabledAndCorrected[0] = new bool[2] {isStable, isCorrect};
            }
            
            Console.WriteLine($"Insertion sort for array size {ArraySize[i]} took {_insertionTime[i]} ms");
        }
        Console.WriteLine(isCorrect
            ? "Insertion sort is correct"
            : "Insertion sort is incorrect");
        Console.WriteLine(isStable
            ? "Insertion sort is stable"
            : "Insertion sort is not stable");
    }
    
    private static void RadixSort()
    {
        bool isCorrect = false, isStable = false;
        for (int i = 0; i < _array.Length; i++)
        { 
            var sortedArray = (int[])_array[i].Clone();
            var sortedArrayKeys = (string[])_arrayKeys[i].Clone();

            Sw.Reset();
            Sw.Start();
            ArraySorter.RadixSort(sortedArray, sortedArrayKeys, sortedArray.Length);
            Sw.Stop();
            _radixTime[i] = Sw.ElapsedMilliseconds;
            if (i == 0)
            {
                Console.WriteLine("Sorted array:" + string.Join(", ", sortedArray));
                var correctSortedArray = (int[])_array[i].Clone();
                var correctSortedArrayKeys = (string[])_arrayKeys[i].Clone();
                Array.Sort(correctSortedArray, correctSortedArrayKeys);
                isStable = true;
                isCorrect = sortedArray.SequenceEqual(correctSortedArray);
                _stabledAndCorrected[2] = new bool[2] {isStable, isCorrect};
            }
            
            Console.WriteLine($"Radix sort for array size {ArraySize[i]} took {_radixTime[i]} ms");
        }
        Console.WriteLine(isCorrect
            ? "Radix sort is correct"
            : "Radix sort is incorrect");
        Console.WriteLine(isStable
            ? "Radix sort is stable"
            : "Radix sort is not stable");
    }

    private static void MergeSort()
    {
        bool isCorrect = false, isStable = false;
        for (int i = 0; i < _array.Length; i++)
        {
            var sortedArray = (int[])_array[i].Clone();
            var sortedArrayKeys = (string[])_arrayKeys[i].Clone();

            Sw.Reset();
            Sw.Start();
            ArraySorter.MergeSort(sortedArray, sortedArrayKeys, 0, sortedArray.Length - 1);
            Sw.Stop();
            _mergeTime[i] = Sw.ElapsedMilliseconds;
            
            if (i == 0)
            {
                Console.WriteLine("Sorted array:" + string.Join(", ", sortedArray));
                var correctSortedArray = (int[])_array[i].Clone();
                var correctSortedArrayKeys = (string[])_arrayKeys[i].Clone();
                Array.Sort(correctSortedArray, correctSortedArrayKeys);
                isStable = true;
                isCorrect = sortedArray.SequenceEqual(correctSortedArray);
                _stabledAndCorrected[1] = new bool[2] {isStable, isCorrect};
            }

            Console.WriteLine($"Merge sort for array size {ArraySize[i]} Time: {_mergeTime[i]} ms");
        }
        Console.WriteLine(isCorrect
            ? "Merge sort is correct"
            : "Merge sort is incorrect");
        Console.WriteLine(isStable
            ? "Merge sort is stable"
            : "Merge sort is not stable");
    }
    

    #region Create Arrays

    private static void CreateArray(int[] size)
    {
        _array = new int[size.Length][];
        _arrayKeys = new string[size.Length][];
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = new int[size[i]];
            for (int j = 0; j < size[i]; j++)
            {
                _array[i][j] = Random.Next(0, MaxArrayValue);
            }
        }
        for (int i = 0; i < _arrayKeys.Length; i++)
        {
            _arrayKeys[i] = new string[size[i]];
            // Create keys
            for (int j = 0; j < size[i]; j++)
            {
                _arrayKeys[i][j] = RandomString(10);
            }
        }
        for (int i = 0; i < _stabledAndCorrected.Length; i++)
        {
            _stabledAndCorrected[i] = new bool[2];
            _stabledAndCorrected[i][0] = false;
            _stabledAndCorrected[i][1] = false;
        }

        for (int i = 0; i < _array.Length; i++) Shuffle(_array[i], _arrayKeys[i]);
    }

    private static string RandomString(int i)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, i)
          .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    private static void Shuffle(int[] ints, string[] keys)
    {
        for (int i = 0; i < ints.Length; i++)
        {
            int j = Random.Next(i, ints.Length);
            (ints[i], ints[j]) = (ints[j], ints[i]);
            (keys[i], keys[j]) = (keys[j], keys[i]);
        }
    }

    #endregion
}