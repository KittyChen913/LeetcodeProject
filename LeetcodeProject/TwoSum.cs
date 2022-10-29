public class TwoSum
{
    /// <summary>
    /// lettcode #1 Two Sum
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int[] Get_TwoSum(int[] nums, int target)
    {
        List<int> numList = nums.ToList();
        Dictionary<int, int> numDictionary = new Dictionary<int, int> { };
        int[] result = new int[2];

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > target) continue;

            int balance = target - nums[i];

            // 改用 Dictionary 減少一個 for 迴圈
            if (numDictionary.ContainsKey(balance))
            {
                result[0] = i;
                result[1] = numDictionary[balance];
                break;
            }

            numDictionary.TryAdd(nums[i], i);
        }

        // old 寫法
        //for (int i = 0; i < nums.Length - 1; i++)
        //{
        //    for (int j = i + 1; j < nums.Length; j++)
        //    {
        //        if (nums[i] + nums[j] == target)
        //        {
        //            result[0] = i;
        //            result[1] = j;
        //        }
        //    }
        //}
        return result;
    }
}