using System;
using System.Collections;
using System.Collections.Generic;

namespace vscode
{
    class Program
    {
        static void Main(string[] args)
        {
            var so = new c191.Solution();
			so.Do(2);
        }
    }

    

public class Solution
{
public void ReorderList (ListNode head)
	{
		if (head == null || head.next == null || head.next.next == null) return;
		//find the middle
		var dummy = new ListNode(0);
		dummy.next = head;
		ListNode p1 = dummy, p2 = dummy;
		while (p2!= null && p2.next != null)
		{
			p1 = p1.next;
			p2 = p2.next.next;
		}
		
		var newHead = ListReverse(p1.next);
		p1.next = null;
		
		ListMerge(head, newHead);
		
	}
	
	private ListNode ListReverse(ListNode head)
	{
		if (head.next == null)
		{
			return head;
		}
		
		ListNode p1 = null, p2 = head, p3 = head.next;
		while (p3 != null)
		{
			p2.next = p1;
			p1 = p2;
			p2 = p3;
			p3 = p3.next;
		}
		p2.next = p1;
		
		return p2;
	}
	
	private void ListMerge(ListNode l1, ListNode l2)
	{
		ListNode p1 = l1, p2 = l2;
		while(p2 != null)
		{
			var t1 = p1.next;
			p1.next = p2;
			var t2 = p2.next;
			p2.next = t1;
			p1 = t1;
			p2 = t2;
		}
	}
}
}
