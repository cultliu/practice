namespace c210{
using System;
using System.Collections.Generic;
public class Solution
{
    public IList<int> Do(int numCourses, int[,] prerequisites)
    {
        var graph = new List<int>[numCourses];
        var counter = new int[numCourses];
        for (int i = 0; i < prerequisites.GetLength(0); i++)
        {
            int course = prerequisites[i,0];
            int require = prerequisites[i,1];

            if (graph[require] == null) graph[require] = new List<int>();

            graph[require].Add(course);
            counter[course]++;
        }

        var queue = new Queue<int>();
        for(int i =0; i< counter.Length; i++)
        {
            if (counter[i] ==0) queue.Enqueue(i);
        }

        var result = new List<int>();
        while(queue.Count > 0)
        {
            int n = queue.Dequeue();
            result.Add(n);
            if (graph[n] != null)
            {
                foreach(var course in graph[n])
                {
                    if(--counter[course] == 0)
                    {
                        queue.Enqueue(course);
                    }
                }
            }
        }
        return  result.Count == numCourses ? result: new List<int>();
    }
}
}