using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Q8
    {
        public void Test()
        {
            Console.WriteLine(MyAtoi("-42"));
            Console.WriteLine(MyAtoi("   -42"));
            Console.WriteLine(MyAtoi("4193 with words"));
            Console.WriteLine(MyAtoi("-91283472332"));
            Console.WriteLine(MyAtoi("21474836460"));
        }

        public int MyAtoi(string s)
        {
            // 先去空白
            s = s.Trim();
            // 防呆
            if (s.Length == 0 )
            {
                return 0;
            }
            // 判斷正負
            int signValue = 1;
            if (s[0] == '-')
            {
                signValue = -1;
                s = s.Remove(0, 1);
            }
            else if (s[0] == '+')
            {
                s = s.Remove(0, 1);
            }
            // 最終結果
            int result = 0;
            while (s.Length != 0)
            {
                // 若遇到非數值則結束
                if (s[0] < '0' || s[0] > '9')
                {
                    break;
                }
                // 轉換成數值
                int digitValue = s[0] - '0';
                // 開始計算(需檢查溢位)
                try
                {
                    result = checked(result * 10 + digitValue);
                }
                catch (OverflowException)
                {
                    // 正值回傳2^31-1；副值回傳-2^31
                    return signValue > 0 ? int.MaxValue : int.MinValue;
                }
                // 移除目前處理的值
                s = s.Remove(0, 1);
            }
            // 結果 * 正負號
            return result * signValue;
        }
    }
}
