namespace c283{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public void Do(int[] nums)
    {
        int cur = 0;
        for(int i =0; i < nums.Length; i++)
        {
            if(nums[i]==0) continue;

            if (cur != i)
            {
                nums[cur] = nums[i];
            }
            cur++;
        }
    }
}
}