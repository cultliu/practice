namespace c336{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public IList<IList<int>> Do(string[] words)
    {
        var result = new List<IList<int>>();
        if (words.Length == 0) return result;

        // make a hash table
        var hash = new Dictionary<string, int>();
        for (int i=0; i<words.Length; i++)
        {
            hash.Add(words[i], i);
        }

        for (int i=0; i<words.Length; i++)
        {
            if (words[i] == "") continue;

            var reverse = ReverseString(words[i]);
            if (reverse != words[i] && hash.ContainsKey(reverse))
            {
                result.Add(new List<int>{i, hash[reverse]});
                continue;
            }

            for(int j = words[i].Length-1; j >=0; j--)
            {
                if (check(words[i].Substring(j)))
                {
                    var pair = ReverseString(words[i].Substring(0,j));
                    if(hash.ContainsKey(pair))
                    {
                        result.Add(new List<int>{i, hash[pair]});
                    }
                }
            }

            for(int j = 1; j <words[i].Length; j++)
            {
                if (check(words[i].Substring(0,j)))
                {
                    var pair = ReverseString(words[i].Substring(j));
                    if(hash.ContainsKey(pair))
                    {
                        result.Add(new List<int>{hash[pair], i});
                    }
                }
            }
        }
        return result;
    }

    string ReverseString(string s)
    {
        var chs = s.ToArray();
        Array.Reverse(chs);
        return new string(chs);
    }

    private bool check(string s)
    {
        int i =0, j = s.Length-1;
        while(i < j)
        {
            if (s[i++] != s[j--]) return false;
        }

        return true;
    }
}
}