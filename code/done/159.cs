namespace c159{
	using System;

	//
	public class Solution{
		public int Do(string s)
		{
			var curChars = new char[2];
			int max =0, preLength = 0;

			for(int i=0; i<s.Length; i++)
			{
				if (s[i] == curChars[0] || s[i]==curChars[1])
				{
					preLength++;
					max = Math.Max(max, preLength);
				}
				else
				{
					curChars[0] = s[i]; curChars[1] = '\0';
					for(int j = i-1; j >=0; j--)
					{
							if (s[j] != curChars[0])
							{
								curChars[1] = s[j];
							}
					}
				}
			}
			return max;
		}
}
}