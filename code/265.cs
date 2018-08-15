namespace c265{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int MinCostII(int[,] costs)
    {
        if (costs.GetLength(0) == 0 || costs.GetLength(1) == 0) return 0;

        int n = costs.GetLength(0), k = costs.GetLength(1);
        int min1 = int.MaxValue, min2 = int.MaxValue, index1 = -1;

        for (int i =0; i< k; i++)
        {
            if (costs[0,i] < min1)
            {
                min1 = costs[0,i];
                min2 = min1;
                index1 = i;
            }
            else if (costs[0,i] < min2)
            {
                min2 = costs[0,i];
            }

        }

        for (int i = 1; i < n; i++)
        {
            int curmin1 = int.MaxValue, curmin2 = int.MaxValue, curindex1 = -1;

            for (int j =0; j< k; j++)
            {
                int curcost = 0;
                if (index1 == j)
                {
                    curcost = min2 + costs[i,j];
                }
                else 
                {
                    curcost = min1 + costs[i,j];
                }

                if (curcost < curmin1)
                {
                    curmin1 = curcost;
                    curmin2 = min1;
                    curindex1 = j;
                }
                else if (curcost < curmin2)
                {
                    curmin2 = curcost;
                }
            }
            min1 = curmin1;
            min2 = curmin2;
            index1 = curindex1;
        }

        return min1;

    }
}
}