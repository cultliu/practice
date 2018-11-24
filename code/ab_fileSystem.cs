namespace ab_file{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static void Main1()
    {
        var fs = new FileSystem();

        fs.Create("/a",1);
        Console.WriteLine(fs.Get("/a"));

        fs.Create("/a/b",2);
        Console.WriteLine(fs.Get("/a/b"));

        try
        {
            fs.Create("/c/d",1);
        }
        catch(Exception)
        {
            Console.WriteLine("c/d not found");
        }

        try
        {
            fs.Get("/c");
        }
        catch(Exception)
        {
            Console.WriteLine("c not found");
        }
    }
}

public class FileSystem
{
    FileNode root = new FileNode();

    public int Get(string s)
    {
        var pathArr = s.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var folderNode = GetFolderNode(root, pathArr);
        
        FileNode node;
        if (folderNode.children.TryGetValue(pathArr[pathArr.Length-1], out node) && node.hasValue)
        {
            return node.value;
        }
        throw new Exception();

    }

    public void Create(string s, int val)
    {
        var pathArr = s.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var folderNode = GetFolderNode(root, pathArr);

        folderNode.children[pathArr[pathArr.Length-1]] = new FileNode(val);
    }

    public FileNode GetFolderNode(FileNode root, string[] pathArr)
    {
        var cur = root;
        for(int i = 0; i < pathArr.Length-1; i++)
        {
            if (cur.children.ContainsKey(pathArr[i]))
            {
                var node = cur.children[pathArr[i]];
                cur = node;
            }
            else
            {
                throw new Exception();
            }
        }

        return cur;
    }
}

public class FileNode
{
    public FileNode(int val)
    {
        hasValue = true;
        value = val;
    }

    public FileNode()
    {
        hasValue = false;
    }

    public Dictionary<string, FileNode> children = new Dictionary<string, FileNode>();

    public bool hasValue;

    public int value;
}
}