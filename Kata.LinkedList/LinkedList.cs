using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Kata.LinkedList
{
    public class LinkedList<T> : IList<T>
    {
        Element<T> firstElement = null;

        public int IndexOf(T item)
        {
            int index = 0;
            var element = firstElement;

            while (element != null)
            {
                if (element.Item != null && element.Item.Equals(item))
                {
                    return index;
                }
                element = element.Next;
                index++;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
//            Contract.Requires(index >= 0);
//            Contract.Requires(item != null);

            if (index > 0 && index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            int i = 0;
            Element<T> previousElement = null;

            while (i < index)
            {
                i++;
                previousElement = previousElement == null ? this.firstElement : previousElement.Next;

            }

            var newElement = new Element<T>(item);
            if (previousElement == null)
            {
                newElement.Next = this.firstElement;
                this.firstElement = newElement;
            }
            else
            {
                newElement.Next = previousElement.Next;
                previousElement.Next = newElement;
            }

        }

        public void RemoveAt(int index)
        {
//            Contract.Requires(index >= 0);
//            Contract.Requires(index < this.Count);

            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            Element<T> previousElement = null;
            int i = 0;

            while (i < index)
            {
                i++;
                previousElement = previousElement == null ? this.firstElement : previousElement.Next;
            }

            if (previousElement == null)
            {
                this.firstElement = this.firstElement.Next;
            }
            else
            {
                previousElement.Next = previousElement.Next.Next;
            }
        }

        public T this[int index]
        {
            get
            {
                var element = GetElementAt(index);

                if (element == null)
                {
                    throw new IndexOutOfRangeException();
                }

                return element.Item;
            }
            set
            {
                var element = this.GetElementAt(index);
                if (element == null)
                {
                    throw new IndexOutOfRangeException();
                }
                element.Item = value;
            }
        }

        private Element<T> GetElementAt(int index)
        {
            var element = this.firstElement;
            int currentIndex = 0;

            while (element != null)
            {
                if (currentIndex == index)
                {
                    return element;
                }
                element = element.Next;
                currentIndex++;
            }
            return null;
        }

        public void Add(T item)
        {
//            Contract.Requires(item != null);
//            Contract.Ensures(Count > 0);

            var element = new Element<T>(item);

            if (this.firstElement == null)
            {
                this.firstElement = element;
            }
            else
            {
                var current = firstElement;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = element;
            }


        }

        public void Clear()
        {
            firstElement = null;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) >= 0;

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            //Contract.Requires(array != null);
//            Contract.Requires(arrayIndex >= 0);
            //Contract.Requires<ArgumentOutOfRangeException>(array.Length - arrayIndex >= this.Count); Failed with NCrunch

            if (array.Length - arrayIndex < this.Count)
            {
                throw new ArgumentOutOfRangeException("array");
            }

            var element = this.firstElement;

            while (element != null)
            {
                array[arrayIndex] = element.Item;
                arrayIndex++;
                element = element.Next;
            }

        }

        public int Count
        {
            get
            {
                int count = 0;

                var item = this.firstElement;

                while (item != null)
                {
                    count++;
                    item = item.Next;
                }

                return count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index < 0)
            {
                return false;
            }

            this.RemoveAt(index);

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LinkedListEnumerator : IEnumerator<T>
        {
            private LinkedList<T> linkedList;
            private Element<T> currentElement;

            public LinkedListEnumerator(LinkedList<T> linkedList)
            {
                this.linkedList = linkedList;
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (currentElement == null)
                {
                    currentElement = this.linkedList.firstElement;
                }
                else
                {
                    currentElement = currentElement.Next;
                }

                return currentElement != null;
            }

            public void Reset()
            {
                currentElement = null;
            }

            public T Current
            {
                get
                {
                    return currentElement.Item;
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
