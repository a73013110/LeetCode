using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Q3
    {
        public void Test()
        {
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb").ToString());
            Console.WriteLine(LengthOfLongestSubstring("bbbbb").ToString());
            Console.WriteLine(LengthOfLongestSubstring("pwwkew").ToString());
        }

        public int LengthOfLongestSubstring(string s)
        {
            int sLen = s.Length;
            int maxLen = 0;  // 最大子字串長度
            int start = 0, end = 0; // 子字串起始結束位置
            HashSet<char> walkForwardSet = new HashSet<char>();    // 紀錄目前窗格內的字母
            /*想像有個小窗格框住字串中的子字串，透過起始、結束位置控制窗格大小*/
            while (start < sLen && end < sLen)
            {
                if (!walkForwardSet.Contains(s[end]))
                {
                    walkForwardSet.Add(s[end]);
                    maxLen = Math.Max(maxLen, end - start + 1);
                    end++;
                }
                else
                {
                    walkForwardSet.Remove(s[start]);
                    start++;
                }
            }
            return maxLen;
        }
    }
}
