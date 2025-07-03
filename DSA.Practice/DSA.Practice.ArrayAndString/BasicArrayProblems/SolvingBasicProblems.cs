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
        for (int i = 0; i < myArray.Length; i++)
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
            if (myArray[i] % 2 == 0)
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
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int[] ReverseArrayWithoutNewArray(int[] arr)
    {
        int n = arr.Length, left = 0;
        int right = n - 1;

        // Swap the elements in the indices

        while (left <= right)
        {
            // Swap without using 3rd variable
            arr[left] = arr[left] + arr[right];
            arr[right] = arr[left] - arr[right];
            arr[left] = arr[left] - arr[right];

            left++;
            right--;
        }
        return arr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="myArray"></param>
    /// <returns></returns>
    public static bool IsSortedArray(int[] myArray)
    {
        int n = myArray[0];

        for (int i = 1; i < myArray.Length; i++)
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

        foreach (int num in arr)
        {
            if (!uniqueTracker.ContainsKey(num))
                uniqueTracker.Add(num, 1);
            else
                uniqueTracker[num]++;
        }
        var kvp = uniqueTracker.FirstOrDefault(x => x.Value == 1);
        return kvp.Key;
    }

    /// <summary>
    /// Rotates the given array to the right by 'k' positions.
    /// </summary>
    /// <param name="array">The input array to rotate.</param>
    /// <param name="k">Number of times the array should be rotated to the right.</param>
    /// <returns>A new array that is the rotated version of the original array.</returns>
    /// <remarks>
    /// This implementation performs a right rotation using array slicing technique.
    /// Time Complexity: O(n), Space Complexity: O(n)
    /// For explanation, see - https://youtu.be/ODBaRTfZsDg?t=2407&si=Y1WUrp7lY10TNE7f
    /// </remarks>
    public static int[] RotateArrayKTimes(int[] array, int k)
    {
        int n = array.Length;

        // Edge case: if array is empty or k is 0, return original array
        if (n == 0 || k == 0)
            return array;

        // Normalize k: if k >= n, rotate only the remainder steps
        k = k % n;

        // Create a new array to hold the rotated result
        int[] result = new int[n];
        int j = 0;

        // Copy the last 'k' elements from the original array to the start of result array
        // These will be the new front part after right rotation
        for (int i = n - k; i < n; i++)
        {
            result[j++] = array[i];
        }

        // Copy the first 'n-k' elements to the end of result array
        for (int i = 0; i < n - k; i++)
        {
            result[j++] = array[i];
        }

        return result;
    }

    /// <summary>
    /// Rotates the array to the right by k positions **in-place** (without using a new array).
    /// </summary>
    /// <param name="array">The input array to rotate.</param>
    /// <param name="k">Number of positions to rotate to the right.</param>
    /// <returns>The same array rotated in-place.</returns>
    public int[] RotateAnArrayKTimesWithoutUsingNewArray(int[] array, int k)
    {
        int n = array.Length;

        // Edge case: empty array or no rotation needed
        if (n == 0 || k == 0 || k % n == 0)
            return array;

        // Normalize k to avoid unnecessary full rotations
        k = k % n;

        // Step 1: Reverse the first part (from 0 to n-k-1)
        ReversePartialArray(array, 0, n - k - 1);

        // Step 2: Reverse the second part (from n-k to n-1)
        ReversePartialArray(array, n - k, n - 1);

        // Step 3: Reverse the whole array
        ReversePartialArray(array, 0, n - 1);

        return array;
    }

    /// <summary>
    /// Reverses a portion of the array from 'left' to 'right' indices (inclusive).
    /// </summary>
    private static void ReversePartialArray(int[] array, int left, int right)
    {
        while (left < right)
        {
            int temp = array[left];
            array[left++] = array[right];
            array[right--] = temp;
        }
    }
}
