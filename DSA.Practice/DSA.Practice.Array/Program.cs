using DSA.Practice.Array.BasicArrayProblems;

Console.WriteLine("-  Array Practice    -");

int[] array1 = { 1, -1, 0, 55, 10 };

SolvingBasicProblems.FindMaximumNumberOfArray(array1);

int[] reverse = SolvingBasicProblems.ReverseArray(array1);
Console.WriteLine("Reversed Array -- ");
for (int i = 0; i < reverse.Length; i++)
    Console.Write(reverse[i] + " ");

Console.WriteLine();

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






static void PrintArray<T>(T[] array)
{
   for (int i = 0;i < array.Length; i++)
        Console.Write(array[i] + "  ");
   Console.WriteLine();
}