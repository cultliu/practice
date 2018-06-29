namespace c144{
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
			var cur = stack.Pop();
			result.Add(cur.val);
			if (cur.right != null) stack.Push(cur.right);
			if (cur.left != null) stack.Push(cur.left);
		}
		
		return result;
	}
}
}