namespace c301{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    List<IList<string>> intermLResult = new List<IList<string>>();
    List<IList<string>> intermRResult = new List<IList<string>>();
    public IList<string> RemoveInvalidParentheses(string s) 
    {
        var left = RLScan(LRScan(s));

        return GenerateResult(left);
    }

    public IList<string> GenerateResult(string s) {
        var results = new List<string>() {""};
        
        foreach(var intermRes in intermLResult)
        {
            var temp = new List<string>();
            foreach(var intermStr in intermRes)
            {
                foreach(var res in results)
                {
                    temp.Add(res + intermStr);
                }
            }
            results = temp;
        }

        for (int i =0; i < results.Count; i++)
        {
            results[i] += s;
        }

        intermRResult.Reverse();
        foreach(var intermRes in intermRResult)
        {
            var temp = new List<string>();
            foreach(var intermStr in intermRes)
            {
                foreach(var res in results)
                {
                    temp.Add(res + intermStr);
                }
            }
            results = temp;
        }

        return results;
    }
    
    string LRScan(string s)
    {
        if (s.Length == 0) return "";

        int left = 0, start = 0, count = 0;
        for(int i = 0; i< s.Length; i++)
        {
            if(s[i] == '(')
            {
                left++;
            }
            else if (s[i] == ')')
            {
                left--;
            }
            count++;

            if(left < 0)
            {
                string sub = s.Substring(start, count);
                intermLResult.Add(FixRight(sub));
                start = i+1;
                left = 0;
                count = 0;
            }
        }

        return start >= s.Length? "" : s.Substring(start);
    }

    public IList<string> FixRight(string s)
    {
        var result = new List<string>();
        bool reset = true;
        for(int i =0; i<s.Length; i++)
        {
            if (s[i] == ')' && reset)
            {
                result.Add(s.Remove(i, 1));
                reset = false;
            }
            else if (s[i] != ')')
            {
                reset = true;
            }
        }
        return result;
    }

    string RLScan(string s)
    {
        int right = 0, start, count = 0;
        for(int i = s.Length-1; i >= 0; i--)
        {
            if(s[i] == ')')
            {
                right++;
            }
            else if (s[i] == '(')
            {
                right--;
            }
            start = i;
            count++;

            if(right < 0)
            {
                var sub = s.Substring(start, count);
                intermRResult.Add(FixLeft(sub));
                right = 0;
                count = 0;
            }
        }

        return s.Substring(0, count);
    }

    public IList<string> FixLeft(string s)
    {
        var result = new List<string>();
        bool reset = true;
        for(int i =0; i<s.Length; i++)
        {
            if (s[i] == '(' && reset)
            {
                result.Add(s.Remove(i, 1));
                reset = false;
            }
            else if (s[i] != '(')
            {
                reset = true;
            }
        }
        return result;
    }
}
}