namespace c160{
    public class Solution
    {
        ListNode Do(ListNode headA, ListNode headB)
        {
            if (headA==null) return null;
            if (headB==null) return null;
            ListNode h1 = headA, h2 = headB;
            

            while ( headA!=null && headB!=null && headA != headB)
            {
                headA = headA.next;
                headB = headB.next;

                if (headA == null) headA = h2;
                if (headB == null) headB = h1;
            }

            return headA;
        }
    }
}