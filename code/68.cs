namespace c68{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    static void Main1()
    {
        var so = new Solution();
        //string[] words = {"This", "is", "an", "example", "of", "text", "justification."};
        //string[] words = {"What","must","be","acknowledgment","shall","be"};
        string[] words = {"Science","is","what","we","understand","well","enough","to","explain", "to","a","computer.","Art","is","everything","else","we","do"};
        //int maxWidth = 16;
        int maxWidth = 20;
        var a = so.FullJustify(words, maxWidth);
        foreach(var result in a)
        {
            Console.WriteLine(result);
        }
    }

    public IList<string> FullJustify(string[] words, int maxWidth) {
        var results = new List<string>();
        
        for(int i = 0; i < words.Length; )
        {
            int start = i;
            int end = i;
            int length = words[start].Length;
            
            while(length <= maxWidth && end < words.Length-1)
            {
                length += (words[++end].Length +1);
            }
            
            if (length > maxWidth)
            {
                length -= (words[end--].Length - 1);
                results.Add(GenerateLine(words, start, end, maxWidth - length));
            }
            else
            {
                results.Add(GenerateLine(words, start, end, 0));
            }
            
            i = end+1;
        }
        return results;
    }
    
    string GenerateLine(string[] words, int start, int end, int extraSpace)
    {
        if (end == start)
        {
            return words[start]+Padding(extraSpace) + '"';
        }
        else 
        {
            int spaceCount = end-start;
            int pad = (extraSpace / spaceCount)+1;
            int extraPadCount = extraSpace % spaceCount;
            string padString = Padding(pad);

            string result = words[start];
            
            for(int i = 0; i <= end-start-1; i++)
            {
                result += padString;
                if (i<=extraPadCount)
                {
                    result += " ";
                }
                result += words[start+i+1];
            }
            return result + '"';
        }
    }

    string Padding(int pad)
    {
        string padString = "";
        for(int i =0; i<pad; i++)
        {
            padString += " ";
        }
        return padString;
    }
}
}