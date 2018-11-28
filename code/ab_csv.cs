namespace ab_csv{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static public void Main1()
    {
        var input = new string[] {@"John,Smith,john.smith@gmail.com,Los Angeles,1", 
        "Jane,Roberts,janer@msn.com,\"San Francisco, CA\",0",
        "\"Alexandra \"\"Alex\"\"\",Menendez,alex.menendez@gmail.com,Miami,1",
        "\"\"\"Alexandra Alex\"\"\""
        };

        Console.WriteLine(ParseLine(input[3]));
    }

    static List<string> ParseCsv(string[] input)
    {
        var result = new List<string>();
        foreach(string line in input)
        {
            result.Add(ParseLine(line));
        }
        return result;
    }

    static string ParseLine(string input)
    {
        var result = new List<string>();
        string cur = "";
        bool instring = false;
        for(int i = 0; i < input.Length; i++)
        {
            if (input[i]=='"' && i<input.Length-1 && input[i+1] == '"')
            {
                cur += "\"";
                i++;
            }
            else if(input[i]=='"')
            {
                instring = !instring;
            }
            else if (input[i] == ',' && !instring)
            {
                result.Add(cur);
                cur = "";
            }
            else 
            {
                cur+=input[i];
            }
        }
        result.Add(cur);
        return string.Join("|", result);
    }
}
}