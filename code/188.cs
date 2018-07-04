namespace c188{
    using System;
public class Solution
{
    public int Do(int[] prices, int k)
    {
        int maxProfit = 0;
        int count = Math.Min(prices.Length/2, k);
        int[] buys = new int[count], sells = new int[count];

        for(int i=0; i<buys.Length; i++)
        {
            buys[i] = int.MinValue;
        }

        foreach(var num in prices)
        {
            for(int i=count-1; i>=0;i--)
            {   
                sells[i] = Math.Max(sells[i], buys[i] + num);
                buys[i] = Math.Max(buys[i], i==0? 0-num: sells[i-1]-num);
                maxProfit = Math.Max(sells[i], maxProfit);
            }
        }

        return maxProfit;
    }
}
}