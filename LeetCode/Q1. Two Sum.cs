using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Q1
    {
        public void Test()
        {
            int[] Result = TwoSum(new int[]{ 2, 7, 11, 15 }, 9);
            Console.WriteLine("[{0}]", string.Join(", ", Result));
            Result = TwoSum(new int[] { 3, 2, 4 }, 6);
            Console.WriteLine("[{0}]", string.Join(", ", Result));
            Result = TwoSum(new int[] { 3, 3 }, 6);
            Console.WriteLine("[{0}]", string.Join(", ", Result));
        }

        public int[] TwoSum(int[] nums, int target)
        {
            // 看過的數值清單
            Dictionary<int, int> hasSeen = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int _target = target - nums[i]; // 要從看過的數值中找出的目標
                // 若數值有看過，回傳該數值index及當下index
                if (hasSeen.ContainsKey(_target))
                {
                    return new int[] { hasSeen[_target], i };
                }
                // 若沒看過，將其加入看過的清單
                else
                {
                    hasSeen[nums[i]] = i;
                }
            }

            return new int[0];  // 若無解，回傳空值
        }
    }
}
