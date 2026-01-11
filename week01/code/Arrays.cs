public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number'
    /// followed by multiples of 'number'.
    /// Example: MultiplesOf(7, 5) -> {7, 14, 21, 28, 35}
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // ===================== PLAN =====================
        // 1. Create a new array of type double with size equal to 'length'.
        // 2. Loop from index 0 up to length - 1.
        // 3. For each index i:
        //      - Multiply 'number' by (i + 1) to get the next multiple.
        //      - Store the result in the array at index i.
        // 4. After the loop finishes, return the filled array.
        // ================================================

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by the given 'amount'.
    /// Example:
    /// data = {1,2,3,4,5,6,7,8,9}, amount = 3
    /// result -> {7,8,9,1,2,3,4,5,6}
    ///
    /// This function modifies the original list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // ===================== PLAN =====================
        // 1. Determine how many elements will move from the end to the front.
        //    - This is equal to 'amount'.
        // 2. Use GetRange to take the last 'amount' elements from the list.
        // 3. Use GetRange to take the remaining elements from the beginning.
        // 4. Clear the original list.
        // 5. Add the last-part first, then add the first-part.
        // ================================================

        int count = data.Count;

        // Get the last 'amount' elements
        List<int> rightPart = data.GetRange(count - amount, amount);

        // Get the remaining elements at the beginning
        List<int> leftPart = data.GetRange(0, count - amount);

        // Clear the original list
        data.Clear();

        // Add elements back in rotated order
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}

