using NUnit.Framework;
using RecentlyUsedListKata;
using System;
using System.Collections.Generic;

namespace RecentlyUsedListKataTests
{
    [TestFixture]
    public class Tests
    {

        private static readonly List<string> UsedListData = new List<string>
        {
            "TODO1",
            "TODO2",
            "TODO3",
            "TODO4"
        };

        [TestCase(-5)]
        [TestCase(0)]
        public void Ctor_Throw_ArgumentOutOfRangeException(int capacity) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => new RecentlyUsedList(capacity));

        [Test]
        public void Count()
        {
            var recentlyUsedList = new RecentlyUsedList(UsedListData.Count);
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, recentlyUsedList.Count);
            UsedListData.ForEach(x =>
            {
                expectedCount++;
                recentlyUsedList.Push(x);
                Assert.AreEqual(expectedCount, recentlyUsedList.Count);
            });
        }

        [Test]
        public void Push_Pop()
        {
            var recentlyUsedList = new RecentlyUsedList(UsedListData.Count);

            UsedListData.ForEach(x => recentlyUsedList.Push(x));

            for (int i = UsedListData.Count - 1; i >= 0; i--)
            {
                Assert.AreEqual(UsedListData[i], recentlyUsedList.Pop());
            }
        }

        [Test]
        public void PushDuplicate_Indexer()
        {
            var recentlyUsedList = new RecentlyUsedList(UsedListData.Count);

            UsedListData.ForEach(x => recentlyUsedList.Push(x));
            UsedListData.ForEach(x =>
            {
                recentlyUsedList.Push(x);
                Assert.AreEqual(x, recentlyUsedList[0]);
            });
        }

        [Test]
        public void Push_Throw_OverflowException()
        {
            int capacity = 1;
            var recentlyUsedList = new RecentlyUsedList(capacity);
            while (capacity-- > 0)
            {
                recentlyUsedList.Push($"{capacity}");
            }

            Assert.Throws<OverflowException>(() => recentlyUsedList.Push($"{capacity}"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void Push_Throw_ArgumentException(string item)
        {
            var recentlyUsedList = new RecentlyUsedList();
            Assert.Throws<ArgumentException>(() => recentlyUsedList.Push(item));
        }

        [Test]
        public void Pop_Throw_InvalidOperationException()
        {
            int capacity = 1;
            var recentlyUsedList = new RecentlyUsedList(capacity);
            for (int i = 0; i < capacity; i++)
            {
                recentlyUsedList.Push($"{i}");
            }

            while (capacity-- > 0)
            {
                recentlyUsedList.Pop();
            }

            Assert.Throws<InvalidOperationException>(() => recentlyUsedList.Pop());
        }

        [Test]
        public void Indexer()
        {
            var recentlyUsedList = new RecentlyUsedList(UsedListData.Count);

            UsedListData.ForEach(x => recentlyUsedList.Push(x));

            int j = 0;
            for (int i = UsedListData.Count - 1; i >= 0; i--)
            {
                Assert.AreEqual(UsedListData[i], recentlyUsedList[j++]);
            }
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void Indexer_Throw_ArgumentOutOfRangeException(int index)
        {
            var recentlyUsedList = new RecentlyUsedList();
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = recentlyUsedList[index]);
        }

        [Test]
        public void Enumerable()
        {
            var recentlyUsedList = new RecentlyUsedList(UsedListData.Count);

            int i = UsedListData.Count;
            while (--i >= 0)
            {
                recentlyUsedList.Push(UsedListData[i]);
            }

            i = 0;
            foreach (var data in recentlyUsedList)
            {
                Assert.AreEqual(UsedListData[i++], data);
            }
        }
    }
}