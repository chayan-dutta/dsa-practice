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