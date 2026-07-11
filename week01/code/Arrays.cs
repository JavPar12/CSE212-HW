using System;
using System.Collections.Generic;

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
        // TODO Problem 1 Start
        // Plan:
        // 1. Create a new array of doubles with the size specified by the 'length' parameter.
        // 2. Set up a for loop that iterates from index 0 up to length - 1.
        // 3. For each iteration, calculate the current multiple by multiplying 'number' by (index + 1).
        // 4. Store the calculated multiple at the current index of the array.
        // 5. Return the fully populated array of multiples.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
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
        // TODO Problem 2 Start
        // Plan:
        // 1. Check if the list is null, empty, or if the rotation amount equals the size of the list (or 0). If true, return immediately as no rotation is needed.
        // 2. Apply a modulo operation to the amount based on data.Count to defensively prevent out-of-range slicing.
        // 3. Calculate the split index where the rotation slice begins by subtracting 'amount' from the total element count (data.Count - amount).
        // 4. Use GetRange starting at the split index to extract the sub-list segment that needs to shift to the front.
        // 5. Use RemoveRange to delete that extracted segment from the back of the original list.
        // 6. Use InsertRange to place the extracted segment back into the original list at index 0, shifting everything else to the right.

        if (data == null || data.Count <= 1 || amount == 0 || amount == data.Count)
        {
            return;
        }

        int realAmount = amount % data.Count;
        if (realAmount == 0) return;

        int splitIndex = data.Count - realAmount;

        List<int> rightPart = data.GetRange(splitIndex, realAmount);
        data.RemoveRange(splitIndex, realAmount);
        data.InsertRange(0, rightPart);
    }
}
