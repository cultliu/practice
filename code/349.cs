namespace c349{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int[] Intersection(int[] nums1, int[] nums2) {
    {
        var set1 = new HashSet<int>(nums1);
        var set2 = new HashSet<int>();

        foreach(int num in nums2)
        {
            if (set1.Contains(num) && !set2.Contains(num))
            {
                set2.Add(num);
            }
        }

        return set2.ToArray();
    }
}
}
}