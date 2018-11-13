namespace c313{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int Do(int n, int[] primes)
    {
        var result = new int[n];
        var index = new int[primes.Length];

        result[0] = 1;

        for(int i =0; i< n; i++)
        {
            int min = int.MaxValue;
            List<int> minIdx = new List<int>();
            for(int j =0; j<index.Length; j++)
            {
                int val = primes[j] * result[index[j]];
                if(val < min)
                {
                    min = val;
                    minIdx.Clear();
                    minIdx.Add(j);
                }
                else if (val == min)
                {
                    minIdx.Add(j);
                }
            }
            result[i] = min;
            foreach(var idx in minIdx)
            {
                index[idx]++;
            }
        }

        return result[n-1];
    }
}
}