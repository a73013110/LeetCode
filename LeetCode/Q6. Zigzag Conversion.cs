using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Q6
    {
        public void Test()
        {
            Console.WriteLine(Convert("PAYPALISHIRING", 3));
            Console.WriteLine(Convert("PAYPALISHIRING", 4));
            Console.WriteLine(Convert("A", 1));
            Console.WriteLine(Convert("AB", 1));
        }

        public string Convert(string s, int numRows)
        {
            // 特殊案例判斷
            if (numRows == 1)
            {
                return s;
            }

            string[] result = new string[numRows];
            // 初始化
            for (int i = 0; i < numRows; i++)
            {
                result[i] = "";
            }
            // 目前準備放到這陣列index
            int currentResultIndex = 0;
            // 陣列index調整參數
            int factor = 1;
            // 遍歷原字串
            for (int i = 0; i < s.Length; i++)
            {
                result[currentResultIndex] += s[i];
                //調整參數。若目前為最後一個index，factor為-1；反之，為第一個index，factor為1
                if (currentResultIndex == numRows - 1)
                {
                    factor = -1;
                }
                else if (currentResultIndex == 0)
                {
                    factor = 1;
                }
                // 調整下一個要輸入的陣列index
                currentResultIndex += factor;
            }
            // 合併字串並回傳
            return string.Join("", result);
        }
    }
}
