using System.Text;

namespace LeetcodeProject;

public class StringToInteger
{
    /// <summary>
    /// 8. String to Integer (atoi)
    /// 要處理正負號、overflow、空格、判定是否為數字
    /// string 一定要是數值起始，要是 string 是從字元起始的話，就 return 0 了（即使後面有數值也不管了）
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int MyAtoi(string s)
    {
        string sTrim = s.Trim();
        StringBuilder result = new StringBuilder();
        bool character = false;

        foreach (char sChar in sTrim)
        {
            if (sChar.Equals('-') || sChar.Equals('+'))
            {
                // 判定一些不合理的狀態：
                // 1. 如果 + - 符號出現第二次，就代表第二個不應該加進 result 的 string 了
                // 2. 如果 string 只有 + - 符號 (Length = 1)
                // 3. 如果有出現 + - 符號，卻不是放在前面
                if (character || sTrim.Length == 1 || (!sTrim[0].Equals('-') && !sTrim[0].Equals('+')))
                {
                    // 跳出迴圈不再繼續往下判定
                    break;
                }

                result.Append(sChar);
                character = true; // 第一次找到 + - 符號就設為 true
                continue;
            }
            if (!int.TryParse(sChar.ToString(), out _))
            {
                // 如果此字元不是 + - 符號，也不是數字，就出去
                break;
            }

            // 是數值，加進 result 用的 string
            result.Append(sChar);

            // 為了避免最後 result 出來的結果 overflow 太多，每加一次就檢查一次大小有沒有超過
            if (long.Parse(result.ToString()) < int.MinValue) return int.MinValue;
            if (long.Parse(result.ToString()) > int.MaxValue) return int.MaxValue;
        }

        // 如果最後 result 的 string 是空的，就代表沒有任何數值，回傳 0
        if (string.IsNullOrEmpty(result.ToString())) return 0;

        // 如果只有 + - 符號，後面沒有數值，這裡 tryParse 可以被過濾掉，轉換失敗都會回傳 0
        return int.TryParse(result.ToString(), out int finalNumber) ? finalNumber : 0;
    }
}
