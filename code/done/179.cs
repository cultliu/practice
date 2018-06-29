namespace c179{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class SolutionComparer: IComparer<string>
     {
         public int Compare(string astr, string bstr)
         {
            return (astr+bstr).CompareTo(bstr+astr);
         }
     }
     public class Solution
     {
        public string Do(int[] nums)
         {
            string[] numsStr = new string[nums.Length];
            for(int i =0; i<nums.Length; i++)
            {
                numsStr[i] = nums[i].ToString();
            }
            Array.Sort(numsStr, new SolutionComparer());
            if (numsStr[0] == "") return "0";
            return string.Join("", numsStr);
         }
     }
}