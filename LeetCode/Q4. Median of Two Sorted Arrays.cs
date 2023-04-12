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
            num1 = new int[] { 1, 3 };
            num2 = new int[] { 2, 7 };
            Console.WriteLine(FindMedianSortedArrays(num1, num2).ToString());
            num1 = new int[] { 0, 0, 0, 0, 0 };
            num2 = new int[] { -1, 0, 0, 0, 0, 0, 1 };
            Console.WriteLine(FindMedianSortedArrays(num1, num2).ToString());
        }

        /**
         * 假設L及R分別為第幾個值為左中位數及右中位數
         * e.g. [2 3 5]，此範例的L=1；R=1
         * e.g. [2 3 5 7]，此範例的L=1；R=2
         */
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int N1 = nums1.Length;
            int N2 = nums2.Length;
            /* 確保第一個Array數量較少
             * 1.預設會從num1取0個值，從nums2拿取左中位數所需要的數量，若此時num1的數量很多，num2的數量很少，使的num1+num2的中位數數量>num2數量，這樣肯定會出現num2 index溢出的問題
             * 2.這樣binary search次數也會減少
             */
            if (N1 > N2) return FindMedianSortedArrays(nums2, nums1);

            int k = (N1 + N2 + 1) / 2;  // 假設num1與num2合併後的左中位數(第k個數)
            int L = 0;  // 左中位數(第L個數)，1個陣列中的左中位數不可能為0，但若在此議題是透過2個陣列合併，可能就表示該陣列不包含左中位數
            int R = N1; // 右中位數(第R個數)
            while (L < R)
            {
                // 左中位數以左(包含)的數值個數[L] + (右中位數以左(包含)的數值個數[R] - 左中位數以左(包含)的數值個數[L]) / 2 => 除以2的用意：取一半L~R之間的數值
                int m1 = L + (R - L) / 2;   // 從num1拿m1個元素
                int m2 = k - m1; // 從num2拿m2個元素
                // 若num1中沒被取出的最小值<num2取出的最大值，表示num1取少了，多取1個
                if (nums1[m1] < nums2[m2-1])
                {
                    L = m1 + 1;
                }
                // 若num1中沒被取出的最小值>=num2取出的最大值，可能是num1取多了，將右中位數設定為本次取的個數
                else
                {
                    R = m1;
                }
            }
            // 先計算分別從num1、num2拿取值的數量
            int M1 = L;
            int M2 = k - M1;
            // 取得左中位數，若同時分別來自num1、num2，則取最大值。若沒有從num1取值，則給定MinValue，透過Max function取num2的值；反之亦然
            int C1 = Math.Max((M1 == 0 ? int.MinValue : nums1[M1 - 1]), (M2 == 0 ? int.MinValue : nums2[M2 - 1]));
            // 若num1、num2合併為奇數個值，中位數為唯一值
            if ((N1 + N2) % 2 == 1) return C1;
            // 若num1、num2合併為偶數個值
            else
            {
                // 取得右中位數，若同時分別來自num1、num2，則取最小值。若從num1取全部的值，則給定MaxValue，透過Max function取num2的值；反之亦然
                int C2 = Math.Min((M1 == N1 ? int.MaxValue : nums1[M1]), (M2 == N2 ? int.MaxValue : nums2[M2]));
                return (C1 + C2) / 2.0;
            }
        }
    }
}
