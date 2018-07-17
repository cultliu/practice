namespace c227{
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int Do(string s)
    {
        var stack = new Stack<int>();

        foreach(char ch in s.ToCharArray())
        {
            int curNum = 0;
            char lastOp = '\0';

            if (ch == '+'  || ch == '-' || ch=='*'|| ch=='/')
            {
                if (lastOp =='+')
                stack.Push(curNum);
                if(lastOp == '-')
                stack.Push(-1*curNum);
                if (lastOp == '*')
                stack.Push(stack.Pop()*curNum);
                if (lastOp == '/')
                stack.Push(stack.Pop()/curNum);

                lastOp = ch;
                curNum = 0;
            }
            else if(ch >='0' && ch <='9')
            {
                curNum = curNum*10+ ch-'0';
            }
        }

        //add all
        var result = 0;
        foreach(int n in stack)
        {
            result += n;
        }
        return result;
    }
}
}