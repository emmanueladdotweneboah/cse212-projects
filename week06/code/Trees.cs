public static class Trees
{
    /// <summary>
    /// Given a sorted list (sortedNumbers), create a balanced BST.  
    /// </summary>
    /// <param name="sortedNumbers">An array of sorted numbers</param>
    /// <returns>A balanced BinarySearchTree</returns>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Inserts the middle element of a range into the BST, then recursively inserts left and right halves.
    /// </summary>
    /// <param name="sortedNumbers">Input numbers that are already sorted</param>
    /// <param name="first">First index of the current range</param>
    /// <param name="last">Last index of the current range</param>
    /// <param name="bst">The BinarySearchTree in which to insert values</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: if range is invalid, stop recursion
        if (first > last)
            return;

        // Find the middle index
        int middle = (first + last) / 2;

        // Insert middle value into BST
        bst.Insert(sortedNumbers[middle]);

        // Recursively insert left half
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Recursively insert right half
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}
