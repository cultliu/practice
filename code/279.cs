namespace c279{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int NumSquares(int n) 
    {
        if (n ==0 ) return 0;
        if (n ==1 ) return 1;

        var results = new int[n+1];
        results[0] = 0;
        results[1] = 1;

        for(int i = 2; i <= n; i++)
        {
            int min = int.MaxValue;
            for(int j = 1; j*j<=n; j++)
            {
                min = Math.Min(min, results[i-j*j]+1);
            }
            results[i] = min;
        }
            
        return results[n];
        
    }
}
}