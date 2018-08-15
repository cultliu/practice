namespace c208{
using System;
using System.Collections.Generic;

public class TrieNode
{
    public TrieNode[] Next {get; set;} = new TrieNode[26];
    public bool HasString {get; set;} = false;

}
public class Trie
{
    private TrieNode root = new TrieNode();

    public Trie()
    {
    }

    public void Insert(string word)
    {
        var arr = word.ToCharArray();
        var cur = root;
        for (int i = 0; i<arr.Length; i++)
        {
            var node = cur.Next[arr[i]-'a'];
            if(node == null) node = new TrieNode();

            if (i==arr.Length-1) node.HasString = true;

            cur.Next[arr[i]-'a'] = node;
            cur = node;
        }
    }

    public bool Search(string s)
    {
        var node = GetNode(s);
        return node != null && node.HasString;
    }

    public bool StartWith(string s)
    {
        return GetNode(s) != null;
    }

    private TrieNode GetNode(string s)
    {
        var arr = s.ToCharArray();
        var cur = root;
        for (int i = 0; i<arr.Length; i++)
        {
            int index = arr[i] - 'a';
            if (cur.Next[index] == null)
            {
                return null;
            }

            cur = cur.Next[index];
        }
        return cur;
    }
}
}