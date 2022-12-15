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

    [Test]
    public void AddTwoNumbers_Success()
    {
        ListNode l1_1 = new ListNode(2);
        ListNode l1_2 = new ListNode(4);
        l1_1.next = l1_2;
        ListNode l1_3 = new ListNode(3);
        l1_2.next = l1_3;

        ListNode l2_1 = new ListNode(5);
        ListNode l2_2 = new ListNode(6);
        l2_1.next = l2_2;
        ListNode l2_3 = new ListNode(4);
        l2_2.next = l2_3;

        var result = AddTwoNumbers.Get_AddTwoNumbers(l1_1, l2_1);

        ListNode result_1 = new ListNode(7);
        ListNode result_2 = new ListNode(0);
        result_1.next = result_2;
        ListNode result_3 = new ListNode(8);
        result_2.next = result_3;

        Assert.AreEqual(result, result_1);
    }

    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    [TestCase(" ", 1)]
    [TestCase("dvdf", 3)]
    public void LengthOfLongestSubstring_Success(string s, int expected)
    {
        var result = LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring(s);
        Assert.AreEqual(result, expected);
    }

    [TestCase("babad", "bab")]
    [TestCase("cbbd", "bb")]
    [TestCase("racecar", "racecar")]
    [TestCase("aacabdkacaa", "aca")]
    public void LongestPalindrome_Success(string s, string expected)
    {
        var result = LongestPalindromicSubstring.LongestPalindrome(s);
        Assert.AreEqual(result, expected);
    }
}