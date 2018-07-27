namespace c241{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    List<int> nums = new List<int>();
    List<char> ops = new List<char>();

    public IList<int> Do(string input)
    {
        int curNum = 0;
        foreach(char ch in input.ToCharArray())
        {
            if (char.IsDigit(ch))
            {
                curNum = curNum *10 + (ch - '0');
            }
            else 
            {   
                nums.Add(curNum);
                ops.Add(ch);
                curNum = 0;
            }
        }
        nums.Add(curNum);

        return Do(0, nums.Count);
    }

    public IList<int> Do(int start, int len)
    {
        if (len == 1) return new List<int> {nums[start]};

        var result = new List<int>();
        for(int i=1; i<=len-1;i++)
        {
            var left = Do(start, i);
            var right = Do(start+i, len-i);
            var op = ops[start+i-1];
            foreach(var resl in left)
            {
                foreach(var resr in right)
                {
                    switch(op)
                    {
                        case '+':
                            result.Add(resl+resr);
                            break;
                        case '-':
                            result.Add(resl-resr);
                            break;
                        case '*':
                            result.Add(resl*resr);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        return result;
    }
}
}