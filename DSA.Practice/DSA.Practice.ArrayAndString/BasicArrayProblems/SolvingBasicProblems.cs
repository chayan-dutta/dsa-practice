namespace DSA.Practice.ArrayAndString.BasicArrayProblems;

/// <summary>
/// 
/// </summary>
/// <param name="myArray"></param>
public class SolvingBasicProblems()
{
    /// <summary>
    /// Find the largest integer present in the array
    /// </summary>
    /// <param name="myArray"> Array of integers to evaluate </param>
    public static void FindMaximumNumberOfArray(int[] myArray)
    {
        int maximum = 0;

        for (int i = 0; i < myArray.Length; i++)
        {
            if (myArray[i] > maximum) 
                maximum = myArray[i]; 
        }

        Console.WriteLine("The maximum number in this array is - {0}", maximum);
    }

    /// <summary>
    /// Sum of all elements of a given array
    /// </summary>
    /// <param name="myArray"> Array of integers to evaluate </param>
    /// <returns></returns>
    public static int SumOfAllArrayElements(int[] myArray)
    {
        int sum = 0;
        for(int i = 0;i < myArray.Length;i++)
            sum += myArray[i];
        
        return sum;
    }

    /// <summary>
    /// Counts the total number of even and odd numbers in the given integer array.
    /// </summary>
    /// <param name="myArray">An array of integers to evaluate.</param>
    /// <returns>
    /// A tuple containing two integers:
    /// <c>totalEvenNumber</c> - the count of even numbers,
    /// <c>totalOddNumber</c> - the count of odd numbers in the array.
    /// </returns>
    /// <example>
    /// int[] numbers = { 1, 2, 3, 4, 5 };
    /// var result = CountEvenOdd(numbers);
    /// result.totalEvenNumber = 2, result.totalOddNumber = 3
    /// </example>
    public static (int totalEvenNumber, int totalOddNumber) CountEvenOdd(int[] myArray)
    {
        int countEven = 0;
        int countOdd = 0;

        for (int i = 0; i < myArray.Length; i++)
        {
            if (myArray[i] % 2  == 0)
                countEven++;
            else
                countOdd++;
        }
        return (countEven, countOdd);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="myArray"> Array of integers to evaluate </param>
    /// <returns>
    /// A reversed array of the given array
    /// </returns>
    public static int[] ReverseArray(int[] myArray)
    {
        int[] reverseArray = new int[myArray.Length];
        int j = myArray.Length - 1;

        for (int i = 0; i < myArray.Length; i++)
        {
            reverseArray[i] = myArray[j];
            j--;
            if (j < 0)
                break;
        }
        return reverseArray;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="myArray"></param>
    /// <returns></returns>
    public static bool IsSortedArray(int[] myArray)
    {
        int n = myArray[0];

        for(int i = 1; i < myArray.Length; i++)
        {
            if (n <= myArray[i])
                n = myArray[i];
            else
                return false;
        }
        return true;
    }

    /// <summary>
    /// Finds the number of unique pairs in the array whose sum is equal to k.
    /// </summary>
    /// <param name="arr">Input array of integers</param>
    /// <param name="k">Target sum for the pairs</param>
    /// <returns>Number of unique pairs whose sum is equal to k</returns>
    public static int TargetSum(int[] arr, int k)
    {
        int noOfPairs = 0;

        // This set keeps track of numbers we've already seen
        HashSet<int> seen = new();

        // This set ensures we count each pair only once
        HashSet<(int, int)> uniquePairs = new();

        foreach (int num in arr)
        {
            int complement = k - num;

            if (seen.Contains(complement))
            {
                // Order the pair so (a, b) and (b, a) are treated the same
                var orderedPair = (Math.Min(num, complement), Math.Max(num, complement));

                if (!uniquePairs.Contains(orderedPair))
                {
                    uniquePairs.Add(orderedPair);
                    noOfPairs++;
                }
            }
            seen.Add(num);
        }

        return noOfPairs;
    }

    // Find unique number in a given array where all other elements are being repeated twice
    // with one value being unique
    public static int UniqueElementOfArrayWhereOthersDuplicate(int[] arr)
    {
        Dictionary<int, int> uniqueTracker = [];

        foreach(int num in arr)
        {
            if (!uniqueTracker.ContainsKey(num))
                uniqueTracker.Add(num, 1);
            else
                uniqueTracker[num]++;
        }
        var kvp = uniqueTracker.FirstOrDefault(x => x.Value == 1);
        return kvp.Key;
    }
}
