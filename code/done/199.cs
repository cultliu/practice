namespace c199{
using System;
using System.Collections.Generic;
public class Solution
{
    public IList<TreeNode> Do(TreeNode root)
    {
        var result = new List<TreeNode>();
        if (root == null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(null);

        while(queue.Count>0)
        {
            var cur = queue.Dequeue();
            if (cur.left != null) queue.Enqueue(cur.left);
            if (cur.right != null) queue.Enqueue(cur.right);

            if(queue.Peek() == null)
            {
                result.Add(cur);
                queue.Dequeue();
                if (queue.Count>0)
                {
                    queue.Enqueue(null);
                }
            }
        }


        return result;
    }
}
} 