
namespace c139{
	using System.Collections.Generic;
public class Solution
{
	public bool WordBreak(string s, IList<string> wordDict)
	{
		if (s.Length == 0) return true;
		int l = 1;
		
		while (l <= s.Length)
		{
			if (wordDict.Contains(s.Substring(0, l)) && WordBreak(s.Substring(l), wordDict))
			{
                return true;
			}
			else
			{
				l++;
			}
		}
		 
		return false;
	}
}
}