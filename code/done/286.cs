namespace c286{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public void WallsAndGates(int[,] rooms)
    {
        var queue = new Queue<int[]>();
        for(int i =0; i < rooms.GetLength(0); i++)
        {
            for (int j =0; j < rooms.GetLength(1); j++)
            {
                if (rooms[i,j] == 0)
                {
                    queue.Enqueue(new int[]{i,j});
                }
            }
        }
        
        while(queue.Count > 0)
        {
            var start = queue.Dequeue();
            int x = start[0], y = start[1];
            int cur = rooms[x,y];
            walk(x-1, y, ref rooms, ref queue, cur);
            walk(x+1, y, ref rooms, ref queue, cur);
            walk(x, y-1, ref rooms, ref queue, cur);
            walk(x, y+1, ref rooms, ref queue, cur);
        }
    }

    void walk(int x, int y, ref int[,]rooms, ref Queue<int[]> queue, int cur)
    {
        if (x<0 || x >= rooms.GetLength(0) || y<0 || y>= rooms.GetLength(1))
            return;

        if (rooms[x,y] == int.MaxValue)
        {
            rooms[x,y] = cur+1;
            queue.Enqueue(new int[2]{x,y});
        }
    }
}
}