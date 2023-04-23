using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Q7
    {
        public void Test()
        {
            Console.WriteLine(Reverse(123));
            Console.WriteLine(Reverse(-123));
            Console.WriteLine(Reverse(120));
        }

        public int Reverse(int x)
        {
            // 紀錄最終結果
            int reverseX = 0;
            // 當x非0就持續處理
            while (x != 0)
            {
                int mod = x % 10;   // 取餘數
                x = x / 10; // 移除剛才取出的餘數
                // try catch抓取溢位例外狀況
                try
                {
                    reverseX = checked(reverseX * 10 + mod);
                }
                catch (OverflowException e)
                {
                    return 0;
                }
            }

            return reverseX;
        }
    }
}
