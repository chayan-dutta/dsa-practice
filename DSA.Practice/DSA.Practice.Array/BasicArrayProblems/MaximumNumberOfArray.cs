namespace DSA.Practice.Array.BasicArrayProblems;

/// <summary>
/// 
/// </summary>
/// <param name="myArray"></param>
public class MaximumNumberOfArray(int[] myArray)
{
    private readonly int[] myArray = myArray;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public void FindMaximumNumberOfArray()
    {
        int maximum = 0;

        for (int i = 0; i < myArray.Length; i++)
        {
            if (myArray[i] > maximum) 
                maximum = myArray[i]; 
        }

        Console.WriteLine("The maximum number in this array is - {0}", maximum);
    }
}
