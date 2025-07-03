using DSA.Practice.ArrayAndString.BasicArrayProblems;
using DSA.Practice.ArrayAndString.BasicStringProblems;

Console.WriteLine("-  Array Practice    -");

int[] array1 = { 1, -1, 0, 55, 10 };

SolvingBasicProblems.FindMaximumNumberOfArray(array1);

int[] reverse = SolvingBasicProblems.ReverseArray(array1);
Console.WriteLine("Reversed Array -- ");
for (int i = 0; i < reverse.Length; i++)
    Console.Write(reverse[i] + " ");

Console.WriteLine();

int[] reverseWithoutNewArr = SolvingBasicProblems.ReverseArrayWithoutNewArray(array1);
Console.WriteLine("Reversed Array without using new array -- ");
for (int i = 0; i < reverseWithoutNewArr.Length; i++)
    Console.Write(reverseWithoutNewArr[i] + " ");

Console.WriteLine();

int[] rotatedArray = SolvingBasicProblems.RotateArrayKTimes(array1, 2);
Console.WriteLine("Array after rotation -- ");
for (int i = 0; i < reverseWithoutNewArr.Length; i++)
    Console.Write(reverseWithoutNewArr[i] + " ");

int sumOfAllArrayElements = SolvingBasicProblems.SumOfAllArrayElements(array1);
Console.WriteLine($"Sum of all array elements - {sumOfAllArrayElements}");

var (totalEvenNumber, totalOddNumber) = SolvingBasicProblems.CountEvenOdd(array1);
Console.WriteLine($"No. of even numbers in the array - {totalEvenNumber}");
Console.WriteLine($"No. of odd numbers in the array - {totalOddNumber}");

bool isTheArraySorted = SolvingBasicProblems.IsSortedArray(array1);
Console.WriteLine($"{
    (isTheArraySorted ? 
        "The array is sorted in ascending order" 
        : "The array is not sorted in ascending order")
}");

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("************* ARRAY BASIC OPERATIONS *************");
Console.WriteLine();

int[] array = {1, 3, 4, 5, 6};
Console.WriteLine("*** Insert element to array ***");
var newArr = BasicArrayOperations.InsertElementInArray<int>(array, 1, 2);
PrintArray(newArr);

Console.WriteLine("*** Delete element from array ***");
newArr = BasicArrayOperations.DeleteElementFromArray(array, 4);
PrintArray(newArr);

Console.WriteLine("*** Insert element to an Sorted Array ***");
int[] sortedArr = { 10, 20, 30, 40, 60 }; 
newArr = BasicArrayOperations.InsertElementInSortedArray(sortedArr, 90);
PrintArray(newArr);

Console.WriteLine("*** Remove all occurrences from an array ***");
int[] arrayWithDuplicate = { 1, 45, 6, 6, 1, 1, 33, 44, 1, 11, 1, 11, 1 };
var modifiedArr = BasicArrayOperations.RemoveAllOccurrencesOfAnArray(arrayWithDuplicate, 1);
PrintArray(modifiedArr);

Console.WriteLine("*** Reverse array ***");
var reversedArr = BasicArrayOperations.ReverseArray(array1);
PrintArray(reversedArr);

static void PrintArray<T>(T[] array)
{
    for (int i = 0; i < array.Length; i++)
        Console.Write(array[i] + "  ");
    Console.WriteLine();
}

Console.WriteLine();

Console.WriteLine(" ****************************** String Problems ******************************");

/////////////////////  Strings \\\\\\\\\\\\\\\\\\\\\\\

Console.WriteLine();

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
Console.WriteLine($"{(areAnagrams ?
        "Both the strings '{0}' and '{1}' are anagrams" :
        "The string '{0}' and '{1}' are not anagrams ")}", firstStr, secondStr);

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