namespace DSA.Practice.ArrayAndString.Searching;

public class LinearSearch
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="element"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int SearchElementByLinearSearch<T>(T[] array, T element)
    {
       int n = array.Length;

        if (n == 0 || array == null)
            throw new ArgumentException("Array is empty or null", nameof(array));

        if (element == null)
            throw new ArgumentException("element is null", nameof(element));

        for (int i = 0; i < n; i++)
        {
            if (array[i]!.Equals(element))
                return i + 1;
        }

        return -1;
    }
}
