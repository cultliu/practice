namespace c140{
using System.Collections.Generic;
public class Solution
{
	public IList<string> WordBreak(string s, IList<string> wordDict)
	{
        if (s.Length == 0) return new List<string>();
		int l = 1;
		
		while (l <= s.Length)
		{
			var curStr = s.Substring(0, l);
			if (wordDict.Contains(curStr))
			{
			  var subRes = WordBreak(s.Substring(l), wordDict);
                if (subRes != null)
                {
                    var newlist = new List<string>() { curStr } ;
                    newlist.AddRange(subRes);
                    return newlist;
                }
			}
			else
			{
				l++;
			}
		}
		 
		return null;
	}
}
}
