namespace c308{
using System;
using System.Collections.Generic;
using System.Linq;


public class NumMatrix
{
    int[,] sum;
    int n = 0;
    int m = 0;
    int[,] matrix;
    public NumMatrix(int[,] matrix) {
        this.matrix = matrix;
        n = matrix.GetLength(0);
        m = matrix.GetLength(1);
        sum = new int[n,m];

        sum[0,0] = matrix[0,0];
        for(int i = 1 ; i< n; i++)
        {
            sum[0,i] = sum[0,i-1] + matrix[0,i];
        }

        for(int i = 1 ; i< n; i++)
        {
            sum[i,0] = sum[i-1,0] + matrix[i,0];
            for(int j = 1; j< m; j++)
            {
                sum[i,j] = sum[i-1,j] + sum[i, j-1] + matrix[i,j] - sum[i-1,j-1];
            }
        }
    }
    
    public void Update(int row, int col, int val) {
        for(int i = row ; i< n; i++)
        {
            for(int j = col; j< m; j++)
            {
                sum[i,j] = sum[i,j] - matrix[i,j] + val;
            }
        }
        matrix[row,col] = val;
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        if (row1 == row2 && col1 == col2) return matrix[row1, col1];

        if (col1 ==0 || row1 ==0)
        {
            return sum[row2,col2] - sum[row1, col1];
        }

        return sum[row2,col2] + sum[row1-1, col1-1] - sum[row1-1, col2] - sum[row2, col1-1];
    }
}
}