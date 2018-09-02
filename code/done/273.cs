namespace c273{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    private readonly string[] thousandWords = {"", " Thousand", " Million", " Billion"};
    private readonly string[] numWords = new string[] {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
    private readonly string[] tenWords = new string[] {"", "", "Twenty", "Thirty", "Forty", "Fifth", "Sixty", "Seventy", "Eighty", "Ninty"};
    private readonly string[] teenWords = new string[] {"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"};
    public string NumberToWords(int num) 
    {
        if (num == 0) return "Zero";

        string result = "";
        for(int i = 0; i < thousandWords.Length; i++)
        {
            var lessThousand = num%1000;
            if (lessThousand > 0)
            {
                var lessThousandStr = LessThousand(lessThousand);
                lessThousandStr += thousandWords[i];
            }

            result = lessThousand + result;
            num /= 1000;
            if (num == 0)
            {
                break;
            }
        }

        return result;
    }

    private string LessThousand(int num)
    {
        string result = "";
        string hunredStr = numWords[(num / 100)];
        if (hunredStr.Length > 0)
        {
            hunredStr += " Hundred";
        }
        result += hunredStr;

        var lessHundred = num%100;
        if (lessHundred < 20 && lessHundred >= 10 )
        {
            if (result.Length > 0) result += " ";
            result += teenWords[lessHundred - 10];
        }
        else  
        {
            if (lessHundred >= 20)
            {
                if (result.Length > 0) result += " ";
                result += tenWords[lessHundred/10];
            }

            if (lessHundred%10 > 0)
            {
                if (result.Length > 0) result += " ";
                result += numWords[lessHundred%10];
            }
        }
        return result;
    }
}
}