using System;
using System.Collections;
using System.Collections.Generic;

namespace RecentlyUsedListKata
{
    public class RecentlyUsedList : IEnumerable<string>
    {
        private const int DefaultCapacity = 5;

        public int Count => throw new NotImplementedException();

        public RecentlyUsedList() 
            : this(DefaultCapacity)
        {

        }

        public RecentlyUsedList(int capacity)
        {

        }

        public string this[int index] => throw new NotImplementedException();

        public void Push(string value)
        {
            throw new NotImplementedException();
        }

        public string Pop()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
