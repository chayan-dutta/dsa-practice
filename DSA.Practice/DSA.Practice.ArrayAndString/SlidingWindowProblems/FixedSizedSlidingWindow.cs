﻿namespace DSA.Practice.ArrayAndString.SlidingWindowProblems;

public class FixedSizedSlidingWindow
{
    /// <summary>
    /// Problem: Given an integer array and a window size k, 
    /// find the maximum sum of any contiguous subarray of size k.
    /// 
    /// Approach:
    /// - Use sliding window technique to keep track of the current window sum.
    /// - Initially calculate the sum of the first k elements.
    /// - Slide the window one step at a time by removing the first element of the current window
    ///   and adding the next element in the array.
    /// - Track the maximum sum encountered during the process.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(1)
    /// </summary>
    /// <param name="array"></param>
    /// <param name="windowSize"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <remarks>for explanation of the logic - https://youtu.be/uqGxFk0cEdI?si=KkueI6LvtnKCHIIJ </remarks>
    public static int MaximumSumOfSubArray(int[] array, int windowSize)
    {
        int n = array.Length;

        // Edge case: if window size is greater than array length
        if (n < windowSize)
            throw new ArgumentException("Window size is larger than the array length.");

        int currentSum = 0;

        // Step 1: Calculate sum of the first window (first k elements)
        for (int i = 0; i < windowSize; i++)
            currentSum += array[i];

        // Step 2: Initialize maxSum with the sum of the first window
        int maxSum = currentSum;

        // Step 3: Slide the window through the array
        for (int i = 1; i <= n - windowSize; i++)
        {
            // Remove the element going out of the window and add the new one
            currentSum = currentSum - array[i - 1] + array[i + windowSize - 1];

            // Update maxSum if current window sum is greater
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

    /// <summary>
    /// Problem:
    /// Count the number of contiguous subarrays of size `k` 
    /// whose average is greater than or equal to a given `target`.
    /// 
    /// Approach:
    /// - Use the sliding window technique to keep track of the sum of the current window.
    /// - Calculate the average by dividing the window sum by `k`.
    /// - Slide the window one element at a time, updating the sum efficiently.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(1)
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int CountSubarraysWithAvgGreaterThanOrEqualToTarget(int[] nums, int k, int target)
    {
        int n = nums.Length;

        // Guard condition: window size must not be greater than the array length
        if (k > n)
            throw new ArgumentException("Subarray size (window size) cannot be greater than array length.");

        int windowSum = 0;
        int count = 0;

        // Step 1: Calculate sum of the first window of size `k`
        for (int i = 0; i < k; i++)
            windowSum += nums[i];

        // Check if the average of the first window meets the condition
        if ((double)windowSum / k >= target)
            count++;

        // Step 2: Slide the window through the array
        // We go from i = 1 to i = n - k (inclusive) -> k is the window size
        // Why? Because:
        // - `i` is the starting index of the new window
        // - The last valid starting index is `n - k` so that
        //   the window (i to i + k - 1) stays within array bounds
        for (int i = 1; i <= n - k; i++)
        {
            // Update the window sum by removing the element that's sliding out
            // and adding the new element that's sliding in
            windowSum = windowSum - nums[i - 1] + nums[i + k - 1];

            // Check the average of the current window
            if ((double)windowSum / k >= target)
                count++;
        }

        return count;
    }

    /// <summary>
    /// Problem:
    /// Find the minimum sum of any contiguous subarray of size k.
    /// 
    /// Approach:
    /// - Use the sliding window technique.
    /// - Start by calculating the sum of the first k elements (first window).
    /// - Slide the window through the array, updating the sum by removing
    ///   the outgoing element and adding the incoming one.
    /// - Track the minimum sum seen during the traversal.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(1)
    /// </summary>
    /// <param name="nums">The input array</param>
    /// <param name="k">Size of each subarray (window)</param>
    /// <returns>Minimum sum of any subarray of size k</returns>
    /// <exception cref="ArgumentException">Thrown if k is larger than array length</exception>
    public static int MinimumSumSubarrayOfSizeK(int[] nums, int k)
    {
        int n = nums.Length;

        if (k > n)
            throw new ArgumentException("Window size is greater than array length.");

        int windowSum = 0;

        // Step 1: Calculate the sum of the first window of size k
        for (int i = 0; i < k; i++)
            windowSum += nums[i];

        int minSum = windowSum;

        // Step 2: Slide the window from index 1 to n - k
        // We slide until the last valid window starts at index (n - k)
        for (int i = 1; i <= n - k; i++)
        {
            // Remove the first element of the previous window and add the new element
            windowSum = windowSum - nums[i - 1] + nums[i + k - 1];

            // Update the minimum sum
            minSum = Math.Min(minSum, windowSum);
        }

        return minSum;
    }

    /// <summary>
    /// Returns the maximum number of vowels in any substring of length k using sliding window.
    /// Time Complexity: O(n)
    /// Space Complexity: O(1) — only a fixed-size vowel set is used
    /// </summary>
    public static int MaxVowels(string s, int k)
    {
        // Handle edge cases early
        if (string.IsNullOrEmpty(s) || k <= 0)
            return 0;

        // Use a HashSet for quick lookup of vowels (both lowercase and uppercase)
        HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

        int maxVowels = 0;       // Final answer: max vowels found in any window
        int currentVowels = 0;   // Number of vowels in the current sliding window

        // Initialize the first window of size k
        for (int i = 0; i < k; i++)
        {
            if (vowels.Contains(s[i]))
                currentVowels++;
        }

        // First window count is our initial maximum
        maxVowels = currentVowels;

        // Slide the window across the rest of the string
        for (int i = k; i < s.Length; i++)
        {
            // Remove the character that's going out of the window (leftmost)
            if (vowels.Contains(s[i - k]))
                currentVowels--;

            // Add the new character entering the window (rightmost)
            if (vowels.Contains(s[i]))
                currentVowels++;

            // Update max if the current window has more vowels
            maxVowels = Math.Max(maxVowels, currentVowels);
        }

        return maxVowels;
    }

    /// <summary>
    /// Find all annnagrams of a string -
    /// Given two strings s and p, return an array of all the start indices of p's anagrams in s. 
    /// You may return the answer in any order.
    /// 
    /// Input: s = "cbaebabacd", p = "abc"
    /// Output: [0, 6]
    /// Explanation:
    /// The substring with start index = 0 is "cba", which is an anagram of "abc".
    /// The substring with start index = 6 is "bac", which is an anagram of "abc".
    /// </summary>
    /// <param name="s"></param>
    /// <param name="p"></param>
    /// <returns>
    /// Leetcode 438 
    /// Yt reference for approach - https://youtu.be/fYgU6Bi2fRg?si=phvAslJDvlhpCpBu
    /// </returns>
    public static IList<int> FindAnagrams(string s, string p)
    {
        int w = p.Length; // Length of the anagram pattern, i.e., window size
        int n = s.Length; // Length of the input string
        List<int> result = []; // List to store starting indices of anagram matches

        // Edge case: if pattern is longer than the input string, no match is possible
        if (n < w)
            return result;

        int[] pCount = new int[26]; // Frequency array for characters in pattern string 'p'
        int[] sCount = new int[26]; // Frequency array for current sliding window in string 's'

        // Step 1: Build frequency map for the pattern and the first window in 's'
        for (int i = 0; i < w; i++)
        {
            pCount[p[i] - 'a']++; // Increment count for pattern character
            sCount[s[i] - 'a']++; // Increment count for window character
        }

        // Step 2: Compare first window with pattern
        if (AreTwoArraysEqual(pCount, sCount))
            result.Add(0); // Anagram found at starting index 0

        // Step 3: Slide the window from index 1 to (n - w)
        for (int i = 1; i <= n - w; i++)
        {
            // Remove character that is sliding out of the window (at i - 1)
            sCount[s[i - 1] - 'a']--;

            // Add character that is sliding into the window (at i + w - 1)
            sCount[s[i + w - 1] - 'a']++;

            // Step 4: Compare current window frequency with pattern frequency
            if (AreTwoArraysEqual(pCount, sCount))
                result.Add(i); // Anagram found at current starting index 'i'
        }

        return result;
    }

    // Compares two frequency arrays of length 26 (for 'a' to 'z')
    private static bool AreTwoArraysEqual(int[] pCount, int[] sCount)
    {
        for (int i = 0; i < 26; i++)
        {
            if (pCount[i] != sCount[i])
                return false;
        }
        return true;
    }
}
