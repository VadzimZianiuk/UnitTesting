using System;
using System.Collections;
using System.Collections.Generic;

namespace RecentlyUsedListKata
{
    public class RecentlyUsedList : IEnumerable<string>
    {
        private const int DefaultCapacity = 5;
        private readonly string[] data;
        private readonly int maxCount;

        public int Count { get; protected set; }

        public RecentlyUsedList()
            : this(DefaultCapacity)
        {
        }

        public RecentlyUsedList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.maxCount = capacity;
            this.data = new string[capacity];
        }

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return data[Count - 1 - index];
            }
        }

        public void Push(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Source value is null or empty or white space.", nameof(value));
            }

            int index = Array.IndexOf(data, value);
            if (index < 0)
            {
                if (Count >= maxCount)
                {
                    throw new OverflowException();
                }

                data[Count++] = value;
            }
            else if (index < maxCount - 1)
            {
                while (++index < Count)
                {
                    data[index - 1] = data[index];
                }

                data[Count - 1] = value;
            }
        }

        public string Pop()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException();
            }

            return data[--Count];
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
