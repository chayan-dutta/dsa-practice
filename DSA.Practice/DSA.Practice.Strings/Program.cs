using DSA.Practice.Strings.BasicStringProblems;

string str = "Hello";
string reversed = BeginnerLevelStringProblems.ReverseString(str);
Console.WriteLine("1. The reversed version of {0} is {1}", str, reversed);

str = "babanana";
string duplicateRemoved = BeginnerLevelStringProblems.RemoveDuplicateCharacterFromString(str);
Console.WriteLine("2. After removing the duplicates from the string {0}, the new string is {1}", str, duplicateRemoved);

str = "I am a boy";
(int vowel, int consonant) = BeginnerLevelStringProblems.CountVowelAndConsonant(str);
Console.WriteLine($"3. In the string - \"{str}\", no. of vowels are {vowel} and no. of consonants are {consonant}");

str = "Chayan";
Dictionary<char, int> occurrencesOfEachChars = BeginnerLevelStringProblems.CountOccurranceOfEachCharacter(str);
Console.WriteLine("4. The Occurrences of all character in the string {0}", str);
PrintDictionary(occurrencesOfEachChars);

str = "ababbbaabac";
char firstNonRepeating = BeginnerLevelStringProblems.FirstNonRepeatingCharacter(str);
Console.WriteLine($"First non repeating character of {str}, is {firstNonRepeating}");

string firstStr = "silent";
string secondStr = "listen";
bool areAnagrams = BeginnerLevelStringProblems.AreAnagrams(firstStr, secondStr);
Console.WriteLine($"{
    (areAnagrams ?
        "Both the strings '{0}' and '{1}' are anagrams" :
        "The string '{0}' and '{1}' are not anagrams ")
}", firstStr, secondStr);

/// <summary>
/// Prints all key-value pairs from the provided dictionary to the console.
/// </summary>
/// <typeparam name="TKey">The type of dictionary keys. Must be non-nullable.</typeparam>
/// <typeparam name="TValue">The type of dictionary values.</typeparam>
/// <param name="dictionary">The dictionary to print.</param>
/// <remarks>
/// Each entry is printed in the format: Key => Value.
/// Throws an exception if the dictionary is null.
/// </remarks>
static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : notnull
{
    foreach (KeyValuePair<TKey, TValue> kvp in dictionary)
        Console.WriteLine($"{kvp.Key} => {kvp.Value}");
}

Console.ReadLine();