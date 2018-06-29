namespace c142{

public class Solution
{
	public ListNode HasCycle (ListNode head)
	{
		if (head.next == null) return null;
		
		ListNode p1 = head, p2 = head;
		
		while(p2!= null && p2.next != null)
		{
			p1 = p1.next;
			p2 = p2.next.next;
			if (p1 == p2)
			{
				p1 = head;
				while(true)
				{
					p1 = p1.next;
					p2 = p2.next;
					if (p1 == p2)
					{
						return p1;
					}
				}
			}
		}
		
		return null;
	}
}
}