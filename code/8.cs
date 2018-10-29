namespace c8{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution {
    public int MyAtoi(string str) {
        
        var chars = str.TrimStart().ToArray();
        if (chars.Length ==0) return 0;
        
        int sign = 1, idx = 0;
        int check = int.MaxValue/10;
        int result = 0;
        if (chars[0] == '-')
        {
            sign = -1;
            idx++;
        }
        else if (chars[0] == '+')
        {
            idx++;
        }
        
        for(;idx < chars.Length; idx++)
        {
            int num = chars[idx] - '0';
            if(num>=0 && num<=9)
            {
                if (result==check && ( sign>0 && num>=7 || sign<0 && num>=8) || result > check)
                {
                    return sign>0? int.MaxValue:int.MinValue;
                }
                
                result = result*10 + num;
            }
            else
            {
                break;
            }
        }
        
        return result * sign;
    }
}
}