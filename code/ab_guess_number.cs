namespace ab1{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static int[] hash;
    
    static void Main1(string[] args)
    {
        ServerSet("4533");
        //Console.WriteLine(ServerCheck("3333").ToString());
        Guess();
    }
    
    static void ServerSet(string secret)
    {
        hash = new int[6];
        foreach (var c in secret)
        {
            hash[c-'0']++;
        }
    }
    
    static int ServerCheck(string guess)
    {
        int[] hashCopy = new int[6];
        hash.CopyTo(hashCopy, 0);
        int result = 0;
        
        foreach(var c in guess)
        {
            if (hashCopy[c-'0']-- > 0)
            {
                result++;
            }
        }
        return result;
    }
    
    static string Guess()
    {
        string guess = "1111";
        int res = ServerCheck(guess);
        
        while(res < 4)
        {
            for(int i = res; i < guess.Length; i++)
            {
                var sb = new StringBuilder(guess);
                sb[i]++;
                guess = sb.ToString();
            }
            Console.WriteLine("guess " + guess);
            res = ServerCheck(guess);
            Console.WriteLine("res " + res);

        }
        
        return guess;
    }
    
}

}