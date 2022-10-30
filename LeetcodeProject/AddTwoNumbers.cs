public class AddTwoNumbers
{
    /// <summary>
    /// lettcode #2 Add Two Numbers
    /// 鏈式結構、Linked List
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>

    public static ListNode Get_AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // result 的 ListNode
        ListNode head = new ListNode(0); //因為鏈結構需要一個起始位置，所以先設置一個 0
        ListNode l3 = head; // 先將 l3 Reference 也指向 head

        int carry = 0; //需要先聲明當前進位，並且起始為 0
        // ex: 紀錄個位數的 sum 如果超過 10，需要將十位數的 "1" 存下來，之後十位數相加的時候也要把這個 "1" 加進去

        while (l1 != null || l2 != null)
        {
            // 為了防止其中一個 ListNode 比較短，所以要是 a 已經沒數值了 b 還有，就還是需要繼續做，沒數值的那位就補 0
            int l1_val = (l1 != null) ? l1.val : 0;
            int l2_val = (l2 != null) ? l2.val : 0;

            int twoSum = l1_val + l2_val + carry;
            carry = twoSum / 10; // 用於確認 sum 有沒有超過 10 位數
            int last_number = twoSum % 10; // 取得該位數的值

            ListNode newNode = new ListNode(last_number);
            l3.next = newNode;
            // 這時候的 l3.val 是 0, 所以將 next 指定為 last_number，就建立完 0 → last_number 的指標了

            // 改變起始位置
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
            l3 = l3.next;
        }

        if (carry > 0) // 為了預防 900 + 900 = 1800 時最後一位數「1」沒有加到的情況
        {
            ListNode lastNode = new ListNode(1);
            l3.next = lastNode; // 將最後一個值加進去
        }

        return head.next;

    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override bool Equals(object? obj)
    {
        return obj is ListNode listNode &&
             listNode.val == val &&
             ((listNode.next == null && next == null) || (listNode.next != null && next != null && listNode.next.Equals(next)));
    }
}