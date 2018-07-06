namespace c200{
using System;
using System.Collections.Generic;
public class Solution
{
    bool[,] visited;
    public int Do(char[,] grid)
    {
        int x = grid.GetLength(0);
        int y = grid.GetLength(1);
        visited = new bool[x, y];

        for (int i = 0; i<x; i++)
        {
            for(int j=0;j<y;j++)
            {
                visited[i,j] = false;
            }
        }

        int result = 0;
        for (int i = 0; i<x; i++)
        {
            for(int j=0;j<y;j++)
            {
                if (!visited[i,j])
                {
                    result += Visit(grid, i, j);
                }
            }
        }
        return result;
    }

    int Visit(char[,] grid, int x, int y)
    {
        if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1)) return 0;
        if (!visited[x,y])
        {
            visited[x,y] = true;
            if (grid[x,y]=='1')
            {   
                Visit(grid,x+1, y);
                Visit(grid,x-1, y);
                Visit(grid,x, y+1);
                Visit(grid,x, y-1);
                return 1;
            }
        }
        return 0;
    }
}
}