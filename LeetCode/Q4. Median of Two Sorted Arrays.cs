using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Q4
    {
        public void Test()
        {
            int[] num1;
            int[] num2;
            num1 = new int[] { 1, 3 };
            num2 = new int[] { 2 };
            Console.WriteLine(FindMedianSortedArrays(num1, num2).ToString());
            num1 = new int[] { 1, 2 };
            num2 = new int[] { 3, 4 };
            Console.WriteLine(FindMedianSortedArrays(num1, num2).ToString());
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // ----------------- 處理例外狀況 -----------------
            // 若其中一個沒有值，就複製有值的資料給另一個沒有值的，這樣中位數理論上是一樣的
            if (nums1.Length == 0) nums1 = nums2;
            if (nums2.Length == 0) nums2 = nums1;
            // ----------------------------------------------
            int nums1Len = nums1.Length;
            int nums2Len = nums2.Length;
            // 預期兩陣列合併的中位數的位置，左邊有幾個值
            int leftCountOfMedian = (nums1Len + nums2Len + 1) / 2 - 1;
            // 若nums1與num2合併，中位數左邊的值，有nums1LeftCountOfMedian~nums1RightCountOfMedian個是來自num1，主要是用來收斂至精準的拿幾個值
            int nums1LeftCountOfMedian = 0;
            // 若nums1與num2合併，中位數左邊的值，有nums1LeftCountOfMedian~nums1RightCountOfMedian個是來自num1，主要是用來收斂至精準的拿幾個值
            int nums1RightCountOfMedian = nums1Len;
            while (nums1LeftCountOfMedian < nums1RightCountOfMedian)
            {
                if (nums1[nums1LeftCountOfMedian] <= nums2[Math.Min(leftCountOfMedian - nums1LeftCountOfMedian, nums2Len - 1)])
                {
                    nums1LeftCountOfMedian++;
                }
                else
                {
                    nums1RightCountOfMedian--;
                }
            }

            // 合併後數量為奇數：中位數為唯一值
            if ((nums1Len + nums2Len) % 2 != 0)
            {
                /* 已知中位數左邊的值分別從num1取left個、num2取leftCountOfMedian-left個 */
                // 從nums1拿走left個當做合併後中位數左邊的值，因此中位數"可能"是第left+1個值(index為left)
                int nums1MedianCandidate = nums1LeftCountOfMedian < nums1Len ? nums1[nums1LeftCountOfMedian] : int.MaxValue;
                // 從num2拿走leftCountOfMedian - left個當做合併後中位數左邊的值，因此中位數可能是第leftCountOfMedian-nums1LeftCountOfMedian+1個值(index為leftCountOfMedian-nums1LeftCountOfMedian)
                int nums2MedianCandidate = leftCountOfMedian - nums1LeftCountOfMedian < nums2Len ? nums2[leftCountOfMedian - nums1LeftCountOfMedian] : int.MaxValue;
                // 找出最小值作為中位數，所以此處使用Math.Min
                return Math.Min(nums1MedianCandidate, nums2MedianCandidate);
            }
            // 合併後數量為奇數：中位數為中間兩位平均值
            else
            {
                List<int> Candiate = new List<int>();
                nums1LeftCountOfMedian = nums1LeftCountOfMedian - 1;
                // 從num1取值，最少取0個，最多取2個
                for (int i = nums1LeftCountOfMedian, j = 0; i < nums1Len && j < 2; i++, j++)
                {
                    Candiate.Add(nums1[i]);
                }
                // 從num2取值，理論上取2個值即可
                for (int i = leftCountOfMedian - nums1LeftCountOfMedian, j = 0; i < nums2Len && j < 2; i++, j++)
                {
                    Candiate.Add(nums2[i]);
                }
                // 開始處理可能是中位數的值，Candiate最少有2個值，最多有4個值
                Candiate.Sort(Comparer<int>.Default);   // 由小到大排序
                return (Candiate[0] + Candiate[1]) / 2.0;
            }
        }
    }
}
