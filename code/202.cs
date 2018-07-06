namespace c202{
using System;
using System.Collections.Generic;
public class Solution
{
    public bool IsHappy(int n) {
        var table = new HashSet<int>();
        int cur = n;
        while(true)
        {
            cur = cal(cur);
            if (cur == 1)
                return true;
            
            if (table.Contains(cur)) return false;
            else table.Add(cur);
        }
    }
    
    int cal(int n)
    {
        int result = 0;
        while (n>0)
        {
            result += (n%10)*(n%10);
            n /=10;
        }
        return result;
    }
}
}