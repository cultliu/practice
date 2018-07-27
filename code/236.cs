namespace c236{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode q, TreeNode p)
    {
        if(root == null || root == q || root == p) return root;

        var left = LowestCommonAncestor(root.left, q,p);
        var right = LowestCommonAncestor(root.right, q,p);
        return (left == null)? right : (right==null) ? left :root;
    }
}
}