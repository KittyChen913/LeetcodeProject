namespace LeetcodeProject;

public class RomantoInteger
{
    static readonly Dictionary<string, int> romanMap = new() {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 }};

    /// <summary>
    /// 13. Roman to Integer
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int RomanToInt(string s)
    {
        int finalInt = 0, index = 0;

        while (index < s.Length)
        {
            int indexValue = romanMap[s[index].ToString()];

            // 如果是第一個 string, 就不用比對, 先直接換算成 int 就好
            if (index == 0)
            {
                finalInt += indexValue;
                index++;
                continue;
            }

            int foreIndexValue = romanMap[s[index - 1].ToString()];

            // 第二個之後的 string , 都要跟前一個 string 比對, 如果 int 比前面大, 就代表他需要做減法
            if (foreIndexValue < indexValue)
            {
                finalInt += indexValue - foreIndexValue * 2;

                // 假設第一個 string 轉成 1, 第二個 string 轉成 5
                // 走到第一個 string 時 finalInt + 1 = 1
                // 走到第二個 string 時發現需要減去, 所以要做 finalInt + 5 並減去第一個 string 的 1
                // 但是由於前面已經做過一次 +1 了, 所以需要減兩次 1 (foreIndexValue *2 的用意)
            }
            else
            {
                // 沒有需要減法的部分就繼續加就好了
                finalInt += indexValue;
            }
            index++;
        }
        return finalInt;
    }
}
