namespace c190{
using System;
public class Solution
{
    public uint Do(uint n)
    {
        uint result = 0; int bits = 0;
        while(n>0)
        {
            bits++;
            result <<=1;
            result += n&1;
            n >>=1;
        }
        result <<= 32-bits;
        return result;
    }
}
}