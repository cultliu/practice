namespace c270{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution {
    public int ClosestValue(TreeNode root, double target) {
        
        var cur = root;
        int result = cur.val;
        while(cur != null)
        {
            result = Math.Abs(target-cur.val) > Math.Abs(target-result)? result : cur.val;

            if (target == cur.val) return cur.val;
            cur = target > cur.val? cur.right:cur.left;
        }

        return result;
    }
}
}