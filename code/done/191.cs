namespace c191{
using System;
public class Solution
{
    public int Do(uint n)
    {
        int bits = 0;
        while(n > 0)
        {
            if ((n&1)!=0)
            {
                bits++;
                n>>=1;
            }
        }
        return bits;
    }
}
}