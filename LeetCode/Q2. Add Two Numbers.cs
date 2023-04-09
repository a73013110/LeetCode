using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Q2
    {
        public void Test()
        {
            var l1 = List2ListNode(new int[] { 2, 4, 3 }.ToList());
            var l2 = List2ListNode(new int[] { 5, 6, 4 }.ToList());
            ListNode result = AddTwoNumbers(l1, l2);
            PrintListNode(result);
            l1 = List2ListNode(new int[] { 0 }.ToList());
            l2 = List2ListNode(new int[] { 0 }.ToList());
            result = AddTwoNumbers(l1, l2);
            PrintListNode(result);
            l1 = List2ListNode(new int[] { 9, 9, 9, 9, 9, 9, 9 }.ToList());
            l2 = List2ListNode(new int[] { 9, 9, 9, 9 }.ToList());
            result = AddTwoNumbers(l1, l2);
            PrintListNode(result);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return GetListNode(l1, l2, 0);
        }

        public ListNode GetListNode(ListNode l1, ListNode l2, int carry)
        {
            if (l1 == null && l2 == null && carry == 0) return null;
            int val1 = l1 != null ? l1.val : 0;
            int val2 = l2 != null ? l2.val : 0;
            l1 = l1 != null ? l1.next : null;
            l2 = l2 != null ? l2.next : null;
            int sum = val1 + val2 + carry;
            return new ListNode(sum % 10, GetListNode(l1, l2, sum / 10));
        }

        /// <summary>
        /// 將List轉成指定的Linklist
        /// </summary>
        /// <param name="numList"></param>
        /// <returns></returns>
        private ListNode List2ListNode(List<int> numList)
        {
            if (numList.Count > 0)
            {
                int num = numList.First();
                numList.RemoveAt(0);
                return new ListNode(num, List2ListNode(numList));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 顯示ListNode資料
        /// </summary>
        /// <param name="listNode"></param>
        private void PrintListNode(ListNode listNode)
        {
            Console.Write("[");
            while (listNode != null)
            {
                Console.Write(listNode.val.ToString());
                if (listNode.next != null)
                {
                    Console.Write(", ");
                }
                listNode = listNode.next;
            }
            Console.Write("]");
            Console.WriteLine();
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
    }
}
