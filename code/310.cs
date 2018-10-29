namespace c310{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();
    public IList<int> FindMinHeightTrees(int n, int[,] edges) {
        int minHeight = int.MaxValue;
        var result = new List<int>();
        if (n==0) return result;
        if (n==1) {result.Add(0); return result;}

        for(int i = 0; i < edges.GetLength(0); i++)
        {
            AddEdge(edges[i,0], edges[i,1]);
            AddEdge(edges[i,1], edges[i,0]);
        }

        foreach(var node in graph)
        {
            int height = DFS(node.Key);
            if (height< minHeight)
            {
                minHeight = height;
                result.Clear();
                result.Add(node.Key);
            }
            else if(height == minHeight)
            {
                result.Add(node.Key);
            }
        }

        return result;
    }

    private void AddEdge(int start, int end)
    {
        var endNode = new int[2]{end, 0};
        if (graph.ContainsKey(start))
        {
            graph[start].Add(endNode);
        }
        else
        {
            graph.Add(start, new List<int[]>(){endNode});
        }
    }

    private int DFS(int root)
    {
        int max = 0;
        foreach(var node in graph[root])
        {
            if(node[1] > 0)
            {
                max = Math.Max(max, node[1]);
            }
            else 
            {
                max = Math.Max(DFS(node[0], root), max);
            }
        }
        return max+1;
    }

    private int DFS(int cur, int parent)
    {
        int max = 0;

        foreach(var node in graph[cur])
        {
            if (node[0] == parent)
            {
                continue;
            }
            else
            {
                if(node[1] > 0)
                {
                    max = Math.Max(max, node[1]);
                }
                else 
                {
                    max = Math.Max(DFS(node[0], cur), max);
                }
            }
        }

        return max+1;
    }
}
}