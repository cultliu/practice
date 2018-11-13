namespace c309{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int MaxProfit(int[] prices) 
    {
        int n = prices.Length;
        if (n < 2) return 0;

        int[] buy = new int[n], sell = new int[n];
        buy[0] = 0-prices[0];
        sell[0] = 0;

        buy[1] = Math.Max(buy[0], 0-prices[1]);
        sell[1] = Math.Max(buy[0]+prices[1], 0);

        for(int i = 1; i<n; i++)
        {
            buy[i] = Math.Max(buy[i-1], sell[i-2]-prices[i]);
            sell[i] = Math.Max(buy[i-1]+prices[i], sell[i-1]);
        }

        return sell[n-1];
    }
}
}