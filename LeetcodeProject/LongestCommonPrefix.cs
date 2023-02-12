namespace LeetcodeProject;

public class LongestCommonPrefix
{
    /// <summary>
    /// 14. Longest Common Prefix
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public static string Longest_Common_Prefix(string[] strs)
    {
        // 最後要 return 的最長字首結果
        string longestPrefix = string.Empty;

        // 先過濾掉特殊狀況
        // 如果是 array 中所有 string 長度都為 0 的 empty string 就直接 return
        if (strs.All(str => str.Length == 0))
            return strs[0];

        for (int i = 0; i < strs[0].Length; i++) // 逐個字母跑的迴圈，直接拿 array 第一個 string 的長度來做判定
        {
            // 從第一個 string 的字首開始往下判定
            var prefix = strs[0][i].ToString();

            for (int str = 0; str < strs.Length; str++) // strs array 逐個 string 項目的迴圈
            {
                // 判定此 string 項目是否有大於第一個 string 的長度
                // 或者
                // 判定第 i 個字首是否與第一個 string 的字首相同
                // 以上條件擇一沒符合都代表無法再繼續了, 直接 return 結果
                if (strs[str].Length <= i || !strs[str][i].ToString().Equals(prefix))
                {
                    return longestPrefix;
                }
            }
            // 如果 array 中每個 string 的字首都符合, 就加進儲存最後結果的字串變數中
            longestPrefix += prefix;
        }
        return longestPrefix;
    }
}
