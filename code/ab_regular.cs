namespace ab_regular{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static void Main1()
    {
        var so = new Solution();
        // Console.WriteLine(so.RegularMatch("aaa","aaa"));
        // Console.WriteLine(so.RegularMatch("abc","abc"));
        // Console.WriteLine(so.RegularMatch("abc","a.c"));
        // Console.WriteLine(so.RegularMatch("abc","ab+c"));
        // Console.WriteLine(so.RegularMatch("abbbc","ab+c"));
        // Console.WriteLine(so.RegularMatch("ac","ab+c"));

        // Console.WriteLine(so.RegularMatch("abc","ab*c"));
        // Console.WriteLine(so.RegularMatch("abbbc","ab*c"));
        // Console.WriteLine(so.RegularMatch("ac","ab*c"));

        Console.WriteLine(so.RegularMatch("saaaa", "s+a*"));
        Console.WriteLine(so.RegularMatch("saaaa", "s+b*"));
        Console.WriteLine(so.RegularMatch("saaaab", "s+a*"));
        Console.WriteLine(so.RegularMatch("saaaab", "s+b*"));
    }

    public bool RegularMatch(string s, string regualr)
    {
        return Helper(s, s.Length-1, regualr, regualr.Length - 1);
    }

    public bool Helper(string s, int sStart, string regualr, int rStart)
    {
        //Console.WriteLine(s.Substring(0, sStart+1) + "," +regualr.Substring(0, rStart+1));
        while(sStart >= 0 && rStart >=0)
        {
            if (regualr[rStart] == '*' || regualr[rStart] == '+')
            {
                char matchCh = regualr[rStart-1];
                int matchStart = sStart;
                while(matchStart >= 0 && s[matchStart] == matchCh )
                {
                    matchStart--;
                }

                // if +, match at least one
                if (regualr[rStart] == '+')
                { 
                    if(matchStart ==sStart)
                    {
                        return false;
                    }
                    sStart--;
                }

                for(int i = matchStart; i<=rStart; i++)
                {
                    if(Helper(s, i, regualr, rStart-2))
                    {
                        return true;
                    }
                }
                
                return false;
            }
            else if (regualr[rStart] == '.')
            {
                rStart--;
                sStart--;
            }
            else
            {
                if (regualr[rStart]== s[sStart])
                {
                    rStart--;
                    sStart--;
                }
                else
                {
                    return false;
                }
            }
        }

        if (sStart == rStart)
        {
            return true;
        }
        return false;

    }
}
}