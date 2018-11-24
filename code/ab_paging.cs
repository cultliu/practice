namespace ab_paging{
using System;
using System.Collections.Generic;
using System.Linq;


class HelloWorld {
    static void Main1() {
        var csv = new List<string>{"host_id,listing_id,score,city","1,28,300.1,SanFrancisco",
    "4,5,209.1,SanFrancisco",
"20,7,208.1,SanFrancisco",
"23,8,207.1,SanFrancisco",
"16,10,206.1,Oakland",
"1,16,205.1,SanFrancisco",
"6,29,204.1,SanFrancisco",
"7,20,203.1,SanFrancisco",
"8,21,202.1,SanFrancisco",
"2,18,201.1,SanFrancisco",
"2,30,200.1,SanFrancisco",
"15,27,109.1,Oakland",
"10,13,108.1,Oakland",
"11,26,107.1,Oakland",
"12,9,106.1,Oakland",
"13,1,105.1,Oakland",
"22,17,104.1,Oakland",
"1,2,103.1,Oakland",
"28,24,102.1,Oakland",
"18,14,11.1,SanJose",
"6,25,10.1,Oakland",
"19,15,9.1,SanJose",
"3,19,8.1,SanJose",
"3,11,7.1,Oakland",
"27,12,6.1,Oakland",
"1,3,5.1,Oakland",
"25,4,4.1,SanJose",
"5,6,3.1,SanJose",
"29,22,2.1,SanJose",
"30,23,1.1,SanJose"};
        var result = Paging(csv);
        
        foreach(var re in result)
        {
            Console.WriteLine(re);
        }
    }
    
    static List<string> Paging(List<string> csv)
    {
        const int pageSize = 12;
        var rows = new List<string>(csv);
        rows.RemoveAt(0);
        var result = new List<string>();


        while(rows.Count>0)
        {
            int curPageSize = 0, i = 0;
            var set = new HashSet<int>();
            while(curPageSize <= pageSize && i < rows.Count)
            {
                int id = Convert.ToInt32(rows[i].Split(',')[0]);
                if(!set.Contains(id))
                {
                    result.Add(rows[i]);
                    set.Add(id);
                    curPageSize++;
                    rows.RemoveAt(i);
                }
                else
                {
                    i++;   
                }
            }
            result.Add("");
        }
        
        return result;
    }
}
}