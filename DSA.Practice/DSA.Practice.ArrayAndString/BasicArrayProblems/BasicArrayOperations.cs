namespace DSA.Practice.ArrayAndString.BasicArrayProblems
{
    public class BasicArrayOperations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array"></param>
        /// <param name="Position"></param>
        /// <param name="Element"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static T[] InsertElementInArray<T>(T[] Array, int Position, T Element)
        {
            int totalElements = Array.Length;
            
            if (Position < 0 || Position >= totalElements)
                throw new ArgumentOutOfRangeException(nameof(Position), "Invalid index for deletion.");

            T[] newArray = new T[totalElements + 1];
            
            // copy existing array to the new array
            for (int i = 0; i < totalElements; i++) 
                newArray[i] = Array[i];

            // Putting the Array at the end  
            if (Position == newArray.Length)
                newArray[Position] = Element;

            // Perform right shift to make space for the new element at the specified position.
            // We iterate backward from the last element index (totalElements - 1) down to the 'position'.
            // Each element is moved one step to the right to free up the target index.
            // 
            // Example:
            //   Original Array (with space): [1, 2, 3, 4, _, _], totalElements = 4
            //   Insert 99 at position 2:
            //     i = 4 → Array[4] = Array[3] → 4
            //     i = 3 → Array[3] = Array[2] → 3
            //   After shifting: [1, 2, 3, 3, 4, _]
            //   Now insert: Array[2] = 99 → [1, 2, 99, 3, 4, _]
            // 
            // Note:
            // - The loop stops at 'position' because that’s where the new value will be inserted.
            for (int i = totalElements; i > Position; i--)
            {
                newArray[i] = newArray[i-1];
            }

            newArray[Position] = Element;
            return newArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static T[] DeleteElementFromArray<T>(T[] array, int position) 
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            int n = array.Length;

            if (position < 0 || position >= n)
                throw new ArgumentOutOfRangeException(nameof(position), "Invalid index for deletion.");

            // Perform left shift to delete the element at the specified position.
            // We start iterating from 'position' because:
            // - All elements before 'position' remain unchanged.
            // - Starting from 'position', each element is replaced by the one to its right.
            //   Example:
            //   Original Array:    [1, 2, 3, 4, 5]
            //   Delete at index 1:     ↑
            //   Shifting Steps:
            //     array[1] = array[2] → 3
            //     array[2] = array[3] → 4
            //     array[3] = array[4] → 5
            //   Resulting Array:   [1, 3, 4, 5, 5] (last value is duplicated temporarily)
            // - Final step: create a new array of size n - 1 to exclude the last duplicate.
            for (int i = position; i < n-1; i++)
                array[i] = array[i+1];

            T[] resultArray = new T[n-1];
            for (int i = 0; i < n - 1; i++)
            {
                resultArray[i] = array[i];
            }
            return resultArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int[] InsertElementInSortedArray(int[] array, int value)
        {
            ArgumentNullException.ThrowIfNull(array);

            int[] newArr = new int[array.Length + 1];


            // Find index
            int index = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= value)
                {
                    index = i;
                    break;
                }               
            }
            
            array.CopyTo(newArr, 0);

            // Doing a right shift
            for (int i = newArr.Length - 1; i > index; i--)
                newArr[i] = newArr[i - 1];

            newArr[index] = value;
            return newArr;                
        }

        public static int[] RemoveAllOccurrencesOfAnArray(int[] array, int value)
        {
            // Step 1: Validate input
            ArgumentNullException.ThrowIfNull(array);

            int k = 0; // 'k' is the write index — the next position where we'll write a valid (non-deleted) value

            // Step 2: Loop through each element in the original array
            for (int i = 0; i < array.Length; i++)
            {
                // If the current element is not equal to the value to remove,
                // copy it to the 'k'th index and move 'k' forward
                if (array[i] != value)
                {
                    array[k] = array[i];  // Overwrite from the front (shifting left)
                    k++;                  // Move write index to next slot
                }

                // If array[i] == value, we skip copying — effectively removing it from the new version
            }

            // Step 3: At this point, first 'k' elements of array are the cleaned version (without the value)
            // So we create a new array of length 'k' to return just those elements
            int[] result = new int[k];
            System.Array.Copy(array, result, k);  // Copy only the cleaned part

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] ReverseArray<T>(T[] array)
        {
            T[] result = new T[array.Length];

            int index = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                result[index] = array[i];
                index++;
            }

            // We can also use Array.Reverse() built-in method in C#
            return result;
        }
    }
}
