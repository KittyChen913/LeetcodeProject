namespace LeetcodeProject;

public class ContainerWithMostWater
{
    /// <summary>
    /// 11. Container With Most Water
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public static int MaxArea(int[] height)
    {
        return 0;
    }

    /// <summary>
    /// 暴力破解的失敗版，雖然可以達成一樣的功能，時間複雜度較高，submit 時會死在 "Time Limit Exceeded"
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public static int MaxArea_BruteForceAttack(int[] height)
    {
        // 最終要提交出去的最大面積
        var finalMaxArea = 0;

        for (int i = 0; i < height.Length; i++) // 第一個迴圈代表每一根
        {
            for (int j = i + 1; j < height.Length; j++) // 第二個迴圈代表跟 i 後面的每一根去比對
            {
                var area = 0;

                // 判斷誰比較短，來決定要使用誰的高度來相乘
                if (height[j] >= height[i])
                {
                    area = (j - i) * height[i];
                }
                else
                {
                    area = (j - i) * height[j];
                }
                finalMaxArea = Math.Max(finalMaxArea, area); // 每計算一次 area，都會比較是否更大，有就更新最大 area 存放的變數
            }
        }
        return finalMaxArea;
    }
}
