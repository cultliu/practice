namespace c270{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution {
    public int ClosestValue(TreeNode root, double target) {
        if (target == root.val) return root.val;
        else if (target < root.val)
        {
            if (root.left==null)
            {
                return root.val;
            }
            
            int leftClose = ClosestValue(root.left, target);
            if (target <= root.left.val)
            {
                return leftClose;
            }
            else
            {
                return Math.Abs(leftClose-target) > Math.Abs(root.val - target) ? root.val : leftClose; 
            }
        }
        else
        {
            if (root.right==null)
            {
                return root.val;
            }
            
            int rightClose = ClosestValue(root.right, target);
            if (target >= root.right.val)
            {
                return rightClose;
            }
            else
            {
                return Math.Abs(rightClose-target) > Math.Abs(root.val - target) ? root.val : rightClose; 
            }
        }
    
    }
}
}