namespace c350{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2) {
    {
        var map1 = new Dictionary<int,int>();
        var result = new List<int>();

        foreach(int num in nums1)
        {
            if(map1.ContainsKey(num))
            {
                map1[num]++;
            }
            else
            {
                map1.Add(num,1);
            }
        }

        foreach(int num in nums2)
        {
            if(map1.ContainsKey(num) && map1[num] > 0)
            {
                result.Add(num);
                map1[num]--;
            }
        }

        return result.ToArray();
    }
}
}
}