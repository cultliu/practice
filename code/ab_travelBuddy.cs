namespace ab_travel{
using System;
using System.Collections.Generic;
using System.Linq;


class HelloWorld {
    
    static List<List<string>> Find(List<string> me, List<List<string>> friends)
    {
        var hash = new HashSet<string>(me);
        
        var process= new List<int[]>();
        
        for(int i =0; i < friends.Count; i++)
        {
            int count = 0;
            foreach(var city in friends[i])
            {
                if (hash.Contains(city))
                {
                    count++;
                }
            }
            int percent = count*10/friends[i].Count;
            if (percent>=5)
            {
                process.Add(new int[2] {percent, i});
            }
        }
        
        process.Sort((a, b) => b[0].CompareTo(a[0]));
        
        var result = new List<List<string>>();
        foreach(var item in process)
        {
            result.Add(friends[item[1]]);
        }
        return result;
    }
    
    
    static void Main1() {
        System.Console.WriteLine("Hello World!");
        var me  = new List<string> {"a","b", "c","d"};
        
        var friends  = new List<List<string>> {
            new List<string> {"a","b", "ca","d"},
            new List<string>{"a","b", "c","da"},
            new List<string>{"a","ba", "c","d"},
            new List<string>{"aa","ba", "cs","d"},
            new List<string>{"a","ba", "cs","d"},
            new List<string>{"a","b", "c","d"},
        };
        
        var res = Find(me, friends);
        foreach(var re in res)
        {
            string friend = "";
            foreach(var city in re)
            {
                friend += city + ",";
            }
            Console.WriteLine(friend);
        }
    }
}
}