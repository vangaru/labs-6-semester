using System;
using Lab5;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class UtilsTests
{
    [Test]
    [TestCase("abc", 3, "abcabcabc")]
    [TestCase("aa", 1, "aa")]
    [TestCase("a", 0, "")]
    public void Repeat_NoSeparator_CorrectResult(string pattern, int repeatsCount, string expectedResult)
    {
        Assert.AreEqual(StringUtils.Repeat(pattern, repeatsCount), expectedResult);
    }

    [Test]
    public void Repeat_NoSeparator_RepeatsLessThanZero_ThrowsException()
    {
        var str = "abc";
        int repeatsCount = -3;
        Assert.Throws<ArgumentOutOfRangeException>(() => StringUtils.Repeat(str, repeatsCount));
    }

    [Test]
    [TestCase("abcdef", "abc", "abc")]
    [TestCase("abcccdef", "abc", "abccc")]
    [TestCase("abcdef", "lll", "")]
    public void Keep_Success(string str, string pattern, string expectedResult)
    {
        Assert.AreEqual(StringUtils.Keep(str, pattern), expectedResult);
    }

    [Test]
    [TestCase("abcdef", "abc", "def")]
    [TestCase("abcccdef", "abc", "def")]
    [TestCase("abcdef", "lll", "abcdef")]
    public void Loose_Success(string str, string pattern, string expectedResult)
    {
        Assert.AreEqual(StringUtils.Loose(str, pattern), expectedResult);
    }

    [Test]
    [TestCase("abcdef", "abckpr", 3)]
    [TestCase("abc", "abc", -1)]
    [TestCase("abc", "def", 0)]
    public void IndexOfDifference_IndexCorrect(string str1, string str2, int expectedIndex)
    {
        Assert.AreEqual(StringUtils.IndexOfDifference(str1, str2), expectedIndex);
    }

    [Test]
    [TestCase("abcdef", "kkcdkk", "cd")]
    [TestCase("abcdef", "", "")]
    [TestCase("aaaa", "aabb", "aa")]
    [TestCase("bbbb", "aabb", "bb")]
    public void Common_ReturnValueCorrect(string str1, string str2, string expected)
    {
        Assert.AreEqual(StringUtils.Common(str1, str2), expected);
    }

    [Test]
    [TestCase("[abcdef]", "[", "]", "abcdef")]
    [TestCase("[abcdef]", "[a", "d", "bc")]
    [TestCase("[abcdef]", "x", "y", "")]
    public void SubstringBetween_ReturnValueCorrect(string str, string open, string close, string expected)
    {
        Assert.AreEqual(StringUtils.SubstringBetween(str, open, close), expected);
    }

    [Test]
    [TestCase("abcdef", "vvvdef", 3)]
    [TestCase("abcdef", "", 6)]
    [TestCase("vvvvvv", "abc", 6)]
    [TestCase("vvvvv", "vvvvv", 0)]
    public void LevenshteinDistance_ReturnValueCorrect(string str1, string str2, int expectedDistance)
    {
        Assert.AreEqual(StringUtils.LevenshteinDistance(str1, str2), expectedDistance);
    }

    [Test]
    [TestCase("abcdef", "abcdef", 0)]
    [TestCase("abcdef", "abcxxx", 3)]
    public void HamingDistance_ReturnValueCorrect(string str1, string str2, int expectedDistance)
    {
        Assert.AreEqual(StringUtils.HamingDistance(str1, str2), expectedDistance);
    }

    [Test]
    public void HamingDistance_StringLengthNotEqual_ThrowsException()
    {
        var str1 = "aaa";
        var str2 = "aaaa";

        Assert.Throws<ArgumentException>(() => StringUtils.HamingDistance(str1, str2));
    }

    [Test]
    public void Sum_SumCorrect()
    {
        long val1 = 3;
        long val2 = 5;
        long val3 = -6;
        Assert.AreEqual(SumUtil.GetSum(val1, val2, val3), val1 + val2 + val3);
    }
}