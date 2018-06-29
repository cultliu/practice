namespace c141{
public class Solution
{
	public bool HasCycle (ListNode head)
	{
		if (head.next == null) return false;
		
		ListNode p1 = head, p2 = head;
		
		while(p2!= null && p2.next != null)
		{
			p1 = p1.next;
			p2 = p2.next.next;
			if (p1 == p2)
			{
				return true;
			}
		}
		
		return false;
	}
}
}