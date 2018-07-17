namespace c221{
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int Do(bool[,] grid)
    {
        int n = grid.GetLength(0), m = grid.GetLength(1);
        int[,] results = new int[n,m];
        int result = 0;

        for (int j =0; j<m; j++)
        {
            if(grid[0,j])
            {
                results[0,j] = 1;
                result = Math.Max(result, 1);
            }
        }

        for(int i=1; i<n; i++)
        {
            if (grid[i,0])
            {
                results[i,0] = 1;

                result = Math.Max(result, 1);
            }

            for (int j =1; j<m; j++)
            {
                if(grid[i,j])
                {
                    int temp = Math.Min(results[i-1,j], results[i, j-1]);
                    temp = Math.Min(temp, results[i-1,j-1]);
                    results[i,j] = temp+1;
                    result = Math.Max(result, temp+1);
                }
            }
        }
        return result;
    }
}
}