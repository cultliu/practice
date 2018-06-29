namespace c145{
using System.Collections.Generic;
public class Solution
{
	public IList<int> Do (TreeNode root)
	{
		var result = new List<int>();
		if (root == null) return result;
		
		var stack = new Stack<TreeNode>();
		stack.Push(root);
		
		while (stack.Count>0)
		{
			var top = stack.Peek();
			if (top.right != null) { stack.Push(top.right); top.right = null;}
			if (top.left != null) { stack.Push(top.left); top.left = null;}
			
			
			if (stack.Peek() == top)
			{
				var cur = stack.Pop();
				result.Add(cur.val);
			}
		}
		
		return result;
	}
}
}
