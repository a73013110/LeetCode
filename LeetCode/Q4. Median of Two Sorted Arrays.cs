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
            int[] num1 = { 1, 3 };
            int[] num2 = { 2 };
            Console.WriteLine(FindMedianSortedArrays(num1, num2).ToString());
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int nums1Len = nums1.Length;
            int nums2Len = nums2.Length;
            int expectedMedian = (nums1Len + nums2Len + 1) / 2; // 預期兩陣列合併的中位數的位置(第幾幾個數)
            int left = 0;   // 若nums1與num2合併，中位數左邊的值，有left~right個是來自num1，主要是用來收斂至精準的拿幾個值
            int right = nums1Len;   // 若nums1與num2合併，中位數左邊的值，有left~right個是來自num1，主要是用來收斂至精準的拿幾個值
            while (left < right)
            {
                if (nums1[left] <= nums2[expectedMedian - 1 - left])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return 0.0;
        }
    }
}
