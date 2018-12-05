namespace ab_hilbert{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static void Main1()
    {
        var so = new Solution();
        Console.WriteLine(so.Do(1,1,2));
        Console.WriteLine(so.Do(0,1,1));
        Console.WriteLine(so.Do(2,2,2));
    }

    public int Do(int x, int y, int lit)
    {
        if (lit == 0) return 1;

        int cut = 1<<(lit-1);
        
        if (x<cut && y<cut)
        {
            return Do(y, x, lit-1);
        }
        else if (x<cut && y>=cut)
        {
            return cut*cut + Do(x, y-cut, lit-1);
        }
        else if (x>=cut && y>=cut)
        {
            return cut*cut*2 + Do(x-cut, y-cut, lit-1);
        }
        else 
        {
            return cut*cut*3 + Do(cut-y, cut-x, lit-1);
        }
    }
}
}