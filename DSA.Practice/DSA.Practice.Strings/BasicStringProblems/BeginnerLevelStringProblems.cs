namespace DSA.Practice.Strings.BasicStringProblems;

public class BeginnerLevelStringProblems
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="givenStr"></param>
    /// <returns></returns>
    public static string ReverseString(string givenStr)
    {
        ArgumentException.ThrowIfNullOrEmpty(givenStr, nameof(givenStr));

        char[] strArr = givenStr.Trim().ToCharArray();

        int left = 0, right = strArr.Length - 1;

        while (left < right)
        {
            (strArr[right], strArr[left]) = (strArr[left], strArr[right]);
            left++;
            right--;
        }

        return new string(strArr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsPalindrome(string str)
    {
        // Throw an exception if the input is null or empty
        ArgumentException.ThrowIfNullOrEmpty(str, nameof(str));

        // Trim leading/trailing whitespace and convert to lowercase for consistent comparison
        str = str.Trim().ToLower();

        // Get the reversed version of the string
        string reversedString = ReverseString(str);

        // Use StringComparison.Ordinal to ensure a strict, byte-by-byte comparison
        // This avoids culture-specific comparison issues and gives consistent results
        return str.Equals(reversedString, StringComparison.Ordinal);
    }

    /// <summary>
    /// We are using both a HashSet and a List here:
    ///
    /// - The HashSet<char> (charHash) is used to **quickly check for duplicates**.
    ///   It gives O(1) lookup time to see if a character has already been seen.
    ///
    /// - The List<char> (charList) is used to **preserve the original order**
    ///   of first appearance of each unique character.
    ///
    /// HashSet alone doesn't preserve insertion order — it's an unordered collection.
    /// So if we return new string([...charHash]), the output may not match the
    /// order in which characters appeared in the original string.
    ///
    /// Example:
    /// Input  = "banana"
    /// charHash contains: { 'b', 'a', 'n' } but in arbitrary order
    /// charList contains: [ 'b', 'a', 'n' ] ← correct order to return
    /// reference - https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-9.0
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string RemoveDuplicateCharacterFromString(string str)
    {
        // Validate input: throw if null or empty
        ArgumentException.ThrowIfNullOrEmpty(str, nameof(str));

        // Trim unnecessary leading/trailing spaces and convert Array
        char[] charArr = str.Trim().ToCharArray();

        HashSet<char> seenChars = new(); // To track which characters we've already seen
        List<char> resultChars = new();  // To store characters in the original order

        foreach (char c in charArr)
        {
            // Add the character to the result only if it's not already seen
            if (seenChars.Add(c)) // Add returns false if already present
            {
                resultChars.Add(c);
            }
        }

        // Convert the ordered list of unique characters back to a string
        return new string([.. resultChars]);
    }

    /// <summary>
    /// Counts the number of vowels and consonants in the given string.
    /// Ignores spaces, digits, punctuation, and other non-letter characters.
    /// Comparison is case-insensitive (e.g., 'A' and 'a' are both treated as vowels).
    /// </summary>
    /// <param name="str">The input string to analyze.</param>
    /// <returns>
    /// A tuple containing:
    /// - vowel: number of vowels
    /// - consonant: number of consonants
    /// </returns>
    /// <exception cref="ArgumentException">Thrown if the input string is null or empty.</exception>
    public static (int vowel, int consonant) CountVowelAndConsonant(string str)
    {
        // Throw if input is null or empty
        ArgumentException.ThrowIfNullOrEmpty(str, nameof(str));

        int vowel = 0, consonant = 0;

        // Define the set of vowel characters for fast lookup ( Big O(1) per lookup)
        HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];

        // Normalize the input: trim spaces and convert to lowercase
        char[] charArr = str.Trim().ToLower().ToCharArray();

        // Iterate over each character
        foreach (char c in charArr)
        {
            // Skip characters that are not letters (e.g., digits, punctuation, whitespace)
            if (!char.IsLetter(c))
                continue;

            // If the character is a vowel, increment the vowel count, else its a consonant
            if (vowels.Contains(c))
                vowel++;
            else 
                consonant++;
        }

        // Return the result as a tuple
        return (vowel, consonant);
    }

    /// <summary>
    /// Counts the number of times each character appears in the input string.
    /// Ignores spaces and treats uppercase and lowercase characters as different.
    /// </summary>
    /// <param name="str">The input string to analyze.</param>
    /// <returns>
    /// A dictionary where:
    /// - Key: character (excluding spaces)
    /// - Value: number of times the character appears
    /// </returns>
    /// <exception cref="ArgumentException">Thrown if the input string is null or empty.</exception>
    public static Dictionary<char, int> CountOccurranceOfEachCharacter(string str)
    {
        ArgumentException.ThrowIfNullOrEmpty(str, nameof(str));

        char[] charArr = str.ToCharArray();

        Dictionary<char, int> occurrances = [];

        foreach (char c in charArr)
        {
            // Ignore spaces (but keep all other characters, including punctuation)
            if (c == ' ')
                continue;

            if (occurrances.ContainsKey(c))
                occurrances[c]++;
            else
                occurrances.Add(c, 1);
        }

        return occurrances;
    }

    /// <summary>
    /// Finds the first non-repeating character in the input string.
    /// Returns the first character that appears exactly once in the string.
    /// </summary>
    /// <param name="str">The input string to analyze.</param>
    /// <returns>The first non-repeating character.</returns>
    /// <exception cref="ArgumentException">Thrown when input is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown if no non-repeating character is found.</exception>
    public static char FirstNonRepeatingCharacter(string str)
    {
        ArgumentException.ThrowIfNullOrEmpty(str, nameof(str));

        char[] charArr = str.ToCharArray();

        // Count character frequencies
        Dictionary<char, int> occurrance = CountOccurranceOfEachCharacter(str);

        foreach (char c in charArr)
        {
            // TryGetValue is safe and efficient
            occurrance.TryGetValue(c, out int value);
            if (value == 1)
                return c;
        }

        // No non-repeating character found
        throw new InvalidOperationException("No non-repeating character found in the input string.");
    }

    /// <summary>
    /// Checks if two strings are anagrams of each other.
    /// This method ignores spaces and is case-insensitive.
    /// </summary>
    /// <param name="str1">The first string.</param>
    /// <param name="str2">The second string.</param>
    /// <returns>True if both strings are anagrams; otherwise, false.</returns>
    /// <exception cref="ArgumentException">Thrown if either input is null or empty.</exception>
    public static bool AreAnagrams(string str1, string str2)
    {
        ArgumentException.ThrowIfNullOrEmpty(str1, nameof(str1));
        ArgumentException.ThrowIfNullOrEmpty(str2, nameof(str2));

        // Normalize both strings: remove spaces, convert to lowercase
        string normalizedStr1 = str1.Replace(" ", "").ToLower();
        string normalizedStr2 = str2.Replace(" ", "").ToLower();

        // Early exit: if lengths differ, they cannot be anagrams
        if (normalizedStr1.Length != normalizedStr2.Length)
            return false;

        // Build frequency dictionary for str1
        Dictionary<char, int> charCounts = CountOccurranceOfEachCharacter(str1);

        // Subtract counts using str2
        foreach (char c in normalizedStr2)
        {
            if (!charCounts.ContainsKey(c))
                return false;

            charCounts[c]--;

            if (charCounts[c] < 0)
                return false; // More occurrences in str2 than in str1
        }

        // All character counts should be zero now
        return true;
    }


}
