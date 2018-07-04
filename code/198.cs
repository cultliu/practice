namespace c198{
using System;
public class Solution
{
    public int Do(int[] nums)
    {
        int n = nums.Length;
        if (n==0) return 0;
        int[] maxRob = new int[n], maxNot = new int[n];
        maxRob[0] = nums[0]; 
        maxNot[0] = 0;
        for (int i =1; i < n; i++)
        {
            maxRob[i] = maxNot[i-1]+ nums[i];
            maxNot[i] = Math.Max(maxRob[i-1], maxNot[i-1]); 
        }

        return Math.Max(maxNot[n-1], maxRob[n-1]);
    }
}
}