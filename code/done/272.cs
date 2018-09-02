namespace c272{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    LinkedList<int> result;

    public IList<int> ClosestKValues(TreeNode root, double target, int k) 
    {
        result = new LinkedList<int>();
        ClosestKValuesHelper(root, target, k);

        return result.ToList();
    }

    private void ClosestKValuesHelper(TreeNode root, double target, int k)
    {
        if (root == null) return;

        ClosestKValuesHelper(root.left, target, k);

        if (result.Count >= k)
        {
            if (Math.Abs(root.val - target) >= Math.Abs(result.First.Value -target))
            {
                return;
            }
            else
            {
                result.AddLast(root.val);
                result.RemoveFirst();
            }
        }
        else
        {
            result.AddLast(root.val);
        }

        ClosestKValuesHelper(root.right, target, k);
    }
}
}