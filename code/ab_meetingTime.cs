namespace ab_meeting{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static void Main()
    {
        var so = new Solution();
        var res = so.Do(new int[][] {
            new int[] {1,3}, 
            new int[] {6,7}, 
            new int[] {2,4}, 
            new int[] {2,3}, 
            new int[] {9,12}});
        foreach(var re in res)
        {
            Console.WriteLine(re[0] + "," + re[1]);
        }
    }

    public List<int[]> Do(int[][] meetings)
    {
        var comparer = Comparer<int[]>.Create( (a,b) => a[0].CompareTo(b[0]));
        Array.Sort(meetings, comparer);
        List<int[]> result = new List<int[]>();

        int curStart = meetings[0][0], curEnd = meetings[0][1];
        for(int i = 1; i<meetings.Length; i++)
        {
            if (meetings[i][0]> curEnd)
            {
                result.Add(new int[] {curEnd, meetings[i][0]});
                curStart = meetings[i][0];
                curEnd = meetings[i][1];
            }
            else
            {
                curEnd = Math.Max(curEnd, meetings[i][1]);
            }
        }

        return result;
    }

}
}