namespace c151{
	using System.Text;
	using System;
public class Solution
{
	public string Do (string a)
	{
	  StringBuilder sb = new StringBuilder();
	  var ar = a.Split(' ', StringSplitOptions.RemoveEmptyEntries);
	  for (int i = a.Length-1; i >=0; i--)
	  {
			sb.Append(ar[i]);
			sb.Append(" ");
	  }
		
		return sb.ToString().TrimEnd();
	}
}
}