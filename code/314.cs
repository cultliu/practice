namespace c314{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    SortedDictionary<int, SortedList<int,int>> map = new SortedDictionary<int, SortedList<int,int>>();
    public IList<IList<int>> VerticalOrder(TreeNode root)
    {
        helper(root, 0, 0);

        var result = new List<IList<int>>();
        foreach(var column in map)
        {
            var list = column.Value.Values.ToList();
            result.Add(list);
        }
        return result;
    }

    private void helper(TreeNode node, int col, int level)
    {
        if (node == null) return;

        if (map.ContainsKey(col))
        {
            map[col].Add(level, node.val);
        }
        else
        {
            map.Add(col, new SortedList<int, int>());
            map[col].Add(level, node.val);
        }
        helper(node.left, col-1, level+1);
        helper(node.right, col+1, level+1);
    }
}
}