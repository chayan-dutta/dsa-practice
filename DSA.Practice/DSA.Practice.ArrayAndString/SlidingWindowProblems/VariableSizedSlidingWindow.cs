namespace DSA.Practice.ArrayAndString.SlidingWindowProblems;

public class VariableSizedSlidingWindow
{
    /// <summary>
    /// Problem:
    /// Find the length of the smallest contiguous subarray such that
    /// the sum of its elements is greater than or equal to the given `target`.
    /// If no such subarray exists, return 0.
    ///
    /// Approach (Variable-size Sliding Window):
    /// - Use two pointers: `left` and `right` to define the window.
    /// - Expand the window by moving `right` and adding to `sum`.
    /// - Once the window sum becomes >= target, try shrinking it from the left
    ///   to minimize its size while still satisfying the condition.
    /// - Keep track of the minimum length found during this process.
    ///
    /// Time Complexity: O(n) — each element is visited at most twice
    /// Space Complexity: O(1) — constant extra space
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int SmallestSubArraySizeOfSumS(int[] nums, int target)
    {
        int n = nums.Length;

        // Initialize left pointer of the window
        int left = 0;

        // To keep track of current window's sum
        int sum = 0;

        // To track the minimum window size found — set to max possible initially
        int minLength = int.MaxValue;

        // Move the right pointer of the window one step at a time
        for (int right = 0; right < n; right++)
        {
            // Expand the window by adding the rightmost element
            sum += nums[right];

            // As soon as the sum of the window becomes >= target,
            // try to shrink the window from the left while maintaining the condition
            while (sum >= target)
            {
                // Update the minimum length found so far
                minLength = Math.Min(minLength, right - left + 1);

                // Shrink the window from the left: subtract the leftmost value
                sum -= nums[left];

                // Move the left pointer rightward
                left++;
            }
        }

        // If we never found a valid window, return 0
        return minLength == int.MaxValue ? 0 : minLength;
    }

    /// <summary>
    /// Problem:
    /// Find the length of the longest contiguous subarray 
    /// whose sum is less than or equal to the given target.
    /// 
    /// Approach (Variable-size Sliding Window):
    /// - Use two pointers: left and right.
    /// - Expand the window by moving right and adding to sum.
    /// - If sum exceeds target, shrink the window from left.
    /// - Track the maximum valid window size found.
    ///
    /// Time Complexity: O(n)
    /// Space Complexity: O(1)
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int LongestSubarrayWithSumLessThanOrEqualToTarget(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0, sum = 0;
        int maxLength = 0;

        for (int right = 0; right < n; right++)
        {
            sum += nums[right]; // expand window to include nums[right]

            // shrink the window until sum becomes <= target
            while (sum > target)
            {
                sum -= nums[left];
                left++;
            }

            // update max length of valid subarray
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    /// <summary>
    /// Finds the length of the longest substring that contains exactly `k` unique characters.
    /// 
    /// Uses a variable-size sliding window and a frequency map (dictionary) to track characters.
    /// Expands the window from the right to include new characters.
    /// Shrinks the window from the left when the number of unique characters exceeds `k`.
    /// Updates the result only when the window has exactly `k` distinct characters.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(k)
    /// 
    /// Video tutorial: https://youtu.be/Lav6St0W_pQ?si=7Al7p27IxrMNQ_KQ
    /// </summary>
    /// <param name="s">Input string</param>
    /// <param name="k">Exact number of unique characters required</param>
    /// <returns>Length of the longest valid substring</returns>
    public static int LongestSubstringWithKUniqueChars(string s, int k)
    {
        // Guard clause: if input is null or empty, throw exception
        ArgumentException.ThrowIfNullOrEmpty(s, nameof(s));

        // Dictionary to keep track of character frequencies in the current window
        Dictionary<char, int> charFrequency = [];

        // Window pointers: `left` is the start, `right` is the end of the window
        int left = 0;

        // This will store the length of the longest valid substring found
        int maxLength = 0;

        // Loop through the string with the `right` pointer
        for (int right = 0; right < s.Length; right++)
        {
            char rightChar = s[right]; // Current character to add to the window

            // Add or update frequency of the character in the dictionary
            if (!charFrequency.ContainsKey(rightChar))
                charFrequency[rightChar] = 0;

            charFrequency[rightChar]++;

            // If the number of distinct characters in the window exceeds k,
            // we need to shrink the window from the left
            while (charFrequency.Count > k)
            {
                char leftChar = s[left]; // Character at the start of the window

                // Decrease the frequency of the leftmost character
                charFrequency[leftChar]--;

                // If its frequency becomes 0, remove it completely from the map
                if (charFrequency[leftChar] == 0)
                    charFrequency.Remove(leftChar);

                // Move the left pointer forward to shrink the window
                left++;
            }

            // At this point, the window has <= k unique characters
            // Only update maxLength if the window has exactly k unique characters
            if (charFrequency.Count == k)
            {
                int currentWindowLength = right - left + 1;
                maxLength = Math.Max(maxLength, currentWindowLength);
            }
        }

        // Return the best length found
        return maxLength;
    }

    /// <summary>
    /// Finds the length of the longest substring with at most `k` distinct characters.
    /// 
    /// Uses a sliding window and a frequency map:
    /// - Expand the window by moving the right pointer
    /// - If the window contains more than `k` distinct characters, shrink it from the left
    /// - Keep updating the maximum window length when valid (≤ k distinct chars)
    ///
    /// Time Complexity: O(n)
    /// Space Complexity: O(k)
    /// </summary>
    /// <param name="s"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int LongestSubstringWithAtMostKDistinctChars(string s, int k)
    {
        ArgumentException.ThrowIfNullOrEmpty(s, nameof(s));

        int left = 0, maxLength = 0;
        Dictionary<char, int> charFrequency = [];

        for (int right = 0; right < s.Length; right++)
        {
            char rightChar = s[right];

            if (!charFrequency.ContainsKey(rightChar))
                charFrequency[rightChar] = 0;

            charFrequency[rightChar]++;

            while (charFrequency.Count > k)
            {
                char leftChar = s[left];

                charFrequency[leftChar]--;

                if (charFrequency[leftChar] == 0)
                    charFrequency.Remove(leftChar);

                left++;
            }

            if (charFrequency.Count <= k)
                maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }
}
