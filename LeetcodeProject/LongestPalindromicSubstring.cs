namespace LeetcodeProject;

public class LongestPalindromicSubstring
{
    /// <summary>
    /// 5. Longest Palindromic Substring
    /// substring
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string LongestPalindrome(string s)
    {
        var longest = string.Empty;

        return longest;
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
