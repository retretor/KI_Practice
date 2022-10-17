using System.Diagnostics;

namespace KI_Practice;

public class ArraySorter
{
    private static int[] _array = new int[1];

    public int[] GetArray()
    {
        return _array;
    }
    public void SetArray(int[] array)
    {
        _array = array;
    }

    #region Insertion sort
    public void InsertionSort(int[] array, string[] keys)
    {
        for (int i = 1; i < array.Length; i++)
        {
            var temp = array[i];
            var tempKey = keys[i];
            var j = i;
            while (j > 0 && array[j - 1] > temp)
            {
                array[j] = array[j - 1];
                keys[j] = keys[j - 1];
                --j;
            }
            array[j] = temp;
            keys[j] = tempKey;
        }
    }
    #endregion

    #region Merge sort
    private static void Merge(int[] arr, int l, int m, int r, string[] keys)
    {
        int n1 = m - l + 1;
        int n2 = r - m;
        
        int[] L = new int[n1];
        int[] R = new int[n2];
        string[] LKeys = new string[n1];
        string[] RKeys = new string[n2];
        int i, j;

        for (i = 0; i < n1; ++i)
        {
            L[i] = arr[l + i];
            LKeys[i] = keys[l + i];
        }

        for (j = 0; j < n2; ++j)
        {
            R[j] = arr[m + 1 + j];
            RKeys[j] = keys[m + 1 + j];
        }

        i = 0;
        j = 0;
        
        int k = l;
        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                arr[k] = L[i];
                keys[k] = LKeys[i];
                i++;
            }
            else {
                arr[k] = R[j];
                keys[k] = RKeys[j];
                j++;
            }
            k++;
        }
        
        while (i < n1) {
            arr[k] = L[i];
            keys[k] = LKeys[i];
            i++;
            k++;
        }
        
        while (j < n2) {
            arr[k] = R[j];
            keys[k] = RKeys[j];
            j++;
            k++;
        }
    }
    
    public void MergeSort(int[] arr, int l, int r, string[] keys)
    {
        if (l < r) {
            int m = l + (r - l) / 2;
            MergeSort(arr, l, m, keys);
            MergeSort(arr, m + 1, r, keys);
            Merge(arr, l, m, r, keys);
        }
    }
    #endregion

    #region Radix sort
    public void RadixSort(int[] arr, int n, string[] keys)
    {
        int m = GetMax(arr, n);

        for (int exp = 1; m / exp > 0; exp *= 10)
            CountSort(arr, n, exp, keys);
    }

    private static void CountSort(int[] arr, int n, int exp, string[] keys)
    {
        int[] output = new int[n];
        string[] outputKeys = new string[n];
        int i;
        int[] count = new int[10];

        for (i = 0; i < 10; i++)
            count[i] = 0;
        
        for (i = 0; i < n; i++)
            count[(arr[i] / exp) % 10]++;
        
        for (i = 1; i < 10; i++)
            count[i] += count[i - 1];
        
        for (i = n - 1; i >= 0; i--) {
            int index = (arr[i] / exp) % 10;
            
            output[count[index] - 1] = arr[i];
            outputKeys[count[index] - 1] = keys[i];
            count[index]--;
        }

        for (i = 0; i < n; i++) {
            arr[i] = output[i];
            keys[i] = outputKeys[i];
        }
    }

    private static int GetMax(int[] arr, int n)
    {
        int mx = arr[0];
        for (int i = 1; i < n; i++)
            if (arr[i] > mx)
                mx = arr[i];
        return mx;
    }
    #endregion
    
    #region Is stable
    
    public bool IsStable(int[] startArray, string[] startKeys, int[] endArray, string[] endKeys)
    {
        // find elements of startArray in endArray and compare their keys
        for (int i = 0; i < startArray.Length; i++)
        {
            for (int j = 0; j < endArray.Length; j++)
            {
                if (startArray[i] == endArray[j])
                {
                    if (startKeys[i] != endKeys[j])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    #endregion
}