namespace c399{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static void Main1()
    {
        var so = new Solution();

        string[,] equations = new string[,] {{"a", "b"}, {"b", "c"}};
        double[] values = new double[] {2.0, 3.0};
        var queries = new string[,] {{"a", "c"}, {"b", "a"}, {"a", "e"}, {"a", "a"}, {"x", "x"}}; 

        var a = so.CalcEquation(equations, values, queries);
        int b = 1;
    }

    public double[] CalcEquation(string[,] equations, double[] values, string[,] queries)
    {
        var grah = new Dictionary<string, List<Tuple<string, double>>>();
        for(int i = 0; i<equations.GetLength(0); i++)
        {
            for(int j = 0; j<equations.GetLength(1); j++)
            {
                if(!grah.ContainsKey(equations[i,j]))
                {
                    grah[equations[i,j]] = new List<Tuple<string, double>>();
                }
            }

            grah[equations[i,0]].Add(new Tuple<string, double>(equations[i,1], values[i]));
            grah[equations[i,1]].Add(new Tuple<string, double>(equations[i,0], 1/values[i]));
        }

        var results = new double[queries.GetLength(0)];
        for(int i =0; i < queries.GetLength(0); i++)
        {
            results[i] = find(grah, new HashSet<string>(), queries[i,0], queries[i,1]);
        }
        return results;
    }

    double find(Dictionary<string, List<Tuple<string, double>>> grah, HashSet<string> visited, string start, string target)
    {
        if (start == target)
        {
            return 1;
        }

        visited.Add(start);
        var nodes = grah[start];
        foreach(var node in nodes)
        {
            if (visited.Contains(node.Item1))
            {
                continue;
            }
            else
            {
                var res = find(grah, visited, node.Item1, target);
                if (res != 0)
                {
                    return node.Item2 * res;
                }
            }
        }
        return 0;
    }
}
}