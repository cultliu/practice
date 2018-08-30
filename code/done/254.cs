namespace c254{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public IList<IList<int>> getFactors(int n)
    {
        if (n ==1) return new List<IList<int>>();
        return getFactors(n, 2);
    }

    public IList<IList<int>> getFactors(int n, int start)
    {
        if (n == start) return new List<IList<int>> ();

        var result = new List<IList<int>>();
        for(int i=start; i<=n/i; i++)
        {
            if (n%i ==0)
            {
                result.Add(new List<int>(){i, n/i});
                var rightRes = getFactors(n/i, i);
                foreach(var right in rightRes)
                {
                    right.Insert(0,i);
                    result.Add(right);
                }
            }
            //up /= i;
        }
        return result;
    }
}
}