namespace c204{
using System;
using System.Collections.Generic;
public class Solution {
    public int CountPrimes(int n) {
        if (n<=2) return 0;
        
        var isPri = new bool[n];
        for(int i=2; i<isPri.Length; i++)
        {
            isPri[i] = true;
        }
         
        for(int i =2; i<n/2; i++)
        {
            for (int j=2; i*j<n; j++)
            {
                isPri[i*j] = false;
            }
        }
        
        int count = 0;
        for(int i=2; i<isPri.Length; i++)
        {
            if (isPri[i]) count++;
        }
        
        return count;
    }
}
}