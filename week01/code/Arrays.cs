public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of size 'length'
        // Step 2: Use a loop to fill the array with multiples of 'number'
        // Step 3: Return the filled array

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine the index where the split should occur.
        // Step 2: Use GetRange to get the last 'amount' elements (the ones to bring to the front)
        // Step 3: Use GetRange to get the first elements (from index 0)
        // Step 4: Clear the original list
        // Step 5: Add the last part first, then add the first part after it

        int splitIndex = data.Count - amount;

        // Step 2: Get the last part (to move to front)
        List<int> lastPart = data.GetRange(splitIndex, amount);

        // Step 3: Get the first part (to stay after the last part)
        List<int> firstPart = data.GetRange(0, splitIndex);

        // Step 4: Clear the original list
        data.Clear();

        // Step 5: Add last part and then first part
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
