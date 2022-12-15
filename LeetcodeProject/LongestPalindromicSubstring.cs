namespace LeetcodeProject;

public class LongestPalindromicSubstring
{
    /// <summary>
    /// 5. Longest Palindromic Substring
    /// 改成由中間往外擴展的判定方式，可以減少一半的判定次數
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string LongestPalindrome(string s)
    {
        int start = 0, end = 0; // 存放最終回文長度的起迄位置

        for (int i = 0; i < s.Length; i++)
        {
            // 這裡有 2 種情況需要處理
            // 1. 中間有一個 不重複 的字符 (ex: a b c b a)
            // 2. 中間沒有字符，每個字符都有辦法往兩邊擴展配對 (ex: a b b a)
            (int l1, int r1) = expandFromMiddle(i, i, start, end, s);     // 判定 1. 情境
            (int l2, int r2) = expandFromMiddle(i, i + 1, start, end, s); // 判定 2. 情境

            // 選出兩種判定方式中最長的回文，記住他的起迄位置
            if ((r1 - l1) > (r2 - l2))
            {
                start = l1;
                end = r1;
            }
            else
            {
                start = l2;
                end = r2;
            }
        }
        return s.Substring(start, end - start + 1); // 根據最終的回文起訖位置來取 string
    }

    public static (int, int) expandFromMiddle(int originateLeft, int originateRight, int start, int end, string s)
    {
        for (int j = originateRight; j < s.Length; j++)
        {
            if (originateLeft < 0) break; // 如果一旦"起始"的位置超過邊界了，就不再繼續往下做

            if (s[originateLeft] != s[j]) break; // 如果一旦左右兩側的字串不同，就代表不是回文了，也不再繼續往下做

            if ((end - start) < (j - originateLeft)) // 判定更長的回文長度才更新起訖位置
            {
                start = originateLeft;
                end = j;
            }
            originateLeft--;
            // 這裡使用 originateLeft 當作左邊的起始位置，用 j 當作右邊的邊界
            // 只要一旦判定左右兩側的字串相同，就繼續擴大圈選範圍，繼續往下判定
        }
        return (start, end);
    }

    /// <summary>
    /// 暴力破解版，但是時間複雜度較高，submit 時會卡在 "Time Limit Exceeded" Testcase
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string LongestPalindrome_BruteForceAttack(string s)
    {
        var longest = string.Empty; // 用於存放最後的最長回文字串

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 1; j <= s.Length - i; j++)
            {
                // 將各種可能的 string 組合都一個一個拿來判定 string item 反轉後是否也與原 string 相同
                var sSub = s.Substring(i, j);
                var charArray = sSub.ToCharArray();
                Array.Reverse(charArray);
                if (new string(charArray) == sSub)
                {
                    if (longest.Length < sSub.Length) longest = sSub; // 更長的 string 就指定至 longest
                }
            }
        }

        return longest;
    }
}
