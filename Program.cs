﻿
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main1(string[] args)
    {
        var so = new c773.Solution1();

        var resut = so.SlidingPuzzle(so.test);
        int a = 1;
    }

    static int GetNextNode(int[] dists)
    {
        int min = int.MaxValue;
        int result = -1;
        for(int i = 0; i < dists.Length; i++)
        {
            if (dists[i] >=0)
            {
                if (dists[i] <=min)
                {
                    min = dists[i];
                    result = i;
                }
            }
        }
        return result;
    }

    static int FindShortest(IList<IList<int>> relations)
    {
        int n = relations.Count;
        var dist = new int[n];
        var pre = new int[n];
        dist[0] = 0;

        for(int i = 1; i < n; i++)
        {
            dist[i] = int.MaxValue;
        }


        for(int i = 0; i < n; i++)
        {
            int node = GetNextNode(dist);
            if (node == n-1)
            {
                break;
            }
            if (dist[node] == int.MaxValue)
            {
                break;
            }

            foreach(int p in relations[node])
            {
                if (dist[p] >=0)
                {
                    int distance = (node-p) * (node - p);
                    dist[p] = Math.Min(dist[p], dist[node] + distance);
                    pre[p] = node;
                }
            }

            dist[node] = -1;
        }

        return dist[n-1];
    }
}