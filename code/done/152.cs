namespace c152{

	using System;
	public class Solution
{
	
	public int Do (int[] nums)
	{
	
	//  2,3,-1, -2, 0,
	// 1, 0,2,0,3,0
	// -1,0,0,0,0
	
		int max =0;
		int min =0;
		int premax = 0;
		int premin =0;
		
		foreach (int i in nums)
		{
		   int curMax = Math.Max(premin*i, Math.Max(premax*i, i));
		   int curMin = Math.Min(premax*i, Math.Min(premin*i, i));
			max = Math.Max(curMin, Math.Max(max, curMax));
			min = Math.Min(curMax, Math.Min(min, curMin));
			premax = curMax;
			premin = curMin;
		}
		
		return max;
	}
}
}