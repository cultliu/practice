namespace c229{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public IList<int> Do(int[] nums)
    {
        int n=0, m=0, countn=0,countm=0;

        for(int i =0; i<nums.Length; i++)
        {
            if(nums[i] ==n)
            {
                countn++;
            }
            else
            {
                countn--;
                if(countn < 0)
                {
                    n = nums[i];
                    countn = 1;
                }
                else if(nums[i] ==m)
                {
                    countm++;
                }
                else
                {
                    countm--;
                    if(countm < 0)
                    {
                        m = nums[i];
                        countm = 1;
                    }
                }
            }
        }
        var result = new List<int>();
        if (countn >= nums.Length/3)
        {
            result.Add(n);
        }
        if (countm > nums.Length/3)
        {
            result.Add(m);
        }
        return result;      
    }
}
}