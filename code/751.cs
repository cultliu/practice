namespace c751{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
    public string p1 = "1.1.1.107";
    public int p2 = 20;
    public List<String> ipToCIDR(String ip, int n)
    {
        var results = new List<string>();
        var ipArr = ip.Split('.');
        Int32 ipData = (Convert.ToInt32(ipArr[0])<<24) + (Convert.ToInt32(ipArr[1])<<16) + (Convert.ToInt32(ipArr[2])<<8) + (Convert.ToInt32(ipArr[3]));

        int curIp = ipData;
        while (n > 0)
        {
            int maskBit = Last1Bit(curIp);
            while (1 << maskBit > n)
            {
                maskBit--; 
            }

            string result = Print(curIp, maskBit);
            results.Add(result);

            int count = 1<<maskBit;
            n-=count;
            curIp+=count;
        }        

        return results;
    }

    int Last1Bit(int i)
    {
        int result = 0;
        while( (i & 1) == 0)
        {
            i >>= 1;
            result++;
        }

        return result;
    }

    string Print(int startIp, int maskBit)
    {
        var result = new StringBuilder(); 
        for(int i = 3; i >= 0; i-- )
        {
            result.Append((startIp >> 8*i) & 0xFF);
            result.Append(".");
        } 

        result[result.Length-1] = '/';

        result.Append(32 - maskBit);

        return result.ToString();
    }
}
}