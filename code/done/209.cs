namespace c209{
using System;
using System.Collections.Generic;
public class Solution
{
    //[2,3,1,2,4,3]
    public int Do(int s, int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (s == 0) return 1;

        int start =0, sum =0, len = int.MaxValue; 
        for(int i=0; i<nums.Length; i++)
        {
            sum += nums[i];
            if (sum >= s)
            {
                while (sum - nums[start] >= s)
                {
                    sum -= nums[start];
                    start++;
                }
                len = Math.Min(len, i-start+1);
            }
        }

        return len > nums.Length? 0: len;
    }
}}