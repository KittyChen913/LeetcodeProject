namespace LeetcodeProject;

public class LongestSubstringWithoutRepeatingCharacters
{
    /// <summary>
    /// 3. Longest Substring Without Repeating Characters
    /// 滑動窗口
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int LengthOfLongestSubstring(string s)
    {
        HashSet<char> result = new HashSet<char>();
        int resultCount = 0; // 最大的長度
        int startIndex = 0; // 滑動窗口的起始點
        var stringArray = s.ToCharArray();

        for (int i = 0; i < stringArray.Length; i++)
        {
            if (!result.Contains(stringArray[i]))
            {
                // 如果沒有重複就一直 add 窗口內的值
                result.Add(stringArray[i]);
                resultCount = Math.Max(result.Count, resultCount); // 每 Add 一次就更新一下 resultCount，隨時 update 目前最大的長度
            }
            else
            {
                // 一但有重複，就移動窗口往後移「一格」
                result.Remove(stringArray[startIndex]);
                startIndex++;
                i--;
            }
        }

        return resultCount;
    }
}
