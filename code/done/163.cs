namespace c163{
    using System.Collections.Generic;
    public class Solution
    {
        IList<string> Do(int[] nums)        
        {
            int gapStart = 0;
            List<string> result = new List<string>();
            foreach(int num in nums)
            {
                if (num == gapStart)
                {
                    gapStart++;
                    continue;
                }
                else
                {
                    if (num == gapStart+1)
                    {
                        result.Add(gapStart.ToString());
                    }
                    else
                    {
                        result.Add($"{gapStart}->{num-1}");
                    }
                    gapStart = num;
                }
            }
            return result;
        }
    }
}