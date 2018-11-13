namespace c300{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        if (nums.Length == 0) return 0;
        int[] leng = new int[nums.Length];
        int max = 1;

        for (int i = nums.Length-1; i >=0; i--)
        {
            leng[i] = 1;
            for(int j = i+1; j <nums.Length; j++)
            {
                if(nums[j] > nums[i])
                {
                    leng[i] = Math.Max( leng[j]+1, leng[i]);
                }
            }
            max = Math.Max(max, leng[i]);
        }

        return max;
    }
}
}