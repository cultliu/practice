namespace c285{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public TreeNode Do(TreeNode root, TreeNode p)
    {
        if (p.right != null)
        {
            return LeftMost(p.right);
        }

        if (p.val == root.val)
        {
            return root.right;
        }
        else if(p.val < root.val)
        {
            var node = Do(root.left, p);
            return node == null ? root:node;
        }
        else
        {
            return Do(root.right, p);
        }

    }

    TreeNode LeftMost(TreeNode root)
    {
        var cur = root;
        while(cur.left != null)
        {
            cur = cur.left;
        }

        return cur;
    }
}
}