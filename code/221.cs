namespace c221{
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int Do(char[,] matrix)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int[,] results = new int[n,m];
        int result = 0;

        for (int j =0; j<m; j++)
        {
            if(matrix[0,j]=='1')
            {
                results[0,j] = 1;
                result = Math.Max(result, 1);
            }
        }

        for(int i=1; i<n; i++)
        {
            if (matrix[i,0]=='1')
            {
                results[i,0] = 1;

                result = Math.Max(result, 1);
            }

            for (int j =1; j<m; j++)
            {
                if(matrix[i,j]=='1')
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