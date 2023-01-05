namespace LeetcodeProject
{
    public class JumpGame
    {
        /// <summary>
        /// 55. Jump Game
        /// 線性版，逐一往前判定的寫法，處理速度較快
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJump(int[] nums)
        {
            // 如果只有 1 個項目，就直接 return 了
            if (nums.Length == 1) return true;

            // 從後面開始依序往前判定
            // 先以最後一個項目的 Index 開始
            var lastIndex = nums.Length - 1;

            // 之所以 i = lastIndex - 1 是因為迴圈直接從倒數第二個 Index 開始跟 lastIndex 比較
            for (int i = lastIndex - 1; i >= 0; i--)
            {
                // i = 當前 Index
                // nums[i] = 可以跳的 Index 步數
                // 判定 (當前 Index) + (可以跳的 Index 步數) 加起來可以走的到 last 的 Index
                if (i + nums[i] >= lastIndex)
                {
                    lastIndex = i;
                    // 就把 last 的 Index 更新為當前 Index，繼續往前判定
                }
                // 如果 (當前 Index) + (可以跳的 Index 步數) 加起來 "走不到" last 的 Index，就不更新 lastIndex，繼續往前找其他 Index 有沒有人可以走到 last 的 Index
            }

            // ex: 第 3 個如果可以走到 第 4 個，那就再往前判定，第 2 個能否走到第 3 個

            // 如果可以一路判定到最前面(index = 0)，就代表可以一路跳完 return true，反之則 false
            return lastIndex == 0;
        }

        /// <summary>
        /// 55. Jump Game
        /// 遞迴，不斷回頭重 try 嘗試其他可能性
        /// 但是迴圈版的時間複雜度較高，處理速度慢
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="startIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        public static bool CanJump_Recursion(int[] nums, int startIndex = 0, int maxIndex = 0)
        {
            // startIndex 是用於紀錄每次重跑的項目位置
            // jumpIndex 為目前跳到哪一個項目
            // maxIndex 是紀錄最長的紀錄是跑到哪一個項目位置，用於在下面判定為 0 的項目是否已經是最後的項目了
            // lastIndex 是最後一個項目的索引

            int jumpIndex = startIndex;
            int lastIndex = nums.Length - 1;

            // 如果只有 1 個項目，就直接 return 了
            if (nums.Length == 1) return true;

            // 還沒走到最後一個項目的索引，就會繼續處理
            while (jumpIndex < lastIndex)
            {
                // 如果停在 0 的項目
                if (nums[jumpIndex] == 0)
                {
                    // 無法再繼續走下去了的條件
                    if (jumpIndex == startIndex && jumpIndex >= maxIndex)
                        return false;

                    // 並且不是最後 1 個項目
                    // 要將這個原本為 false 的結果，遞迴回去繼續做其他可能的嘗試
                    if (jumpIndex != lastIndex)
                    {
                        // 如果起始的 Index 大於 1，代表他還有可以減少步數的空間
                        // ex: startIndex = 7，只是代表他最多可以走 7 步，但是他也可以走 5 步就好，或 4 步 或 3 步 以此類推.....
                        if (nums[startIndex] > 1)
                        {
                            nums[startIndex] = nums[startIndex] - 1; // 所以逐一遞減它往前走的步數
                        }
                        else
                        {
                            // 如果不能再減了，就代表這個項目能走的步數都嘗試完了，就繼續 try 下一個項目
                            startIndex++;
                        }
                        maxIndex = Math.Max(maxIndex, jumpIndex);
                        return CanJump_Recursion(nums, startIndex, maxIndex);
                    }
                }
                jumpIndex += nums[jumpIndex];
            }

            // 如果索引並不是停在最後一個項目，就回傳 false，反之如果他成功走到最後一個項目(或是超過)，就回傳 true
            return jumpIndex >= lastIndex;
        }
    }
}
