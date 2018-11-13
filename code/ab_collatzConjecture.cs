namespace ab_coll{
using System;
using System.Collections.Generic;
using System.Linq;


class HelloWorld {
    static void Main() {
        System.Console.WriteLine(Collatz(3));
    }
    
    static int Collatz(int n)
    {
        var hash = new Dictionary<int, int>();
        int result = 0;
        
        for(int i = 1; i<=n; i++)
        {
            int cur = i, step = 0;
            while(cur !=1 )
            {
                if (!hash.ContainsKey(cur))
                {
                    if (cur%2 == 0)
                    {
                        cur /= 2;
                    }
                    else
                    {
                        cur = 3*cur+1;
                    }
                    step++;
                }
                else
                {
                    step += hash[cur];
                    break;
                }
            }
            hash[i] = step;
            result = Math.Max(result, step);
        }
        
        return result;
    }
}
}