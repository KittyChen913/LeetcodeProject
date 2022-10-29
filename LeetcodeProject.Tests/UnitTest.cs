namespace LeetcodeProject.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 0 })]
    [TestCase(new int[] { 3, 2, 4 }, 6, new int[] { 2, 1 })]
    [TestCase(new int[] { 3, 3 }, 6, new int[] { 1, 0 })]
    [TestCase(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new int[] { 11, 5 })]
    public void TwoSum_Success(int[] nums, int target, int[] expected)
    {
        var result = TwoSum.Get_TwoSum(nums, target);
        Assert.AreEqual(result, expected);
    }
}