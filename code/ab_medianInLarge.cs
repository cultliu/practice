namespace ab_medianInLargeFile{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static void Main()
    {
        Console.WriteLine(FindMedian(new int[]{1,2,3}));
    }

    static double FindKth(int[] stream, int k, int min, int max)
    {
        Console.WriteLine(min + "," + max);
        int guess = (min + max)/2;
        int maxLeft = min;
        int count = 0;
        foreach(int val in stream)
        {
            if (val <= guess)
            {
                count++;
                maxLeft = Math.Max(maxLeft, val);
            }
        }

        if (count == 0)
        {
            return FindKth(stream, k, guess, max);
        }
        else if (count == k)
        {
            return maxLeft;
        }
        else if (count > k)
        {
            return FindKth(stream, k, min, maxLeft);
        }
        else
        {
            return FindKth(stream, k, maxLeft, max);
        }
    }

    static double FindMedian(int[] stream)
    {
        // I should be able to get the length. 
        int length = stream.Length;

        if (length%2 != 0)
        {
            return FindKth(stream, length/2+1, int.MinValue, int.MaxValue);
        }
        else
        {
            return (FindKth(stream, length/2, int.MinValue, int.MaxValue) + FindKth(stream, length/2+1, int.MinValue, int.MaxValue))/2;
        }
    }
}
}