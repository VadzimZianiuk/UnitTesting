using System;
using System.Collections.Generic;
using NUnit.Framework;
using SudokuKata;

namespace SudokuKataTests
{
    [TestFixture]
    public class Tests
    {
        private static readonly int[][] ValidSudokuData = {
            new[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
            new[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
            new[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
            new[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
            new[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
            new[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
            new[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
            new[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
            new[] {3, 4, 5, 2, 8, 6, 1, 7, 9}
        };

        private static IEnumerable<TestCaseData> InvalidCases
        {
            get
            {
                yield return new TestCaseData(new object[] { new[]
                {
                    new[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                    new[] {6, 7, 2, 1, 9, 0, 3, 4, 8},
                    new[] {1, 0, 0, 3, 4, 2, 5, 6, 0},
                    new[] {8, 5, 9, 7, 6, 1, 0, 2, 0},
                    new[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                    new[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                    new[] {9, 0, 1, 5, 3, 7, 2, 1, 4},
                    new[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                    new[] {3, 0, 0, 4, 8, 1, 1, 7, 9}
                }});
                yield return new TestCaseData(new object[] { new[]
                {
                    new[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                    new[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                    new[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                    new[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                    new[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                    new[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                    new[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                    null,
                }});
                yield return new TestCaseData(new object[] { new[]
                {
                    new[] {5, 3, 4, 6, 7, 8, 9, 1},
                    new[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                    new[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                    new[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                    new[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                    new[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                    new[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                    new[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                    new[] {3, 4, 5, 2, 8, 6, 1, 7, 9}
                }});
                yield return new TestCaseData(new object[] { new[]
                {
                    new[] {5, 3, 6, 4, 7, 8, 9, 1, 2},
                    new[] {6, 7, 1, 2, 9, 5, 3, 4, 8},
                    new[] {1, 9, 3, 8, 4, 2, 5, 6, 7},
                    new[] {8, 5, 7, 9, 6, 1, 4, 2, 3},
                    new[] {4, 2, 8, 6, 5, 3, 7, 9, 1},
                    new[] {7, 1, 9, 3, 2, 4, 8, 5, 6},
                    new[] {9, 6, 5, 1, 3, 7, 2, 8, 4},
                    new[] {2, 8, 4, 7, 1, 9, 6, 3, 5},
                    new[] {3, 4, 2, 5, 8, 6, 1, 7, 9}
                }});
            }
        }

        [Test]
        public void ValidSolution_ThrowArgumentNullException() => 
            Assert.Throws<ArgumentNullException>(() => Sudoku.ValidSolution(null));

        [TestCaseSource(nameof(InvalidCases))]
        public void ValidSolution_False(int[][] data) => Assert.IsFalse(Sudoku.ValidSolution(data));

        [Test]
        public void ValidSolution_True() => Assert.IsTrue(Sudoku.ValidSolution(ValidSudokuData));
    }
}