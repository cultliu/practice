namespace c137{
public class Solution
{
	public int SingleNumber(int[] nums)
	{
		int a=0,b=0;
		foreach(int num in nums)
		{
			a = (a&~b&~num) | (~a&b&num);
			b=~a&((b&~num) | (~b&num));
		}
		return a|b;
	}
}

}