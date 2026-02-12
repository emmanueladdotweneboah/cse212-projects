using System;
using System.Collections.Generic;

public static class Recursion
{
    // ------------------------------------------------------------
    // Problem 1: Recursive Squares Sum
    // ------------------------------------------------------------
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    // ------------------------------------------------------------
    // Problem 2: Permutations Choose
    // ------------------------------------------------------------
    public static List<string> PermutationsChoose(char[] letters, int size)
    {
        var results = new List<string>();
        PermuteHelper(letters, size, "", results);
        return results;
    }

    private static void PermuteHelper(char[] letters, int size, string current, List<string> results)
    {
        if (current.Length == size)
        {
            results.Add(current);
            return;
        }

        foreach (char c in letters)
        {
            if (!current.Contains(c))
            {
                PermuteHelper(letters, size, current + c, results);
            }
        }
    }

    // ------------------------------------------------------------
    // Problem 3: Climbing Stairs (Memoization)
    // ------------------------------------------------------------
    public static int CountWaysToClimb(int s, Dictionary<int, int> remember)
    {
        if (s < 0)
            return 0;

        if (s == 0)
            return 1;

        if (remember.ContainsKey(s))
            return remember[s];

        int ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // ------------------------------------------------------------
    // Problem 4: Wildcard Binary Patterns
    // ------------------------------------------------------------
    public static void ExpandBinaryPattern(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        ExpandBinaryPattern(
            pattern.Substring(0, index) + "0" + pattern.Substring(index + 1),
            results);

        ExpandBinaryPattern(
            pattern.Substring(0, index) + "1" + pattern.Substring(index + 1),
            results);
    }
}
