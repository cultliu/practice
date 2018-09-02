namespace c274{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int Do(int[] citations)
    {
        if (citations.Length == 0) return 0;

        Array.Sort(citations);
        var n = citations.Length;

        for(int i = n; i>=0; i--)
        {
            if (citations[n-i] >= i)
            {
                if (n-i == 0 || citations[n-i-1]<=i)
                {
                    return i;
                }
            }
        }
        return -1;
    }
}
}