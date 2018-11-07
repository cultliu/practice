namespace ab_1{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int[][] testData = new int[][]{ new int[] {1,2,3}, new int[]{1,4,7,8,3}, new int[]{1,4,5,8,3}, new int[]{1,4,2,3}};

    public List<int> Do(int[][] lists)
    {
        var set = new HashSet<int>();
        var graph = new Dictionary<int, ISet<int>>();
        foreach(var list in lists)
        {
            set.UnionWith(list);
            if (list.Length <= 1)
            {
                continue;
            }

            for(int i=0 ; i< list.Length-1; i++)
            {
                if (!graph.ContainsKey(list[i]))
                {
                    graph.Add(list[i], new HashSet<int>{list[i+1]});
                }
                else
                {
                    graph[list[i]].Add(list[i+1]);
                }
            }
        }

        return dps(graph, set);
    }

    List<int> dps(IDictionary<int, ISet<int>> graph, ISet<int> nodes)
    {
        var result = new List<int>();
        var visit = new HashSet<int>(nodes);
        foreach(var node in nodes)
        {
            result.InsertRange(0, dpsHelper(node, visit, graph));
        }

        return result;
    }

    List<int> dpsHelper(int node, ISet<int> visit, IDictionary<int, ISet<int>> graph)
    {
        var result = new List<int>(node);
        if (!visit.Contains(node))
        {
            return result;
        }

        if (graph.ContainsKey(node))
        {
            foreach(var nextNode in graph[node])
            {
                result.InsertRange(0, dpsHelper(nextNode, visit, graph));
            }
        }

        visit.Remove(node);
        result.Insert(0, node);
        return result;
    }

}
}
