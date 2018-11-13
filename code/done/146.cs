namespace c146{
using System;
using System.Collections.Generic;
using System.Linq;

public class LRUCache {
    private LinkedList<KeyValuePair<int,int>> list = new LinkedList<KeyValuePair<int,int>>();
    private Dictionary<int, LinkedListNode<KeyValuePair<int,int>>> map = new Dictionary<int, LinkedListNode<KeyValuePair<int,int>>>();
    private readonly int _capacity; 

    public LRUCache(int capacity) {
        this._capacity = capacity;
    }
    
    public int Get(int key) {
        if (!map.ContainsKey(key)) 
            return -1;
        
        MoveFront(key);
        return list.First.Value.Value;
    }
    
    public void Put(int key, int value) {
        if(map.ContainsKey(key))
        {
            this.MoveFront(key);
            list.First.Value = new KeyValuePair<int,int>(key,value);
        }
        else
        {
            var node = list.AddFirst(new KeyValuePair<int, int>(key, value));
            map.Add(key, node);

            if (list.Count > this._capacity)
            {
                var lastNode = list.Last;
                list.RemoveLast();
                map.Remove(lastNode.Value.Key);
            }
        }
    }

    private void MoveFront(int key)
    {
        var node = map[key];
        if (list.First != node)
        {
            list.Remove(node);
            list.AddFirst(node);
        }
    }
}
}