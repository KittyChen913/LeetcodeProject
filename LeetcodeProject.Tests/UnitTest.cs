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

    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(120, 21)]
    [TestCase(1534236469, 0)]
    [TestCase(-2147483648, 0)]
    public void Reverse_Success(int x, int expected)
    {
        var result = ReverseInteger.Reverse(x);
        Assert.AreEqual(result, expected);
    }

    [TestCase("42", 42)]
    [TestCase("   -42", -42)]
    [TestCase("4193 with words", 4193)]
    [TestCase("2147483648  over max value ", 2147483647)]
    [TestCase("words and 987", 0)]
    [TestCase("+-12", 0)]
    [TestCase("00000-42a1234", 0)]
    [TestCase("20000000000000000000", 2147483647)]
    [TestCase("-abc", 0)]
    [TestCase("-5-", -5)]
    public void MyAtoi_Success(string s, int expected)
    {
        var result = StringToInteger.MyAtoi(s);
        Assert.AreEqual(result, expected);
    }

    [TestCase(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [TestCase(new int[] { 1, 1 }, 1)]
    public void MaxArea_Success(int[] height, int expected)
    {
        var result = ContainerWithMostWater.MaxArea(height);
        Assert.AreEqual(result, expected);
    }

    [TestCase(new int[] { 2, 3, 1, 1, 4 }, true)]
    [TestCase(new int[] { 3, 2, 1, 0, 4 }, false)]
    [TestCase(new int[] { 1 }, true)]
    [TestCase(new int[] { 2, 0 }, true)]
    [TestCase(new int[] { 2, 5, 0, 0 }, true)]
    [TestCase(new int[] { 8, 2, 4, 4, 4, 9, 5, 2, 5, 8, 8, 0, 8, 6, 9, 1, 1, 6, 3, 5, 1, 2, 6, 6, 0, 4, 8, 6, 0, 3, 2, 8, 7, 6, 5, 1, 7, 0, 3, 4, 8, 3, 5, 9, 0, 4, 0, 1, 0, 5, 9, 2, 0, 7, 0, 2, 1, 0, 8, 2, 5, 1, 2, 3, 9, 7, 4, 7, 0, 0, 1, 8, 5, 6, 7, 5, 1, 9, 9, 3, 5, 0, 7, 5 }, true)]
    [TestCase(new int[] { 0, 2, 3 }, false)]
    [TestCase(new int[] { 1, 0, 1, 0 }, false)]
    public void CanJump_Success(int[] nums, bool expected)
    {
        var result = JumpGame.CanJump(nums);
        Assert.AreEqual(result, expected);
    }

    [TestCase("III", 3)]
    [TestCase("LVIII", 58)]
    [TestCase("MCMXCIV", 1994)]
    public void RomanToInt_Success(string s, int expected)
    {
        var result = RomantoInteger.RomanToInt(s);
        Assert.AreEqual(result, expected);
    }

    [TestCase(new string[] { "flower", "flow", "flight" }, "fl")]
    public void LongestCommonPrefix_Success(string[] strs, string expected)
    {
        var result = LongestCommonPrefix.Longest_Common_Prefix(strs);
        Assert.AreEqual(result, expected);
    }
}