using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Q5
    {
        public void Test()
        {
            Console.WriteLine(LongestPalindrome("babad"));
            Console.WriteLine(LongestPalindrome("cbbd"));
            Console.WriteLine(LongestPalindrome("zudfweormatjycujjirzjpyrmaxurectxrtqedmmgergwdvjmjtstdhcihacqnothgttgqfywcpgnuvwglvfiuxteopoyizgehkwuvvkqxbnufkcbodlhdmbqyghkojrgokpwdhtdrwmvdegwycecrgjvuexlguayzcammupgeskrvpthrmwqaqsdcgycdupykppiyhwzwcplivjnnvwhqkkxildtyjltklcokcrgqnnwzzeuqioyahqpuskkpbxhvzvqyhlegmoviogzwuiqahiouhnecjwysmtarjjdjqdrkljawzasriouuiqkcwwqsxifbndjmyprdozhwaoibpqrthpcjphgsfbeqrqqoqiqqdicvybzxhklehzzapbvcyleljawowluqgxxwlrymzojshlwkmzwpixgfjljkmwdtjeabgyrpbqyyykmoaqdambpkyyvukalbrzoyoufjqeftniddsfqnilxlplselqatdgjziphvrbokofvuerpsvqmzakbyzxtxvyanvjpfyvyiivqusfrsufjanmfibgrkwtiuoykiavpbqeyfsuteuxxjiyxvlvgmehycdvxdorpepmsinvmyzeqeiikajopqedyopirmhymozernxzaueljjrhcsofwyddkpnvcvzixdjknikyhzmstvbducjcoyoeoaqruuewclzqqqxzpgykrkygxnmlsrjudoaejxkipkgmcoqtxhelvsizgdwdyjwuumazxfstoaxeqqxoqezakdqjwpkrbldpcbbxexquqrznavcrprnydufsidakvrpuzgfisdxreldbqfizngtrilnbqboxwmwienlkmmiuifrvytukcqcpeqdwwucymgvyrektsnfijdcdoawbcwkkjkqwzffnuqituihjaklvthulmcjrhqcyzvekzqlxgddjoir"));
        }

        private int startIndex = 0;
        private int maxLength = 0;

        public string LongestPalindrome(string s)
        {
            // 初始化
            startIndex = 0;
            maxLength = 0;

            // 簡易狀況處理
            if (s.Length < 2)
            {
                return s;
            }

            // 遍歷一遍字串，要區分對稱字串長度為奇數、偶數的狀況
            for (int i = 0; i < s.Length; i++)
            {
                extendPalindrome(s, i, i);  // 預期對稱字串長度為奇數
                extendPalindrome(s, i, i+1);  // 預期對稱字串長度為偶數
            }

            return s.Substring(startIndex, maxLength);
        }

        private void extendPalindrome(string s, int left, int right)
        {
            // 從該字元往左右兩邊找，若都相同就繼續往下，直到左右兩邊不同值
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            // 先將上方最後多處理1次的值還原
            left++; right--;
            // 計算本次長度
            int length = right - left + 1;
            if (length > maxLength)
            {
                maxLength = length;
                startIndex = left;
            }
        }
    }
}
