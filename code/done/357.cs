namespace c357{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int CountNumbersWithUniqueDigits(int n) {
        if (n == 0) return 1;
        
        int count = Math.Max(10,n);
        int[] result = new int[n];
        result[0] = 10;
   
        for(int i=1; i < n; i++)
        {
            int t = 9;
            for(int j = 1; j < i; j++)
            {
                t *= (10-j);
            }
        
            result[i] = result[i-1] + t;
        }
        
        return result[n-1];
        
    }
}
}