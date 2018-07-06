namespace c201{
using System;
using System.Collections.Generic;
public class Solution
{
    public int RangeBitwiseAnd(int m, int n)
    {
        uint mask = 0x80000000;
        uint x = (uint)m,y=(uint)n;
        int count = 0;
        while(count<32)
        {
            if(((x&mask)^(y&mask)) == 0)
            {
                count++;
                x<<=1;
                y<<=1;
            }
            else
            {
                break;
            }
        }

        var mask2 = 0xffffffff << (32-count);
        return m&(int)mask2;
    }
}
}