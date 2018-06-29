namespace c138{

	using System;
	using System.Collections.Generic;

public class Solution
{
    private Dictionary<int, RandomListNode> table = new Dictionary<int, RandomListNode>();
	public RandomListNode Copy(RandomListNode node)
	{
		if (node == null) return null;
		
		var cur = node;
		while (cur != null)
		{
			var copy  = GetCopyNode(cur);
			copy.next  = cur.next ==null? null: GetCopyNode(cur.next);
			copy.random = cur.random == null? null: GetCopyNode(copy.random);
			
			cur  = cur.next;
		}
		
		return table[node.label];
	}
	
	RandomListNode GetCopyNode(RandomListNode node)
	{
		if (!table.ContainsKey(node.label))
		{
			var newCopy = new RandomListNode(node.label);
			table[node.label] = newCopy;
		}
		return table[node.label];
	}
	
}
}