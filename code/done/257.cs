namespace c257{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        //if (root == null) return new List<string>();

        return Do("", root);
    }

    public IList<string> Do(string parent, TreeNode root)
    {
        var result = new List<string>();

        if(root == null) 
        {
            return result;
        }

        parent = string.IsNullOrEmpty(parent)? string.Empty :"->" + root.val.ToString();

        if (root.left == null && root.right == null) 
        {
            result.Add(parent);
            return result;
        }

        var left = Do(parent, root.left);
        var right = Do(parent, root.right);

        result.AddRange(left);
        result.AddRange(right);

        return result;
    }
}
}