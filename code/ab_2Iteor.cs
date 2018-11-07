namespace ab2dit{
using System;
using System.Collections.Generic;
using System.Linq;


public class NewEnumerator
{
    private List<List<int>> data;
    private int col = 0, row = 0;


    public NewEnumerator(List<List<int>> data)
    {
        this.data = data;
    }

    public int Next()
    {
        if (col < 0)
        {
            throw new Exception();
        }

        var result = data[col][row];
        if (row<data[col].Count-1)
        {
            row++;
        }
        else
        {
            int i = col+1;
            for(; i< data.Count; i++)
            {
                if (data[i].Count > 0)
                {
                    col = i;
                    row = 0;
                    break;
                }
            }
            if (i == data.Count)
            {
                col = -1;
            }
        }
        return result;
    }

    public bool HasNext()
    {
        if (col<0) throw new Exception();

        if (row<data[col].Count-1)
        {
            return true;
        }
        else 
        {
            int i = col+1;
            for(; i< data.Count; i++)
            {
                if (data[i].Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public void Remove()
    {
        data[col].RemoveAt(row);
        if (data[col].Count == 0)
        {
            data.RemoveAt(col);
        }
        col = -1;
    }
}

public class Solution
{
    static void Main1(string[] args)
    {
        var data = new List<List<int>>();
        data.Add(new List<int> {1,2,3,4,5});
        data.Add(new List<int> {11,12,13,14,15});
        data.Add(new List<int> {});
        data.Add(new List<int> {111});
        data.Add(new List<int> {21,22,23,24,25});
        var it = new NewEnumerator(data);
        
        while(it.HasNext())
        {
            var val = it.Next();
            Console.WriteLine(val);
            if (val == 111)
            {
                it.Remove();
                break;
            }
        }
    }
}
}