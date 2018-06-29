namespace c173{
/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
using System.Collections.Generic;
public class BSTIterator {

    private Stack<TreeNode> stack = new Stack<TreeNode>();
    private TreeNode next;

    public BSTIterator(TreeNode root) {
        AddNode(root);
    }

    private void AddNode(TreeNode root)
    {
        var cur =root;
        while(cur != null)
        {
            stack.Push(cur);
            cur = cur.left;
        }
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return stack.Peek() != null;
    }


    /** @return the next smallest number */
    public int Next() {
        var res = stack.Pop();
        if (res.right != null)
        {
            AddNode(res.right);
        }
        return res.val;
    }
}

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = new BSTIterator(root);
 * while (i.HasNext()) v[f()] = i.Next();
 */
}