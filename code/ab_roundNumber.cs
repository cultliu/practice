namespace ab_round{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static void Main1()
    {
        var test = new double[] {1.2, 2.8, 5.5};
        var res = Round(test);
    }


    static public int[] Round(double[] input)
    {
        int sumRound = (int)Math.Round(input.Sum());

        var result = new int[input.Length];
        var sortArray = new Tuple<double, int>[input.Length];

        int ceilSum = 0;
        for(int i =0; i < input.Length; i++)
        {
            result[i] = (int)Math.Ceiling(input[i]);
            ceilSum += result[i];
            sortArray[i] = new Tuple<double, int>(input[i] - result[i] + 1, i);
        }

        int diff = ceilSum - sumRound;

        Array.Sort(sortArray, (a,b) =>{
            return (a.Item1-Math.Floor(a.Item1)).CompareTo(b.Item1-Math.Floor(b.Item1));
         } );

        for(int i =0; i < diff; i++)
        {
            result[sortArray[i].Item2]--;
        }
        return result;
    }
}
}