namespace c40{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        return Helper(candidates, 0, target);
    }
    
    public IList<IList<int>> Helper(int[] candidates, int start, int target) {

        var result = new List<IList<int>>();

        if (candidates[start] > target)
            return result;
        
        var resultA = Helper(candidates, start+1, target-candidates[start]);
        foreach(var resA in resultA)
        {
            resA.Insert(0, candidates[start]);
        }
        var resultB = Helper(candidates, start+1, target);
        
        resultA.Add(resultB);
        return resultA;
    }
}
}