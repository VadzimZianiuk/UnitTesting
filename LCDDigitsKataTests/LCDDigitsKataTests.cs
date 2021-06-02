using System.Collections.Generic;
using LCDDigitsKata;
using NUnit.Framework;

namespace LCDDigitsKataTests
{
    public class Tests
    {
        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(0, "._." +
                                                 "|.|" +
                                                 "|_|");
                yield return new TestCaseData(1, "..." +
                                                 "..|" +
                                                 "..|");
                yield return new TestCaseData(2, "._." +
                                                 "._|" +
                                                 "|_.");
                yield return new TestCaseData(3, "._." +
                                                 "._|" +
                                                 "._|");
                yield return new TestCaseData(4, "..." +
                                                 "|_|" +
                                                 "..|");
                yield return new TestCaseData(5, "._." +
                                                 "|_." +
                                                 "._|");
                yield return new TestCaseData(6, "._." +
                                                 "|_." +
                                                 "|_|");
                yield return new TestCaseData(7, "._." +
                                                 "..|" +
                                                 "..|");
                yield return new TestCaseData(8, "._." +
                                                 "|_|" +
                                                 "|_|");
                yield return new TestCaseData(9, "._." +
                                                 "|_|" +
                                                 "..|");
                yield return new TestCaseData(-1, "    ..." +
                                                  "--- ..|" +
                                                  "    ..|");
                yield return new TestCaseData(910, "._. ... ._." +
                                                   "|_| ..| |.|" +
                                                   "..| ..| |_|");
            }
        }

        
        [TestCaseSource(nameof(TestCases))]
        public void Test(int number, string expected)
        {
            Assert.AreEqual(expected, LCDDigits.Convert(number));
        }
    }
}