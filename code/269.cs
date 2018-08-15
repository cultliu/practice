namespace c269{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public string AlienOrder(string[] words)
    {
        if (words.Length == 0) return "";

        var chars = new HashSet<char>();
        var grah = new Dictionary<char, IList<char>>();
        chars.UnionWith(words[0]);
        if (words.Length == 1) return new String(chars.ToArray());

        for(int i =1; i < words.Length; i++)
        {
            chars.UnionWith(words[1]);
            char[] s1 = words[i-1].ToArray(), s2 = words[i].ToArray();
            for(int j =0; j < Math.Min(s1.Length, s2.Length); j++)
            {
                if(s1[j]!=s2[j]) 
                {
                    if (grah.ContainsKey(s1[j]))
                    {
                        grah[s1[j]].Add(s2[j]);
                    }
                    else
                    {
                        grah.Add(s1[j], new List<char>(){s2[j]});
                    }
                }
            }
        }
    }
}
}