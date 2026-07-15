using System;
using System.Collections.Generic;

public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers) {
        // Use a set to track the numbers we have already evaluated
        var seen = new HashSet<int>();

        foreach (var number in numbers) {
            // Calculate the required target number to reach the sum of 10
            int target = 10 - number;

            // If the target number is already in the set, we found a matching pair
            if (seen.Contains(target)) {
                Console.WriteLine($"{number} {target}");
            }

            // Store the current number in our set for future comparisons
            seen.Add(number);
        }
    }
}