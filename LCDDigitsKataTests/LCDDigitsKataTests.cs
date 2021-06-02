using System;
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
                yield return new TestCaseData(0, "._." + Environment.NewLine + 
                                                 "|.|" + Environment.NewLine +
                                                 "|_|");
                yield return new TestCaseData(1, "..." + Environment.NewLine +
                                                 "..|" + Environment.NewLine +
                                                 "..|");
                yield return new TestCaseData(2, "._." + Environment.NewLine +
                                                 "._|" + Environment.NewLine +
                                                 "|_.");
                yield return new TestCaseData(3, "._." + Environment.NewLine +
                                                 "._|" + Environment.NewLine +
                                                 "._|");
                yield return new TestCaseData(4, "..." + Environment.NewLine +
                                                 "|_|" + Environment.NewLine +
                                                 "..|");
                yield return new TestCaseData(5, "._." + Environment.NewLine +
                                                 "|_." + Environment.NewLine +
                                                 "._|");
                yield return new TestCaseData(6, "._." + Environment.NewLine +
                                                 "|_." + Environment.NewLine +
                                                 "|_|");
                yield return new TestCaseData(7, "._." + Environment.NewLine +
                                                 "..|" + Environment.NewLine +
                                                 "..|");
                yield return new TestCaseData(8, "._." + Environment.NewLine +
                                                 "|_|" + Environment.NewLine +
                                                 "|_|");
                yield return new TestCaseData(9, "._." + Environment.NewLine +
                                                 "|_|" + Environment.NewLine +
                                                 "..|");
                yield return new TestCaseData(-1, "    ..." + Environment.NewLine +
                                                  "--- ..|" + Environment.NewLine +
                                                  "    ..|");
                yield return new TestCaseData(910, "._. ... ._." + Environment.NewLine +
                                                   "|_| ..| |.|" + Environment.NewLine +
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