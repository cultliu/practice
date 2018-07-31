namespace c235{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public TreeNode Do(TreeNode root, TreeNode q, TreeNode p)
    {
        var cur = root;
        while (cur != null)
        {
            if ((q.val > cur.val) && (p.val > cur.val))
            {
                cur = root.right;
            }  
            else if (q.val < cur.val && p.val < cur.val)
            {
                cur = root.left;
            }
            else 
            {
                return cur;
            }
        }
        return null;
    }
}
}