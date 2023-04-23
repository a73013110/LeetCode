using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Q9
    {
        public void Test()
        {
            Console.WriteLine(IsPalindrome(121));
            Console.WriteLine(IsPalindrome(-121));
            Console.WriteLine(IsPalindrome(10));
        }

        public bool IsPalindrome(int x)
        {
            // 特殊情況處理，因有負號所以不可能為Palindrome
            if (x < 0)
            {
                return false;
            }
            // 紀錄原始X值
            int originalX = x;
            // 紀錄反轉後的值
            int reverseX = 0;
            while (x != 0)
            {
                int mod = x % 10;
                x = x / 10;
                reverseX = reverseX * 10 + mod;
            }
            
            return originalX == reverseX;
        }
    }
}
