namespace c269{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    HashSet<char> visited = new HashSet<char>();
    HashSet<char> nodes = new HashSet<char>();
    Dictionary<char, HashSet<char>> grah = new Dictionary<char, HashSet<char>>();

    public string AlienOrder(string[] words)
    {
        if (words.Length == 0) return "";

        nodes.UnionWith(words[0]);
        if (words.Length == 1) return new String(nodes.ToArray());

        for(int i =1; i < words.Length; i++)
        {
            nodes.UnionWith(words[i]);
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
                        grah.Add(s1[j], new HashSet<char>(){s2[j]});
                    }
                    break;
                }
            }
        }
        
        //Do DPS 
        return dps();
    }


    public string dps()
    {
        string result = "";
        foreach(var node in nodes)
        {
            int deep = 0;
            bool loopFound = false;
            result = dpsHelper(node, deep, ref loopFound) + result;
            if (loopFound) return "";
        }
        return result;
    }

    public string dpsHelper(char node, int deep, ref bool loopFound)
    {
        deep++;
        if (deep > nodes.Count)
        {
            loopFound = true;
            return "";
        }
        if(visited.Contains(node))
        {
            return "";
        }

        if (!grah.ContainsKey(node))
        {
            visited.Add(node);
            return new string(node, 1);
        }

        string result = "";
        foreach(var next in grah[node])
        {
            result = dpsHelper(next, deep, ref loopFound) + result;
            if (loopFound)
            {
                return "";
            }
        }
        visited.Add(node);
        result = node + result;

        return result;
    }
}
}