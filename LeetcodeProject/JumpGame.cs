namespace LeetcodeProject
{
    public class JumpGame
    {
        /// <summary>
        /// 55. Jump Game
        /// 遞迴，不斷回頭重 try 嘗試其他可能性
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="startIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        public static bool CanJump(int[] nums, int startIndex = 0, int maxIndex = 0)
        {
            // startIndex 是用於紀錄每次重跑的項目位置
            // jumpIndex 為目前跳到哪一個項目
            // maxIndex 是紀錄最長的紀錄是跑到哪一個項目位置，用於在下面判定為 0 的項目是否已經是最後的項目了

            int jumpIndex = startIndex;

            // 如果只有 1 個項目，就直接 return 了
            if (nums.Length == 1) return true;

            while (jumpIndex < nums.Length - 1)
            {
                // 無法再繼續走下去了的條件
                if (nums[jumpIndex].Equals(0) && jumpIndex == startIndex && jumpIndex >= maxIndex)
                    return false;

                // 如果停在 0 的項目，並且不是最後 1 個項目
                // 要將這個原本為 false 的結果，遞迴回去繼續做其他可能的嘗試
                if (nums[jumpIndex].Equals(0) && jumpIndex != nums.Length - 1)
                {
                    // 如果起始的 Index 大於 1，代表他還有可以減少步數的空間
                    // ex: startIndex = 7，只是代表他最多可以走 7 步，但是他也可以走 5 步就好，或 4 步 或 3 步 以此類推.....
                    if (nums[startIndex] > 1)
                    {
                        nums[startIndex] = nums[startIndex] - 1; // 所以逐一遞減它往前走的步數
                    }
                    else
                    {
                        startIndex++;
                    }
                    maxIndex = Math.Max(maxIndex, jumpIndex);
                    return CanJump(nums, startIndex, maxIndex);
                }

                // 為了怕超出邊界，最多就 length -1 
                jumpIndex = (jumpIndex + nums[jumpIndex] > nums.Length - 1) ? nums.Length - 1 : jumpIndex + nums[jumpIndex];
            }

            // 如果索引並不是停在最後一個項目，就回傳 false，反之如果他成功走到最後一個項目，就回傳 true
            return (!jumpIndex.Equals(nums.Length - 1)) ? false : true;
        }
    }
}
