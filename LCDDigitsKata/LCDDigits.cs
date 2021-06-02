using System;
using System.Collections.Generic;
using System.Text;

namespace LCDDigitsKata
{
    public static class LCDDigits
    {
        private const char Separator = ' ';
        private const char Minus = '-';
        private const int DigitSize = 3;
        private static readonly string[][] Map =
        {
            new[] {"._.", "...", "._.", "._.", "...", "._.", "._.", "._.", "._.", "._."},
            new[] {"|.|", "..|", "._|", "._|", "|_|", "|_.", "|_.", "..|", "|_|", "|_|"},
            new[] {"|_|", "..|", "|_.", "._|", "..|", "._|", "|_|", "..|", "|_|", "..|"}
        };

        public static string Convert(int number)
        {
            var numbers = new List<int>(10);
            int k = number < 0 ? -1 : 1;
            do
            {
                numbers.Add(k * (number % 10));
                number /= 10;
            } while (number != 0);

            return Convert(numbers, k < 0);
        }

        private static string Convert(IReadOnlyList<int> digits, bool isNegative)
        {
            var builder = new StringBuilder();

            string minusPrefix = default;
            string minusPrefixMiddle = default;
            if (isNegative)
            {
                minusPrefix = new string(Separator, DigitSize + 1);
                minusPrefixMiddle = new string(Minus, DigitSize) + Separator;
            }

            builder.AppendConverted(digits, Map[0], minusPrefix);
            builder.Append(Environment.NewLine);
            builder.AppendConverted(digits, Map[1], minusPrefixMiddle);
            builder.Append(Environment.NewLine);
            builder.AppendConverted(digits, Map[2], minusPrefix);
            return builder.ToString();
        }

        private static void AppendConverted(this StringBuilder builder, IReadOnlyList<int> digits, IReadOnlyList<string> map, string prefix)
        {
            if (!string.IsNullOrEmpty(prefix))
            {
                builder.Append(prefix);
            }

            for (int i = digits.Count - 1; i >= 1; i--)
            {
                builder.Append(map[digits[i]] + Separator);
            }

            builder.Append(map[digits[0]]);
        }
    }
}
